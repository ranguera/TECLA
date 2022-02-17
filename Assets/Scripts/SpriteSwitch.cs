using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitch : MonoBehaviour
{
    public Sprite[] sprites;
    public float cycleDuration;

    private Image img;
    private float delta;
    private float counter;
    private int index;

    void Start()
    {
        this.img = GetComponent<Image>();
        counter = delta = cycleDuration / this.sprites.Length;        
        index = 0;
    }

    void Update()
    {
        if (Time.time - counter > 0f)
        {
            counter = Time.time + delta;

            index++;
            if (index >= sprites.Length)
                index = 0;

            this.img.sprite = sprites[index];
        }
    }
}
