using UnityEngine;

public class AnimationsStartPoint : TgmMonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxSendDamePlayer"))
        {
            animator.SetTrigger("isTrigger");
        }
    }
}
