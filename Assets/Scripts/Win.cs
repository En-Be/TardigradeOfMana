﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("playerMana", 1);
        GameManager.Instance.previousLevel = ("Demo_001");
        GameManager.Instance.currentLevel = ("Demo_001");
        coroutine = WaitAndLoad();
        StartCoroutine(coroutine);   
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Demo_001");
    }
}
