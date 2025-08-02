using UnityEngine;

public class ResetPlayerRigibody : TgmMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigibody2D();
    }
    protected virtual void LoadRigibody2D()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;
        rb.freezeRotation = true;
        rb.sharedMaterial = Resources.Load<PhysicsMaterial2D>("noFriction");
    }
}
