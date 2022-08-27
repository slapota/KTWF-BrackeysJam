using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : MonoBehaviour
{
    public float damage;
    public GameObject shop;
    public Vector3 startPos;
    public CollissionManager cm;
    public SoundManager sm;
    public AudioSource source;
    public float reloadTime;
    bool ready = true;
    public GameObject scope, gameMenu;
    public Player player;
    public float kickBack;

    private void Start()
    {
        startPos = transform.localPosition;
        enabled = false;
        StartCoroutine(Aim());
    }
    private void Update()
    {
        if (!player.shoot) return;
        if (Input.GetMouseButtonDown(0) && ready) Shoot();
    }
    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            player.xRotation -= kickBack;
            cm.Sniper(hit, damage);
            source.PlayOneShot(sm.sniperShot);
            StartCoroutine(Ready());
        }
    }
    IEnumerator Aim()
    {
        yield return new WaitUntil(()=>enabled);
        yield return new WaitUntil(()=>Input.GetMouseButtonDown(1));
        gameMenu.SetActive(false);
        scope.SetActive(true);
        Camera.main.fieldOfView = 30;
        yield return new WaitUntil(() => Input.GetMouseButtonUp(1));
        gameMenu.SetActive(true);
        scope.SetActive(false);
        Camera.main.fieldOfView = 60;
        StartCoroutine(Aim());
    }
    IEnumerator Ready()
    {
        ready = false;
        yield return new WaitForSeconds(reloadTime);
        ready = true;
    }
}
