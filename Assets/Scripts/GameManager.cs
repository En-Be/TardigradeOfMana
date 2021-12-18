﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables

    public Player player;
    
    public int hazardsToConvert;
    public int hazardsConverted;
    public bool won;

    public bool usingJoystick;

    public Animator anim;

    private static GameManager instance;

    // Awake is called before start

    void Awake()
    {
        instance = this;
        FadeIn();
    }

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    // Update is called once per frame

    void Update()
    {
        if(hazardsConverted == hazardsToConvert && !won)
        {
            StartCoroutine("Win");
            won = true;
        }

    }

    public void Dead()
    {
        SceneManager.LoadScene("Dead");
    }

    public void ExitingScene(string levelToLoad)
    {
        anim.SetTrigger("FadeOut");
        StartCoroutine("Load", levelToLoad);
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Win");
    }

    public void FadeIn()
    {
        anim.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        anim.SetTrigger("FadeOut");
    }

    private IEnumerator Load(string levelToLoad)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelToLoad);
    }
}

