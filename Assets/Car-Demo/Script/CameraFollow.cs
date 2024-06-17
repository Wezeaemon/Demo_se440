using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float Speed;
    private float XRotation;
    public Transform PlayerRota;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * Speed * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * Speed * Time.deltaTime;
        XRotation -= MouseY;
        XRotation = Mathf.Clamp(XRotation, -50f, 50f);
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        PlayerRota.Rotate(Vector3.up * MouseX);
    }
}
