﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed = 3f;
    public float cameraRightClamp = 16f;
    public float cameraLeftClamp = -16f;

    private bool canMoveRight = true;
    private bool canMoveLeft = true;
    private float mouseXStart;

    private void Start()
    {
        mouseXStart = Input.mousePosition.x;
    }

    void Update()
    {
        if(transform.position.x < cameraLeftClamp)
        {
            canMoveRight = true;
            canMoveLeft = false;
        }
        else
            canMoveLeft = true;

        
        if (transform.position.x > cameraRightClamp)
        {
            canMoveRight = false;
            canMoveLeft = true;
        }
        else
            canMoveRight = true;

        /*
        Debug.Log(Input.mousePosition.x);
        if(Input.mousePosition.x > -10 && canMoveRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.mousePosition.x < 10 && canMoveLeft)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        */
        if (Input.mousePosition.x > mouseXStart -300 && canMoveRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.mousePosition.x < mouseXStart + 300 && canMoveLeft)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }

    }
}
