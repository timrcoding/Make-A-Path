using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public static CameraZoom instance;
    
    [SerializeField]
    private float stepCount;
    [SerializeField]
    private int zoomInStop;
    [SerializeField]
    private int zoomOutStop;
    private Camera cam;
    void Start()
    {
        instance = this;
        cam = GetComponent<Camera>();
    }

    public IEnumerator zoomIn()
    {
        yield return null;
        cam.orthographicSize += stepCount;
        if(cam.orthographicSize < zoomInStop)
        {
            StartCoroutine(zoomIn());
        }
    }

    public IEnumerator zoomOut()
    {
        yield return null;
        cam.orthographicSize -= stepCount;
        if (cam.orthographicSize > zoomOutStop)
        {
            StartCoroutine(zoomOut());
        }
    }
}
