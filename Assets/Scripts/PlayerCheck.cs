using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheck : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("MovePlatform");
            Debug.Log("3 big Guys ");
        }
    }

}
