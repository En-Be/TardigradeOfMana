using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaReceiver : MonoBehaviour
{
    public float mana;
    public float manaMax;
    public float manaRate;
    public bool getting = false;
    public Player player;
    public Sprite[] sprite;
    public SpriteRenderer rend;

    // public Text text;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float manaFlow = manaRate * Time.deltaTime;

        if(getting && mana < manaMax)
        {
            mana += manaFlow;
            player.mana -= manaFlow;
        }

        if(!getting && mana < manaMax && mana > 0)
        {
            mana -= manaFlow;
        }

        if(mana == manaMax)
        {
            rend.sprite = sprite[1];
            Hazard hazard = GetComponent<Hazard>();
            if (hazard != null)
            {   
                if(hazard.isHazard)
                {
                    // emitter.Emit();
                    LevelManager.Instance.hazardsConverted +=1;
                    hazard.isHazard = false;

                }
            }
        }

        mana = Mathf.Clamp(mana, 0, manaMax);
        // text.text = $"{mana.ToString("F0")} of {manaMax}";
    }

    public void GetMana()
    {
        if(Input.touches.Length == 1 && !GameManager.Instance.usingJoystick)
        {
            Debug.Log("one touch on a hazard");
            player.giving = true;
            getting = true;
        }
        else if(Input.touches.Length == 2 && GameManager.Instance.usingJoystick)
        {
            Debug.Log("a touch each on a hazard and joystick");
            player.giving = true;
            getting = true;
        }

    }

    public void StopGettingMana()
    {
        Debug.Log("stop");
        player.giving = false;
        getting = false;
    }
}
