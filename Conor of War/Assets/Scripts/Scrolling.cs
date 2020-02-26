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
    
    void Start()
    {
        /*
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        */
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


        //transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0f, 0f);

        if(canMoveRight && Input.GetAxisRaw("Mouse X") > -1)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        if (canMoveLeft && Input.GetAxisRaw("Mouse X") < 1)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("CameraRigthWall"))
        {
            Debug.Log("Right Wall");
            canMoveRight = false;
            canMoveLeft = true;
        }
        if(other.CompareTag("CameraLeftWall"))
        {
            Debug.Log("Left Wall");
            canMoveRight = true;
            canMoveLeft = false;
        }
    }
    */
}
