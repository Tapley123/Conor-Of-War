using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float health = 70f;
    public float cost = 10f;
    public float cooldown = 1f;
    public string speedRate = "Medium";
    public float speed = 2f;
    public string characterType = "Melee";
    public float damagePerSecond = 20f;
    public float pointPerKill = 15f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
