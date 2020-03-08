using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform CameraT; 

    void Update()
    {
        this.transform.position = new Vector3 (CameraT.position.x, this.transform.position.y);
    }
}
