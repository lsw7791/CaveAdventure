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
        //������ �̵� ����
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            curMovementInput = context.ReadValue<Vector2>();
            //�̵� Ű�� ������ ������ �̵��ϵ��� ��� �Է½�����
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            //�̵� Ű ���� ���̻� �νĵ��� ������ �̵����� �ʰ� ����
        }
    }
}
