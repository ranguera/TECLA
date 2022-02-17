using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [HideInInspector]
    public int score;

    private TextMeshProUGUI scoreText;
    private bool pause;
    private float t;

    void Start()
    {
        this.scoreText = GetComponent<TextMeshProUGUI>();
        this.t = 0f;
    }

    void Update()
    {
        if (!pause)
            t += Time.deltaTime;

        this.score = Mathf.RoundToInt(t * 10f);
        scoreText.text = "Punts: " + this.score;
    }

    public void Pause()
    {
        this.pause = true;
    }

    public void Resume()
    {
        this.pause = false;
    }
}
