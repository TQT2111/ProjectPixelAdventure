using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private float timeFireOff = 3f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private bool fireOn = false;

    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private Animator animator;
    void Start()
    {
        boxCollider2D.enabled = false;
    }

    private void Update()
    {
        TimeOnFire();
    }
    private void FireOn()
    {
        boxCollider2D.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxSendDamePlayer")) {
            animator.SetBool("isFireOn", true);
            Invoke(nameof(FireOn), 0.5f);
            fireOn = true;
        }
    }

    private void TimeOnFire()
    {
        if (fireOn == true) timer += Time.deltaTime;
        if (timer > timeFireOff) timer = timeFireOff;
        TurnOffFire();
    }

    private void TurnOffFire()
    {
        if (timer == timeFireOff)
        {
            boxCollider2D.enabled = false;
            timer = 0f;
            fireOn = false;
            animator.SetBool("isFireOn", false);
        }
    }
}
