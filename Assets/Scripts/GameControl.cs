using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;

    public GameObject spaceship;
    public GameObject enemySpawner;
    public QuestionPanel questionPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowQuestion()
    {
        this.spaceship.SetActive(false);
        this.enemySpawner.SetActive(false);
        this.questionPanel.LoadCurrentQuestion();
    }

    public void HideQuestion()
    {
        this.spaceship.SetActive(true);
        this.enemySpawner.SetActive(true);
    }
}
