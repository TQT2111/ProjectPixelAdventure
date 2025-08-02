using Unity.VisualScripting;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int hp = 1;
    [SerializeField] private int hpMax = 3;
    [SerializeField] private bool isDead = false;
    [SerializeField] private bool isLostHp = false;
    [SerializeField] private float damageCooldown = 3f;
    [SerializeField] private float lastDamageTime;
    [Header("Dead Distance")]
    [SerializeField] protected float disLimit = 40f;
    [SerializeField] protected float distance = 0f;
    [Header("Knockback")]
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private Vector3 pushDirection = Vector2.right;
    [Header("Components")]
    [SerializeField] private SceneManagement sceneManagement;
    [SerializeField] private Animator animator;
    [SerializeField] protected Transform mainCam;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        mainCam = Transform.FindFirstObjectByType<Camera>().transform;
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void Update()
    {
        IsTrueDead();
        ChangeCheckPoint();
        FallOutCamera();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap") || collision.CompareTag("DamageEnemy"))
        {
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                isLostHp = true;
                MinusHP();
                lastDamageTime = Time.time; 
            }
        }
        if (collision.CompareTag("Boss"))
        {
            isDead = true;
        }
    }
    public void MinusHP()
    {
        if (isLostHp)
        {
            hp -= 1;
            audioManager.PlayTakeDameSound();
            animator.SetTrigger("isHit");
            KnockBack();
            isLostHp = false;
        }

    }
    private void ChangeCheckPoint()
    {
        if (hp == 0) return;
    }
    public void IsTrueDead()
    {
        if (hp < 0 || isDead == true)
        {
            hp = 0;
            isDead = true;
            Invoke(nameof(UIGameOver), 1.5f);
        }
    }
    private void UIGameOver()
    {
        gameManager.GameOver();
    }
    public int Hp()
    {
        return hp;
    }
    public bool IsPlayerDead()
    {
        return isDead;
    }
    private void FallOutCamera()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCam.position);
        if (this.distance > this.disLimit) isDead = true;
    }
    public void AddHP(int add)
    {
        hp += add;
        if (hp > hpMax) hp = hpMax;
    }
    private void KnockBack()
    {
        rb.AddForce(pushDirection.normalized * knockbackForce, ForceMode2D.Impulse);
    }
}
