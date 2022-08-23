using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float sensitivity;
    public Transform cam;
    float xRotation = 0f;
    public Rigidbody rb;
    public float jumpForce;
    public GameObject weapon;
    public int money;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

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
        }
    }
}
