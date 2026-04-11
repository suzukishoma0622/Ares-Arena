using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObject : MonoBehaviour
{
    public GameObject Dobj;
    public void D()
    {
        Destroy(Dobj);
    }
}
