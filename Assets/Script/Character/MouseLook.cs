using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    float rotationOnX;
    float mouseSensitivity = 500f;
    public Transform player;

    void Start()
    {
        Cursor.visible=false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

        rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);
    }
}