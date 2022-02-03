using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

//     public Player player;
//     public Canvas canvas;
//     public CameraFollow cam;
    public DialogueUI dialogueUI;
    public DialogueTrigger dialogueTrigger;
//     public Animator anim;
    public GameObject guide;
//     public Transform[] spawnpoints;
//     public string[] spawnFrom;
    

    public int currentStoryBeat;


//     // Start is called before the first frame update
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

//     void Start()
//     {
//         StartingLevel();
//     }

//     public void StartingLevel()
//     {
//         // anim = canvas.GetComponentInChildren<Animator>();
//         // dialogueUI = canvas.GetComponentInChildren<DialogueUI>();

//         FadeIn();
//         player.gameObject.transform.position = spawnpoints[System.Array.IndexOf(spawnFrom, GameManager.Instance.previousLevel)].position;
//         // if(PlayerPrefs.GetFloat("playerMana") == 0)
//         // {
//         //     PlayerPrefs.SetFloat("playerMana", 1.0f);
//         // }

//         LoadPrefs();
//         // player.mana = PlayerPrefs.GetFloat("playerMana");
//         cam.SnapTo();
//     }

    public void ExitingLevel(string levelToLoad)
    {
        // FadeOut();
        StartCoroutine("Load", levelToLoad);
    }

    private IEnumerator Load(string levelToLoad)
    {
        yield return new WaitForSeconds(0.5f);
        // SavePrefs();
        SceneManager.LoadScene(levelToLoad);
    }

//     public void FadeIn()
//     {
//         anim.SetTrigger("FadeIn");
//     }

//     public void FadeOut()
//     {
//         anim.SetTrigger("FadeOut");
//     }

//     // Update is called once per frame
//     void Update()
//     {   
//         // Debug.Log($"level player mana = {player.mana}");
//         if(hazardsToConvert != 0)
//         {
//             if(hazardsConverted == hazardsToConvert && !won)
//             {
//                 StartCoroutine("Win");
//                 won = true;
//             }
//         }
//     }

//     private IEnumerator Win()
//     {
//         yield return new WaitForSeconds(1.0f);
//         SceneManager.LoadScene("Win");
//     }

//     private void SavePrefs()
//     {
//         PlayerPrefs.SetFloat("playerMana", player.mana);
//         PlayerPrefs.SetInt($"{SceneManager.GetActiveScene().name}_storyBeat", currentStoryBeat);
//     }
//     private void LoadPrefs()
//     {
//         player.SetMana(PlayerPrefs.GetFloat("playerMana"));
//         currentStoryBeat = PlayerPrefs.GetInt($"{SceneManager.GetActiveScene().name}_storyBeat");
//     }

    public void ShowDialogue(DialogueObject dialogueObject)
    {   
        // Debug.Log($"dialogueUI = {dialogueUI}");
        // Debug.Log($"dialogueobject = {dialogueObject}");
        dialogueUI.ShowDialogue(dialogueObject);
    }

    public void StopDialogue()
    {
        dialogueUI.StopDialogue();
    }

    public void StoryBeat(int i)
    {   

        // Debug.Log(i);
        // Debug.Log(currentStoryBeat);

        if(i <= currentStoryBeat)
        {
            return;
        }
        else
        {
            currentStoryBeat = i;
        }

        switch (SceneManager.GetActiveScene().name)
        {


            case "Demo_004":
                switch(currentStoryBeat)
                {
                    case 2:
                        dialogueTrigger.TriggerDialogue();
                        guide.GetComponent<Guide>().enabled = true;
                        break;
                    
                    case 3:
                        Debug.Log("open the wall");
                        break;

                    default:
                        break;
                }
                break;

            default:
                // print ("No story beat this level.");
                break;
        }
    }
}
