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
        base.Awake();  // 필요하면 부모의 Awake 메서드를 호출
        // 추가적인 로직을 여기에 작성
    }
}