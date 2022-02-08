using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCAgent : ManaAgent, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private bool pressing;
    [SerializeField] private float receiveRate = 0;
    [SerializeField] private PlayerAgent player = null;

    [SerializeField] private Hazard hazard = null;
    [SerializeField] private Friend friend = null;



    protected override void Start()
    {
        hazard = GetComponent<Hazard>();
        friend = GetComponent<Friend>();
    }

    void Update()
    {
        // Debug.Log($"touches = {Input.touches.Length}");

        if(pressing)
        {
            float manaFlow = receiveRate * Time.deltaTime;

            if(CurrentMana() != MaxMana())
            {   
                player.AdjustMana(receiveRate * -1);
                AdjustMana(receiveRate);
                // Trigger change in hazard or friend
            }

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("touching");
        Debug.Log($"touches = {Input.touches.Length}");
        Debug.Log($"using joystick = {GameManager.Instance.usingJoystick}");

        if(!GameManager.Instance.usingJoystick)
        {
            Debug.Log("one touch on an agent");
            pressing = true;
        }
        else if(Input.touches.Length >= 2 && GameManager.Instance.usingJoystick)
        {
            Debug.Log("a touch each on an agent and joystick");
            pressing = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Stop touching");
        pressing = false;
    }

    protected override void AtMaxMana()
    {
        Debug.Log("NPC at max mana");
        base.AtMaxMana();
        if(hazard != null)
        {
            hazard.IsHazard(false);
        }
        
        if(friend != null)
        {
            Debug.Log("friend isn't null");
            // friend.IsFriend(true);
            friend.enabled = true;
            this.enabled = false;
        }
    }

    public void SetPlayer(PlayerAgent p)
    {
        player = p;
    }
}
