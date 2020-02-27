using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Rigidbody2D myRb;

    public float health;
    public float cost;
    public float cooldown;
    public string speedRate;
    public float speed;
    public string characterType;
    public float damagePerSecond;
    public float pointPerKill;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        myRb.velocity = new Vector2(speed, 0);
    }
}
