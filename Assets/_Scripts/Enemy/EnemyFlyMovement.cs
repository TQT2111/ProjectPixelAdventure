using UnityEngine;

public class EnemyFlyMovement : EnemyMovement
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private bool moveLeft = true;

    [SerializeField] private Animator animator;

    protected override void Start()
    {
        startPos = transform.parent.position;
    }

    protected override void HandleMovement()
    {

        float leftBound = startPos.x + moveDistance;
        float rightBound = startPos.x - moveDistance;

        float direction = moveLeft ? -1f : 1f;
        transform.parent.Translate(moveSpeed * Time.deltaTime * direction * Vector2.right);

        Vector3 currentPos = transform.parent.position;
        if (moveLeft && currentPos.x <= rightBound)
        {
            moveLeft = false;
        }
        else if (!moveLeft && currentPos.x >= leftBound)
        {
            moveLeft = true;
        }
        Flip();
    }

    protected virtual void Flip()
    {
        Vector3 localScale = transform.parent.localScale;
        if ((moveLeft && localScale.x < 0f) || (!moveLeft && localScale.x > 0f))
        {
            localScale.x *= -1f;
            transform.parent.localScale = localScale;
        }
    }
}
