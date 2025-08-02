using UnityEngine;

public class FruitsDespawn : MonoBehaviour
{
    [SerializeField] protected float disLimit = 40f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;
    private void Start()
    {
        LoadCamera();
    }
    private void FixedUpdate()
    {
        Despawn();
    }
    private void LoadCamera()
    {
        if (mainCam != null) return;
        mainCam = Transform.FindFirstObjectByType<Camera>().transform;
        Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    }

    private void Despawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCam.position);
        if (this.distance > this.disLimit)
        {
            Destroy(gameObject);
        }
    }
}
