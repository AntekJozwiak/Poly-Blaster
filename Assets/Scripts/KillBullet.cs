using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBullet : MonoBehaviour
{
    public float interval;
    public ParticleSystem collisionparticleSystem;
    public MeshRenderer mr;
    public bool once = true;
    public Rigidbody rb;
    public bool balls = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, interval);
    }

    void OnTriggerEnter(Collider other)
    {

        rb.velocity = Vector3.zero;

        if (other.gameObject.CompareTag("Untagged") || other.gameObject.CompareTag ("redbullet")  && once)
        {

            var em = collisionparticleSystem.emission;
            var dur = collisionparticleSystem.duration;

            

            em.enabled = true;
            collisionparticleSystem.Play();

            once = false;
            Destroy(mr);
            Invoke(nameof(DestroyObj), dur);


        }

    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }

    

}
