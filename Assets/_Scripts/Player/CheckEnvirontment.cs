using UnityEngine;

public class EnvironmentCheck : MonoBehaviour
{
    private static EnvironmentCheck instance;
    public static EnvironmentCheck Instance => instance;

    [Header("Grounded Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded;

    [Header("Wall Check")]
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private bool isWall;
    public bool IsGrounded => isGrounded;
    public bool IsWall => isWall;
    private void Awake()
    {
        instance = this;

        groundCheck = transform.Find("GroundCheck");
        groundLayer = LayerMask.GetMask("Ground");

        wallCheck = transform.Find("WallCheck");
        wallLayer = LayerMask.GetMask("Wall");
    }

    private void Update()
    {
        IsGroundCheck();
        IsWallCheck();
    }

    private bool IsGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        return isGrounded;
    }

    private bool IsWallCheck()
    {
        isWall = Physics2D.OverlapCircle(wallCheck.position, 0.3f, wallLayer);
        return isWall;
    }
}
