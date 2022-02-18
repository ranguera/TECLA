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

    public AudioClip gameover;
    public AudioClip win;
    public AudioSource asrc;

    void Start()
    {
        score.text = Questions.Instance.score.ToString();

        if(Questions.Instance.finished)
        {
            tryAgainButton.SetActive(false);
            congrats.SetActive(true);
            title1.text = "FELICITATS!";
            title2.text = "FELICITATS!";
            asrc.clip = win;
            asrc.Play();
        }
        else
        {
            tryAgainButton.SetActive(true);
            congrats.SetActive(false);
            asrc.clip = gameover;
            asrc.Play();
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Intro");
    }
}
