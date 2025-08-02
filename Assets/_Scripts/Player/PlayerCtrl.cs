using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : TgmMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model  => model;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected Transform movement;
    public Transform Movement => movement;

    [SerializeField] protected PlayerReceiverDamage playerReceiveDamage;
    public PlayerReceiverDamage PlayerReceiveDamage => playerReceiveDamage;

    [SerializeField] protected MakePlayerAnimations playerAnimations;
    public MakePlayerAnimations PlayerAnimations => playerAnimations;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadPlayerMovement();
        LoadPlayerReceiveDamage();
        LoadPlayerAnimations();
        LoadAnimator();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }
    protected virtual void LoadAnimator()
    {
        GameObject animatorInModel = GameObject.Find("Model");
        animator = transform.GetComponentInChildren<Animator>();
    }
    protected virtual void LoadPlayerMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.Find("Movement");
    }
    protected virtual void LoadPlayerReceiveDamage()
    {
        if (this.playerReceiveDamage != null) return;
        this.playerReceiveDamage = transform.GetComponentInChildren<PlayerReceiverDamage>();
    }
    protected virtual void LoadPlayerAnimations()
    {
        if (this.playerAnimations != null) return;
        playerAnimations = GetComponentInChildren<MakePlayerAnimations>();
    }
}
