using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundplayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sfx1, sfx2, sfx3,sfx4,sfx5;
    public void bt1()
    {
        audioSource.clip = sfx1;
        audioSource.Play();
    }
public void bt2()
    {
        audioSource.clip = sfx2;
        audioSource.Play();
    }
public void bt3()
    {
        audioSource.clip = sfx3;
        audioSource.Play();
    }
public void bt4()
    {
        audioSource.clip = sfx4;
        audioSource.Play();
    }
public void bt5()
    {
        audioSource.clip = sfx5;
        audioSource.Play();
    }
}
