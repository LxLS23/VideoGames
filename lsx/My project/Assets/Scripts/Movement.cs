using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 5f;
    public Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //a -1, 0, d 1
        float vertical = Input.GetAxis("Vertical"); // w 1, 0, s -1

        Vector3 cameraForward = new Vector3 (cameraTransform.forward.x, 0, cameraTransform.forward.z);
        
        Vector3 cameraRight = new Vector3 (cameraTransform.right.x, 0, cameraTransform.right.z);
        
        Vector3 direction = cameraForward.normalized * vertical + cameraRight.normalized * horizontal;
        //Debug.Log(direction);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            //Interpolación
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            //transform.rotation = targetRotation;    
            //transform.Translate(direction * (speed * Time.deltaTime));
        }

        transform.position += direction * (speed * Time.deltaTime);
    }
}
