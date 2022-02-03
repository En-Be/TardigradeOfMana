using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueUI : MonoBehaviour
{
    public TMP_Text textBox;
    public GameObject dialogueBox;
    public bool tapped;
    private Typewriter typewriter;

    public delegate void DialogueDisplayed(int i);
    public static event DialogueDisplayed DialogueFinished;

    void Start()
    {
        typewriter = GetComponent<Typewriter>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        CloseDialogueBox();
        // Debug.Log("gets to show dialogue");
        if(!dialogueBox.activeInHierarchy)
        {
            // Debug.Log($"dialogue box = {dialogueBox}");
            dialogueBox.SetActive(true);
            StartCoroutine(StepThroughDialogue(dialogueObject));
        }
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriter.Run(dialogue, textBox);
            yield return new WaitUntil(() => tapped);
            yield return new WaitForSeconds(0.5f);
            tapped = false;
        }

        if(DialogueFinished != null)
        {
            DialogueFinished(LevelManager.Instance.CurrentStoryBeat());
        }

        CloseDialogueBox();
    }

    public void StopDialogue()
    {
        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textBox.text = string.Empty;
    }

    public void Tapped()
    {
        tapped = true;
    }
}
