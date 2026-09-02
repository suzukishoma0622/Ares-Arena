using TMPro;
using UnityEngine;

public class Enemy_AetherRizer : MonoBehaviour
{
    public BattleManager Bscript;
    public PuzzleManager Pscript;
    public CanvasGroup[] ActForecast;
    public GameObject[] AttackObj;
    public TMP_Text[] AttackText;
    public int Momentum = 0;
    public CanvasGroup EnemyChat;
    public TMP_Text ChatText;
    public float StrengthRate = 1f;
    bool IsChat;
    int Language;
    bool IsForecast;
    public GameObject[] Effect;
    public GameObject Counter;

    public CanvasGroup[] DebuffCG;
    public TMP_Text DebuffStuck;
    public TMP_Text DebuffDesc;
    public CanvasGroup[] BuffCG;
    public TMP_Text BuffStuck;
    public TMP_Text BuffDesc;
    bool IsDebuff;
    public int Wind = 0;
    public GameObject WindEffect1;
    public GameObject WindEffect2;
    public GameObject[] WindDisplay = new GameObject[13];
    public int[] Windnum = new int[49];
    public int[] WindDict = new int[13];
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyStatusLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 6800;
                break;
            case 2:
                Bscript.EnemyMaxHP = 7100;
                break;
            case 3:
                Bscript.EnemyMaxHP = 7400;
                break;
            case 4:
                Bscript.EnemyMaxHP = 7700;
                break;
            case 5:
                Bscript.EnemyMaxHP = 8000;
                break;
        }
        Bscript.EnemyHP = Bscript.EnemyMaxHP;
    }
    void Update()
    {
        switch (Language)
        {
            case 1:
                AttackText[0].text = $"{400 + Bscript.Iscript.Crown * 30 + Momentum}ダメージを与える。悠風{30 + Bscript.AbilityLevel * 5}を付与する。";
                AttackText[2].text = $"{250 + Bscript.Iscript.Crown * 20 + Momentum}ダメージを与える。悠風15を付与する。";
                AttackText[1].text = $"{40 + Bscript.Iscript.Crown * 10 + Momentum}ダメージを5回与える。";
                AttackText[3].text = $"上昇{80 + Bscript.AbilityLevel * 10}を得る。";
                DebuffDesc.text = $"ハンドする毎に、盤上に風が発生する。風内の宝石を消去する毎に{Wind}ダメージを受ける。";
                BuffDesc.text = $"与えるダメージが{Momentum}加算される。";
                break;
            case 2:
                AttackText[0].text = $"Deal {400 + Bscript.Iscript.Crown * 30 + Momentum} Damage. Inflict {30 + Bscript.AbilityLevel * 5} Leisurewind.";
                AttackText[1].text = $"Deal {40 + Bscript.Iscript.Crown * 10 + Momentum} Damage 5 times.";
                AttackText[2].text = $"Deal {250 + Bscript.Iscript.Crown * 20 + Momentum} Damage. Inflict 15 Leisurewind.";
                AttackText[3].text = $"Gain {80 + Bscript.AbilityLevel * 10} Ascension.";
                DebuffDesc.text = $"Wind is generated each time you hand. Take {Wind} damage each time you cast a gem within the wind.";
                BuffDesc.text = $"Damage dealt is increased by {Momentum}.";
                break;
        }
        DebuffStuck.text = Wind.ToString();
        BuffStuck.text = Momentum.ToString();
        if (Bscript.IsDefeat)
        {
            IsForecast = false;
        }
        if (IsDebuff)
        {
            DebuffCG[0].alpha += Time.deltaTime * 2f;
            DebuffCG[0].interactable = true;
            DebuffCG[0].blocksRaycasts = true;
        }
        if (Momentum > 0)
        {
            BuffCG[0].alpha += Time.deltaTime * 2f;
            BuffCG[0].interactable = true;
            BuffCG[0].blocksRaycasts = true;
        }
        if (IsChat)
        {
            EnemyChat.alpha += Time.deltaTime * 2f;
        }
        else
        {
            EnemyChat.alpha -= Time.deltaTime * 2f;
        }
        if(Bscript.IsR)
        {
            Action();
            Bscript.IsR = false;
        }
        if(IsForecast && !Bscript.IsDefeat)
        {
            if (Bscript.CurrentRound == 1)
            {
                ActForecast[0].alpha += Time.deltaTime * 2f;
                ActForecast[0].interactable = true;
                ActForecast[0].blocksRaycasts = true;
            }
            else
            {
                ActForecast[(Bscript.CurrentRound - 2) % 3 + 1].alpha += Time.deltaTime * 2f;
                ActForecast[(Bscript.CurrentRound - 2) % 3 + 1].interactable = true;
                ActForecast[(Bscript.CurrentRound - 2) % 3 + 1].blocksRaycasts = true;
            }
        }
        else
        {
            for(int i = 0; i < ActForecast.Length; i++)
            {
                ActForecast[i].alpha -= Time.deltaTime * 2f;
                ActForecast[i].interactable = true;
                ActForecast[i].blocksRaycasts = true;
            }
        }
    }
    public void DisWind(int i)
    {
        if (Windnum[i] == 1)
        {
            for (int j = 0; j < 13; j++)
            {
                if (i == WindDict[j])
                {
                    GameObject g = Instantiate(WindEffect2);
                    g.transform.position = Pscript.JewelDisplay[WindDict[j]].transform.position;
                    g.SetActive(true);
                    g.transform.SetParent(Pscript.gameObject.transform, true);
                    GameObject g2 = Instantiate(AttackObj[0]);
                    g2.transform.position = this.transform.position;
                    g2.GetComponent<BlockTrail>().GoPlayer = true;
                    g2.GetComponent<EffectScript>().EffectNum = Wind;
                }
            }
        }
    }
    private void F()
    {
        IsForecast = true;
    }
    void ActEnd()
    {
        Bscript.RoundStart();
        IsForecast = true;
    }
    public void Action()
    {
        IsForecast = false;
        if (Bscript.CurrentRound == 1)
        {
            Act1_1();
            Invoke("Act1_2", 0.5f);
            Invoke("ActEnd", 2f);
        }
        else
        {
            switch (Bscript.CurrentRound % 3)
            {
                case 2:
                    Act2_1();
                    for(int i = 0;i < 5;i++)
                    {
                        Invoke("Act2_2", 0.5f + i * 0.2f);
                    }
                    Invoke("ActEnd", 2.3f);
                    break;
                case 0:
                    Act3_1();
                    Invoke("Act3_2", 0.5f);
                    Invoke("ActEnd", 1.5f);
                    break;
                case 1:
                    Act4_1();
                    Invoke("Act4_2", 0.5f);
                    Invoke("ActEnd", 1.5f);
                    break;
            }
        }
    }
    void OutChat()
    {
        IsChat = false;
    }
    void Act1_1()
    {
        GameObject g = Instantiate(Effect[0]);
        g.transform.position = Effect[0].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[0]);
    }
    void Act1_2()
    {
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(400 + Bscript.Iscript.Crown * 30 + Momentum);
        Wind += 30 + Bscript.AbilityLevel * 5;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
        IsDebuff = true;
    }
    void Act2_1()
    {
        GameObject g = Instantiate(Effect[1]);
        g.transform.position = Effect[1].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[1]);
    }
    void Act2_2()
    {
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(40 + Bscript.Iscript.Crown * 10 + Momentum);
    }
    void Act3_1()
    {
        GameObject g = Instantiate(Effect[2]);
        g.transform.position = Effect[2].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[2]);
    }
    void Act3_2()
    {
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(250 + Bscript.Iscript.Crown * 20 + Momentum);
        Wind += 15;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
    }
    void Act4_1()
    {
        GameObject g = Instantiate(Effect[3]);
        g.transform.position = Effect[3].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[3]);
    }
    void Act4_2()
    {
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = $"上昇 +{80 + Bscript.AbilityLevel * 10}";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = $"Ascension +{80 + Bscript.AbilityLevel * 10}";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        Momentum += 80 + Bscript.AbilityLevel * 10;
    }
}
