using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueObject dialogueObject;
    public DialogueConditions dialogueConditions;

    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.tag == "Player")
        {
            if(dialogueConditions != null)
            {
                dialogueObject = dialogueConditions.ChooseDialogue(other.gameObject);
            }

            LevelManager.Instance.ShowDialogue(dialogueObject);
        }
    }

    public void TriggerDialogue(int i)
    {
        dialogueObject = dialogueConditions.ChooseDialogue(i);
        LevelManager.Instance.ShowDialogue(dialogueObject);
    }
}
