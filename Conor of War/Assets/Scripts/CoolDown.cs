using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour
{
    public static bool zombieButtonClicked = false;
    public float cooldownTime = 5f;
    public Transform coolDownBar;
    private float startCoolDownTime;

    void Start()
    {
        coolDownBar.localScale = new Vector3(1f, 1f);
        startCoolDownTime = cooldownTime;
    }

    
    void Update()
    {
        if(zombieButtonClicked)
        {
            StartCoroutine(CooldownCoroutine(cooldownTime));
        }
    }

    IEnumerator CooldownCoroutine(float cooldownTime)
    {
        float counter = cooldownTime;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            coolDownBar.localScale = new Vector3(counter / startCoolDownTime, 1f);
        }
        if (counter <= 0)
        {
            zombieButtonClicked = false;
        }
    }
}
