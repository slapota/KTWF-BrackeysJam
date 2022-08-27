using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candles : MonoBehaviour
{
    public GameObject flame;
    public EnemySpawner es;

    private void Start()
    {
        StartCoroutine(Ignite());
    }
    private void Update()
    {
        flame.transform.LookAt(Camera.main.transform.position);
    }
    IEnumerator Ignite()
    {
        flame.SetActive(false);
        yield return new WaitWhile(es.Cleared);
        flame.SetActive(true);
        yield return new WaitUntil(es.Cleared);
        StartCoroutine(Ignite());
    }
}
