using UnityEngine;

public class BuffItem : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            IBuff buff = GetComponent<IBuff>();
            buff.ApplyBuff(player);  
            Destroy(gameObject);    
        }
    }
}
