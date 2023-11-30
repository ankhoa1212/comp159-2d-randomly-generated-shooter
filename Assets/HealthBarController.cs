using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    private PlayerHealth healthScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        healthScript = playerObject.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        scale.x = (float)healthScript.getPlayerHealth()/(float)healthScript.getMaxPlayerHealth();
        transform.localScale = scale;
    }
}
