using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public Bullet bullet;
    public float bulletSpeed;
    public float damage;
    public CollissionManager cm;
    public float range;
    public float firingSpeedMin;
    public float firingSpeedMax;
    public EnemySpawner es;
    public SoundManager sm;
    public AudioSource source;
    public Transform žalud;
    public void StartShooting()
    {
        switch (name.ToLower())
        {
            case "pistolfriend(clone)":
                StartCoroutine(Shoot());
                break;
            case "sniperfriend(clone)":
                StartCoroutine(RayShoot());
                break;
        }
    }
    IEnumerator Shoot()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        if(enemies.Length > 0)
        {
            Transform target = enemies[Random.Range(0, enemies.Length - 1)].transform;
            transform.LookAt(target);
            Bullet instance = Instantiate(bullet, transform.position, transform.rotation);
            instance.damage = damage;
            instance.speed = bulletSpeed;
            instance.cm = cm;
            StartCoroutine(Range(instance.gameObject));
            source.PlayOneShot(sm.shot);
            yield return new WaitForSeconds(Random.Range(firingSpeedMin, firingSpeedMax));
        }
        if (!es.Cleared()) StartCoroutine(Shoot());
    }
    IEnumerator RayShoot()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies.Length > 0)
        {
            GameObject target = enemies[Random.Range(0, enemies.Length - 1)];
            transform.LookAt(target.transform);
            /*RaycastHit hit;
            if(Physics.Raycast(žalud.position, transform.rotation.eulerAngles, out hit))
            {
                cm.Sniper(hit, damage);
            }*/
            target.GetComponent<Enemy>().health -= damage;
            source.PlayOneShot(sm.sniperShot);
            yield return new WaitForSeconds(Random.Range(firingSpeedMin, firingSpeedMax));
        }
        if (!es.Cleared()) StartCoroutine(RayShoot());
    }
    IEnumerator Range(GameObject go)
    {
        yield return new WaitForSeconds(range);
        Destroy(go);
    }
}