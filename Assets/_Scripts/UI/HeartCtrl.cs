using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class HeartCtrl : TgmMonoBehaviour
{
    [SerializeField] private Image[] hearts;

    [SerializeField] private int health;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    [SerializeField] private DamageReceiver damageReceiver;
    private void Update()
    {
        HeartsBar();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHearts();
    }
    protected virtual void LoadHearts()
    {
        hearts = GetComponentsInChildren<Image>();
        if (hearts == null || hearts.Length == 0)
        {
            Debug.LogWarning("No heart images found in " + gameObject.name);
            return;
        }
    }

    private void HeartsBar()
    {
        health = damageReceiver.Hp();

        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i  = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}
