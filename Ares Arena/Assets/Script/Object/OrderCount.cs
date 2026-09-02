using TMPro;
using UnityEngine;

public class OrderCount : MonoBehaviour
{
    public int Num;
    [SerializeField]public TMP_Text text;
    void Update()
    {
        text.text = Num.ToString();
    }
}
