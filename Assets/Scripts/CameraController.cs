using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float dampTime = 0f;
    [SerializeField] private Vector3 followOffset = Vector3.zero;
    private Vector3 velocity;
    private Vector3 cameraOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        cameraOffset = new Vector3(0, 0, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 targetDest = target.position + followOffset + cameraOffset;
            transform.position = Vector3.SmoothDamp(transform.position,
                targetDest, ref velocity, dampTime);
        }
    }
}
