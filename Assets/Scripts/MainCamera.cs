using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Transform playerPos;  // �÷��̾��� Transform�� ������ ����
    Vector3 offset;
    // ī�޶�� �÷��̾� ������ �Ÿ�

    // Start is called before the first frame update
    void Start()
    {
        // �÷��̾� �±װ� ���� ������Ʈ�� ã�Ƽ� �÷��̾� ������ �Ҵ�
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        offset = new Vector3(0, -0, -10);  // X, Y, Z �� ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾��� ��ġ�� ī�޶� �ݿ�
        if (playerPos != null)
        {
            // ī�޶��� ��ġ�� �÷��̾� ��ġ + ���������� ����
            transform.position = playerPos.position + offset;
        }
    }
}
