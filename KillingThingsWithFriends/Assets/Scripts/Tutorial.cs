using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public int wave;
    public EnemySpawner es;
    public GameObject text;

    private void Start()
    {
        StartCoroutine(Show());
        text.SetActive(false);
    }
    private void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }
    IEnumerator Show()
    {
        yield return new WaitUntil(()=>es.wave == wave);
        yield return new WaitUntil(es.Cleared);
        text.SetActive(true);
    }
}
