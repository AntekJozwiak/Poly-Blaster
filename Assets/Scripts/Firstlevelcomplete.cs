using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstlevelcomplete : MonoBehaviour
{
    public GameObject fin;
    public GameObject ing;

    private void OnCollisionEnter(Collision collision)
    {
        fin.SetActive(true);
        ing.SetActive(false);
        Time.timeScale = 0;
    }


}
