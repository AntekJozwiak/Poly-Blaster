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
    public Collider col;
    public AudioSource explosound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gun")
        {
            health -= 1;

            if (health <= 0)
            {
                Destroy(gameObject, interval);
                Destroy(mr);
                Destroy(col);
                explosionparticleSystem.Play();
                explosound.Play();
            }
        }
    }
}
