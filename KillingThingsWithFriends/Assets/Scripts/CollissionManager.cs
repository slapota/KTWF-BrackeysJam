using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionManager : MonoBehaviour
{
    public void Bullet(Collision collision, Bullet bullet)
    {
        switch (collision.collider.name.ToLower())
        {
            case "basicenemy(clone)":
                Debug.Log("hit");
                collision.gameObject.GetComponent<Enemy>().health -= bullet.damage;
                Destroy(bullet.gameObject);
                break;
        }
    }
}
