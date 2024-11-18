using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject inventoryUI;

    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public Animator animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer spriteRenderer;

    [Header("Jump")]
    public float jumpForce = 5f; 
    private bool isGrounded; 
    public Transform groundCheck; 
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer; 

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        UpdateAnimation();
        CheckGroundStatus();
    }

    void Move()
    {
        Vector2 dir = transform.up * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;

        _rigidbody.velocity = new Vector2(dir.x, _rigidbody.velocity.y); 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed || context.phase == InputActionPhase.Started)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    void Jump()
    {
        Vector2 dir = transform.up * curMovementInput.y;
        dir *= jumpForce;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            animator.SetTrigger("isJumping"); 
        }
    }

    public void OnInventoryToggle(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            bool isActive = inventoryUI.activeSelf;
            inventoryUI.SetActive(!isActive);
        }
    }

    void UpdateAnimation()
    {
        bool isMoving = curMovementInput != Vector2.zero;
        animator.SetBool("isWalking", isMoving);

        if (curMovementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (curMovementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void CheckGroundStatus()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
