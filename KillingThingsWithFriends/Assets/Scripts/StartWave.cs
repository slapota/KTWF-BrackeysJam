using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : MonoBehaviour
{
    public EnemySpawner es;

    private void OnMouseDown()
    {
        StartCoroutine(es.Spawner());
        gameObject.SetActive(false);
    }
}
