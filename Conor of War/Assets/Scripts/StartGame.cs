using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject humanSpawner;

    void Start()
    {
        humanSpawner.SetActive(false);
    }

    public void ButtonClicked()
    {
        humanSpawner.SetActive(true);
    }
}
