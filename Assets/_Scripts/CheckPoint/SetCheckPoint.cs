using UnityEngine;

public class SetCheckPoint : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Animator animator;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ReturnCheckPoint.Instance.respawnPoint = transform;
            boxCollider.enabled = false;
            animator.SetTrigger("isCheckPoint");
        }
    }
}
