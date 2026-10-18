using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestManager : MonoBehaviour
{
    SaveData data;
    public GameObject ParentObj;
    public InfoDisplay Iscript;
    public Slider HpSlider;
    public TMP_Text HpText;
    public CanvasGroup RestEffect;
    public CanvasGroup TrainEffect;
    bool IsRest;
    bool IsTrain;
    bool RestText;
    bool TrainText;
    public CanvasGroup[] ActDesc;
    public Button[] ActButton;
    public CanvasGroup[] ActText;
    public GameObject[] BattleObj;
    public GameObject[] EliteObj;
    public GameObject[] BossObj;
    public GameObject[] CrownObj;
    public GameObject[] NextObj;

    public int[] GemBox;
    public GameObject[] GemButton;
    public InfoDisplay_Gem[] GemInfo;
    public GameObject EquipButton;

    int Medal;
    public TMP_Text MedalText;
    int[] ShopGem = new int[5];
    int[] ShopGemValue = {3, 3, 3, 3, 3};
    public Animator[] ShopGemanim;
    public TMP_Text[] ShopGemValueText;
    public InfoDisplay_Gem[] ShopGemInfo;
    public CanvasGroup[] ShopGemCG;
    bool[] Gembought = new bool[5];
    int[] ShopBless = new int[5];
    int[] ShopBlessValue = {3, 3, 3, 3, 3};
    public Animator[] ShopBlessanim;
    public TMP_Text[] ShopBlessValueText;
    public InfoDisplay_Bless[] ShopBlessInfo;
    public CanvasGroup[] ShopBlessCG;
    bool[] Blessbought = new bool[5];
    public GameObject GemSlotHL;
    public GameObject GemBoxHL;
    int ChoosedBox = -1;
    int ChoosedGem = -1;
    float TrainNum = 1.2f;

    public Animator Map5anim;
    public Animator Bossanim;
    int Crown;
    public GameObject[] ShopObj;
    public AudioClip GemSE;
    public AudioClip PurchaseSE;
    public AudioClip RestSE;
    public AudioClip SmithSE;

    public int Reroll;
    public CanvasGroup RerollFlash;
    public GameObject RerollButton;
    public TMP_Text RerollText;

    public GameObject AresFlash;
    void Start()
    {
        data = Iscript.GetComponent<DataManager>().Dscript;
        Iscript.BGMnum = 2;
        Crown = PlayerPrefs.GetInt("Crown", 0);
        if((Iscript.Saint == 6 && Iscript.Crown >= 5) || (Iscript.Saint == 6 && Iscript.Crown >= 4) || (Iscript.Saint == 10 && Iscript.Crown >= 5))
        {
            Map5anim.Play("Map2");
        }
        for(int i = 0; i < Iscript.CurrentRound - 1; i++)
        {
            CrownObj[i].SetActive(true);
        }
        NextObj[Iscript.CurrentRound - 1].SetActive(true);
        for (int i = 0; i < 20; i++)
        {
            GemBox[i] = PlayerPrefs.GetInt($"GemBox{i}", -1);
            if (GemBox[i] >= 0)
            {
                GemButton[i].SetActive(true);
                GemButton[i].GetComponent<Animator>().Play($"Gem{GemBox[i]}");
                GemInfo[i].GemNum = GemBox[i];
            }
        }
        Medal = PlayerPrefs.GetInt("Medal", 0);
        MedalText.text = Medal.ToString();
        int k = 1;
        for(;k > 0 ; )
        {
            ShopGemJudge();
            k = 0;
            for(int i = 0;i < 5;i++)
            {
                for(int j = 0;j < 20;j++)
                {
                    if (ShopGem[i] == GemBox[j])
                    {
                        k += 1;
                        break;
                    }
                }
                for (int j = 0; j < 5; j++)
                {
                    if (ShopGem[i] == Iscript.JewelNum[j])
                    {
                        k += 1;
                        break;
                    }
                }
            }
        }
        int h = 1;
        for (; h > 0;)
        {
            ShopBlessJudge();
            h = 0;
            for (int i = 0; i < 5; i++)
            {
                if (Iscript.Bless[ShopBless[i]] == 1)
                {
                    h += 1;
                    break;
                }
            }
        }
        int J1 = Random.Range(0, 3);
        int J2 = Random.Range(0, 3);
        int J3 = Random.Range(3, 5);
        for (;J1 == J2 ; )
        {
            J2 = Random.Range(0, 3);
        }
        ShopGemValue[J1] += 1;
        ShopGemValue[J3] -= 1;
        if (Iscript.Saint != 8 || Iscript.Crown <= 1)
        {
            ShopGemValue[J2] -= 1;
        }
        for(int i = 0; i < 3; i++)
        {
            if (ShopGem[i] == 171)
            {
                ShopGemValue[i] += 2;
            }
        }
        int J4 = Random.Range(0, 3);
        int J5 = Random.Range(0, 3);
        int J6 = Random.Range(3, 5);
        for (; J4 == J5;)
        {
            J5 = Random.Range(0, 3);
        }
        if (Iscript.Saint != 8 || Iscript.Crown <= 1)
        {
            ShopBlessValue[J4] -= 1;
        }
        ShopBlessValue[J5] -= 1;
        ShopBlessValue[J6] -= 1;
        if (Iscript.Bless[11] == 1)
        {
            for (int m = 0; m < 1 + Iscript.Bless[54]; m++)
            {
                int J11 = Random.Range(0, 6);
                if (J11 <= 2)
                {
                    ShopGemValue[J11] -= 1;
                }
                else
                {
                    ShopBlessValue[J11 - 3] -= 1;
                }
            }
        }
        if(Iscript.Bless[24] == 1)
        {
            RerollButton.SetActive(true);
            RerollText.text = "x" + Iscript.Bless24;
            if(Iscript.Bless24 == 0)
            {
                RerollButton.GetComponent<Button>().interactable = false;
            }
        }
        for (int i = 0; i < 5; i++)
        {
            ShopGemanim[i].Play($"Gem{ShopGem[i]}");
            ShopGemValueText[i].text = ShopGemValue[i].ToString();
            ShopGemInfo[i].GemNum = ShopGem[i];
            ShopBlessanim[i].Play($"Bless{ShopBless[i]}");
            ShopBlessValueText[i].text = ShopBlessValue[i].ToString();
            ShopBlessInfo[i].BlessNum = ShopBless[i];
        }
        if (Iscript.Bless[23] == 1)
        {
            ShopObj[0].SetActive(true);
            ShopObj[1].SetActive(true);
            if (Iscript.Bless[54] == 1)
            {
                ShopObj[2].SetActive(true);
                ShopObj[3].SetActive(true);
            }
        }
        
        if(Iscript.Bless[58] == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                ShopGemValue[i] = Mathf.FloorToInt(ShopGemValue[i] * 0.5f);
                ShopBlessValue[i] = Mathf.FloorToInt(ShopBlessValue[i] * 0.5f);
                ShopGemValueText[i].text = ShopGemValue[i].ToString();
                ShopBlessValueText[i].text = ShopBlessValue[i].ToString();
            }
            Iscript.Bless[58] = 2;
        }
        if(Iscript.Tutorial >= 1)
        {
            Iscript.TutorialObj[2].SetActive(true);
            Iscript.Tutorial = 0;
        }
        Bossanim.Play($"Boss{Iscript.Boss}");
    }
    void ShopGemJudge()
    {
        for (int i = 0; i < 5; i++)
        {
            ShopGem[i] = Random.Range(8, 200);
        }
        for (; ShopGem[0] == ShopGem[1];)
        {
            ShopGem[1] = Random.Range(8, 200);
        }
        for (; ShopGem[0] == ShopGem[2] || ShopGem[1] == ShopGem[2];)
        {
            ShopGem[2] = Random.Range(8, 200);
        }
        for (; ShopGem[0] == ShopGem[3] || ShopGem[1] == ShopGem[3] || ShopGem[2] == ShopGem[3];)
        {
            ShopGem[3] = Random.Range(8, 200);
        }
        for (; ShopGem[0] == ShopGem[4] || ShopGem[1] == ShopGem[4] || ShopGem[2] == ShopGem[4] || ShopGem[3] == ShopGem[4];)
        {
            ShopGem[4] = Random.Range(8, 200);
        }
    }
    void ShopBlessJudge()
    {
        for (int i = 0; i < 5; i++)
        {
            int j1 = Random.Range(0, 5);
            if (j1 == 0)
            {
                ShopBless[i] = Random.Range(71, 81);
            }
            else
            {
                ShopBless[i] = Random.Range(25, 65);
            }
        }
        for (; ShopBless[0] == ShopBless[1];)
        {
            int j1 = Random.Range(0, 5);
            if (j1 == 0)
            {
                ShopBless[1] = Random.Range(71, 81);
            }
            else
            {
                ShopBless[1] = Random.Range(25, 65);
            }
        }
        for (; ShopBless[0] == ShopBless[2] || ShopBless[1] == ShopBless[2];)
        {
            int j1 = Random.Range(0, 5);
            if (j1 == 0)
            {
                ShopBless[2] = Random.Range(71, 81);
            }
            else
            {
                ShopBless[2] = Random.Range(25, 65);
            }
        }
        for (; ShopBless[0] == ShopBless[3] || ShopBless[1] == ShopBless[3] || ShopBless[2] == ShopBless[3];)
        {
            int j1 = Random.Range(0, 5);
            if (j1 == 0)
            {
                ShopBless[3] = Random.Range(71, 81);
            }
            else
            {
                ShopBless[3] = Random.Range(25, 65);
            }
        }
        for (; ShopBless[0] == ShopBless[4] || ShopBless[1] == ShopBless[4] || ShopBless[2] == ShopBless[4] || ShopBless[3] == ShopBless[4];)
        {
            int j1 = Random.Range(0, 5);
            if (j1 == 0)
            {
                ShopBless[4] = Random.Range(71, 81);
            }
            else
            {
                ShopBless[4] = Random.Range(25, 65);
            }
        }
        if(Iscript.Bless81 > 0 && Iscript.Bless81 == Iscript.CurrentRound)
        {
            int i = Random.Range(0, 3);
            ShopBless[i] = 81;
        }
    }
    void Update()
    {
        HpSlider.maxValue = Iscript.PlayerMaxHP;
        HpSlider.value = Iscript.PlayerHP;
        HpText.text = Iscript.PlayerHP + "/" + Iscript.PlayerMaxHP;
        if (IsRest)
        {
            RestEffect.alpha += Time.deltaTime;
            for (int i = 0; i < ActButton.Length; i++)
            {
                ActText[i].alpha -= Time.deltaTime * 2f;
            }
            if (RestEffect.alpha == 1f)
            {
                IsRest = false;
            }
        }
        else
        {
            RestEffect.alpha -= Time.deltaTime;
        }
        if (IsTrain)
        {
            TrainEffect.alpha += Time.deltaTime;
            for (int i = 0; i < ActButton.Length; i++)
            {
                ActText[i].alpha -= Time.deltaTime * 2f;
            }
            if (TrainEffect.alpha == 1f)
            {
                IsTrain = false;
            }
        }
        else
        {
            TrainEffect.alpha -= Time.deltaTime;
        }
        if(RestText)
        {
            ActDesc[0].alpha += Time.deltaTime * 2f;
        }
        else
        {
            ActDesc[0].alpha -= Time.deltaTime * 2f;
        }
        if (TrainText)
        {
            ActDesc[1].alpha += Time.deltaTime * 2f;
        }
        else
        {
            ActDesc[1].alpha -= Time.deltaTime * 2f;
        }
        for (int i = 0; i < 5; i++)
        {
            if (Gembought[i])
            {
                ShopGemCG[i].alpha -= Time.deltaTime * 2f;
                ShopGemCG[i].interactable = false;
            }
            if (Blessbought[i])
            {
                ShopBlessCG[i].alpha -= Time.deltaTime * 2f;
                ShopBlessCG[i].interactable = false;
            }
        }
        if(RerollFlash.alpha > 0f)
        {
            RerollFlash.alpha -= Time.deltaTime;
        }
    }
    public void Rest()
    {
        IsRest = true;
        if(Iscript.IsGem190)
        {
            Iscript.Gem190 = 0;
        }
        Iscript.SE.PlayOneShot(RestSE);
        for(int i = 0; i < ActButton.Length; i++)
        {
            ActButton[i].interactable = false;
            ActButton[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if (Iscript.Bless[3] == 1)
        {
            Iscript.PlayerMaxHP += Mathf.FloorToInt((Iscript.PlayerMaxHP - Iscript.PlayerHP) * 0.1f);
        }
        if (Iscript.Bless[19] == 1)
        {
            Iscript.PlayerMaxHP += 50 * (1 + Iscript.Bless[54]);
        }
        if (Iscript.Bless[44] == 1)
        {
            Medal += 2;
            MedalText.text = Medal.ToString();
            PlayerPrefs.SetInt("Medal", Medal);
        }
        if (Iscript.Saint == 3 && Iscript.Crown >= 3)
        {
            Iscript.PlayerHP = Iscript.PlayerHP + Mathf.FloorToInt((Iscript.PlayerMaxHP - Iscript.PlayerHP) * 0.75f);
        }
        else
        {
            Iscript.PlayerHP = Iscript.PlayerMaxHP;
        }
        HpSlider.value = Iscript.PlayerHP;
        HpText.text = Iscript.PlayerHP + "/" + Iscript.PlayerMaxHP;
        PlayerPrefs.SetInt("RestCount", PlayerPrefs.GetInt("RestCount", 0) + 1);
        PlayerPrefs.Save();
    }
    public void Train()
    {
        IsTrain = true;
        if (Iscript.IsGem181)
        {
            Iscript.Gem181 += 2;
        }
        Iscript.SE.PlayOneShot(SmithSE);
        for (int i = 0; i < ActButton.Length; i++)
        {
            ActButton[i].interactable = false;
            ActButton[i].GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if (Iscript.Bless[33] == 1)
        {
            TrainNum += 0.1f;
        }
        Iscript.PlayerMaxHP = Mathf.FloorToInt(Iscript.PlayerMaxHP * TrainNum);
        Iscript.PlayerHP = Mathf.FloorToInt(Iscript.PlayerHP * TrainNum);
        HpSlider.maxValue = Iscript.PlayerMaxHP;
        HpSlider.value = Iscript.PlayerHP;
        HpText.text = Iscript.PlayerHP + "/" + Iscript.PlayerMaxHP;
        Iscript.PlayerHPRate *= TrainNum;
        Iscript.Revenge = Mathf.FloorToInt(Iscript.Revenge * TrainNum) + 1;
        PlayerPrefs.SetInt("TrainCount", PlayerPrefs.GetInt("TrainCount", 0) + 1);
        PlayerPrefs.Save();
    }
    public void RestDescOn()
    {
        RestText = true;
    }
    public void RestDescOff()
    {
        RestText = false;
    }
    public void TrainDescOn()
    {
        TrainText = true;
    }
    public void TrainDescOff()
    {
        TrainText = false;
    }
    public void EnterArena()
    {
        Iscript.SE.PlayOneShot(Iscript.OKSE);
        Iscript.Fade = true;
        Invoke("E", 1f);
    }
    void E()
    {
        if (Iscript.CurrentRound == 7)
        {
            GameObject g = Instantiate(BossObj[Iscript.Boss]);
            g.transform.position = BossObj[Iscript.Boss].transform.position;
            g.SetActive(true);
            Destroy(ParentObj);
        }
        else if (Iscript.CurrentRound == 6 || (Iscript.CurrentRound == 5 && ((Iscript.Saint == 6 && Iscript.Crown >= 5) || (Iscript.Saint == 6 && Iscript.Crown >= 4) || (Iscript.Saint == 10 && Iscript.Crown >= 5))))
        {
            int Judge = Random.Range(0, EliteObj.Length);
            for (; Iscript.ElitePool[Judge] == 1;)
            {
                Judge = Random.Range(0, EliteObj.Length);
            }
            Iscript.ElitePool[Judge] = 1;
            GameObject g = Instantiate(EliteObj[Judge]);
            g.transform.position = EliteObj[Judge].transform.position;
            g.SetActive(true);
            Destroy(ParentObj);
        }
        else
        {
            int Judge = Random.Range(0, BattleObj.Length);
            for(; Iscript.EnemyPool[Judge] == 1; )
            {
                Judge = Random.Range(0, BattleObj.Length);
            }
            Iscript.EnemyPool[Judge] = 1;
            GameObject g = Instantiate(BattleObj[Judge]);
            g.transform.position = BattleObj[Judge].transform.position;
            g.SetActive(true);
            Destroy(ParentObj);
        }
    }
    public void BuyGem(int i)
    {
        if (Medal >= ShopGemValue[i] && GemBox[19] == -1)
        {
            Gembought[i] = true;
            Iscript.SE.PlayOneShot(PurchaseSE);
            Medal -= ShopGemValue[i];
            MedalText.text = Medal.ToString();
            PlayerPrefs.SetInt("Medal", Medal);
            data.GemUnlock[ShopGem[i] + 1] = 1;
            for (int j = 0; j < GemBox.Length; j++)
            {
                if (GemBox[j] == -1)
                {
                    GemBox[j] = ShopGem[i];
                    GemButton[j].SetActive(true);
                    GemButton[j].GetComponent<Animator>().Play($"Gem{GemBox[j]}");
                    GemInfo[j].GemNum = GemBox[j];
                    PlayerPrefs.SetInt($"GemBox{j}", ShopGem[i]);
                    PlayerPrefs.Save();
                    if (ShopGem[i] == 134)
                    {
                        Iscript.PlayerMaxHP = Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.5f);
                        if(Iscript.PlayerHP > Iscript.PlayerMaxHP)
                        {
                            Iscript.PlayerHP = Iscript.PlayerMaxHP;
                        }
                    }
                    if (ShopGem[i] == 163)
                    {
                        for (int j2 = 0; j2 < GemBox.Length; j2++)
                        {
                            if (GemBox[j2] == -1)
                            {
                                GemBox[j2] = 164;
                                GemButton[j2].SetActive(true);
                                GemButton[j2].GetComponent<Animator>().Play($"Gem{GemBox[j]}");
                                GemInfo[j2].GemNum = GemBox[j2];
                                PlayerPrefs.SetInt($"GemBox{j2}", 164);
                                PlayerPrefs.Save();
                                data.GemUnlock[165] = 1;
                                break;
                            }
                        }
                    }
                    if (ShopGem[i] == 164)
                    {
                        for (int j2 = 0; j2 < GemBox.Length; j2++)
                        {
                            if (GemBox[j2] == -1)
                            {
                                GemBox[j2] = 163;
                                GemButton[j2].SetActive(true);
                                GemButton[j2].GetComponent<Animator>().Play($"Gem{GemBox[j]}");
                                GemInfo[j2].GemNum = GemBox[j2];
                                PlayerPrefs.SetInt($"GemBox{j2}", 163);
                                PlayerPrefs.Save();
                                data.GemUnlock[164] = 1;
                                break;
                            }
                        }
                    }
                    break;
                }
            }
            if (ShopGem[i] == 181)
            {
                Iscript.IsGem181 = true;
            }
            if (ShopGem[i] == 190)
            {
                Iscript.IsGem190 = true;
            }
        }
    }
    public void BuyBless(int i)
    {
        if (Medal >= ShopBlessValue[i])
        {
            Blessbought[i] = true;
            Iscript.SE.PlayOneShot(PurchaseSE);
            Medal -= ShopBlessValue[i];
            MedalText.text = Medal.ToString();
            PlayerPrefs.SetInt("Medal", Medal);
            PlayerPrefs.Save();
            Iscript.BlessAdd(ShopBless[i]);
            if (ShopBless[i] == 27)
            {
                for (int j = 0; j < 3; j++)
                {
                    AlchemyGem();
                }
            }
            if (ShopBless[i] == 75)
            {
                for (int j = 0; j < 2; j++)
                {
                    Offering();
                }
            }
            if (ShopBless[i] == 81)
            {
                AresFlash.SetActive(true);
                Bossanim.Play($"Boss6");
            }

        }
    }
    public void GemHold(int i)
    {
        if (ChoosedBox == -1)
        {
            GemBoxHL.SetActive(true);
            GemBoxHL.transform.position = GemButton[i].transform.position;
            GemSlotHL.SetActive(true);
            ChoosedBox = i;
            ChoosedGem = GemBox[i];
        }
        else
        {
            ChoosedBox = -1;
            ChoosedGem = -1;
            GemBoxHL.SetActive(false);
            GemSlotHL.SetActive(false);
        }
        Iscript.SE.PlayOneShot(GemSE);
        EquipButton.SetActive(true);
    }
    public void GemEquip(int i)
    {
        if(ChoosedGem != -1 && Iscript.JewelNum[i] != 106)
        {
            int j = Iscript.JewelNum[i];
            Iscript.JewelNum[i] = GemBox[ChoosedBox];
            GemBox[ChoosedBox] = j;
            GemButton[ChoosedBox].GetComponent<Animator>().Play($"Gem{GemBox[ChoosedBox]}");
            GemInfo[ChoosedBox].GemNum = GemBox[ChoosedBox];
            PlayerPrefs.SetInt($"GemBox{ChoosedBox}", GemBox[ChoosedBox]);
            PlayerPrefs.SetInt($"GemEquip{i}", Iscript.JewelNum[i]);
            PlayerPrefs.SetInt("A18", 1);
            PlayerPrefs.Save();
            ChoosedBox = -1;
            ChoosedGem = -1;
            GemBoxHL.SetActive(false);
            GemSlotHL.SetActive(false);
            Iscript.SE.PlayOneShot(GemSE);
            EquipButton.SetActive(false);
        }
    }
    public void AlchemyGem()
    {
        int Agem = Random.Range(8, 200);
        int k = 1;
        for (; k > 0;)
        {
            Agem = Random.Range(8, 200);
            k = 0;
            for (int j = 0; j < 20; j++)
            {
                if (Agem == GemBox[j])
                {
                    k += 1;
                    break;
                }
            }
            for (int j = 0; j < 5; j++)
            {
                if (Agem == Iscript.JewelNum[j])
                {
                    k += 1;
                    break;
                }
            }
            for (int j = 0; j < 3; j++)
            {
                if (Agem == ShopGem[j])
                {
                    k += 1;
                    break;
                }
            }
        }
        for (int j = 0; j < GemBox.Length; j++)
        {
            if (GemBox[j] == -1)
            {
                GemBox[j] = Agem;
                GemButton[j].SetActive(true);
                GemButton[j].GetComponent<Animator>().Play($"Gem{GemBox[j]}");
                GemInfo[j].GemNum = GemBox[j];
                PlayerPrefs.SetInt($"GemBox{j}", Agem);
                PlayerPrefs.Save();
                data.GemUnlock[Agem + 1] = 1;
                break;
            }
        }
        if(Agem == 181)
        {
            Iscript.IsGem181 = true;
        }
        if (Agem == 190)
        {
            Iscript.IsGem190 = true;
        }
    }
    public void Offering()
    {
        int b;
        int j1 = Random.Range(0, 5);
        if (j1 == 0)
        {
            b = Random.Range(71, 81);
        }
        else
        {
            b = Random.Range(25, 65);
        }
        int k = 1;
        for (; k > 0;)
        {
            j1 = Random.Range(0, 5);
            if (j1 == 0)
            {
                b = Random.Range(71, 81);
            }
            else
            {
                b = Random.Range(25, 65);
            }
            k = 0;
            for (int j = 0; j < 12; j++)
            {
                if (b == Iscript.BlessList[j])
                {
                    k += 1;
                    break;
                }
            }
            for (int j = 0; j < 3; j++)
            {
                if (b == ShopBless[j])
                {
                    k += 1;
                    break;
                }
            }
        }
        for (int j = 0; j < Iscript.BlessList.Length; j++)
        {
            if (Iscript.BlessList[j] == 0)
            {
                Iscript.BlessAdd(b);
                data.BlessUnlock[b + 1] = 1;
                break;
            }
        }
    }
    public void ShopReroll()
    {
        if (Iscript.Bless24 > 0)
        {
            Iscript.Bless24 -= 1;

            for (int j = 0; j < 5; j++)
            {
                ShopGemValue[j] = 3;
                ShopBlessValue[j] = 3;
            }
            int k = 1;
            for (; k > 0;)
            {
                ShopGemJudge();
                k = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if (ShopGem[i] == GemBox[j])
                        {
                            k += 1;
                            break;
                        }
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (ShopGem[i] == Iscript.JewelNum[j])
                        {
                            k += 1;
                            break;
                        }
                    }
                }
            }
            int h = 1;
            for (; h > 0;)
            {
                ShopBlessJudge();
                h = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (Iscript.Bless[ShopBless[i]] == 1)
                    {
                        h += 1;
                        break;
                    }
                }
            }
            int J1 = Random.Range(0, 3);
            int J2 = Random.Range(0, 3);
            int J3 = Random.Range(3, 5);
            for (; J1 == J2;)
            {
                J2 = Random.Range(0, 3);
            }
            ShopGemValue[J1] += 1;
            ShopGemValue[J2] -= 1;
            ShopGemValue[J3] -= 1;
            for (int i = 0; i < 3; i++)
            {
                if (ShopGem[i] == 171)
                {
                    ShopGemValue[i] += 2;
                }
            }
            int J4 = Random.Range(0, 3);
            int J5 = Random.Range(0, 3);
            int J6 = Random.Range(3, 5);
            for (; J4 == J5;)
            {
                J5 = Random.Range(0, 3);
            }
            ShopBlessValue[J4] -= 1;
            ShopBlessValue[J5] -= 1;
            ShopBlessValue[J6] -= 1;
            for (int i = 0; i < 5; i++)
            {
                ShopGemanim[i].Play($"Gem{ShopGem[i]}");
                ShopGemValueText[i].text = ShopGemValue[i].ToString();
                ShopGemInfo[i].GemNum = ShopGem[i];
                ShopBlessanim[i].Play($"Bless{ShopBless[i]}");
                ShopBlessValueText[i].text = ShopBlessValue[i].ToString();
                ShopBlessInfo[i].BlessNum = ShopBless[i];
            }
            if (Iscript.Bless[11] == 1)
            {
                for (int m = 0; m < 1 + Iscript.Bless[54]; m++)
                {
                    int J11 = Random.Range(0, 6);
                    if (J11 <= 2)
                    {
                        ShopGemValue[J11] -= 1;
                    }
                    else
                    {
                        ShopBlessValue[J11 - 3] -= 1;
                    }
                }
            }

            RerollFlash.alpha = 1f;
            RerollText.text = "x" + Iscript.Bless24;
            if (Iscript.Bless24 == 0)
            {
                RerollButton.GetComponent<Button>().interactable = false;
            }
        }
    }
}
