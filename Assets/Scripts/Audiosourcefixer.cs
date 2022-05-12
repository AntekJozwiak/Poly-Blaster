using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audiosourcefixer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gunsounds;
    void Start()
    {
        new WaitForSeconds(0.15f);
        gunsounds.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
