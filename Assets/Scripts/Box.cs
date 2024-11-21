using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{
    public Sprite openBox;  // 변경될 이미지 (상자가 열린 상태의 이미지)
    private SpriteRenderer spriteRenderer;  // 상자의 SpriteRenderer
    public GameObject portal;

    public GameObject[] firework;  // 상자 열릴 때 나타낼 이펙트 (파티클 시스템 등)
    public float effectDuration;  // 이펙트가 지속되는 시간

    private bool isOpened = false;  // 상자가 열렸는지 체크하는 변수

    public ParticleSystem BoxParticle;     //파티클

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 2D 충돌 검사
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 상자가 아직 열리지 않았고, 충돌한 객체가 "Player" 태그를 가지고 있는지 확인
        if (!isOpened && collision.gameObject.CompareTag("Player"))
        {
            OpenBox();  // 상자 열기
        }
    }

    // 상자 열기 처리
    void OpenBox()
    {
        isOpened = true;  // 상자가 열렸다고 설정

        // 이미지 변경 (상자가 열린 이미지로 변경)
        ChangeImage();

        // 이펙트 활성화
        ActivateEffects();

        // 일정 시간 후 이펙트를 비활성화
        StartCoroutine(DeactivateEffectsAfterDelay(effectDuration));

        portal.SetActive(true);

        // 파티클 활성화
        Instantiate(BoxParticle, transform.position, Quaternion.identity);
        BoxParticle.Play();
    }

    // 상자 이미지 변경
    void ChangeImage()
    {
        spriteRenderer.sprite = openBox;  // 상자 이미지를 열린 상태로 변경
    }

    // 이펙트 활성화
    void ActivateEffects()
    {
        foreach (GameObject effect in firework)
        {
            if (effect != null)
            {
                effect.SetActive(true);  // 이펙트 오브젝트를 활성화
            }
        }
    }

    // 일정 시간 후 이펙트를 비활성화
    IEnumerator DeactivateEffectsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // delay 시간만큼 기다림
        foreach (GameObject effect in firework)
        {
            if (effect != null)
            {
                effect.SetActive(false);  // 이펙트 오브젝트를 비활성화
            }
        }
    }
}

