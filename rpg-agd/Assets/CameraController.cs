using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //target/offset
    public Transform target;
    public Vector3 offset;
    public float pitch = 2; //height  player

    //zoom
    private float currentZoom = 10f;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom=15f;

    //rotation
    public float yawSpeed = 100f;
    private float yawInput = 0f; //also current yaw

    // Start is called before the first frame update
    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; //did we zoom?
        currentZoom=Mathf.Clamp(currentZoom, minZoom, maxZoom);

        yawInput-=Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime; //did we rotate ? (A-D)

    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom; 
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, yawInput);
    }
}
