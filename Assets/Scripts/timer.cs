using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private Text text;
    private float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        elapsed = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (Time.time - elapsed).ToString("F2");
    }
}
