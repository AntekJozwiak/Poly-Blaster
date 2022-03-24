using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    public float health;
    public GameObject explosion;

    void Update()
    {

        if (health <= 0)
        {
            Instantiate(explosion, new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gun")
        {
            health -= 1;
        }
    }



}
