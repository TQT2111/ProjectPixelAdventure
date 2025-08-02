using UnityEngine;

public class ItemIsPickUp : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CircleCollider2D circleCollider;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            animator.SetBool("isCollected", true);
            ColliderTurnOf();
            //Invoke(nameof(DestroyItem), 5f);
        }
    }
    private void ColliderTurnOf()
    {
        circleCollider.enabled = false;
    }

    private void DestroyItem()
    {
        Destroy(transform.parent.gameObject);
    }
}
