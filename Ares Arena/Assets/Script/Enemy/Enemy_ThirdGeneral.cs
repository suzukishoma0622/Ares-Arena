using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_ThirdGeneral : MonoBehaviour
{
    public BattleManager Bscript;
    public PuzzleManager Pscript;
    public CanvasGroup[] ActForecast;
    public GameObject[] AttackObj;
    public TMP_Text[] AttackText;
    public float AttackRate = 1;
    public CanvasGroup EnemyChat;
    public TMP_Text ChatText;
    public float StrengthRate = 1f;
    bool IsChat;
    int Language;
    bool IsForecast;
    public GameObject[] Effect;
    public GameObject Counter;

    public CanvasGroup[] DebuffCG;
    public TMP_Text[] DebuffStuck;
    public TMP_Text[] DebuffDesc;
    public CanvasGroup[] BuffCG;
    public TMP_Text BuffStuck;
    public TMP_Text BuffDesc;
    bool IsDebuff;
    bool IsBuff;
    public GameObject[] NullObj;
    public int[] DisabledBless;
    public AudioClip[] EnemySE;
    bool IsC;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyStatusLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 3100;
                break;
            case 2:
                Bscript.EnemyMaxHP = 3300;
                break;
            case 3:
                Bscript.EnemyMaxHP = 3500;
                break;
            case 4:
                Bscript.EnemyMaxHP = 3700;
                break;
            case 5:
                Bscript.EnemyMaxHP = 3900;
                break;
        }
        Bscript.EnemyHP = Bscript.EnemyMaxHP;
    }
    void Update()
    {
        switch (Language)
        {
            case 1:
                AttackText[0].text = $"{(300 + Bscript.Iscript.Crown * 20) * AttackRate}ダメージを与える。洗脳を付与する。";
                AttackText[1].text = ((450 + Bscript.Iscript.Crown * 30) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。麻痺" + (4 + Bscript.AbilityLevel).ToString() + "を付与する。";
                AttackText[2].text = (800 + Bscript.AbilityLevel * 40).ToString() + "シールドを得る。";
                AttackText[3].text = $"{(200 + Bscript.Iscript.Crown * 10) * AttackRate}ダメージを与える。25%の攻撃激化を得る。";
                DebuffDesc[0].text = "この戦闘中、全ての祝福が無効化される。";
                DebuffDesc[1].text = "このターン、ハンド数が" + Pscript.Debuff_Lightning + "減少する。";
                BuffDesc.text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = $"Deal {(300 + Bscript.Iscript.Crown * 20) * AttackRate} Damage. Inflict Brainwashing.";
                AttackText[1].text = "Deal " + ((450 + Bscript.Iscript.Crown * 30) * AttackRate * StrengthRate).ToString("0") + " Damage. Inflict Paralysis " + (4 + Bscript.AbilityLevel).ToString() + ".";
                AttackText[2].text = "Gain " + (800 + Bscript.Iscript.Crown * 40).ToString() + " Shield.";
                AttackText[3].text = $"Deal {(200 + Bscript.Iscript.Crown * 10) * AttackRate} Damage. Gain 25% Intensified.";
                DebuffDesc[0].text = "All blessings are nullified during this battle.";
                DebuffDesc[1].text = "This turn, the number of hand decreases by " + Pscript.Debuff_Lightning + ".";
                BuffDesc.text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        DebuffStuck[0].text = Pscript.Debuff_Lightning.ToString();
        BuffStuck.text = ((AttackRate - 1f) * 100f).ToString("0") + "%";
        if (Bscript.IsDefeat)
        {
            IsForecast = false;
            if (!IsC)
            {
                for (int i = 0; i < 12; i++)
                {
                    Pscript.Iscript.Bless[Pscript.Iscript.BlessList[i]] = 1;
                    NullObj[i].SetActive(false);
                }
                IsC = true;
            }
        }
        if(IsDebuff)
        {
            DebuffCG[0].alpha += Time.deltaTime * 2f;
            DebuffCG[0].interactable = true;
            DebuffCG[0].blocksRaycasts = true;
        }
        if (Pscript.Debuff_Lightning > 0)
        {
            DebuffCG[1].alpha += Time.deltaTime * 2f;
            DebuffCG[1].interactable = true;
            DebuffCG[1].blocksRaycasts = true;
        }
        else
        {
            DebuffCG[1].alpha -= Time.deltaTime * 2f;
            DebuffCG[1].interactable = false;
            DebuffCG[1].blocksRaycasts = false;
        }
        if (IsBuff)
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
            if(Bscript.CurrentRound == 1)
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
        if(Bscript.CurrentRound == 1)
        {
            IsChat = true;
            switch (Language)
            {
                case 1:
                    if (Bscript.Iscript.Saint == 10)
                    {
                        ChatText.text = "同志よ、悪いがここは通さぬ！";
                    }
                    else
                    {
                        ChatText.text = "己の力を思い知るがいい！";
                    }
                    break;
                case 2:
                    if (Bscript.Iscript.Saint == 10)
                    {
                        ChatText.text = "Comrade, sorry but you won't pass!";
                    }
                    else
                    {
                        ChatText.text = "Witness your own power!";
                    }
                    break;
            }
            Invoke("OutChat", 1.5f);
            Invoke("Act1_1", 1.5f);
            Invoke("Act1_2", 2.3f);
            Invoke("ActEnd", 3.3f);
        }
        else
        {
            switch((Bscript.CurrentRound - 1) % 3)
            {
                case 1:
                    Act2_1();
                    Invoke("Act2_2", 0.4f);
                    Invoke("ActEnd", 1.4f);
                    break;
                case 2:
                    Act3_1();
                    Invoke("Act3_2", 0.8f);
                    Invoke("ActEnd", 1.8f);
                    break;
                case 0:
                    Act4_1();
                    Invoke("Act4_2", 0.6f);
                    Invoke("ActEnd", 1.6f);
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
        IsDebuff = true;
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((300 + Bscript.Iscript.Crown * 20) * AttackRate);
        for (int i = 0; i < 12; i++)
        {
            if (Pscript.Iscript.BlessList[i] > 0)
            {
                DisabledBless[i] = Pscript.Iscript.BlessList[i];
                Pscript.Iscript.Bless[Pscript.Iscript.BlessList[i]] = 0;
                NullObj[i].SetActive(true);
            }
        }
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((450 + Bscript.Iscript.Crown * 30) * AttackRate);
        Pscript.Debuff_Lightning = 4 + Bscript.AbilityLevel;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
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
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = false;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(800 + Bscript.Iscript.Crown * 40);
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
        GameObject g2 = Instantiate(AttackObj[0]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = true;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((200 + Bscript.Iscript.Crown * 20) * AttackRate);
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "攻撃激化 +25%";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Intensified +25%";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        AttackRate += 0.25f;
        IsBuff = true;
    }
}
