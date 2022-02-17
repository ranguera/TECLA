using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class Questions : MonoBehaviour
{
    public static Questions Instance;

    [HideInInspector]
    public string userID;

    [HideInInspector]
    public int score;

    [HideInInspector]
    public List<Question> questions;

    [HideInInspector]
    public List<string> userAnswers;

    [HideInInspector]
    public List<float> userTimes;

    private int questionIndex;

    [HideInInspector]
    public DateTime startTime;

    [HideInInspector]
    public DateTime endTime;

    [HideInInspector]
    public bool finished;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    void Start()
    {
        TextAsset ta = Resources.Load("preguntes") as TextAsset;
        this.questions = new List<Question>();
        this.startTime = DateTime.Now;

        string[] tmp = ta.text.Split('\n');
        for (int i = 0; i < tmp.Length; i++)
        {
            string[] fields = tmp[i].Split(',');
            Question q = new Question();
            q.question = fields[0];
            q.answer = fields[1];

            for (int j = 1; j < fields.Length; j++)
            {
                q.options.Add(fields[j]);
            }

            this.questions.Add(q);
            this.userAnswers.Add("");
            this.userTimes.Add(-1f);
        }

        var rnd = new System.Random();
        questions = questions.OrderBy(item => rnd.Next()).ToList<Question>();

        for (int i = 0; i < this.questions.Count; i++)
        {
            questions[i].options = questions[i].options.OrderBy(item => rnd.Next()).ToList<string>();
        }

        for (int i = 0; i < this.questions.Count; i++)
        {
            print(this.questions[i]);
        }
    }

    public Question GetCurrentQuestion()
    {
        return this.questions[this.questionIndex];
    }

    public void NextQuestion()
    {
        this.questionIndex++;
        if (this.questionIndex >= this.questions.Count)
        {
            this.endTime = DateTime.Now;
            this.finished = true;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void AddAnswer(string _answer)
    {
        this.userAnswers[this.questionIndex] = _answer;
    }

    public void AddTime(float _t)
    {
        this.userTimes[this.questionIndex] = _t;
    }
}

public class Question
{
    public string question;
    public string answer;
    public List<string> options;

    public Question()
    {
        this.question = "";
        this.answer = "";
        this.options = new List<string>();
    }

    public override string ToString()
    {
        string s = this.question + System.Environment.NewLine +
            this.answer + System.Environment.NewLine;

        for (int i = 0; i < this.options.Count; i++)
        {
            s += this.options[i] + System.Environment.NewLine;
        }

        return s;
    }
}
