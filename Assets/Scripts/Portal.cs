using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Animator playerAnimator; // 애니메이션을 제어할 애니메이터
    public string portalAnimationTrigger = "PortalEnter"; // 애니메이션 트리거 이름
    public string nextSceneName = "NextScene"; // 다음 씬의 이름
    private bool isPlayerInsidePortal = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어가 포탈에 접촉했을 때
        if (other.CompareTag("Player"))
        {
            isPlayerInsidePortal = true;
            StartCoroutine(PortalSequence(other.gameObject));
        }
    }

    private IEnumerator PortalSequence(GameObject player)
    {
        // 포탈 애니메이션 시작
        playerAnimator.SetTrigger(portalAnimationTrigger);

        // 애니메이션의 길이만큼 대기
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length);

        // 애니메이션이 끝난 후 씬을 전환하거나, 다른 행동을 취합니다.
        //SceneManager.LoadScene(nextSceneName);
    }
}
