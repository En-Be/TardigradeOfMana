using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueConditions : MonoBehaviour
{
    public DialogueObject[] dialogueObjects;

    public DialogueObject ChooseDialogue(GameObject other)
    {
        Player player = other.GetComponent<Player>();

        if(player.mana < player.manaMax)
        {
            return dialogueObjects[0];
        }
        else
        {
            return dialogueObjects[1];
        }
    }

    public DialogueObject ChooseDialogue(int i)
    {
        return dialogueObjects[i];
    }
}
