using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public float interval;
    public float health;
    public ParticleSystem explosionparticleSystem;
    public MeshRenderer mr;
    public bool once = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gun")
        {
            health -= 1;

            if (health <= 0)
            {
                Destroy(gameObject, interval);
                Destroy(mr);
                explosionparticleSystem.Play();

            }
        }
    }
}
