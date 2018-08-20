using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    private GameObject MapCamera;
    private float size;
    private void Awake()
    {
        
    }
    public void OnMap_maxButtonClick()
    {
        MapCamera = GameObject.FindGameObjectWithTag(Tags.mapCamera);
        size = MapCamera.GetComponent<Camera>().orthographicSize;
        if (size < 17)
        {
            MapCamera.GetComponent<Camera>().orthographicSize++;
        }
    }

    public void OnMap_mixButtonClick()
    {
        MapCamera = GameObject.FindGameObjectWithTag(Tags.mapCamera);
        size = MapCamera.GetComponent<Camera>().orthographicSize;
        if (size > 7)
        {
            MapCamera.GetComponent<Camera>().orthographicSize--;
        }
    }
}
