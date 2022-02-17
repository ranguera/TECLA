using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEngine : MonoBehaviour
{
    public static AudioEngine Instance;

    public AudioClip start;
    public AudioClip hit;
    public AudioClip question;
    public AudioClip answer;

    public enum Sound
    {
        Start,
        Hit,
        Question,
        Answer
    }

    private AudioSource asrc;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    void Start()
    {
        this.asrc = GetComponent<AudioSource>();
    }

    public void Play(Sound sound)
    {
        if (!this.asrc.isPlaying)
        {
            switch (sound)
            {
                case Sound.Start:
                    this.asrc.PlayOneShot(this.start);
                    break;
                case Sound.Hit:
                    this.asrc.PlayOneShot(this.hit);
                    break;
                case Sound.Question:
                    this.asrc.PlayOneShot(this.question);
                    break;
                case Sound.Answer:
                    this.asrc.PlayOneShot(this.answer);
                    break;
                default:
                    break;
            }
        }
    }
}
