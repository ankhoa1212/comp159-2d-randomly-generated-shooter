using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Camera cam;
    private Rigidbody2D rb;
    //private PlayerHealth playerHealthScript;
    private bool playerAlive;
    //private bool m_FacingRight = true;

    private Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAlive = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
        if (playerAlive)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            rb.velocity = new Vector2(horizontalInput, verticalInput) * moveSpeed;
            playerAlive = GetComponent<PlayerHealth>().IsAlive();
        }
        /*
        if (horizontalInput < 0 && m_FacingRight)
        {
            Flip();
        }
        else if (horizontalInput > 0 && !m_FacingRight)
        {
            Flip();
        }
        */
    }

    //Function points the ShootingPoint game object in the direction of the crosshair (aka cursor)
    private void FixedUpdate()
    {
        Vector2 aimDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    /*
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    */
}
