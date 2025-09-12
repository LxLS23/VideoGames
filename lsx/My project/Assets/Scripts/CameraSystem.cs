using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
        transform.position = target.position + offset;
    }
}
