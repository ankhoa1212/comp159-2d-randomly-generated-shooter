using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MinimapIconController : MonoBehaviour
{
    private Camera minimapCamera;
    private bool minimapReady;

    [SerializeField] private float iconScale; // scaling icons based on camera size
    [SerializeField] private float miniMapCameraScale; // scaling minimap size based on level size
    // Start is called before the first frame update
    void Start()
    {
        minimapReady = false;
        minimapCamera = GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Camera>();
        minimapReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // set minimap camera size based on size of level
    public void SetMinimapCameraSize()
    {
        var bounds = FindObjectOfType<LayoutController>().GetLevelBounds();
        var width = Math.Abs(bounds.x - bounds.y);
        var height = Math.Abs(bounds.z - bounds.w);
        minimapCamera.orthographicSize = height * miniMapCameraScale;
        if (width > height)
        {
            minimapCamera.orthographicSize = width * miniMapCameraScale;
        }
        ResizeMinimapIcons();
    }

    public bool ResizeMinimapIcons()
    {
        if (minimapReady)
        {
            var cameraSize = minimapCamera.orthographicSize;
            GameObject[] icons = GameObject.FindGameObjectsWithTag("MinimapIcon");
            foreach (var icon in icons)
            {
                var scale = cameraSize * iconScale;
                icon.transform.localScale = new Vector3(scale, scale, scale);
            }
        }

        return minimapReady;
    }
}
