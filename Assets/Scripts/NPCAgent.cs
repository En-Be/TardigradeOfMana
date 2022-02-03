using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAgent : ManaAgent
{
    [SerializeField] private bool pressing;
    [SerializeField] private float receiveRate = 0;
    [SerializeField] private PlayerAgent player = null;

    [SerializeField] private Sprite[] sprite = null;
    [SerializeField] private SpriteRenderer rend = null;
    [SerializeField] private Hazard hazard = null;

    protected override void Start()
    {

    }

    void Update()
    {
        if(pressing)
        {
            float manaFlow = receiveRate * Time.deltaTime;

            if(CurrentMana() != MaxMana())
            {   
                Debug.Log("pressing");
                player.AdjustMana(receiveRate * -1);
                AdjustMana(receiveRate);
            }

        }
    }

    public void PointerEnter()
    {
        if(Input.touches.Length == 1 && !GameManager.Instance.usingJoystick)
        {
            Debug.Log("one touch on a hazard");
            pressing = true;
        }
        else if(Input.touches.Length == 2 && GameManager.Instance.usingJoystick)
        {
            Debug.Log("a touch each on a hazard and joystick");
            pressing = true;
        }
    }

    public void PointerExit()
    {
        Debug.Log("Stop press");
        pressing = false;
    }

    protected override void AtMaxMana()
    {
        Debug.Log("NPC at max mana");
        rend.sprite = sprite[1];
        if(hazard != null)
        {
            hazard.IsHazard(false);
        }
    }
}
