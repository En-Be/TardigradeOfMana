using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

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

    void Start()
    {

    }



    public void ExitingLevel(string levelToLoad)
    {
        FadeOut();
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




    public int CurrentStoryBeat()
    {
        return currentStoryBeat;
    }

    public void StoryBeat(int i)
    {   

        if(i <= currentStoryBeat)
        {
            return;
        }
        else
        {
            currentStoryBeat = i;
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
