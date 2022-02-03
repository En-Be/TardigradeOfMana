using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables

    // public Player player;
    // public LevelManager levelManager;

    public bool usingJoystick;

    [SerializeField] private string previousLevel;
    [SerializeField] private string currentLevel;

    public string PreviousLevel => previousLevel;
    public string CurrentLevel => currentLevel;

    [SerializeField] private GameStateObject gameState = null;
    [SerializeField] private PlayerStateObject playerState = null;

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
        if(scene.name != "Win" && scene.name != "Dead" && scene.name != currentLevel)
        {
            previousLevel = currentLevel;
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
    }

}

