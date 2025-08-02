using UnityEngine;

public class MakePlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private DamageReceiver dameReceiver;
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SetPlayerMovement();
        SetPlayerJumping();
        SetPlayerWallJump();
        SetPlayerDead();
    }

    private void SetPlayerMovement()
    {
        animator.SetFloat("moveSpeed", Mathf.Abs(rb.linearVelocity.x));
    }

    private void SetPlayerJumping()
    {
        bool isGrounded = EnvironmentCheck.Instance.IsGrounded;
        bool inputJump = InputManager.Instance.GetInputJump;

        if (!isGrounded)
        {
            animator.SetBool("isJumping", true);
            animator.SetFloat("veclocityFall", rb.linearVelocity.y);
        }
        if (!isGrounded && inputJump)
        {
            animator.SetBool("isDoubleJump", true);
            animator.SetFloat("veclocityFall", rb.linearVelocity.y);
        }
        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJump", false);
        }

    }

    private void SetPlayerWallJump()
    {
        bool isGrounded = EnvironmentCheck.Instance.IsGrounded;
        bool isWall = EnvironmentCheck.Instance.IsWall;
        float inputMove = InputManager.Instance.GetInputMove;
        if (!isGrounded && isWall && inputMove != 0)
        {
            animator.SetBool("isWallJump", true);
            animator.SetBool("isDoubleJump", false);
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isWallJump", false);
        }
    }
    private void SetPlayerDead()
    {
        bool isdead = dameReceiver.IsPlayerDead();
        if (isdead == true) animator.SetBool("isDead", true);
    }
    public void SetPlayerHit()
    {
        animator.SetTrigger("isHit");
    }
}

