using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShop : MonoBehaviour
{
    public Gun gun;
    public int price;
    public Text text;
    public bool purchased;
    public GameObject equip;
    public Player player;
    public float minDistance;
    public Vector3 HandPos;

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
                    player.weapon.GoBack();
                }
                player.weapon = gun;
                gun.transform.parent = gun.cam.transform;
                gun.transform.localPosition = HandPos;
                gun.transform.rotation = gun.cam.transform.rotation;
                gun.equiped = true;
            }
            else
            {
                if(player.money >= price)
                {
                    purchased = true;
                    Destroy(text.gameObject);
                    equip.SetActive(true);
                    player.money -= price;
                }
            }
        }
    }
}
