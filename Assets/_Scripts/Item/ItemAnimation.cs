using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetItemCollected()
    {

    }
}
