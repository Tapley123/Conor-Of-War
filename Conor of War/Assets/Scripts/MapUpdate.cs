using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUpdate : MonoBehaviour
{
    private GameObject mapWarning;//exclimation mark

    void Start()
    {
        mapWarning = GameObject.Find("MapWarning");
        mapWarning.SetActive(false);
    }

    
    void Update()
    {
        
    }
}
