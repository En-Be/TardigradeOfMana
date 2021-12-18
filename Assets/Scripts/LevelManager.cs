using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    public Player player;
    public Canvas canvas;

    public Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        anim = canvas.GetComponentInChildren<Animator>();
        FadeIn();
    }

    public static LevelManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void ExitingScene(string levelToLoad)
    {
        FadeOut();
        StartCoroutine("Load", levelToLoad);
    }

    private IEnumerator Load(string levelToLoad)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelToLoad);
    }

    public void FadeIn()
    {
        anim.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        anim.SetTrigger("FadeOut");
    }

    public void GameSaysHi()
    {
        Debug.Log("GameSaysHi");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
