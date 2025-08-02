using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    [SerializeField] private BulletFly bulletFly;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
        }
    }

}
