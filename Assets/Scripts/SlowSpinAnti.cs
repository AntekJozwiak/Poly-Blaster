using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpinAnti : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0f * Time.deltaTime, 0f, 0.5f));
    }


}
