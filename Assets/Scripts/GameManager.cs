using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables

    public Player player;
    
    public int hazardsToConvert;

    public int hazardsConverted;
    public bool usingJoystick;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        if(hazardsConverted == hazardsToConvert)
        {
            SceneManager.LoadScene("Win");
        }

        if(player.mana == player.manaMax)
        {
            SceneManager.LoadScene("Win");
        }
    }

}

