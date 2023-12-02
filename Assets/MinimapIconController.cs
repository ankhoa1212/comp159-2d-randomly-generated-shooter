using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIconController : MonoBehaviour
{
    private GameObject minimapCamera;
    // Start is called before the first frame update
    void Start()
    {
        minimapCamera = GameObject.FindGameObjectWithTag("MinimapCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResizeMinimapIcons()
    {
        var size = minimapCamera.GetComponent<Camera>().orthographicSize;
        GameObject[] icons = GameObject.FindGameObjectsWithTag("MinimapIcon");
        foreach (var icon in icons)
        {
            var scale = size / 10;
            icon.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
