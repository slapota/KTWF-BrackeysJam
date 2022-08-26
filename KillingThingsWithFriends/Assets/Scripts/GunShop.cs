using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShop : MonoBehaviour
{
    public GameObject gun;
    public int price;
    public Text text;
    public bool purchased;
    public GameObject equip;
    public Player player;
    public float minDistance;
    public Vector3 HandPos;
    public SoundManager sm;
    public AudioSource source;

    private void Start()
    {
        text.text = "BUY FOR: " +
            $"{price}";
        equip.SetActive(false);
        purchased = false;
    }
    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= minDistance)
        {
            if (purchased)
            {
                if(player.weapon != null)
                {
                    player.GoBack();
                }
                switch (gun.name.ToLower())
                {
                    case "pistol":
                        Pistol pistol = gun.GetComponent<Pistol>();
                        pistol.enabled = true;
                        player.weapon = gun;
                        gun.transform.parent = pistol.cam.transform;
                        gun.transform.localPosition = HandPos;
                        gun.transform.rotation = pistol.cam.transform.rotation;
                        break;
                    case "sprayrifle":
                        SprayRifle spray = gun.GetComponent<SprayRifle>();
                        spray.enabled = true;
                        player.weapon = gun;
                        gun.transform.parent = spray.cam.transform;
                        gun.transform.localPosition = HandPos;
                        gun.transform.rotation = spray.cam.transform.rotation;
                        break;
                    case "sniperrifle":
                        SniperRifle sniper = gun.GetComponent<SniperRifle>();
                        sniper.enabled = true;
                        player.weapon = gun;
                        gun.transform.parent = Camera.main.transform;
                        gun.transform.localPosition = HandPos;
                        gun.transform.rotation = Camera.main.transform.rotation;
                        break;
                }
            }
            else
            {
                if(player.money >= price)
                {
                    source.PlayOneShot(sm.buy);
                    purchased = true;
                    Destroy(text.gameObject);
                    equip.SetActive(true);
                    player.money -= price;
                }
            }
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
