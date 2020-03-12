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
