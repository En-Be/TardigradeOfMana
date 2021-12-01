using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        coroutine = WaitAndLoad();
        StartCoroutine(coroutine);   
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("demo_mana");
    }
}
