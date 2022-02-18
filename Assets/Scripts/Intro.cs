using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Intro : MonoBehaviour
{
    public TMP_InputField initials;

    public TextMeshProUGUI title1, title2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (initials.text != string.Empty)
            {
                Questions.Instance.userID = initials.text;
                AudioEngine.Instance.Play(AudioEngine.Sound.Start);
                StartCoroutine(DelayedStart());
            }
            else
            {

            }
        }

        title2.characterSpacing = title1.characterSpacing = Mathf.PingPong(Time.time*4f, 50f);
    }

    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(2f);        
        SceneManager.LoadScene("Game");
    }
}
