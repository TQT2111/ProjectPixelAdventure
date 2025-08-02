using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private Vector3 pushDirection = Vector2.right;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            HandleKnockBack();
        }
    }

    private void HandleKnockBack()
    {
        rb.AddForce(pushDirection.normalized * knockbackForce, ForceMode2D.Impulse);
    }
}
