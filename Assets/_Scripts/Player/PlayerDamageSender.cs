using UnityEngine;

public class PlayerDamageSender : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private Vector2 pushDirection = Vector2.right;

    private Rigidbody2D rb;
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            KnockBack();
        }
    }
    private void KnockBack()
    {
        rb.AddForce(pushDirection.normalized * knockbackForce, ForceMode2D.Impulse);
    }
}
