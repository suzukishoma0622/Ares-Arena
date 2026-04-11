using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour
{
    public bool fade = false;
    public GameObject img;
    public float num = 0.004f;
    public float count;
    public bool IsCount;
    float c;
    void Start()
    {
        if (IsCount)
        {
            Invoke("Fadestart", count);
        }
        c = GetComponent<Renderer>().material.color.a;
    }
    void Update()
    {
        if (fade)
        {
            c -= Time.deltaTime * num;
            img.GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, c);
        }
        count -= Time.deltaTime;
        if(IsCount && count <= 0f)
        {
            fade = true;
        }
    }
    public void Fadestart()
    {
        fade = true;
    }
}
