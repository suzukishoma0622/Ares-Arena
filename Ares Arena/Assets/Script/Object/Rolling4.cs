using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling4 : MonoBehaviour
{
    public float num = 1f;
    float R;
    void Start()
    {
        R = this.transform.eulerAngles.z;
    }
    void Update()
    {
        R += Time.deltaTime * num;
        this.transform.eulerAngles = new Vector3(0, 0, R);
    }
}
