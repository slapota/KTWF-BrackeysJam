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
    public Vector3 handPos;
    Vector3 aimPos = new Vector3(0, -0.479999989f, 1.69000006f);

    private void Start()
    {
        startPos = transform.localPosition;
        enabled = false;
        StartCoroutine(Aim());
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
    IEnumerator Aim()
    {
        yield return new WaitUntil(() => enabled);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(1));
        transform.localPosition = aimPos;
        Camera.main.fieldOfView = 45;
        yield return new WaitUntil(() => Input.GetMouseButtonUp(1));
        Camera.main.fieldOfView = 60;
        transform.localPosition = handPos;
        StartCoroutine(Aim());
    }

}
