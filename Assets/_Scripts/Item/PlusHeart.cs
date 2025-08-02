using UnityEngine;

public class PlusHeart : MonoBehaviour
{
    [SerializeField] DamageReceiver damageReceiver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damageReceiver.AddHP(1);
        }
    }
}
