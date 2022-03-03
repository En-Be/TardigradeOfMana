using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ManaAgent : MonoBehaviour
{
    [SerializeField] private float currentMana = 1;
    [SerializeField] private float maxMana = 100;
    // [SerializeField] private float receiveRate = 10;
    // [SerializeField] private float loseRate = 5;

    [SerializeField] UnityEvent AnnounceMaxMana = null;

    [SerializeField] private GameObject manaAdjustmentRing;
    private bool ringEmitted = false;

    public float CurrentMana() 
    {
        return currentMana;
    }
    public void CurrentMana(float f)
    {
        currentMana = f;
    }

    public void AdjustMana(float f) 
    {
        currentMana += f;
        
        if(!ringEmitted)
        {
            GameObject visualAdjustment = Instantiate(manaAdjustmentRing, transform.position, transform.rotation);
            visualAdjustment.GetComponent<ManaAdjustmentRing>().t = gameObject.transform;

            if(f > 0)
            {                
                visualAdjustment.GetComponent<Animator>().SetTrigger("receive");
            }
            else
            {
                visualAdjustment.GetComponent<Animator>().SetTrigger("give");
            }

            ringEmitted = true;
            StartCoroutine("RingDelay");
        }

        if(CheckIfMax())
        {
            AtMaxMana();
        }
        else if(CheckIfMin())
        {
            AtMinMana();
        }

        ManaAdjusted(f);
    }

    // public float MaxMana {get; set;}
    public float MaxMana()
    {
        return maxMana;
    }

    public void MaxMana(float f)
    {
        maxMana = f;
    }
    // public float ReceiveRate {get; set;}
    // public float LoseRate {get; set;}

    protected IEnumerator RingDelay()
    {
        yield return new WaitForSeconds(0.1f);
        ringEmitted = false;
    }

    protected virtual void Start()
    {       
        throw new Exception("ManaAgent is a base class. Attach an agent class that inherits from it instead.");
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

    protected virtual void AtMaxMana()
    {
        AnnounceMaxMana.Invoke();
    }

    protected virtual void AtMinMana()
    {

    }

    protected virtual void ManaAdjusted(float f)
    {
        
    }
}
