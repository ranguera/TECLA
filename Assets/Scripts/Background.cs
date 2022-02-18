using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;

    private RectTransform r;
    private Vector3 initialpos;
    void Start()
    {
        r = GetComponent<RectTransform>();
        this.initialpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * speed);

        print(r.position.x);
        if (r.position.x <= -1919)
            this.transform.position = this.initialpos;
    }
}
