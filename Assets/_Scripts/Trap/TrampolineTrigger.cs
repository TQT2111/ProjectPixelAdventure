using UnityEngine;

public class TrampolineTrigger : MonoBehaviour
{
    [SerializeField] private float bounceForce = 20f;
    [SerializeField] private Animator animator;
    [SerializeField] private float maxVerticalVelocity = 50f;
    [SerializeField] private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxSendDamePlayer"))
        {
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

                rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

                if (rb.linearVelocity.y > maxVerticalVelocity)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, maxVerticalVelocity);
                }

                if (animator != null)
                {
                    animator.SetTrigger("trigger");
                }
            }
        }
    }
}
