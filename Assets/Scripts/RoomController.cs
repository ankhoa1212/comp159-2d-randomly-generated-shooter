using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject makeTransparent; // object that turns transparent when player enters
    [SerializeField] private Vector4 spawnArea; // spawn area (minX, maxX, minY, maxY)
    [SerializeField] private GameObject enemy; // enemy prefab
    [SerializeField] private int numEnemies = 0; // number of enemies to spawn
    [SerializeField] private Transform entrance;
    [SerializeField] private float offsetFromEntrance = 1f;
    // Start is called before the first frame update
    private List<GameObject> objects;
    void Start()
    {
        objects = new List<GameObject>();
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnObject(enemy);
        }
        foreach (var obj in objects) // hide objects at start
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObject(GameObject obj)
    {
        var randX = Random.Range(spawnArea[0], spawnArea[1]);
        var randY = Random.Range(spawnArea[2], spawnArea[3]);
        while (!LocationAvailable(randX, randY))
        {
            randX = Random.Range(spawnArea[0], spawnArea[1]);
            randY = Random.Range(spawnArea[2], spawnArea[3]);
        }
        var position = transform.position;
        randX += position.x;
        randY += position.y;
        GameObject spawnedObject = Instantiate(obj, new Vector3(randX, randY, 0f), Quaternion.identity);
        objects.Add(spawnedObject);
    }

    private bool LocationAvailable(float x, float y)
    {
        Vector2 testLocation = new Vector2(x, y);
        if (objects.Count > 0)
        {
            foreach(var obj in objects)
            {
                Vector2 location = obj.transform.position;
                if (Vector2.Distance(testLocation, location) < 1)
                {
                    return false;
                }
            }
        }
        if (Vector2.Distance(testLocation, entrance.position) < offsetFromEntrance)
        {
            return false;
        }
        return true;
    }
    
    // show room when player enters
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && makeTransparent != null)
        {
            makeTransparent.SetActive(false); // show room
            foreach (var obj in objects) // show objects
            {
                obj.SetActive(true);
            }
        }
    }
    // hide room when player leaves
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && makeTransparent != null)
        {
            makeTransparent.SetActive(true); // hide room
            foreach (var obj in objects) // hide objects
            {
                if (!obj.CompareTag("Enemy")) // hide non-enemy objects
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
