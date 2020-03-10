using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioS;
    [SerializeField] private AudioClip button, zombie, vampire, skeleton, demon, werewolf;

    void Start()
    {
        audioS = GetComponent<AudioSource>();   
    }

    void Update()
    {
        
    }

    public void ButtonClick()
    {
        audioS.PlayOneShot(button);
    }
    public void Zombie()
    {
        audioS.PlayOneShot(zombie);
    }
    public void Vampire()
    {
        audioS.PlayOneShot(vampire);
    }
    public void Skeleton()
    {
        audioS.PlayOneShot(skeleton);
    }
    public void Demon()
    {
        audioS.PlayOneShot(demon);
    }
    public void Werewolf()
    {
        audioS.PlayOneShot(werewolf);
    }
}
