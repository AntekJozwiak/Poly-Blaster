using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmg : MonoBehaviour
{
    public GameObject box;
    public Vector3 boxsize = new Vector3(2, 0.5f, 1.7f);
    public bool slicing;
    public List<GameObject> sliced;

    // Start is called before the first frame update
    void Start()
    {

    }
    bool prevsliced;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            gameObject.GetComponent<Animator>().SetBool("Hit", true);
        }

        if (slicing)
        {
            Collider[] hitColliders = Physics.OverlapBox(box.transform.position, boxsize);
            foreach (Collider gay in hitColliders)
            {
                bool nuts = false;
                for (int i = 0; i < sliced.Count; i++)
                {
                    if (sliced[i] == gay.gameObject)
                    {
                        nuts = true;
                    }
                }
                if (!nuts)
                {
                    if (gay.gameObject.layer == 11)
                    {
                        gay.gameObject.GetComponent<enemyhealth>().dodamage(4);
                    }
                    sliced.Add(gay.gameObject);
                }
            }
        }
        else
        {
            sliced = new List<GameObject>();
        }
        if (slicing != prevsliced && !slicing)
        {
            gameObject.GetComponent<Animator>().SetBool("Hit", false);
        }
        prevsliced = slicing;
    }

    private void OnDrawGizmos()
    {
        if (slicing)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(box.transform.position, boxsize);
        }

    }
}
