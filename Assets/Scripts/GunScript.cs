using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunScript : MonoBehaviour
{
    public int pelletCount;
    public float spreadAngle;
    public GameObject projectile;
    public Transform BarrelExit;
    public float Vel;
    float time;
    public float FireRate = 1.15f;
    public float maxAmmo;
    public float currentAmmo;
    public AudioSource gunSound;
    public Animator anim;
    public GameObject cam;

    List<Quaternion> pellets;

    void Start()
    {
        anim = GetComponent<Animator>();
        pellets = new List<Quaternion>(pelletCount);

        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    void Update()
    {

        time += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (currentAmmo > 0)
            {
                if (time > FireRate)
                {
                    currentAmmo--;

                    time = 0;

                    fire();
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            anim.SetTrigger("shoot");
        }

    }

    void fire()
    {
        for (int i = 0; i < pelletCount; i++)
        {

            pellets[i] = Random.rotation;
            GameObject pellet = Instantiate(projectile, BarrelExit.position, BarrelExit.transform.rotation);
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
            {
                pellet.transform.LookAt(hit.point);
            }
            pellet.transform.rotation = Quaternion.RotateTowards(pellet.transform.rotation, pellets[i], spreadAngle);
            pellet.GetComponent<Rigidbody>().AddForce(pellet.transform.forward * Vel);

            i++;

            gunSound.Play();
            anim.SetTrigger("shoot");
            Debug.Log("Trigger");
        }
    }

    public void PlayGunSound()
    {
        gunSound.Play();
    }
}