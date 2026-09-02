using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] Image[] Icon;
    [SerializeField] Image[] Bar;
    public int CurrentPosition;
    int CanPress;
    bool IsOpen;
    bool IsFade;
    [SerializeField] GameObject FadeObj;
    [SerializeField] GameObject StarterScreen;
    [SerializeField] GameObject[] BattleScreen;
    [SerializeField] GameObject[] EliteScreen;
    [SerializeField] GameObject[] BossScreen;
    [SerializeField] GameObject RestScreen;
    int[] BattleNum = new int[5];
    GameObject ClonedBattle;
    float count;
    bool IsC;
    void Start()
    {
        
    }
    void Update()
    {
        if(IsOpen)
        {
            GetComponent<CanvasGroup>().alpha += Time.deltaTime * 2f;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            GetComponent<CanvasGroup>().interactable = true;
            if (CanPress != 0)
            {
                if (IsC)
                {
                    count += Time.deltaTime;
                    if (count > 0.6f)
                    {
                        IsC = false;
                    }
                }
                else
                {
                    count -= Time.deltaTime;
                    if (count <= 0.2f)
                    {
                        IsC = true;
                    }
                }
                Icon[CurrentPosition].GetComponent<CanvasGroup>().alpha = count;
            }
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = 0f;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            GetComponent<CanvasGroup>().interactable = false;
        }
        if (IsFade)
        {
            FadeObj.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 2f;
            FadeObj.GetComponent<CanvasGroup>().blocksRaycasts = true;
            FadeObj.GetComponent<CanvasGroup>().interactable = true;
        }
        else
        {
            FadeObj.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 2f;
            FadeObj.GetComponent<CanvasGroup>().blocksRaycasts = false;
            FadeObj.GetComponent<CanvasGroup>().interactable = false;
        }

    }
    public void MapOpen()
    {
        IsOpen = true;
        Press(CurrentPosition + 1);
    }
    public void MapMove(int i)
    {
        if (CanPress == i)
        {
            Bar[i - 1].GetComponent<CanvasGroup>().alpha = 1f;
            Icon[i - 1].GetComponent<CanvasGroup>().alpha = 1f;
            CanPress = 0;
            CurrentPosition += 1;
            Invoke("Move1", 0.7f);
            Invoke("Move2", 1.4f);
            Invoke("Move3", 2.2f);
        }
    }
    public void Press(int i)
    {
        CanPress = i;
    }
    void Move1()
    {
        IsFade = true;
    }
    void Move2()
    {
        IsOpen = false;
    }
    void Move3()
    {
        if (CurrentPosition == 1 || CurrentPosition == 3 || CurrentPosition == 5 || CurrentPosition == 7 || CurrentPosition == 9)
        {
            if (CurrentPosition == 1)
            {
                Destroy(StarterScreen);
            }
            else
            {
                Destroy(ClonedBattle);
            }
            int Judge = Random.Range(0, BattleScreen.Length);
            BattleNum[0] = Judge;
            GameObject g = Instantiate(BattleScreen[Judge]);
            g.SetActive(true);
            ClonedBattle = g;
        }
        else if (CurrentPosition == 2 || CurrentPosition == 4 || CurrentPosition == 6 || CurrentPosition == 8 || CurrentPosition == 10 || CurrentPosition == 12)
        {
            GameObject g = Instantiate(RestScreen);
            g.SetActive(true);
            ClonedBattle = g;
        }
        else if(CurrentPosition == 11)
        {
            Destroy(ClonedBattle);
            int Judge = Random.Range(0, EliteScreen.Length);
            GameObject g = Instantiate(EliteScreen[Judge]);
            g.SetActive(true);
            ClonedBattle = g;
        }
        else
        {
            Destroy(ClonedBattle);
            int Judge = Random.Range(0, BossScreen.Length);
            GameObject g = Instantiate(BossScreen[Judge]);
            g.SetActive(true);
            ClonedBattle = g;
        }
        IsFade = false;
    }
}
