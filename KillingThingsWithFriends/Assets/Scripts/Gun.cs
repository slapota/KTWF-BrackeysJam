using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage;
    public GameObject shop;
    public Vector3 startPos;
    public bool equiped;
    public Bullet bullet;
    public float speed;
    public float range;
    public GameObject cam;
    bool ready = true;
    public float shootWaitTime;
    public float spread;
    public float fireOffset;

    private void Start()
    {
        startPos = transform.localPosition;
    }
    public void GoBack()
    {
        transform.parent = shop.transform;
        transform.localPosition = startPos;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        equiped = false;
    }
    private void Update()
    {
        Vector3 offset = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0);
        if (equiped)
        {
            if(name.ToLower() == "pistol")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Bullet instance = Instantiate(bullet, transform.TransformPoint(transform.forward * fireOffset), cam.transform.rotation);
                    instance.speed = speed;
                    instance.range = range;
                    StartCoroutine(instance.Range());
                }
            }
            else
            {
                if (Input.GetMouseButton(0) && ready)
                {
                    Bullet instance = Instantiate(bullet, transform.position, Quaternion.Euler(cam.transform.rotation.eulerAngles + offset));
                    instance.speed = speed;
                    instance.range = range;
                    StartCoroutine(Ready());
                    StartCoroutine(instance.Range());
                }
            }
        }
    }
    IEnumerator Ready()
    {
        ready = false;
        yield return new WaitForSeconds(shootWaitTime);
        ready = true;
    }
}
