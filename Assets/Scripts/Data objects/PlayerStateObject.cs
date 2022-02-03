using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Statefiles/PlayerState")]
public class PlayerStateObject : ScriptableObject
{
    [SerializeField] private float currentMana;
    [SerializeField] private float maxMana;

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

    public void Reset()
    {
        currentMana = 1;
        maxMana = 100;
    }
}
