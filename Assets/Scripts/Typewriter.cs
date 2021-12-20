using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typewriter : MonoBehaviour
{
    public float speed;

    public void Run(string textToType, TMP_Text textBox )
    {
        StartCoroutine(TypeText(textToType, textBox));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textBox)
    {
        textBox.text = string.Empty;
        yield return new WaitForSeconds(1);
        
        float t = 0;
        int charIndex = 0;

        while(charIndex < textToType.Length)
        {
            t += Time.deltaTime * speed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            textBox.text = textToType.Substring(0, charIndex);
            yield return null;
        }
    }
}
