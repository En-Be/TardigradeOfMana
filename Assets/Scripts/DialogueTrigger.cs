using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueObject[] dialogueObjects;

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
        int i = LevelManager.Instance.currentStoryBeat;
        try
        {
            LevelManager.Instance.ShowDialogue(dialogueObjects[i]);
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
            LevelManager.Instance.StopDialogue();
        }
    }
}
