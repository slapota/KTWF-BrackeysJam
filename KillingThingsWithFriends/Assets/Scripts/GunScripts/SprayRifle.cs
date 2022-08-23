using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayRifle : MonoBehaviour
{
    public float frequency;
    bool ready = true;
    public float damage;
    public GameObject shop;
    public Vector3 startPos;
    public Bullet bullet;
    public float speed;
    public float range;
    public GameObject cam;
    public float spread;
    public GameObject barrel;
    public CollissionManager cm;

    private void Start()
    {
        startPos = transform.localPosition;
        enabled = false;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && ready)
        {
            Vector3 offset = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0);
            Bullet instance = Instantiate(bullet, barrel.transform.position, Quaternion.Euler(cam.transform.rotation.eulerAngles + offset));
            instance.speed = speed;
            instance.cm = cm;
            instance.damage = damage;
            StartCoroutine(Ready());
            StartCoroutine(Range(instance.gameObject));
        }
    }

    IEnumerator Ready()
    {
        ready = false;
        yield return new WaitForSeconds(frequency);
        ready = true;
    }
    IEnumerator Range(GameObject go)
    {
        yield return new WaitForSeconds(range);
        Destroy(go);
    }
}
