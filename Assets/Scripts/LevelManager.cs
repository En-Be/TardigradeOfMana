using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    [SerializeField] private LevelStateObject levelState = null;
    [SerializeField] private GameObject guide = null;
    [SerializeField] private bool guideCollected = false;
    [SerializeField] private GameObject[] agentsToConvert = null;
    [SerializeField] private bool[] agentsConverted = null;
    
    [SerializeField] private CanvasManager canvas = null;

    [SerializeField] private int currentStoryBeat = 0;
    [SerializeField] UnityEvent StoryBeat0 = null;
    [SerializeField] UnityEvent StoryBeat1 = null;
    [SerializeField] UnityEvent StoryBeat2 = null;
    [SerializeField] UnityEvent StoryBeat3 = null;
    [SerializeField] UnityEvent StoryBeat4 = null;


    void Awake()
    {
        instance = this;
    }

    public static LevelManager Instance
    {
        get
        {
            return instance;
        }
    }

    public LevelStateObject LevelState()
    {
        return levelState;
    }

    public void SetLevelState(LevelStateObject l)
    {
        levelState = l;
    }

    void Start()
    {
        LoadState();
        if(guideCollected == true)
        {
            Destroy(guide);
        }
    }

    private void LoadState()
    {  
        Debug.Log($"loading state of {levelState}");
        currentStoryBeat = levelState.CurrentStoryBeat();
        // Debug.Log($"{levelState} story beat loaded as {levelState.CurrentStoryBeat()}");
        guideCollected = levelState.GuideCollected();
        // Debug.Log($"{levelState} guide collected loaded as {levelState.GuideCollected()}");
        agentsConverted = levelState.AgentsConverted();
        // Debug.Log($"{levelState} agents converted loaded as {levelState.AgentsConverted()}");
    }

    private void SaveState()
    {
        // Debug.Log($"saving state of {levelState}");
        levelState.CurrentStoryBeat(currentStoryBeat);
        // Debug.Log($"{levelState} story beat saved as {levelState.CurrentStoryBeat()}");
        levelState.GuideCollected(guideCollected);
        // Debug.Log($"{levelState} guide collected saved as {levelState.GuideCollected()}");
        levelState.AgentsConverted(agentsConverted);
        // Debug.Log($"{levelState} agents converted saved as {levelState.AgentsConverted()}");

    }

    public void ExitingLevel(string levelToLoad)
    {
        FadeOut();
        SaveState();
        StartCoroutine("Load", levelToLoad);
    }

    public void FadeOut()
    {
        canvas.FadeOut();
    }

    private IEnumerator Load(string levelToLoad)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelToLoad);
    }

    public void CollectGuide()
    {
        guideCollected = true;
    }

    public int CurrentStoryBeat()
    {
        return currentStoryBeat;
    }

    public void StoryBeat(int i)
    {   

        if(i == currentStoryBeat + 1)
        {
            currentStoryBeat = i;
        }
        else
        {
            return;
        }

        Debug.Log($"Current story beat is now {currentStoryBeat}");

        switch (currentStoryBeat)
        {
            case 0:
                StoryBeat0.Invoke();
                break;
            case 1:
                StoryBeat1.Invoke();
                break;
            case 2:
                StoryBeat2.Invoke();
                break;
            case 3:
                StoryBeat3.Invoke();
                break;
            case 4:
                StoryBeat4.Invoke();
                break;
            default:
                print ("No story beat this level.");
                break;
        }
    }
}
