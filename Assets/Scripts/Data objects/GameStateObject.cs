using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Statefiles/GameState")]
public class GameStateObject : ScriptableObject
{
    [SerializeField] private string previousLevel;
    [SerializeField] private string currentLevel;

    public string PreviousLevel {get; set;}
    public string CurrentLevel {get; set;}

}
