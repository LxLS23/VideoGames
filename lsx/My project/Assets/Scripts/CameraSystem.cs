using System;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Transform cameraTransform;
    public float sensibility = 5f;
    public bool isInverted;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void LateUpdate()
    {
        Vector3 direction = target.position - cameraTransform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        cameraTransform.rotation = targetRotation;
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 5);
        cameraTransform.localPosition = offset;
        float degrees = Input.mousePositionDelta.x * Time.deltaTime * sensibility;
        float sign = isInverted ? -1 : 1;
        transform.Rotate(0f,degrees * sign,0f);
    }
}
