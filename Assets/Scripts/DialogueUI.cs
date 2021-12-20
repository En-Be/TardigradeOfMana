using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueUI : MonoBehaviour
{
    public TMP_Text textBox;
    [SerializeField] private GameObject dialogueBox;
    public bool tapped;
    private Typewriter typewriter;

    void Start()
    {
        typewriter = GetComponent<Typewriter>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        Debug.Log("gets to show dialogue");
        if(!dialogueBox.activeInHierarchy)
        {
            Debug.Log($"dialogue box = {dialogueBox}");
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
            tapped = false;
        }

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
