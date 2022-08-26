using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float sensitivity;
    public Transform cam;
    public float xRotation = 0f;
    public Rigidbody rb;
    public float jumpForce;
    public GameObject weapon;
    public int money;
    public CollissionManager cm;
    public bool touchingGround;
    public Text moneyText;
    public float bigFriendHealth;
    public Slider healthBar;
    public bool end;
    public GameObject endScreen;
    public GameObject sun;
    public GameObject eyesOpened, eyesClosed;
    float mouseX;
    float mouseY;
    public bool shoot;

    private void Start()
    {
        endScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(BigFriendDeath());
    }

    private void Update()
    {
        moneyText.text = money.ToString();
        if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(Time.timeScale == 1)
        {
            mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
            mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        }
        else
        {
            xRotation = 0;
        }

        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition -= transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * moveSpeed * Time.deltaTime;
        }
    }
    public void GoBack()
    {
        switch (weapon.name.ToLower())
        {
            case "pistol":
                Pistol pistol = weapon.GetComponent<Pistol>();
                pistol.transform.parent = pistol.shop.transform;
                pistol.transform.localPosition = pistol.startPos;
                pistol.transform.rotation = Quaternion.Euler(Vector3.zero);
                pistol.enabled = false;
                break;
            case "sprayrifle":
                SprayRifle spray = weapon.GetComponent<SprayRifle>();
                spray.transform.parent = spray.shop.transform;
                spray.transform.localPosition = spray.startPos;
                spray.transform.rotation = Quaternion.Euler(Vector3.zero);
                spray.enabled = false;
                break;
            case "sniperrifle":
                SniperRifle sniper = weapon.GetComponent<SniperRifle>();
                sniper.transform.parent = sniper.shop.transform;
                sniper.transform.localPosition = sniper.startPos;
                sniper.transform.rotation = Quaternion.Euler(Vector3.zero);
                sniper.enabled = false;
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        cm.Player(ref touchingGround, collision);
    }
    private void OnCollisionExit(Collision collision)
    {
        cm.Player(ref touchingGround, collision);
    }
    IEnumerator BigFriendDeath()
    {
        yield return new WaitUntil(() => bigFriendHealth <= 0f);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForEndOfFrame();
        end = true;
        endScreen.SetActive(true);
        transform.position = new Vector3(-50, 8.5f, 0);
        transform.rotation = Quaternion.Euler(new Vector3(19, 270, 0));
        eyesOpened.SetActive(false);
        eyesClosed.SetActive(true);
        sun.SetActive(false);
    }
}
