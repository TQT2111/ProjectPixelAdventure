using UnityEngine;

public class EnemyCantMoveReceiverDamage : MonoBehaviour
{
    [Header("Rotation After Dead")]
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float targetRotationZ; 
    [SerializeField] private bool isRotating;
    [Header("knock Back")]
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private Vector2 pushDirection = Vector2.right;

    [SerializeField] private bool enemyIsDead = false;

    [SerializeField] private BoxCollider2D colliderHitBox;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    void Start()
    {
        colliderHitBox = GetComponent<BoxCollider2D>();
        if (colliderHitBox == null) return;
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RotationObject();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxSendDamePlayer"))
        {
            Invoke(nameof(EnemyIsDead), 0.01f);
        }
    }

    private void EnemyIsDead()
    {
        TurnOfBoxCollider();
        SetRandomRotationZ();
        KnockBack();
        animator.SetBool("isHit", true);
        rb.bodyType = RigidbodyType2D.Dynamic;
        enemyIsDead = true;
    }

    public bool StatusDeadEnemy()
    {
        return enemyIsDead;
    }

    private void TurnOfBoxCollider()
    {
        colliderHitBox.enabled = false;
    }
    private void RotationObject()
    {
        if (isRotating)
        {
            Quaternion currentRotation = transform.parent.rotation;
            Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, targetRotationZ);
            transform.parent.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed / 180f);

            if (Quaternion.Angle(currentRotation, targetRotation) < 0.1f)
            {
                isRotating = false; 
            }
        }
    }
    private void SetRandomRotationZ()
    {
        targetRotationZ = Random.Range(-90f, 90f);
        isRotating = true; 
    }
    private void KnockBack()
    {
        rb.AddForce(pushDirection.normalized * knockbackForce, ForceMode2D.Impulse);
    }
}
