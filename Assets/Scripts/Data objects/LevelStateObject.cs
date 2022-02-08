using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Statefiles/LevelState")]
public class LevelStateObject : ScriptableObject
{   
    [SerializeField] private int currentStoryBeat = 0;
    [SerializeField] private bool guideCollected = false;
    [SerializeField] private bool[] agentsConverted = null;
    
    public void Reset()
    {
        currentStoryBeat = 0;
        guideCollected = false;
        agentsConverted = new bool[50];
    }

    public int CurrentStoryBeat()
    {
        return currentStoryBeat;
    }

    public void CurrentStoryBeat(int i)
    {
        currentStoryBeat = i;
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
