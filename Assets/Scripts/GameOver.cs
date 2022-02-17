using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject tryAgainButton;
    public GameObject congrats;
    public TextMeshProUGUI score;
    public TextMeshProUGUI title1;
    public TextMeshProUGUI title2;

    void Start()
    {
        score.text = Questions.Instance.score.ToString();

        if(Questions.Instance.finished)
        {
            tryAgainButton.SetActive(false);
            congrats.SetActive(true);
            title1.text = "FELICITATS!";
            title2.text = "FELICITATS!";
        }
        else
        {
            tryAgainButton.SetActive(true);
            congrats.SetActive(false);
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Intro");
    }
}
