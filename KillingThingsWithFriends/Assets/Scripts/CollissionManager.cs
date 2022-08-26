using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionManager : MonoBehaviour
{
    public Player player;
    public void Bullet(Collision collision, Bullet bullet)
    {
        switch (collision.collider.name.ToLower())
        {
            case "basicenemy(clone)":
                collision.gameObject.GetComponent<Enemy>().health -= bullet.damage;
                Destroy(bullet.gameObject);
                break;
        }
    }
    public void Player(ref bool touchingGround, Collision collision)
    {
        switch (collision.collider.name.ToLower())
        {
            case "ground":
                touchingGround = !touchingGround;
                break;
        }
    }
    public void EnemyBullet(Collision collision, EnemyBullet enemyBullet)
    {
        switch (collision.gameObject.name.ToLower())
        {
            case "bigfriend":
                player.bigFriendHealth -= enemyBullet.damage;
                player.healthBar.value -= enemyBullet.damage;
                Destroy(enemyBullet.gameObject);
                break;
        }
    }
    public void Sniper(RaycastHit hit, float damage)
    {
        switch (hit.collider.name.ToLower())
        {
            case "basicenemy(clone)":
                hit.collider.gameObject.GetComponent<Enemy>().health -= damage;
                break;
        }
    }
}
