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
    public bool won;

    public bool usingJoystick;

    // Start is called before the first frame update

    void Start()
    {
        
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

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Win");
    }
}

