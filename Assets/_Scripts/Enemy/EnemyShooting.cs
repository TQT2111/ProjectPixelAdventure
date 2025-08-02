using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private float timer = 0f;
    private float timeShoot = 2.75f;
    [SerializeField] private float shootingDelay = 3f;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Animator animator;
    void Update()
    {
        bulletPrefabs.SetActive(false);
        IsShooting();
    }

    private void IsShooting()
    {
        timer += Time.deltaTime;
        if (timer > timeShoot) animator.SetBool("isAttack", true);
        if (timer >= shootingDelay) timer = shootingDelay;
        if (timer == shootingDelay)
        {
            bulletPrefabs.SetActive(true);
            Instantiate(bulletPrefabs, shootPoint.position, transform.rotation);
            animator.SetBool("isAttack", false);
        }
        if (timer >= shootingDelay) timer = 0;
    }
}
