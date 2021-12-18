using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    public Player player;
    public Canvas canvas;
    public CameraFollow cam;

    public Transform[] spawnpoints;
    public string[] spawnFrom;
    
    public Animator anim;

    public int hazardsToConvert;
    public int hazardsConverted;
    public bool won;

    // Start is called before the first frame update
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
        StartingLevel();
    }

    public void StartingLevel()
    {
        anim = canvas.GetComponentInChildren<Animator>();
        FadeIn();
        player.gameObject.transform.position = spawnpoints[System.Array.IndexOf(spawnFrom, GameManager.Instance.previousLevel)].position;
        cam.SnapTo();
    }

    public void ExitingLevel(string levelToLoad)
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

    // Update is called once per frame
    void Update()
    {   
        if(hazardsToConvert != 0)
        {
            if(hazardsConverted == hazardsToConvert && !won)
            {
                StartCoroutine("Win");
                won = true;
            }
        }
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Win");
    }
}
