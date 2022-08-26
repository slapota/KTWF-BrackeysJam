using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public CollissionManager cm;
    public float speed;
    public float damage;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        cm.EnemyBullet(collision, gameObject.GetComponent<EnemyBullet>());
    }
}
