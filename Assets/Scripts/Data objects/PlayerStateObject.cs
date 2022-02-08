using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Statefiles/PlayerState")]
public class PlayerStateObject : ScriptableObject
{
    [SerializeField] private float currentMana;
    [SerializeField] private float maxMana;
    [SerializeField] private bool hasGuide;

    public float CurrentMana()
    {
        return currentMana;
    }

    public void CurrentMana(float f)
    {
        currentMana = f;
    }

    public float MaxMana() 
    {
        return maxMana;
    }

    public void MaxMana(float f)
    {
        maxMana = f;
    }

    public bool HasGuide() 
    {
        return hasGuide;
    }

    public void HasGuide(bool b)
    {
        hasGuide = b;
    }

    public void Reset()
    {
        currentMana = 1;
        maxMana = 100;
        hasGuide = false;
    }
}
