using System.Collections;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Sprite openBox;  //변경될 이미지
    private SpriteRenderer spriteRenderer;  

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //void 상호작용 메서드()
    //{
    //    ChangeImage();

    //    StartCoroutine(DestroyBoxAfterDelay(2f));
    //}

    void ChangeImage()
    {
            spriteRenderer.sprite = openBox;  
    }

    IEnumerator DestroyBoxAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  
        Destroy(gameObject); 
    }
}
