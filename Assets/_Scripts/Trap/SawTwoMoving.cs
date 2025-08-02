using UnityEngine;

public class SawTwoMoving : MonoBehaviour
{
    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;
    [SerializeField] private float speed = 2f;
    private Vector3 target;
    void Start()
    {
        target = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(transform.parent.position, target) < 0.1f)
        {
            if (target == posA.position)
            {
                target = posB.position;
            }
            else
            {
                target = posA.position;
            }
        }
    }
}
