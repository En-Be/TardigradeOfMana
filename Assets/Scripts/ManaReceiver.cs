using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaReceiver : MonoBehaviour
{
    public GameManager gameManager;
    public float mana;
    public float manaMax;
    public float manaRate;
    public GameObject textTarget;
    public TextMesh text;
    public bool getting = false;
    public Player player;
    public Sprite sprite;
    public SpriteRenderer rend;
    public ManaEmitter emitter;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        emitter = GetComponent<ManaEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.touches.Length);

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
            rend.sprite = sprite;
            Hazard hazard = GetComponent<Hazard>();
            if (hazard.isHazard)
            {
                emitter.Emit();
                // gameManager.friendlies +=1;
            }
            hazard.isHazard = false;
        }

        mana = Mathf.Clamp(mana, 0, manaMax);
        text.text = mana.ToString("F0");
    }

    public void GetMana()
    {
        if(Input.touches.Length == 1 && !gameManager.usingJoystick)
        {
            Debug.Log("one touch on a hazard");
            Debug.Log("get");
            player.giving = true;
            getting = true;
        }
        else if(Input.touches.Length == 2 && gameManager.usingJoystick)
        {
            Debug.Log("a touch each on a hazard and joystick");
            Debug.Log("get");
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
