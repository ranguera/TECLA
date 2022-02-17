using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour
{
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSf0QBTX7FNH5pqW7XKVE_mXcDstcfkJqxrqC8zdZwsaNSR8VQ/formResponse";

    IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.826223488", Questions.Instance.userID); // inicials
        form.AddField("entry.979022914", ""); // grup classe
        form.AddField("entry.2082708030", Questions.Instance.startTime.ToString("yyyy-MM-dd__HH:mm:ss")); // hora inici
        form.AddField("entry.1168266524", Questions.Instance.endTime.ToString("yyyy-MM-dd__HH:mm:ss")); // hora fi
        
        form.AddField("entry.1679845199", Questions.Instance.questions[0].question); // p1
        form.AddField("entry.1532841224", Questions.Instance.userAnswers[0]); // r1
        form.AddField("entry.322240264", Questions.Instance.userTimes[0].ToString("F2")); // t1

        form.AddField("entry.1736222609", Questions.Instance.questions[1].question); // p2
        form.AddField("entry.1382300238", Questions.Instance.userAnswers[1]); // r2
        form.AddField("entry.1353351306", Questions.Instance.userTimes[1].ToString("F2")); // t2

        form.AddField("entry.308031473", Questions.Instance.questions[2].question); // p3
        form.AddField("entry.938832308", Questions.Instance.userAnswers[2]); // r3
        form.AddField("entry.1560903232", Questions.Instance.userTimes[2].ToString("F2")); // t3

        form.AddField("entry.2020643701", Questions.Instance.questions[3].question); // p4
        form.AddField("entry.2103664202", Questions.Instance.userAnswers[3]); // r4
        form.AddField("entry.229746625", Questions.Instance.userTimes[3].ToString("F2")); // t4

        form.AddField("entry.1493831420", Questions.Instance.questions[4].question); // p5
        form.AddField("entry.244216595", Questions.Instance.userAnswers[4]); // r5
        form.AddField("entry.1537938513", Questions.Instance.userTimes[4].ToString("F2")); // t5

        form.AddField("entry.690270960", Questions.Instance.score.ToString()); // score
        form.AddField("entry.2034261630", ""); // carnet
        /*
        ** Outdated
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
        */
        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
    public void Start()
    {
        StartCoroutine(Post());

    }
}