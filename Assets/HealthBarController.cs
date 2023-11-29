using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealth healthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Vector3 scale = transform.localScale;
        scale.x = (float)healthScript.getPlayerHealth()/(float)healthScript.getMaxPlayerHealth();
        transform.localScale = scale;
    }
}
