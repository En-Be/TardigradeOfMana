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
        Debug.Log($"Reset called on {this}");
        currentStoryBeat = 0;
        guideCollected = false;
        agentsConverted = null;
    }

    public int CurrentStoryBeat()
    {
        return currentStoryBeat;
    }

    public void CurrentStoryBeat(int i)
    {
        currentStoryBeat = i;
        Debug.Log($"Currentstorybeat changed on {this} to {currentStoryBeat}");
    }

    public bool GuideCollected()
    {
        return guideCollected;
    }

    public void GuideCollected(bool b)
    {
        guideCollected = b;
        Debug.Log($"GuideCollected changed on {this} to {guideCollected}");
    }

    public bool[] AgentsConverted()
    {
        return agentsConverted;
    }

    public void AgentsConverted(bool[] b)
    {
        agentsConverted = b;
        Debug.Log($"AgentsCollected changed on {this} to {agentsConverted}");
    }
}
