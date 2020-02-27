using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private Rigidbody2D myRb;
    public float speed = 2f;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        myRb.velocity = new Vector2(speed, 0);
    }
}
