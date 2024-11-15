using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public Animator animator;
    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }
    void Move()
    {
        Vector2 dir = transform.up * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;

        _rigidbody.velocity = dir;
        //실제로 이동 구현
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            curMovementInput = context.ReadValue<Vector2>();
            //이동 키를 누르고 있을때 이동하도록 계속 입력시켜줌
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            //이동 키 값이 더이상 인식되지 않을때 이동되지 않게 해줌
        }
    }
}
