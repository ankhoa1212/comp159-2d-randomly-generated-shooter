using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject door;
    private int neighborsToSave;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // decrement number of neighbors left to be saved
    public void NeighborSaved()
    {
        neighborsToSave--;
        if (neighborsToSave == 0)
        {
            var doorPosition = playerTransform.position;
            doorPosition.x += 2;
            Instantiate(door, doorPosition, Quaternion.identity);
        }
    }

    // initialize number of neighbors player needs to collect
    public void StartLevel()
    {
        neighborsToSave = 0;
        StartCoroutine(nameof(GetNumberOfNeighbors));
    }

    private IEnumerator GetNumberOfNeighbors()
    {
        while (neighborsToSave == 0)
        {
            yield return new WaitForSeconds(0.5f); // wait for rooms to finish loading
            neighborsToSave = 0;
            var rooms = GameObject.FindGameObjectsWithTag("Room");
            foreach (var room in rooms)
            {
                neighborsToSave += room.GetComponent<RoomController>().GetNumberOfNeighbors();
            }
        }
        Debug.Log($"Number of neighbors to save: {neighborsToSave}");
    }

    // initialize the next level
    public void NextLevel()
    {
        // reset player position after 1 second to play door opening animation
        StartCoroutine(ResetPlayerPosition(1));
        
        var layout = FindObjectOfType<LayoutController>();
        // clear objects in level layout
        layout.ClearLevelLayout();
        // increment max street segments, min street length, and max street length, respectively
        var newStreetSizes = layout.GetStreetSizes() + new int3(5, 1, 1);
        // set new street size
        layout.SetStreetSizes(newStreetSizes);
        layout.GenerateLevelLayout();
    }
    
    // reset player position after amount of time
    public IEnumerator ResetPlayerPosition(float time)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        yield return new WaitForSeconds(time);
        player.transform.position = Vector3.zero;
    }

    // trigger game over screen
    public void GameOver()
    {
        
    }
}
