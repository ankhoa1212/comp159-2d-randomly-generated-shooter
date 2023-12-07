using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPointController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    private Vector2 mousePos;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Function points the ShootingPoint game object in the direction of the crosshair (aka cursor)
    private void FixedUpdate()
    {
        transform.position = target.position; // set transform to target
        Vector2 aimDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
