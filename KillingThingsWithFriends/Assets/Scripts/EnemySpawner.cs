using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int wave;
    public Enemy basicEnemy;
    public int enemiesKilled;
    public List<int> enemiesEachWave;
    public GameObject bigFriend;
    public GameObject startButton;
    public Player player;

    bool waveCleared() => enemiesKilled == enemiesEachWave[wave];

    private void Start()
    {
        wave = 0;
        enemiesKilled = 0;
    }
    public IEnumerator Spawner()
    {
        enemiesKilled = 0;
        wave++;
        for (int i = 0; i < enemiesEachWave[wave]; i++)
        {
            Enemy instance = Instantiate(basicEnemy, new Vector3(Random.Range(20f, 85f), Random.Range(2f, 15f), Random.Range(-40f, 40f)), Quaternion.identity);
            instance.transform.LookAt(bigFriend.transform);
            instance.player = player;
            instance.es = this;
        }
        yield return new WaitUntil(waveCleared);
        startButton.SetActive(true);
    }
}
