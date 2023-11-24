using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class LayoutController : MonoBehaviour
{
    [SerializeField] private GameObject street;
    [SerializeField] private GameObject streetFiller;
    [SerializeField] private int maxStreetSegments = 100;
    [SerializeField] private int minStreetLength = 1;
    [SerializeField] private int maxStreetLength = 10;

    private List<GameObject> streets = new List<GameObject>();

    private Vector2 lastPosition; // last position of street object placed
    private string lastDirection; // last direction of street object placed
    private bool loop = true; // to reset generating street layout if a street loop is found
    // Start is called before the first frame update
    void Start()
    {
        Reset();
        while (streets.Count < maxStreetSegments && loop)
        {
            GenerateStreetLayout();
            if (loop == false)
            {
                ReplaceLastStreet();
                List<GameObject> streetFillers = new List<GameObject>();
                foreach (var obj in streets)
                {
                    if (obj.CompareTag("StreetFiller"))
                    {
                        streetFillers.Add(obj);
                    }
                }
                int count = streets.Count;
                while (count == streets.Count)
                {
                    int randIndex = Random.Range(0, streetFillers.Count);
                    lastPosition = streetFillers[randIndex].transform.position;
                    lastDirection = "Start";
                    GenerateStreetLayout();
                }
                loop = true;
            }
        }
        ReplaceLastStreet();
    }
    // replace the last street with street filler
    private void ReplaceLastStreet()
    {
        GameObject replaceLast = streets[^1];
        // foreach (var obj in streets)
        // {
        //     if (lastPosition == (Vector2)obj.transform.position)
        //     {
        //         replaceLast = obj;
        //     }
        // }
        
        GameObject deadEnd = Instantiate(streetFiller, replaceLast.transform.position, Quaternion.identity);
        
        streets.Remove(replaceLast);
        Destroy(replaceLast.gameObject);
        streets.Add(deadEnd);
    }
    // reset last position and last direction
    private void Reset()
    {
        lastPosition = transform.position;
        lastDirection = "Start";
        AddStreet(streetFiller, "");
    }
    // generate a street based on the last direction of the last placed street
    private void GenerateStreetLayout()
    {
        // int ind = streets.Count - 1;
        // lastPosition = streets[ind].transform.position;
        int ind = -1;
        for (int y = 0; y < streets.Count; y++)
        {
            if (lastPosition == (Vector2)streets[y].transform.position)
            {
                ind = y;
            }
        }
        int randNum = Random.Range(0, 4);
        int randStreetLength = Random.Range(minStreetLength, maxStreetLength + 1);
        if (randNum == 0)
        {
            if (lastDirection != "Down")
            {
                for (int x = 0; x < randStreetLength; x++)
                {
                    AddNewStreet("Up", ind+x);
                }
            }
        }
        else if (randNum == 1)
        {
            if (lastDirection != "Up")
            {
                for (int x = 0; x < randStreetLength; x++)
                {
                    AddNewStreet("Down", ind+x);
                }
            }
        }
        else if (randNum == 2)
        {
            if (lastDirection != "Right")
            {
                for (int x = 0; x < randStreetLength; x++)
                {
                    AddNewStreet("Left", ind+x);
                }
            }
        }
        else if (randNum == 3)
        {
            if (lastDirection != "Left")
            {
                for (int x = 0; x < randStreetLength; x++)
                {
                    AddNewStreet("Right", ind+x);
                }
            }
        }
    }
    // if the street direction changes, add street filler accordingly
    // add street in new direction
    // returns the lastDirection of the street
    private void AddNewStreet(string newDirection, int ind)
    {
        AddFiller(newDirection, ind);
        if (AddStreet(street, newDirection))
        {
            // set last position and direction based on the newly placed street
            int index = streets.Count - 1;
            lastPosition = streets[index].transform.position;
            lastDirection = newDirection;
        }
        lastPosition = streets[^1].transform.position;
    }
    // add filler street if the street direction changes
    private void AddFiller(string newDirection, int ind)
    {
        if (lastDirection != "Start" && newDirection != lastDirection)
        {
            if (AddStreet(streetFiller, lastDirection))
            {
                // if (ind + 1 < streets.Count)
                // {
                //     lastPosition = streets[ind + 1].transform.position;
                // }
            }
            else
            {
                // lastPosition = streets[ind + 1].transform.position;
            }
            lastPosition = streets[^1].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // add new street object based on direction 
    // return true if successful, false if position already occupied
    private bool AddStreet(GameObject streetType, string direction)
    {
        Vector3 nextPosition = lastPosition;
        GameObject streetObject;
        switch (direction)
        {
            case "Up":
                nextPosition.y += 10;
                if (!NewPositionIsAvailable(nextPosition)) return false;
                streetObject = Instantiate(streetType, nextPosition, Quaternion.Euler(0, 0, 90));
                break;
            case "Down":
                nextPosition.y -= 10;
                if (!NewPositionIsAvailable(nextPosition)) return false;
                streetObject = Instantiate(streetType, nextPosition, Quaternion.Euler(0, 0, 90));
                break;
            case "Left":
                nextPosition.x -= 10;
                if (!NewPositionIsAvailable(nextPosition)) return false;
                streetObject = Instantiate(streetType, nextPosition, Quaternion.identity);
                break;
            case "Right":
                nextPosition.x += 10;
                if (!NewPositionIsAvailable(nextPosition)) return false;
                streetObject = Instantiate(streetType, nextPosition, Quaternion.identity);
                break;
            default:
                if (!NewPositionIsAvailable(nextPosition)) return false;
                streetObject = Instantiate(streetType, nextPosition, Quaternion.identity);
                break;
        }
        streets.Add(streetObject);
        return true;
    }

    private bool NewPositionIsAvailable(Vector3 nextPosition)
    {
        foreach (var obj in streets)
        {
            if (obj.transform.position == nextPosition)
            {
                loop = false;
                Replace(nextPosition); // next position already taken, so replace with street filler
                return false;
            }
        }

        return true;
    }
    // replace street at position with street filler
    private void Replace(Vector3 nextPosition)
    {
        Debug.Log($"Replaced at {nextPosition}");
        GameObject newObject = null;
        GameObject oldObject = null;
        foreach (var obj in streets)
        {
            if (obj.transform.position == nextPosition)
            {
                oldObject = obj;
                newObject = Instantiate(streetFiller, nextPosition, Quaternion.identity);
            }
        }

        if (oldObject != null)
        {
            streets.Remove(oldObject);
            Destroy(oldObject);
        }
        streets.Add(newObject);
    }
}
