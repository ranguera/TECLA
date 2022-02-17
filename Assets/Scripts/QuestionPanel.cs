using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionPanel : MonoBehaviour
{
    public Score score;
    public GameObject panel;
    public TextMeshProUGUI question;
    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;
    public TextMeshProUGUI option4;

    private float answerTime;

    public void LoadCurrentQuestion()
    {
        this.panel.SetActive(true);
        this.score.Pause();

        Question q = Questions.Instance.GetCurrentQuestion();
        this.question.text = q.question;
        this.option1.text = q.options[0] != null ? q.options[0] : "";
        this.option2.text = q.options[1] != null ? q.options[1] : "";
        this.option3.text = q.options[2] != null ? q.options[2] : "";
        this.option4.text = q.options[3] != null ? q.options[3] : "";

        this.answerTime = Time.time;
    }

    public void ButtonClick(int num)
    {
        Question q = Questions.Instance.GetCurrentQuestion();
        Questions.Instance.AddAnswer(q.options[num]);
        Questions.Instance.AddTime(Time.time - answerTime);

        if ( q.options[num] == q.answer )
        {
            Questions.Instance.score = this.score.score;
            this.score.Resume();
            this.panel.SetActive(false);
            GameControl.Instance.HideQuestion();
            Questions.Instance.NextQuestion();
        }
        else
        {
            SceneManager.LoadScene("GameOver");

            //Questions.Instance.score = this.score.score;
            //this.score.Resume();
            //this.panel.SetActive(false);
            //GameControl.Instance.HideQuestion();
        }
        
    }
}
