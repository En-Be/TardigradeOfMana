using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerAgent : ManaAgent
{

    public Text text;
    private Animator anim;

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        if(anim == null)
        {
            throw new Exception("player has no animator");
        }
        DisplayMana();

        //         PlayerPrefs.SetFloat("playerMana", player.mana);
        //         player.SetMana(PlayerPrefs.GetFloat("playerMana"));

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
            Debug.Log($"player lost {v} mana");
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

    private void DisplayMana()
    {
        text.text = $"{CurrentMana().ToString("F0")} of {MaxMana()}";
    }
}
