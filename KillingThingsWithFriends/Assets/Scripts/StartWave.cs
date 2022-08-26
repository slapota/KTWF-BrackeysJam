using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : MonoBehaviour
{
    public EnemySpawner es;
    public List<Friend> friends = new List<Friend>();
    public Player player;

    private void OnMouseDown()
    {
        es.Spawn();
        foreach (Friend item in friends)
        {
            item.StartShooting();
        }
        player.shoot = true;
        gameObject.SetActive(false);
    }
    void OnMouseOver()
    {
        player.shoot = false;
    }
    private void OnMouseExit()
    {
        player.shoot = true;
    }
}
