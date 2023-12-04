using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeUseItem : MonoBehaviour
{
    [SerializeField] private GameObject barricade;
    [SerializeField] private Transform SpawnBarricadePoint;
    [SerializeField] private float barricadeTime;
    private int numOfBarricades;
    private GameObject barricadePlaced;
    // Start is called before the first frame update
    void Start()
    {
        numOfBarricades = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Pressing E will place down the barricade
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(BarricadeTimer());
        }
        
    }

    private void PlaceDownBarricade()
    {
        if (numOfBarricades > 0)
        {
            //Places down the barricade
            Instantiate(barricade, SpawnBarricadePoint.position, SpawnBarricadePoint.rotation);
            numOfBarricades--;
            barricadePlaced = GameObject.FindGameObjectWithTag("Barricade");
        }
    }

    private void DestroyBarricade()
    {
        Destroy(barricadePlaced);
    }

    private IEnumerator BarricadeTimer()
    {
        //Places the barricade, waits for x amount of seconds, and destroys the barricade
        PlaceDownBarricade();
        yield return new WaitForSeconds(barricadeTime);
        DestroyBarricade();
    }
}
