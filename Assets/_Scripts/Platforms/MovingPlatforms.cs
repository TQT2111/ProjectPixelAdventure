using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;
    [SerializeField] private float speed = 2f;
    private Vector3 target;
    [SerializeField] private Transform player;
    void Start()
    {
        target = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, target, speed * Time.deltaTime);
        if(Vector3.Distance(transform.parent.position, target) < 0.1f)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxSendDamePlayer"))
        {
            collision.transform.parent.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxSendDamePlayer"))
        {
            collision.transform.parent.SetParent(player);
        }
    }
}
