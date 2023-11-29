using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int neighborTarget;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // initialize number of neighbors player needs to collect
    public void StartLevel()
    {
        neighborTarget = 0;
        StartCoroutine(nameof(GetNumberOfNeighbors));
    }

    private IEnumerator GetNumberOfNeighbors()
    {
        while (neighborTarget == 0)
        {
            neighborTarget = 0;
            var rooms = GameObject.FindGameObjectsWithTag("Room");
            foreach (var room in rooms)
            {
                neighborTarget += room.GetComponent<RoomController>().GetNumberOfNeighbors();
            }
            yield return new WaitForSeconds(0.5f); // wait for rooms to finish loading
        }
        Debug.Log($"Number of neighbors to save: {neighborTarget}");
    }

    // initialize the next level
    public void NextLevel()
    {
        
    }

    // trigger game over screen
    public void GameOver()
    {
        
    }
}
