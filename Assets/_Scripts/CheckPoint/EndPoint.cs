using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private GameObject winnerUI;
    [SerializeField] private AudioManager audioManager;
    private void Start()
    {
        winnerUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            winnerUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
