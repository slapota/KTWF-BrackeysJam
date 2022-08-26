using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int worth;
    public float damage;
    public float health;
    public float speed;
    public Player player;
    public EnemySpawner es;
    public CollissionManager cm;
    public SoundManager sm;
    public AudioSource source;
    public Rigidbody rb;
    public GameObject bigFriend;
    public float distance;
    public EnemyBullet enemyBullet;
    public float shootSpeed;

    private void Start()
    {
        StartCoroutine(AwaitDeath());
        StartCoroutine(Stop());
    }
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    IEnumerator Stop()
    {
        yield return new WaitUntil(() => Vector3.Distance(bigFriend.transform.position, transform.position) < distance);
        speed = 0;
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        EnemyBullet instance = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        instance.transform.rotation = transform.rotation;
        instance.damage = damage;
        instance.cm = cm;
        source.PlayOneShot(sm.enemyShot);
        yield return new WaitForSeconds(shootSpeed);
        StartCoroutine(Shoot());
    }

    IEnumerator AwaitDeath()
    {
        yield return new WaitUntil(() => health <= 0f);
        player.money += worth;
        es.enemiesEachWave[es.wave]--;
        source.PlayOneShot(sm.enemyDeath);
        rb.useGravity = true;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        speed = 0;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
