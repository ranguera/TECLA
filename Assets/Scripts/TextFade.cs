using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    private TextMeshProUGUI t;
    private Color c;

    void Start()
    {
        t = GetComponent<TextMeshProUGUI>();
        c = t.color;
    }

    void Update()
    {
        c.a = Mathf.PingPong(Time.time, 1f);
        t.color = c; 
    }
}
