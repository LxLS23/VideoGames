using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //a -1, 0, d 1
        float vertical = Input.GetAxis("Vertical"); // w 1, 0, s -1
        
        Vector3 direction = new Vector3(horizontal, 0, vertical);

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
