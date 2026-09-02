using TMPro;
using UnityEngine;

public class CatalystCount : MonoBehaviour
{
    public int Num;
    [SerializeField] TMP_Text text;
    void Update()
    {
        text.text = Num.ToString();
    }
}
