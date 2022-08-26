using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    public int wave;
    public Enemy basicEnemy;
    public List<int> enemiesEachWave;
    public GameObject bigFriend;
    public GameObject startButton;
    public Player player;
    public float waitTime;
    public SoundManager sm;
    int enemiesSpawned;
    int enemiesToSpawn;
    public CollissionManager cm;
    float health;
    float damage;
    int money;

    public bool Cleared()
    {
        return enemiesEachWave[wave] == 0;
    }

    private void Start()
    {
        wave = 0;
    }
    public void Spawn()
    {
        if (wave == enemiesEachWave.Count - 2) enemiesEachWave.Add((int)(enemiesEachWave.Last() * 1.2f));
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        wave++;
        if (wave % 4 == 0)
        {
            money += Mathf.RoundToInt(0.1f * 1.5f);
            health += 0.1f * 1.5f;
            damage += 0.1f * 1.5f;
        }
        enemiesSpawned = 0;
        enemiesToSpawn = enemiesEachWave[wave];
        StartCoroutine(Spawning());
        yield return new WaitUntil(Cleared);
        startButton.SetActive(true);
    }
    IEnumerator Spawning()
    {
        Enemy instance = Instantiate(basicEnemy, new Vector3(Random.Range(20f, 85f), Random.Range(2f, 15f), Random.Range(-40f, 40f)), Quaternion.identity);
        instance.transform.LookAt(bigFriend.transform);
        instance.player = player;
        instance.es = this;
        instance.sm = sm;
        instance.bigFriend = bigFriend;
        instance.cm = cm;
        instance.health += health;
        instance.damage += damage;
        instance.worth += money;
        yield return new WaitForSeconds(waitTime);
        enemiesSpawned++;
        if (enemiesSpawned != enemiesToSpawn) StartCoroutine(Spawning());
    }
}
