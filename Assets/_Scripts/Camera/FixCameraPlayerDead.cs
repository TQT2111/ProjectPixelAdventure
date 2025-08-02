using Unity.Cinemachine;
using UnityEngine;

public class FixCameraPlayerDead : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cinemachine;
    [SerializeField] protected Transform mainCam;
    [SerializeField] protected float disLimit = 15f;
    [SerializeField] protected float distance = 0f;
    private void Start()
    {
        mainCam = Transform.FindFirstObjectByType<Camera>().transform;
    }
    private void FixedUpdate()
    {
        PosCamera();
        FixCamera();
    }
    private void PosCamera()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCam.position);
    }
    private void FixCamera()
    {
        if (distance > disLimit)
        {
            cinemachine.Follow = null;
        }
    }
}
