using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float mana;
    public float manaMax;
    public float manaReceiveRate;
    public bool giving;

    public Text text;

    private Animator anim;

    public delegate void ManaChanged();
    public static event ManaChanged AtMaxMana;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float manaFlow = manaReceiveRate * Time.deltaTime;

        if(mana < manaMax && !giving)
        {
            // ManaAdjust(manaFlow);
        }
        
    }

    public void SetMana(float f)
    {
        mana = f;
        text.text = $"{mana.ToString("F0")} of {manaMax}";
    }

    public void ManaAdjust(float f)
    {
        mana += f;

        if(f > 0)
        {
            anim.SetTrigger("Healed");
        }
        else
        {
            anim.SetTrigger("Damaged");
        }

        mana = Mathf.Clamp(mana, 0, manaMax);

        if(mana >= manaMax)
        {
            if(AtMaxMana != null)
            {
                AtMaxMana();
            }
        }
        else if(mana <= 0)
        {
            GameManager.Instance.Dead();
        }

        text.text = $"{mana.ToString("F0")} of {manaMax}";

    }
}
