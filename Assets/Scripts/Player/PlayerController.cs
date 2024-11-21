using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    public float collisionCooldown = 1.0f; // 충돌 쿨타임 (초 단위)
    private float lastCollisionTime = -Mathf.Infinity; // 마지막 충돌 시간 기록
    public UIHeart uiHeart;

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

    private bool isInPortalAnimation = false; 

    private void Awake()
    {
        Player = Resources.Load<GameObject>("Prefabs/GameSettings/Player");
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
        //dir.y = _rigidbody.velocity.y;

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
                _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);// X축 속도를 0으로 설정
            }
            if (_rigidbody.velocity.y < 0)
                _rigidbody.velocity = new Vector2(0, -4);
                animator.SetBool("isfalling", false);
        }
    }

    //여기부턴 사다리 타기 부분
    private void OnTriggerEnter2D(Collider2D other)
    {

        // 몬스터 또는 기믹에 충돌했을 때
        if (other.gameObject.CompareTag("Monster") || other.gameObject.CompareTag("Gimmick"))
        {
            if (Time.time - lastCollisionTime >= collisionCooldown)
            {
                uiHeart.Loss();
            }
        }

        // 사다리 진입 처리
        if (other.gameObject.layer == 8)
        {
            this.gameObject.tag = "InLadder";
            GetComponent<Animator>().SetBool("isLadderIdle", true);
        }

        // 포탈 처리
        if (other.gameObject.CompareTag("Portal"))
        {
            StartPortalAnimation();
        }
    }

    void Ladder(float k)
    {
        
        if (this.tag == "InLadder")
        {
            _rigidbody.velocity = new Vector2(0, 0);
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

    private void StartPortalAnimation()
    {
        isInPortalAnimation = true; // 애니메이션 실행 상태 설정
        animator.SetBool("isPortalAnimation", true); // Animator 파라미터 변경

        // 애니메이션 길이 확인 후 실행 완료 콜백 등록
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke(nameof(EndPortalAnimation), animationLength);
    }

    private void EndPortalAnimation()
    {
        animator.SetBool("isPortalAnimation", false); // Animator 파라미터 초기화
        isInPortalAnimation = false; // 상태 초기화
    }
}
