using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObject2 : MonoBehaviour
{
    public float time;
    public GameObject Dobj;
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0f)
        {
            D();
        }
    }
    public void D()
    {
        if (Dobj == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(Dobj);
        }
    }
}
