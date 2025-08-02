using UnityEngine;

public abstract class EnemyMovement : TgmMonoBehaviour
{
    protected virtual void Update()
    {
        Movement();
    }

    protected virtual void Movement()
    {
        HandleMovement();
    }

    protected abstract void HandleMovement();
}
