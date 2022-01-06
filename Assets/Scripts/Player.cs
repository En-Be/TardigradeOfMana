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
            mana += manaFlow;
        }
        
        if(mana < 1)
        {
            GameManager.Instance.Dead();
        }

        mana = Mathf.Clamp(mana, 0, manaMax);
        text.text = $"{mana.ToString("F0")} of {manaMax}";
    }

    public void Damaged(float damage)
    {
        mana -= damage;
        anim.SetTrigger("Damaged");
    }

    public void Healed(float heal)
    {
        mana += heal;
        anim.SetTrigger("Healed");
    }
}
