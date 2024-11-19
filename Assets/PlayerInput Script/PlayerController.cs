using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject Player;

    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public Animator animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer spriteRenderer;

    [Header("Jump")]
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    [SerializeField]
    private GameObject[] FireBallPrefab;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        Move();
        UpdateAnimation();
        CheckGroundStatus();

        if (isGrounded == false)
        {
            if (_rigidbody.velocity.y < 0)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isfalling", true);
            }
        }
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

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
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

    // 벽과 충돌하면서 벽에 붙지 않도록 처리
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Groundlayer"))  
        {
            if (curMovementInput.x != 0)
            {
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);  // X축 속도를 0으로 설정
            }
            animator.SetBool("isfalling", false);
        }
    }
    //파이어볼 소환 부분
    //public void Attack(InputAction.CallbackContext context)
    //{
    //    if (context.phase == InputActionPhase.Performed)
    //    {
    //        Instantiate(FireBallPrefab[0], transform.position, Quaternion.identity);
    //    }
    //}

    //여기부턴 사다리 타기 부분
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            this.gameObject.tag = "InLadder";
            animator.SetBool("isLadderIdle", true);
        }
    }
    void Ladder(float k)
    {
        _rigidbody.velocity = new Vector2(0, 0);
        if (this.tag == "InLadder")
        {

            isGrounded = false;
            Player.layer = 9;
            _rigidbody.gravityScale = 0;
            if (k > 0)
            {
                this.transform.Translate(0, moveSpeed * Time.deltaTime, 0);
                animator.SetBool("isLadder", true);
            }
            if (k < 0)
            {
                this.transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
                animator.SetBool("isLadder", true);
            }
        }
    }
    void LadderOut()
    {
        this._rigidbody.gravityScale = 1;
        this.gameObject.layer = 6;
        this.tag = "Player";
        animator.SetBool("isLadderIdle", false);
        animator.SetBool("isLadder", false);
    }
    void FixedUpdate()
    {
        float k = Input.GetAxisRaw("Vertical");
        if (k != 0)
        {
            Ladder(k);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            LadderOut();
            animator.SetTrigger("isIdle");
        }
    }
}
