using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float xMin;

    private RectTransform rect;
    
    void Start()
    {
        this.rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        this.transform.Translate(Vector3.left * this.speed * Time.deltaTime);

        if (this.rect.position.x < this.xMin)
            Destroy(this.gameObject);
    }
}
