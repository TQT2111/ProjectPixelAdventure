using System.Collections;
using UnityEngine;

public class EnemyGroundMovement : EnemyMovement
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private float pauseDuration = 2f;
    [SerializeField] private Vector3 startPos;

    [SerializeField] private Animator animator;

    private bool isPaused;
    private float pauseTimer;

    [SerializeField] private bool moveLeft = true;

    protected override void Start()
    {
        startPos = transform.parent.position;
        isPaused = false;
        pauseTimer = 0f;
    }

    protected override void HandleMovement()
    {
        if (isPaused)
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0f)
            {
                isPaused = false;
            }
            return;
        }

        float leftBound = startPos.x + moveDistance;
        float rightBound = startPos.x - moveDistance;

        float direction = moveLeft ? -1f : 1f;
        transform.parent.Translate(moveSpeed * Time.deltaTime * direction * Vector2.right);
        animator.SetBool("isMove", true);


        Vector3 currentPos = transform.parent.position;
        if (moveLeft && currentPos.x <= rightBound)
        {
            moveLeft = false;
            StartPause();
        }
        else if (!moveLeft && currentPos.x >= leftBound)
        {
            moveLeft = true;
            StartPause();
        }

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
    private void StartPause()
    {
        isPaused = true;
        pauseTimer = pauseDuration;
        StartCoroutine(WaitAndFlip());
        animator.SetBool("isMove", false);

    }
    IEnumerator WaitAndFlip()
    {
        yield return new WaitForSeconds(pauseDuration);
        Flip();
    }
}
