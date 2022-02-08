using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerAgent : ManaAgent
{
    [SerializeField] private PlayerStateObject playerState = null;

    [SerializeField] private Text text = null;
    [SerializeField] private GameObject prefabGuide = null;
    [SerializeField] private GameObject[] guides = null;
    [SerializeField] private int numberOfGuides = 0;

    private Animator anim;

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        if(anim == null)
        {
            throw new Exception("player has no animator");
        }

        LoadState();
        DisplayMana();
        SetGuides();
    }

    protected override void ManaAdjusted(float v)
    {
        if(text != null)
        {
            DisplayMana();
        }

        if(v > 0)
        {
            Debug.Log($"player gained {v} mana");
            anim.SetTrigger("Healed");
        }
        else
        {
            Debug.Log($"player lost {v * -1} mana");
            anim.SetTrigger("Damaged");
        }
    }

    protected override void AtMaxMana()
    {
        base.AtMaxMana();
        Debug.Log("Player at max mana");
    }

    protected override void AtMinMana()
    {
        Debug.Log("Player at min mana");
        GameManager.Instance.Dead();
    }

    private void SaveState()
    {
        playerState.CurrentMana(CurrentMana());
        playerState.MaxMana(MaxMana());
        playerState.NumberOfGuides(numberOfGuides);
    }

    private void LoadState()
    {
        CurrentMana(playerState.CurrentMana());
        MaxMana(playerState.MaxMana());
        numberOfGuides = (playerState.NumberOfGuides());
    }

    private void DisplayMana()
    {
        text.text = $"{CurrentMana().ToString("F0")} of {MaxMana()}";
    }

    private void OnDisable()
    {
        if(CurrentMana() > 0)
        {
            SaveState();
        }
    }

    private void SetGuides()
    {
        // if(guides.Length == numberOfGuides)
        // {
            guides = new GameObject[numberOfGuides];
            for(int i = 0; i < numberOfGuides; i++)
            {
                GameObject g = Instantiate(prefabGuide, transform.position,transform.rotation);
                guides[i] = g;
                GuideFriend guide = g.GetComponent<GuideFriend>();
                guide.SetTarget(transform);
                // NPCAgent npc = g.GetComponent<NPCAgent>();
                // npc.SetPlayer(this);
            }
        // }
    }

    public int NumberOfGuides()
    {
        return numberOfGuides;
    }

    public void IncreaseNumberOfGuides()
    {
        numberOfGuides ++;
        MaxMana(10 + (numberOfGuides * 10));
        CurrentMana(MaxMana());
        DisplayMana();
    }

    public void DecreaseNumberOfGuides()
    {
        numberOfGuides --;
    }
}
