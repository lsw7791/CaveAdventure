using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IManager
{
}
public class GameManager : MonoSingleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();  // �ʿ��ϸ� �θ��� Awake �޼��带 ȣ��
        // �߰����� ������ ���⿡ �ۼ�
    }
}