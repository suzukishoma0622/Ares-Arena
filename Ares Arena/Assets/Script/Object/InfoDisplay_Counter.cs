using TMPro;
using UnityEngine;

public class InfoDisplay_Counter : MonoBehaviour
{
    float count;
    public GameObject ThisText;
    public TMP_Text TextDisplay;
    public CanvasGroup ThisCG;
    public string Thisnum;
    public float Coloring_R;
    public float Coloring_G;
    public float Coloring_B;
    void Start()
    {
        TextDisplay.text = Thisnum.ToString();
    }
    void Update()
    {
        count += Time.deltaTime;
        if (count < 0.5f)
        {
            ThisText.GetComponent<RectTransform>().localPosition += new Vector3(0f, (0.4f + (1f - count * 2f) * 3f) * Time.deltaTime, 0f);
        }
        else
        {
            ThisText.GetComponent<RectTransform>().localPosition += new Vector3(0f, 0.4f * Time.deltaTime, 0f);
        }
        if(count < 0.1f)
        {
            ThisText.GetComponent<RectTransform>().localScale = new Vector3(0.015f + (0.1f - count) * 0.4f, 0.015f + (0.1f - count) * 0.4f, 1f);
        }
        else
        {
            ThisText.GetComponent<RectTransform>().localScale = new Vector3(0.015f, 0.015f, 1f);
        }
        if (count < 0.2f)
        {
            TextDisplay.color = new Color(1f - ((1f - Coloring_R) * count * 5f), 1f - ((1f - Coloring_G) * count * 5f), 1f - ((1f - Coloring_B) * count * 5f), 1f);
        }
        else
        {
            TextDisplay.color = new Color(Coloring_R, Coloring_G, Coloring_B, 1f);
        }
        if(count > 1.5f)
        {
            ThisCG.alpha -= Time.deltaTime;
            if(ThisCG.alpha == 0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
