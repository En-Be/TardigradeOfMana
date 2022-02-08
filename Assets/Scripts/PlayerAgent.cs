using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerAgent : ManaAgent
{
    [SerializeField] private PlayerStateObject playerState = null;

    [SerializeField] private Text text = null;
    [SerializeField] private GameObject prefabGuide;
    [SerializeField] private GameObject guide;
    [SerializeField] private Transform guideTarget;

    private Animator anim;

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        if(anim == null)
        {
            throw new Exception("player has no animator");
        }

        LoadState();
        DisplayMana();
        SetGuide();
    }

    protected override void ManaAdjusted(float v)
    {
        if(text != null)
        {
            DisplayMana();
        }

        if(v > 0)
        {
            Debug.Log($"player gained {v} mana");
            anim.SetTrigger("Healed");
        }
        else
        {
            Debug.Log($"player lost {v * -1} mana");
            anim.SetTrigger("Damaged");
        }
    }

    protected override void AtMaxMana()
    {
        base.AtMaxMana();
        Debug.Log("Player at max mana");
    }

    protected override void AtMinMana()
    {
        Debug.Log("Player at min mana");
        GameManager.Instance.Dead();
    }

    private void SaveState()
    {
        playerState.CurrentMana(CurrentMana());
        playerState.MaxMana(MaxMana());
    }

    private void LoadState()
    {
        CurrentMana(playerState.CurrentMana());
        MaxMana(playerState.MaxMana());
    }

    private void DisplayMana()
    {
        text.text = $"{CurrentMana().ToString("F0")} of {MaxMana()}";
    }

    private void OnDisable()
    {
        if(CurrentMana() > 0)
        {
            SaveState();
        }
    }

    private void SetGuide()
    {
        if(guide == null && playerState.HasGuide())
        {
            guide = Instantiate(prefabGuide, transform.position,transform.rotation);
            guide.GetComponent<GuideFriend>().SetTarget(guideTarget);
        }
    }

    public bool HasGuide()
    {
        return playerState.HasGuide();
    }

    public void HasGuide(bool b)
    {
        playerState.HasGuide(b);
    }
}
