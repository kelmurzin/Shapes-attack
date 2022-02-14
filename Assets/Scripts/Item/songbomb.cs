using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songbomb : MonoBehaviour
{
    public AudioSource bomb;
    
    public void Playsong()
    {
        bomb.Play();
    }
}