using UnityEngine;

public class CheckPointCtrl : MonoBehaviour
{
    private static CheckPointCtrl instance;
    public static CheckPointCtrl Instance => instance;

    [SerializeField] private Transform respawnPoint;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent.position = respawnPoint.position;
        }
    }
}
