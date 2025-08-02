using UnityEngine;
using UnityEngine.Tilemaps;

public class LoopBackGroud : MonoBehaviour
{
    [SerializeField] private float loopSpeed = 1f;
    [SerializeField] private float tilemapHeight;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.down * loopSpeed * Time.deltaTime);

        if (transform.position.y <= startPos.y - tilemapHeight)
        {
            transform.position = startPos;
        }
    }
}
