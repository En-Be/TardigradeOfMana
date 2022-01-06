using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Demo_004_events : MonoBehaviour
{

    void OnEnable()
    {
        Player.AtMaxMana += Beat01;
        ManaReceiver.AtMaxMana += Beat02;
        DialogueUI.DialogueFinished += Beat03;
    }

    void Beat01()
    {
        LevelManager.Instance.StoryBeat(1);
        Player.AtMaxMana -= Beat01;
    }

    void Beat02()
    {
        LevelManager.Instance.StoryBeat(2);
        ManaReceiver.AtMaxMana -= Beat02;
    }

    void Beat03(int i)
    {
        Debug.Log($"Dialogue object index = {i}");
        if(i == 2)
        {
            LevelManager.Instance.StoryBeat(3);
            DialogueUI.DialogueFinished -= Beat03;
        }
    }

    void OnDisable()
    {
        Player.AtMaxMana -= Beat01;
        ManaReceiver.AtMaxMana -= Beat02;
        DialogueUI.DialogueFinished -= Beat03;
    }

}
