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

    private void Start()
    {
        startPos = transform.localPosition;
        enabled = false;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Bullet instance = Instantiate(bullet, barrel.transform.position, cam.transform.rotation);
            instance.speed = speed;
            instance.cm = cm;
            instance.damage = damage;
            StartCoroutine(Range(instance.gameObject));
        }
    }
    IEnumerator Range(GameObject go)
    {
        yield return new WaitForSeconds(range);
        Destroy(go);
    }

}
