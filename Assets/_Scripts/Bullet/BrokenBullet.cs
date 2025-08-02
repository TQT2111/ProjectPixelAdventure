using Unity.VisualScripting;
using UnityEngine;

public class BrokenBullet : MonoBehaviour
{
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject piecesBullet;
    [SerializeField] private BulletFly bulletFly;
    void Awake()
    {
        piecesBullet.SetActive(false);
    }

    void Update()
    {
        //brokenBullet.gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            model.SetActive(false);
            piecesBullet.SetActive(true);
            bulletFly.BulletSpeed(0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            model.SetActive(false);
            piecesBullet.SetActive(true);
        }
    }
}
