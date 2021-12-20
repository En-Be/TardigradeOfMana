using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueObject dialogueObject;

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("player hit");
            Debug.Log($"level manager instance = {LevelManager.Instance}");
            LevelManager.Instance.ShowDialogue(dialogueObject);
        }
    }
}
