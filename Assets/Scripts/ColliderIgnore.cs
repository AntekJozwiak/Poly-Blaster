using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderIgnore : MonoBehaviour
{
    public GameObject player;
    void Start()
    {       
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        


    }

}