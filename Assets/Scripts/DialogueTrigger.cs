using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueObject[] dialogueObjects = null;
    [SerializeField] private CanvasManager canvas = null;


    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.tag == "Player")
        {
            // int i = LevelManager.Instance.currentStoryBeat;
            // LevelManager.Instance.ShowDialogue(dialogueObjects[i], i);
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        int i = LevelManager.Instance.CurrentStoryBeat();
        Debug.Log($"current story beat = {i}");

        try
        {
            canvas.ShowDialogue(dialogueObjects[i]);
            // LevelManager.Instance.ShowDialogue(dialogueObjects[i]);
        }
        catch
        {
            Debug.Log("no more dialogue now");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // LevelManager.Instance.StopDialogue();
            canvas.StopDialogue();
        }
    }
}
