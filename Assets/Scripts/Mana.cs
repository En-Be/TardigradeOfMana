using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mana : MonoBehaviour
{
    [SerializeField] private float currentMana = 1;
    [SerializeField] private float maxMana = 100;
    // [SerializeField] private float receiveRate = 10;
    // [SerializeField] private float loseRate = 5;

    [SerializeField] private ManaAgent agent;

    public float CurrentMana 
    {
        get
        {
            return currentMana;
        }
        set
        {
            currentMana += value;

            if(CheckIfMax())
            {
                agent.AtMaxMana();
            }
            else if(CheckIfMin())
            {
                agent.AtMinMana();
            }
            else
            {
                agent.ManaAdjusted(value);
            }
        }
    }

    public float MaxMana {get; set;}
    // public float ReceiveRate {get; set;}
    // public float LoseRate {get; set;}

    void Start()
    {       
        agent = GetComponent<ManaAgent>();

        if(agent == null)
        {
            throw new Exception($"{this} has no agent component to go with it's mana component");
        }
    }

    private bool CheckIfMax()
    {
        if(currentMana >= maxMana)
        {
            currentMana = maxMana;
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckIfMin()
    {
        if(currentMana <= 0)
        {
            currentMana = 0;
            return true;
        }
        else
        {
            return false;
        }
    } 
}
