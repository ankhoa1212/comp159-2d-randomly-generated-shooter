using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToShoot : MonoBehaviour
{
    private Vector3 target;
    [SerializeField] private GameObject crosshair;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        target = transform.GetComponent<Camera>()
            .ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                Input.mousePosition.y, 
                transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);
    }
}
