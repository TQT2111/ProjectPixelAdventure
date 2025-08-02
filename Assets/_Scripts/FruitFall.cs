using UnityEngine;

public class FruitFall : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.down;
    void Update()
    {
        Fall();
    }

    private void Fall()
    {
        transform.Translate(moveSpeed * Time.deltaTime * direction);
    }
}
