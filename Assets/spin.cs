using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(1000f * Time.deltaTime, 0f , 0f));
    }
}
