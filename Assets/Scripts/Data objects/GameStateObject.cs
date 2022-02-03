using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Statefiles/GameState")]
public class GameStateObject : ScriptableObject
{
    [SerializeField] private string previousLevel = null;
    [SerializeField] private string currentLevel = null;

    public string PreviousLevel()
    {
        return previousLevel;
    }

    public void PreviousLevel(string s)
    {
        previousLevel = s;
    }

    public string CurrentLevel()
    {
        return currentLevel;
    }

    public void CurrentLevel(string s)
    {
        currentLevel = s;
    }

    public void Reset()
    {
        previousLevel = null;
        currentLevel = null;
    }
}
