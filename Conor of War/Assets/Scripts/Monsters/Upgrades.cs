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

    Transform selectedUnit;

    public int chanceRequirement, zombieSpawnCount = 0;

    LayerMask myLayerMask;

    private void Start()
    {
        Zombie();
        Werewolf();
        
    }

    private void Update()
    {
        humanScript = GameObject.Find("Humans").GetComponentInChildren<Human>();
       
        Werewolf();
        

        
        if (zombieSpawnCount >= 2)
        {
            chanceRequirement = 0;
        }

        if(Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if(hit.collider != null)
            {
                Debug.Log(hit.transform.gameObject.name);
                selectedUnit = hit.transform;
                Vampire();
            }
        }
        
    }

    public void Zombie()
    {
        chanceRequirement = Random.Range(1, 10);
        zombieSpawnCount = 0;
       
        /*if (upgradeName == "Zombie Horde")
        {
            uiScript.upgrades.Add("Zombie Horde");
            uiScript.zombieMultiply = true;
            uiScript.chanceRequirement = 7;
        }

        if (upgradeName == "Peel Flesh")
        {
            uiScript.upgrades.Add("Peel Flesh");
            uiScript.chanceRequirement = 6;
        }*/
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
        if(selectedUnit.tag == "Vampire" && selectedUnit != null)
        {
            selectedUnit.GetComponent<Monster>().vampCantAttack = false;
        }
    }

    IEnumerator Freeze()
    {
        Debug.Log("skkkkrt");
        
        foreach(GameObject human in humanSpawnScript.humansOnScreen)
        {
            Debug.Log("yeet");
            human.GetComponent<Human>().speed = 0;
            human.GetComponent<Human>().enabled = false;
            /*if (human.GetComponent<Human>().myScene == "Scene1")
            {
                
            }*/
            
        }

        yield return new WaitForSeconds(5f);

        foreach (GameObject human in humanSpawnScript.humansOnScreen)
        {
            //Debug.Log("yeet");
            
            human.GetComponent<Human>().enabled = true;
            human.GetComponent<Human>().speed = human.GetComponent<Human>().mySpeed;
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
