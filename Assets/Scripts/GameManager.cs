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

    private static GameManager instance;

    // Awake is called before start

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        currentLevel = SceneManager.GetActiveScene().name;
        previousLevel = SceneManager.GetActiveScene().name;

        gameState.CurrentLevel = currentLevel;
        gameState.PreviousLevel = previousLevel;

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
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("playerMana", 1);
        // Debug.Log("set pref to 1");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name != "Win" && scene.name != "Dead" && scene.name != currentLevel)
        {
            previousLevel = currentLevel;
            currentLevel = scene.name;
            gameState.CurrentLevel = currentLevel;
            gameState.PreviousLevel = previousLevel;
            Debug.Log($"gamestate previous level is {gameState.PreviousLevel}");
            Debug.Log($"gamestate current level is {gameState.CurrentLevel}");

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

    public void Reset()
    {
        gameState.CurrentLevel = "";
        gameState.CurrentLevel = "";
    }

}

