using UnityEngine;

public class BulletDespawn : MonoBehaviour
{
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private bool isWall;
    [SerializeField] private CircleCollider2D circleCollider;

    private void Update()
    {
        Despawn();
        IsWallCheck();
    }
    private void IsWallCheck()
    {
        isWall = Physics2D.OverlapCircle(wallCheck.position, 0.1f, wallLayer);
    }
    private void Despawn()
    {
        if (isWall)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
