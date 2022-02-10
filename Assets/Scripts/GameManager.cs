using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables

    // public Player player;

    public bool usingJoystick;

    [SerializeField] private string previousLevel;
    [SerializeField] private string currentLevel;

    public string PreviousLevel => previousLevel;
    public string CurrentLevel => currentLevel;

    [SerializeField] private GameStateObject gameState = null;
    [SerializeField] private PlayerStateObject playerState = null;
    [SerializeField] private LevelStateObject levelState = null;

    private static GameManager instance;

    // Awake is called before start

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        levelState = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>().LevelState();

        ResetData();

        currentLevel = SceneManager.GetActiveScene().name;
        previousLevel = SceneManager.GetActiveScene().name;

        gameState.CurrentLevel(currentLevel);
        gameState.PreviousLevel(previousLevel);

    }

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject g = GameObject.FindWithTag("LevelManager");
        if(g != null)
        {
            levelState = g.GetComponent<LevelManager>().LevelState();
        }

        if(scene.name != "Win" && scene.name != "Dead")
        {
            bool b = (currentLevel == SceneManager.GetActiveScene().name);
            if(gameState.CurrentLevel() == null && gameState.PreviousLevel() == null)
            {
                previousLevel = SceneManager.GetActiveScene().name;
            } 
            else if(!b)
            {
                previousLevel = currentLevel;
                gameState.PreviousLevel(previousLevel);

            }
            currentLevel = SceneManager.GetActiveScene().name;
            gameState.CurrentLevel(currentLevel);
        }

    }

    void OnSceneUnloaded(Scene scene)
    {
        if(scene.name != "Win" && scene.name != "Dead")
        {   
            gameState.CurrentLevel(currentLevel);
            gameState.PreviousLevel(previousLevel);
            // Debug.Log("scene unloaded");
            // Debug.Log($"Previous level saved as{gameState.PreviousLevel()}");
            // Debug.Log($"Current level saved as {gameState.CurrentLevel()}");
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void Dead()
    {
        SceneManager.LoadScene("Dead");
    }

    public void ResetData()
    {
        gameState.Reset();
        playerState.Reset();
        levelState.Reset();
    }

}

