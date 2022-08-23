using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int worth;
    public float damage;
    public float health;
    public Player player;
    public EnemySpawner es;

    private void Start()
    {
        StartCoroutine(AwaitDeath());
    }

    IEnumerator AwaitDeath()
    {
        yield return new WaitUntil(() => health <= 0f);
        player.money += worth;
        es.enemiesKilled++;
        Destroy(gameObject);
    }
}
