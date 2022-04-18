using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{
    public
        AudioSource activate;
    void Start()
    {
        activate.Play();
    }

}