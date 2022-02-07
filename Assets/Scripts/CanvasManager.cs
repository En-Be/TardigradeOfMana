using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{   
    [SerializeField] private Animator gobo = null;
    [SerializeField] private DialogueUI dialogueUI = null;

    // Start is called before the first frame update
    void Start()
    {
        FadeIn();
    }

    public void FadeIn()
    {
        gobo.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        gobo.SetTrigger("FadeOut");
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {   
        dialogueUI.ShowDialogue(dialogueObject);
    }

    public void StopDialogue()
    {
        dialogueUI.StopDialogue();
    }
}
