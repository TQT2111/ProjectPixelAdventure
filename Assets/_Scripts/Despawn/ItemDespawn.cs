using UnityEngine;

public class ItemDespawn : DespawnByTime
{
    public void Despawn()
    {
        CanDespawn();
    }
    protected override bool CanDespawn()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer > this.delay) return true;
        return false;
    }
}
