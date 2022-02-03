using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerAgent : ManaAgent
{
    [SerializeField] private PlayerStateObject playerState = null;

    [SerializeField] private Text text = null;
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
}
