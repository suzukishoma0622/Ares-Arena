using UnityEngine;
using TMPro;

public class InfoDisplay_Basic : MonoBehaviour
{
    public GameObject DisplayObj;
    public void OnDisplay()
    {
        DisplayObj.SetActive(true);
    }
    public void OffDisplay()
    {
        DisplayObj.SetActive(false);
    }
}
