using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public float followSpeed;
    public float detectionRadius;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            followSpeed * Time.deltaTime
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ICollectible collectible = GetComponent<ICollectible>();

            collectible.Collect();
            Destroy(gameObject);
        }
    }

}
