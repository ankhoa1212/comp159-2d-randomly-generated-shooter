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
    [SerializeField] private List<GameObject> possibleRooms;
    [SerializeField] private GameObject fence;

    private List<GameObject> rooms = new List<GameObject>();
    private List<GameObject> streets = new List<GameObject>(); // list of all street parts on screen
    private Vector2 lastPosition; // last position of street object placed
    private string lastDirection; // last direction of street object placed
    private bool loop = true; // to reset generating street layout if a street loop is found
    // Start is called before the first frame update
    void Start()
    {
        GenerateStreetLayout();
        GenerateRooms();
    }

    private void GenerateRooms()
    {
        Vector4 bounds = new Vector4(); // street bounds
        foreach (var obj in streets)
        {
            if (obj.transform.position.x < bounds.x)
            {
                bounds.x = obj.transform.position.x;
            }
            if (obj.transform.position.x > bounds.y)
            {
                bounds.y = obj.transform.position.x;
            }
            if (obj.transform.position.y < bounds.z)
            {
                bounds.z = obj.transform.position.y;
            }
            if (obj.transform.position.y > bounds.w)
            {
                bounds.w = obj.transform.position.y;
            }
        }
        float vertOffset = 25;
        float horizOffset = 50;
        for (var x = bounds.x; x < bounds.y; x += horizOffset)
        {
            int randNum = Random.Range(0, possibleRooms.Count);
            GameObject newRoom = Instantiate(possibleRooms[randNum], new Vector3(x, bounds.z - vertOffset, 0), Quaternion.Euler(0,0, 180));
            rooms.Add(newRoom);
        }
        for (var x = bounds.x; x < bounds.y; x += horizOffset)
        {
            int randNum = Random.Range(0, possibleRooms.Count);
            GameObject newRoom = Instantiate(possibleRooms[randNum], new Vector3(x, bounds.w + vertOffset, 0), Quaternion.identity);
            rooms.Add(newRoom);
        }
        for (var y = bounds.z; y < bounds.w; y += horizOffset)
        {
            int randNum = Random.Range(0, possibleRooms.Count);
            GameObject newRoom = Instantiate(possibleRooms[randNum], new Vector3(bounds.x - vertOffset, y, 0), Quaternion.Euler(0,0, 90));
            rooms.Add(newRoom);
        }
        for (var y = bounds.z; y < bounds.w; y += horizOffset)
        {
            int randNum = Random.Range(0, possibleRooms.Count);
            GameObject newRoom = Instantiate(possibleRooms[randNum], new Vector3(bounds.y + vertOffset, y, 0), Quaternion.Euler(0,0, 270));
            rooms.Add(newRoom);
        }
        float fenceOffset = 5f;
        bounds.x -= 2*vertOffset;
        bounds.y += 2*vertOffset;
        bounds.z -= 2*vertOffset;
        bounds.w += 2*vertOffset;
        Debug.Log(bounds);
        for (var x = bounds.x; x < bounds.y; x += fenceOffset)
        {
            Instantiate(fence, new Vector3(x, bounds.z, 0), Quaternion.identity);
            Instantiate(fence, new Vector3(x, bounds.w, 0), Quaternion.identity);
        }
        for (var y = bounds.z; y < bounds.w; y += fenceOffset)
        {
            Instantiate(fence, new Vector3(bounds.x - fenceOffset*2/5, y + fenceOffset/2, 0), Quaternion.Euler(0, 0, 270));
            Instantiate(fence, new Vector3(bounds.y - fenceOffset*2/5, y + fenceOffset/2, 0), Quaternion.Euler(0, 0, 270));
        }
    }

    private void GenerateStreetLayout()
    {
        StreetSetup();
        while (streets.Count < maxStreetSegments && loop)
        {
            AddRandomStreet();
            // loop == false checks if street loop occurs when generating layout
            if (loop == false) 
            {
                // replace last street with street filler
                ReplaceLastStreet();
                // create list of all street fillers so new street can be added
                List<GameObject> streetFillers = new List<GameObject>();
                foreach (var obj in streets)
                {
                    if (obj.CompareTag("StreetFiller"))
                    {
                        streetFillers.Add(obj);
                    }
                }
                int count = streets.Count;
                // loop until new street is added
                while (count == streets.Count)
                {
                    int randIndex = Random.Range(0, streetFillers.Count); // get random index of street filler
                    lastPosition = streetFillers[randIndex].transform.position;
                    lastDirection = "Start";
                    AddRandomStreet();
                }
                loop = true; // resume loop
            }
        }
        ReplaceLastStreet();
    }
    
    // set up starting values
    private void StreetSetup()
    {
        lastPosition = transform.position;
        lastDirection = "Start";
        AddStreet(streetFiller, "");
    }
    
    // replace the last street with street filler
    private void ReplaceLastStreet()
    {
        GameObject replaceLast = streets[^1];
        GameObject deadEnd = Instantiate(streetFiller, replaceLast.transform.position, Quaternion.identity);
        streets.Remove(replaceLast);
        Destroy(replaceLast);
        streets.Add(deadEnd);
    }
    
    // generate a street based on the last direction of the last placed street
    private void AddRandomStreet()
    {
        int randNum = Random.Range(0, 4); // rand num for each direction (up, down, left, right)
        int randStreetLength = Random.Range(minStreetLength, maxStreetLength + 1);
        switch (randNum)
        {
            case 0:
            {
                if (lastDirection != "Down")
                {
                    for (int x = 0; x < randStreetLength; x++)
                    {
                        if (!AddNewStreet("Up"))
                        {
                            break;
                        }
                    }
                }
                break;
            }
            case 1:
            {
                if (lastDirection != "Up")
                {
                    for (int x = 0; x < randStreetLength; x++)
                    {
                        if (!AddNewStreet("Down"))
                        {
                            break;
                        }
                    }
                }
                break;
            }
            case 2:
            {
                if (lastDirection != "Right")
                {
                    for (int x = 0; x < randStreetLength; x++)
                    {
                        if (!AddNewStreet("Left"))
                        {
                            break;
                        }
                    }
                }

                break;
            }
            case 3:
            {
                if (lastDirection != "Left")
                {
                    for (int x = 0; x < randStreetLength; x++)
                    {
                        if (!AddNewStreet("Right"))
                        {
                            break;
                        }
                    }
                }
                break;
            }
        }
    }
    
    // if the street direction changes, add street filler and street in new direction
    // returns true if new street has been added, false if location was already occupied
    private bool AddNewStreet(string newDirection)
    {
        AddFiller(newDirection);
        if (AddStreet(street, newDirection))
        {
            // set last direction and position based on the newly placed street
            lastDirection = newDirection;
            lastPosition = streets[^1].transform.position;
            return true;
        }
        lastPosition = streets[^1].transform.position;
        return false;
    }
    
    // add filler street if the street direction changes
    private void AddFiller(string newDirection)
    {
        if (lastDirection != "Start" && newDirection != lastDirection)
        {
            AddStreet(streetFiller, lastDirection);
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
        streets.Remove(oldObject);
        Destroy(oldObject);
        streets.Add(newObject);
    }
}
