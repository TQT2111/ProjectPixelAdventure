using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.left;
    void Update()
    {
        Fly();
    }

    private void Fly()
    {
        transform.parent.Translate(moveSpeed * Time.deltaTime * direction);
    }

    public void BulletSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
}
