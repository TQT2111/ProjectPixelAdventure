using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SetEnemyMove();
    }

    private void SetEnemyMove()
    {
    }
}
