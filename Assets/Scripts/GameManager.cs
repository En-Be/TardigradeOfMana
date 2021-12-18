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

    public string previousLevel;
    public string currentLevel;

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
        previousLevel = currentLevel;
        currentLevel = scene.name;
        // FindManagers();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }




    // Update is called once per frame

    void Update()
    {


    }

    // private void FindManagers()
    // {
    //     GameObject l_Manager = GameObject.FindGameObjectWithTag("LevelManager");
    //     if (l_Manager != null)
    //     {
    //         levelManager = l_Manager.GetComponent<LevelManager>();
    //     }
    // }

    public void Dead()
    {
        SceneManager.LoadScene("Dead");
    }

}

