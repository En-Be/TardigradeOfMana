using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueUI : MonoBehaviour
{
    public TMP_Text textBox;

    void Start()
    {
        GetComponent<Typewriter>().Run("lalalalalla\nhahahahahahahahaha\ndoodoodoododododoodoodooooo", textBox);
    }
}
