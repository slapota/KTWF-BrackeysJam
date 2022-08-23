using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public CollissionManager cm;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        cm.Bullet(collision, gameObject.GetComponent<Bullet>());
    }
}
