using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2 : MonoBehaviour
{
    public float speed = 0.02f;
    float X;
    float Y;
    private void Start()
    {
        X = this.transform.localScale.x;
        Y = this.transform.localScale.y;
    }
    void Update()
    {
        X += Time.deltaTime * speed;
        Y += Time.deltaTime * speed;
        transform.localScale = new Vector3(X, Y, 0f);
    }
}
