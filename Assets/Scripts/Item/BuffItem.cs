using System.Collections;
using UnityEngine;

public class BuffItem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            IBuff buff = GetComponent<IBuff>();
            if (buff != null)
            {
                // 버프 효과 활성화
                buff.ActivateEffect(player);

                // 버프 적용
                buff.ApplyBuff(player);

                // 버프 지속 시간 관리
                StartCoroutine(HandleBuffDuration(player, buff));

                // 버프 아이템 파괴
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator HandleBuffDuration(Player player, IBuff buff)
    {
        // 버프 지속 시간 대기
        yield return new WaitForSeconds(buff.BuffDuration);

        // 버프 효과 비활성화
        buff.DeactivateEffect(player);

        // 버프 해제
        buff.RemoveBuff(player);
    }
}
