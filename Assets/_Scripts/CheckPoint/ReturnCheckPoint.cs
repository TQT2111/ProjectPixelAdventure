using UnityEngine;
using System.Collections;

public class ReturnCheckPoint : MonoBehaviour
{
    private static ReturnCheckPoint instance;
    public static ReturnCheckPoint Instance => instance;

    public Transform respawnPoint;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.parent.position = respawnPoint.position;
    }
}
