using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerAgent : ManaAgent
{

    public Text text;
    private Animator anim;

    public override void Start()
    {
        base.Start();

        anim = GetComponent<Animator>();
        if(anim == null)
        {
            throw new Exception("player has no animator");
        }
    }

    public override void ManaAdjusted(float v)
    {
        text.text = $"{mana.CurrentMana.ToString("F0")} of {mana.MaxMana}";

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

    public override void AtMaxMana()
    {
        Debug.Log("Player at max mana");
    }

    public override void AtMinMana()
    {
        Debug.Log("Player at min mana");
    }
}
