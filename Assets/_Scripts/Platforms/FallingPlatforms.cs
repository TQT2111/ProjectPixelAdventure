using System.Collections;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    [SerializeField] private float fallDelay = 0.1f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxSendDamePlayer"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        animator.SetTrigger("isHit");
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
