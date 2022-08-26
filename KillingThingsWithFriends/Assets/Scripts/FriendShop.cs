using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendShop : MonoBehaviour
{
    public Friend friend;
    public int price;
    int friends;
    public Player player;
    public float minDistance;
    public Text text;
    public StartWave sw;
    public CollissionManager cm;
    public EnemySpawner es;
    public SoundManager sm;
    public AudioSource source;
    public float xPos;

    private void Start()
    {
        text.text = "BUY FOR: " +
            $"{price}";
    }
    private void OnMouseDown()
    {
        if(player.money >= price && Vector3.Distance(transform.position, player.transform.position) < minDistance && friends < 14)
        {
            source.PlayOneShot(sm.buy);
            friends++;
            Friend instance = Instantiate(friend, new Vector3(xPos, 1.2f, -16 + 2 * friends), friend.transform.rotation);
            player.money -= price;
            sw.friends.Add(instance);
            instance.cm = cm;
            instance.es = es;
            instance.sm = sm;
        }
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
