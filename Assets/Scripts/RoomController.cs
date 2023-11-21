using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject makeTransparent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // make room visible when player enters
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && makeTransparent != null)
        {
            makeTransparent.SetActive(false);
        }
    }
    // cover room when player leaves
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && makeTransparent != null)
        {
            makeTransparent.SetActive(true);
        }
    }
}
