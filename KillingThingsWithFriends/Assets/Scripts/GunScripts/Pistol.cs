using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float damage;
    public GameObject shop;
    public Vector3 startPos;
    public Bullet bullet;
    public float speed;
    public float range;
    public GameObject cam;
    public GameObject barrel;
    public CollissionManager cm;
    public SoundManager sm;
    public AudioSource source;
    public Player player;

    private void Start()
    {
        startPos = transform.localPosition;
        enabled = false;
    }
    
    private void Update()
    {
        if (!player.shoot) return;
        if (Input.GetMouseButtonDown(0))
        {
            Bullet instance = Instantiate(bullet, barrel.transform.position, cam.transform.rotation);
            instance.speed = speed;
            instance.cm = cm;
            instance.damage = damage;
            StartCoroutine(Range(instance.gameObject));
            source.PlayOneShot(sm.shot);
        }
    }
    IEnumerator Range(GameObject go)
    {
        yield return new WaitForSeconds(range);
        Destroy(go);
    }

}
