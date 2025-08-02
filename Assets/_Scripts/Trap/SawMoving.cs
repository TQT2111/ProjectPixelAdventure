using UnityEngine;
using UnityEngine.UIElements;

public class SawMoving : MonoBehaviour
{
    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;
    [SerializeField] private Transform posC;
    [SerializeField] private Transform posD;
    [SerializeField] private float speed = 1f;
    private Vector3[] positions;
    private int targetIndex;
    private Vector3 target;
    void Start()
    {
        target = posA.position;

        positions = new Vector3[] { posA.position, posB.position, posC.position, posD.position };
        targetIndex = 0;
        target = positions[targetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.parent.position, target) < 0.1f)
        {
            targetIndex = (targetIndex + 1) % positions.Length;
            target = positions[targetIndex];
        }
    }
}
