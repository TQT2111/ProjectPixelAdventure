using UnityEngine;

public class PlayerLooting : MonoBehaviour 
{
    [SerializeField] private GameManager itemIsPickUp;
    [SerializeField] private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            Debug.Log("Loot");
            itemIsPickUp.AddScore(1);
            audioManager.PlayLootingSound();
        }
        if (collision.CompareTag("Heart"))
        {
            audioManager.PlayLootHeartSound();
        }
    }
}
