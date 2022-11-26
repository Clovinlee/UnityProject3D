using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovement : MonoBehaviour
{
    //atur sensitivity kamera
    float sensitivity = 1000f;
    public Transform body;
    float rx = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Freedom.f)
        {
            Cursor.lockState = CursorLockMode.Locked;
            float mx = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float my = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            rx -= my;
            rx = Mathf.Clamp(rx, -90f, 90f);
            transform.localRotation = Quaternion.Euler(rx, 0f, 0f);
            body.Rotate(Vector3.up * mx);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
