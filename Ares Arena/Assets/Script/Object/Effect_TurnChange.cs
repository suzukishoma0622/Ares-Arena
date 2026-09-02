using TMPro;
using UnityEngine;

public class Effect_TurnChange : MonoBehaviour
{
    public int Thisturn;
    public CanvasGroup TurnCG;
    public TMP_Text TurnText;
    public CanvasGroup StartText;
    public RectTransform BackGround;
    float count;
    float s = 7f;
    void Start()
    {
        TurnText.text = "Round" + Thisturn.ToString();
    }
    void Update()
    {
        count += Time.deltaTime;
        if (count >= 2f)
        {
            Destroy(this.gameObject);
        }
        if (count >= 1f)
        {
            if (s > 2f)
            {
                s -= Time.deltaTime * 10f;
                StartText.alpha += Time.deltaTime * 3f;
            }
            else
            {
                StartText.alpha -= Time.deltaTime * 2f;
            }
            TurnCG.alpha -= Time.deltaTime * 3f;
            StartText.gameObject.GetComponent<RectTransform>().localScale = new Vector3(s, s, 1f);
        }
        else
        {
            TurnCG.alpha += Time.deltaTime * 3f;
        }
    }
}
