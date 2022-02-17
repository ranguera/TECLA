using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    public float speed = 1f;
    
    public Sprite straight;
    public Sprite up;
    public Sprite down;

    public float xMin, xMax, yMin, yMax;

    private Image shipImg;
    private RectTransform rect;

    void Start()
    {
        shipImg = GetComponent<Image>();
        this.rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        Movement();
    }

    private void Rotation()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.shipImg.sprite = up;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.DownArrow))
                this.shipImg.sprite = down;
            else
                this.shipImg.sprite = straight;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.shipImg.sprite = down;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow))
                this.shipImg.sprite = up;
            else
                this.shipImg.sprite = straight;
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            this.shipImg.sprite = straight;
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if( this.rect.localPosition.y < this.yMax)
                this.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (this.rect.localPosition.y > this.yMin)
                this.transform.Translate(Vector3.down * this.speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.rect.localPosition.x < this.xMax)
                this.transform.Translate(Vector3.right * this.speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.rect.localPosition.x > this.xMin)
                this.transform.Translate(Vector3.left * this.speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioEngine.Instance.Play(AudioEngine.Sound.Hit);
        Destroy(other.gameObject);
        GameControl.Instance.ShowQuestion();
    }
}
