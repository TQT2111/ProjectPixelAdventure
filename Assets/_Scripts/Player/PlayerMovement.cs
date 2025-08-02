using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private bool isFacingRight = true;
    [Header("Wall Sliding")]
    [SerializeField] private bool isSliding;
    [SerializeField] private float wallSlidingSpeed;
    [Header("Jumping")]
    [SerializeField] private float jumpPower = 10f;
    [SerializeField] private bool doubleJump;
    [Header("Wall Jumping")]
    [SerializeField] private float wallJumpDuration;
    [SerializeField] private Vector2 wallJumpPower;
    [SerializeField] private bool wallJumping;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private ParticleSystem dustTwo;
    [SerializeField] private DamageReceiver dameReceiver;
    [SerializeField] private AudioManager audioManager;
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        dust = GetComponentInChildren<ParticleSystem>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    void Update()
    {
        if (dameReceiver.IsPlayerDead()) return;
        HandleMove();
        HandleJump();
        WallSliding();
        IsWallSliding();
        WallJumping();
    }
    private void HandleMove()
    {
        float inputMove = InputManager.Instance.GetInputMove;
        bool isGrounded = EnvironmentCheck.Instance.IsGrounded;
        rb.linearVelocity = new Vector2(moveSpeed * inputMove, rb.linearVelocity.y);
        if (inputMove != 0f && isGrounded) 
        {
            dustTwo.Play();
        }
        Flip();
    }
    private void HandleJump()
    {
        bool inputJump = InputManager.Instance.GetInputJump;
        bool isGrounded = EnvironmentCheck.Instance.IsGrounded;
        bool isWallTouch = EnvironmentCheck.Instance.IsWall;

        if (inputJump)
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
                doubleJump = true;
                dust.Play();
                audioManager.PlayJumpSound();
            }
            else if (doubleJump && !isWallTouch)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower * 0.8f);
                doubleJump = false;
                audioManager.PlayJumpSound();
                dust.Play();
            } else if (isSliding)
            {
                wallJumping = true;
                Invoke(nameof(StopWallJump), wallJumpDuration);
                audioManager.PlayJumpSound();
                dust.Play();
            }
        }

    }
    private void StopWallJump()
    {
        wallJumping = false;
    }

    private void WallJumping()
    {
        float inputMove = InputManager.Instance.GetInputMove;
        if (wallJumping)
        {
            rb.linearVelocity = new Vector2(-inputMove * wallJumpPower.x, wallJumpPower.y);
        }else
        {
            rb.linearVelocity = new Vector2(inputMove * moveSpeed, rb.linearVelocity.y);
        }
    }
    private void WallSliding()
    {
        if (isSliding) rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -wallSlidingSpeed, float.MaxValue));
    }
    private void IsWallSliding()
    {
        bool isGrounded = EnvironmentCheck.Instance.IsGrounded;
        float inputMove = InputManager.Instance.GetInputMove;
        bool isWallTouch = EnvironmentCheck.Instance.IsWall;

        if (isWallTouch && !isGrounded && inputMove != 0)
        {
            isSliding = true;

        } else
        {
            isSliding = false;
        }
    }
    private void Flip()
    {
        float inputMove = InputManager.Instance.GetInputMove;
        if (isFacingRight && inputMove < 0f || !isFacingRight && inputMove > 0f)
        {
            Vector3 localScale = transform.parent.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.parent.localScale = localScale;
            
        } 
    }
}
