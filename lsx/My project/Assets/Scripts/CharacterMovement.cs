using UnityEngine;

[RequireComponent (typeof(CharacterController))] //Anotacion sobre la declaración de clase
public class CharacterMovement : MonoBehaviour
{
    
    /*Variables de Movimiento*/
    public Transform CameraTransform;
    private CharacterController controller;
    public float movementSpeed = 5f;
    public float jumpForce = 10f; 
    public float rotationSpeed = 20f;
    public float gravity;
    
    /*Variables de Animación*/
    public Animator animator;
    private readonly int moveSpeedHash = Animator.StringToHash("MoveSpeed");
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            gravity = Physics.gravity.y * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space)) gravity = jumpForce;
        }
        else
        {
            gravity += Physics.gravity.y * Time.deltaTime;
        }
        
        var gravityVector = Vector3.up * gravity;
        
        //Obtener el input a y d
        var horizontal = Input.GetAxisRaw("Horizontal");
        //Obtener el input w y s
        var vertical = Input.GetAxisRaw("Vertical");
        
        var cameraForward = new Vector3(CameraTransform.forward.x, 0, CameraTransform.forward.z);
        var cameraRight = new Vector3(CameraTransform.right.x, 0, CameraTransform.right.z);
        var direction = cameraForward * vertical + cameraRight * horizontal;
        
        controller.Move((direction * movementSpeed + gravityVector) * Time.deltaTime);
        
        //Aplicar rotación al personaje
        if (direction != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
        //Mover el parametro de "MoveSpeed" de 0 a 1 (es el slider)
        animator.SetFloat(moveSpeedHash, direction.normalized.magnitude);
        
    }
}
