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
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject g = GameObject.FindWithTag("LevelManager");
        if(g != null)
        {
            levelState = g.GetComponent<LevelManager>().LevelState();
        }


        if(gameState.PreviousLevel() == null)
        {
            gameState.PreviousLevel(scene.name);
            gameState.CurrentLevel(scene.name);
            currentLevel = scene.name;
            previousLevel = scene.name;
            Debug.Log(scene.name);
        }

        if(scene.name != "Win" && scene.name != "Dead" && scene.name != currentLevel)
        {
            previousLevel = currentLevel;
            Debug.Log($"previous level set to {previousLevel}");
            currentLevel = scene.name;
            gameState.CurrentLevel(currentLevel);
            gameState.PreviousLevel(previousLevel);
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }




    // Update is called once per frame

    void Update()
    {

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

