using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float mana;
    public float manaMax;
    public float manaReceiveRate;
    public bool giving;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
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
            SceneManager.LoadScene("Dead");
        }

        mana = Mathf.Clamp(mana, 0, manaMax);
        text.text = mana.ToString("F0");
    }
}
