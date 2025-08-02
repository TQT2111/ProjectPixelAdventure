using UnityEngine;

public class FatBird : MonoBehaviour
{
    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;
    [SerializeField] private float speedPosA = 2f;
    [SerializeField] private float speedPosB = 10f;
    [SerializeField] private float stunTime = 1f;
    private float currentSpeed;
    [SerializeField] private bool isWaiting;
    private float waitTimer;
    private Vector3 target;

    [SerializeField] EnemyReceiverDamage enemyReceiverDamage;
    [SerializeField] private Animator animator;
    void Start()
    {
        target = posA.position;
        currentSpeed = speedPosA;
        isWaiting = false;
        waitTimer = 0f;
    }

    void Update()
    {
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                target = posA.position;
                currentSpeed = speedPosA;
            }
            animator.SetBool("isGround", true);
            return;
        }

        transform.parent.position = Vector3.MoveTowards(transform.parent.position, target, currentSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.parent.position, target) < 0.1f)
        {
            if (target == posA.position)
            {
                target = posB.position;
                currentSpeed = speedPosB;
                animator.SetBool("isFall", true);
            }
            else
            {
                animator.SetBool("isFall", false);
                isWaiting = true;
                waitTimer = stunTime;
            }
        }
        
        if (isWaiting == false) animator.SetBool("isGround", false);

        IfEnemyDead();
    }

    private void IfEnemyDead()
    {
        bool isDead = enemyReceiverDamage.StatusDeadEnemy();

        if (isDead == true)
        {
            speedPosA = 0f;
            speedPosB = 0f;
        }
    }
}
