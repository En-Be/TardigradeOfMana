using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables

    // public Player player;
    // public LevelManager levelManager;

    public int hazardsToConvert;
    public int hazardsConverted;
    public bool won;

    public bool usingJoystick;

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
    }

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    // void OnEnable()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }

    // void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     Debug.Log("OnSceneLoaded: " + scene.name);
    //     FindManagers();
    //     LevelManager.Instance.GameSaysHi();

    // }

    // void OnDisable()
    // {
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }




    // Update is called once per frame

    void Update()
    {
        if(hazardsConverted == hazardsToConvert && !won)
        {
            StartCoroutine("Win");
            won = true;
        }

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


    private IEnumerator Win()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Win");
    }



}

