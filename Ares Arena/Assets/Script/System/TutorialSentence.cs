using UnityEngine;
using TMPro;
public class TutorialSentence : MonoBehaviour
{
    public int PageNum;
    int CurrentPage = 1;
    public GameObject[] PageObj;
    bool IsClose;
    public TMP_Text PageText;
    void Start()
    {
        PageText.text = CurrentPage + "/" + PageNum;
    }
    void Update()
    {
        if(IsClose)
        {
            GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 2f;
        }
        else
        {
            GetComponent<CanvasGroup>().alpha += Time.deltaTime * 2f;
        }
    }
    public void PageChange(int a)
    {
        switch(a)
        {
            case 0:
                if (CurrentPage > 1)
                {
                    CurrentPage -= 1;
                }
                break;
            case 1:
                if (CurrentPage < PageNum)
                {
                    CurrentPage += 1;
                }
                break;
        }
        for(int i = 0; i < PageNum; i++)
        {
            PageObj[i].SetActive(false);
        }
        PageObj[CurrentPage - 1].SetActive(true);
        PageText.text = CurrentPage + "/" + PageNum;
    }
    public void CloseButton()
    {
        IsClose = true;
        Invoke("D", 0.5f);
    }
    void D()
    {
        Destroy(this.gameObject);
    }
}
