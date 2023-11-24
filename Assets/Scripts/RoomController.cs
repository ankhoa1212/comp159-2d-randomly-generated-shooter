using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject makeTransparent; // object that turns transparent when player enters
    [SerializeField] private Vector4 spawnArea; // spawn area (minX, maxX, minY, maxY)
    [SerializeField] private List<GameObject> possibleEnemies; // enemy prefabs
    [SerializeField] private List<GameObject> possibleItems;
    [SerializeField] private int numEnemies = 0; // number of enemies to spawn
    [SerializeField] private int numItems = 0; // number of items to spawn
    [SerializeField] private Transform entrance;
    [SerializeField] private float offsetFromEntrance = 1f;
    
    private List<GameObject> enemies;
    private List<GameObject> items;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnObject(RandomObjectInList(possibleEnemies));
        }
        SetActiveInList(false, enemies);
        
        items = new List<GameObject>();
        for (int i = 0; i < numItems; i++)
        {
            SpawnObject(RandomObjectInList(possibleItems));
        }
        SetActiveInList(false, items);
    }

    // given a list, set all objects in the list to active/not active
    private void SetActiveInList(bool active, List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(active);
            }
        }
    }
    // given a list, return a random object in the list
    private GameObject RandomObjectInList(List<GameObject> objects)
    {
        int randIndex = Random.Range(0, objects.Count);
        return objects[randIndex];
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
        if (obj.CompareTag("Enemy"))
        {
            enemies.Add(spawnedObject);
        }
        else
        {
            items.Add(spawnedObject);
        }
    }

    private bool LocationAvailable(float x, float y)
    {
        Vector2 testLocation = new Vector2(x, y);
        int minDistance = 1;
        if (!MinimumDistanceInList(testLocation, enemies, minDistance) || !MinimumDistanceInList(testLocation, items, minDistance)) return false;
        if (Vector2.Distance(testLocation, entrance.position) < offsetFromEntrance)
        {
            return false;
        }
        return true;
    }
    // return true if test location is < minimumDistance from each object in objects
    private bool MinimumDistanceInList(Vector2 testLocation, List<GameObject> objects, int minimumDistance)
    {
        if (objects == null || objects.Count <= 0) return true;
        foreach (var obj in objects)
        {
            Vector2 location = obj.transform.position;
            if (Vector2.Distance(testLocation, location) < minimumDistance)
            {
                return false;
            }
        }
        return true;
    }

    // show room when player enters
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && makeTransparent != null)
        {
            makeTransparent.SetActive(false); // show room
            SetActiveInList(true, items); // show items
            SetActiveInList(true, enemies); // show enemies
        }
    }
    // hide room when player leaves
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && makeTransparent != null)
        {
            makeTransparent.SetActive(true); // hide room
            SetActiveInList(false, items); // hide items
        }
    }
}
