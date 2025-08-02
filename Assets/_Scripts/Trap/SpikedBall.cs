using UnityEngine;

public class SpikedBall : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Transform posRotation;

    void Update()
    {
        transform.parent.RotateAround(posRotation.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
