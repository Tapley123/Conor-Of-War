using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public string upgradeName;

    public UIManager uiScript;

    public Monster[] monScript;

    public Human humanScript;

    public HumanSpawner humanSpawnScript;

    public Transform selectedUnit;



    private void Start()
    {
        Zombie();
        Werewolf();
    }

    private void Update()
    {
        humanScript = GameObject.Find("Humans1").GetComponentInChildren<Human>();
       
        Werewolf();
        Vampire();

        /*if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit;

            if(Physics2D.Raycast())
        }*/
    }

    public void Zombie()
    {
        if (upgradeName == "Zombie Horde")
        {
            uiScript.upgrades.Add("Zombie Horde");
            uiScript.zombieMultiply = true;
            uiScript.chanceRequirement = 7;
        }

        if (upgradeName == "Peel Flesh")
        {
            uiScript.upgrades.Add("Peel Flesh");
            uiScript.chanceRequirement = 6;
        }
    }

    public void Werewolf()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            StartCoroutine("Freeze");

        }
    }

    public void Vampire()
    {

    }

    IEnumerator Freeze()
    {
        Debug.Log("skkkkrt");
        
        foreach(GameObject human in humanSpawnScript.humansOnScreen)
        {
            Debug.Log("yeet");
            human.GetComponent<Human>().speed = 0;
            human.GetComponent<Human>().isFrozen = true;
            /*if (human.GetComponent<Human>().myScene == "Scene1")
            {
                
            }*/
            
        }

        yield return new WaitForSeconds(5f);

        foreach (GameObject human in humanSpawnScript.humansOnScreen)
        {
            //Debug.Log("yeet");
            human.GetComponent<Human>().speed = human.GetComponent<Human>().mySpeed;
            human.GetComponent<Human>().isFrozen = false;
            /*if (human.GetComponent<Human>().myScene == "Scene1")
            {
                
            }*/
        }
        
    }

    public void GetUpgrade()
    {
        upgradeName = gameObject.GetComponent<Button>().name;
    }
}
