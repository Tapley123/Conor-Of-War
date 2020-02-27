using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed = 3f;
    public float cameraRightClamp = 16f;
    public float cameraLeftClamp = -16f;

    private bool canMoveRight = true;
    private bool canMoveLeft = true;

    public float mouseScrollingXOffset = 80f;
    public float mouseScrollingYOffset = 80f;
    private float screenWidth, screenHeight;

    private void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
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



        if (Input.mousePosition.x > mouseScrollingXOffset && canMoveRight && Input.mousePosition.y < screenHeight - mouseScrollingYOffset)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.mousePosition.x < screenWidth - mouseScrollingXOffset && canMoveLeft && Input.mousePosition.y < screenHeight - mouseScrollingYOffset)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }
}
