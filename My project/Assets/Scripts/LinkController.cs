using UnityEngine;
using UnityEngine.InputSystem;
public class LinkController : MonoBehaviour
{
    
    [SerializeField]private CharacterController controller;
    [SerializeField] private LinkSound linkSound;
    public Transform cam;
    [SerializeField]private float speed = 1f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private bool isDead = false;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.2f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    public bool IsGrounded => isGrounded;

    [SerializeField] private float jumpHeight = 3f; 
    public static LinkController Instance { get; private set; }
    private void Awake()
    {
        if(Instance!= null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        if (isDead) return;
        HandleJump();
        HandleMovement();
        
    }
    public void Die()
    {
        isDead = true;
    }
    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void HandleJump()
    {
        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            linkSound.JumpSound();
        }
    }
    private void HandleMovement()
    {
      
        Vector2 input = new Vector2();
        if (Keyboard.current != null)
        {   
            if (Keyboard.current.wKey.isPressed) input.y += 1f;
            if (Keyboard.current.sKey.isPressed) input.y -= 1f;
            if (Keyboard.current.dKey.isPressed) input.x += 1f;
            if (Keyboard.current.aKey.isPressed) input.x -= 1f;
            if (Keyboard.current.shiftKey.isPressed) speed = 10f;
            else speed = 6f;
        }
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime );
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
    
}
