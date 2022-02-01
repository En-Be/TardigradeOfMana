using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManaAgent : MonoBehaviour
{
    public Mana mana;

    public virtual void Start()
    {
        mana = GetComponent<Mana>();

        if(mana == null)
        {
            throw new Exception($"{this} has no mana component to go with it's agent component");
        }
    }

    public virtual void ManaAdjusted(float v)
    {

    }

    public virtual void AtMaxMana()
    {

    }

    public virtual void AtMinMana()
    {

    }
}
