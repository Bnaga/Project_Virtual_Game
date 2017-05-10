using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distanceFromTarget = 2;
    public Vector3 targetOffset = new Vector3(0, 1.7f, 0);
    

    public float mouseSensitivityX = 10;
    public float mouseSensitivityY = 10;

    public float pitchMin = 60;
    public float pitchMax = -60;

    private float yaw;
    private float pitch;

    void Start()
    {

    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivityX;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivityY;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        transform.eulerAngles = new Vector3(pitch, yaw);

        transform.position = target.position - transform.forward * distanceFromTarget + targetOffset;
    }
}
