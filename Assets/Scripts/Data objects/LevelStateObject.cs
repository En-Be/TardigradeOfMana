using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Statefiles/LevelState")]
public class LevelStateObject : ScriptableObject
{
    [SerializeField] private bool guideCollected = false;
    [SerializeField] private bool[] agentsConverted = null;
    
    public void Reset()
    {
        guideCollected = false;
        agentsConverted = new bool[50];
    }

    public bool GuideCollected()
    {
        return guideCollected;
    }

    public void GuideCollected(bool b)
    {
        guideCollected = b;
    }

    public bool[] AgentsConverted()
    {
        return agentsConverted;
    }

    public void AgentsConverted(bool[] b)
    {
        agentsConverted = b;
    }
}
