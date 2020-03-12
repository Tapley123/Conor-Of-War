using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioSource audioS;
    public static AudioClip buttonp, zombiep, vampirep, skeletonp, demonp, werewolfp;
    [SerializeField] private AudioClip button, zombie, vampire, skeleton, demon, werewolf;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        buttonp = button;
        zombiep = zombie;
        vampirep = vampire;
        skeletonp = skeleton;
        demonp = demon;
        werewolfp = werewolf;
    }

    void Update()
    {
        
    }

    public void ButtonClick()
    {
        audioS.PlayOneShot(button);
    }
    public static void Zombie()
    {
        audioS.PlayOneShot(zombiep);
    }
    public static void Vampire()
    {
        audioS.PlayOneShot(vampirep);
    }
    public static void Skeleton()
    {
        audioS.PlayOneShot(skeletonp);
    }
    public static void Demon()
    {
        audioS.PlayOneShot(demonp);
    }
    public static void Werewolf()
    {
        audioS.PlayOneShot(werewolfp);
    }
}
