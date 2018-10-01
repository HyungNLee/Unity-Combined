using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    public Camera MiniMapCamera;

    //target for minimap to follow
    public Transform Target;

    //zoom variables
    public int ZoomIndex;
    public float ZoomAmount;

    void start()
    {
        ZoomIndex = 2;
    }

    void LateUpdate()
    {
        //get target location and store in variable
        Vector3 newPosition = Target.position;

        //set Y position of target to y position of minimap camera
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //to rotate minimap with rotation of target
        transform.rotation = Quaternion.Euler(90f, Target.eulerAngles.y, 0f);
    }

    public void ZoomIn()
    {
        if (ZoomIndex > 0 && MiniMapCamera.orthographicSize > 13.01f)
        {
            ZoomIndex--;
            MiniMapCamera.orthographicSize -= ZoomAmount;
        }
    }

    public void ZoomOut()
    {
        if (ZoomIndex <= 6)
        {
            ZoomIndex++;
            MiniMapCamera.orthographicSize += ZoomAmount;
        }
    }
}
