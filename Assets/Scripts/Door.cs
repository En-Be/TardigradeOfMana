using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.ExitingScene();
            StartCoroutine("Load");
        }
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelToLoad);
    }
}
