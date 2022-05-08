using UnityEngine;
using System.Collections;

public class ColliderIgnore : MonoBehaviour
{
    public Transform bulletPrefab;

    void Start()
    {
        Transform bullet = Instantiate(bulletPrefab) as Transform;
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
    }
}