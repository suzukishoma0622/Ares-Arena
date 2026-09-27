using TMPro;
using UnityEngine;

public class Enemy_CaptainScissors : MonoBehaviour
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

    public CanvasGroup[] DebuffCG;
    public TMP_Text[] DebuffStuck;
    public TMP_Text[] DebuffName;
    public TMP_Text[] DebuffDesc;
    public AudioClip[] EnemySE;
    public int Refrect;
    public GameObject Counter;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        if (Bscript.Iscript.CurrentRound <= 5)
        {
            StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        }
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1270;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1340;
                break;
        }
        Bscript.EnemyMaxHP = Mathf.FloorToInt(Bscript.EnemyMaxHP * StrengthRate);
        Bscript.EnemyHP = Bscript.EnemyMaxHP;
    }
    void Update()
    {
        switch (Language)
        {
            case 1:
                AttackText[0].text = $"{(140 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate}ダメージを与える。反射{Mathf.FloorToInt((4 + Bscript.AbilityLevel + Bscript.CurrentRound) * StrengthRate)}を得る。";
                AttackText[1].text = $"{(60 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate}ダメージを2回与える。{(200 + Bscript.HPLevel * 20) * StrengthRate}シールドを得る。";
                DebuffName[0].text = "反射";
                DebuffDesc[0].text = $"このターン、ダメージを受ける毎に、{Refrect}の反撃ダメージを与える。";
                break;
            case 2:
                AttackText[0].text = $"Deal {(140 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate} Damage. Gain {Mathf.FloorToInt((4 + Bscript.AbilityLevel + Bscript.CurrentRound) * StrengthRate)} Refrect.";
                AttackText[1].text = $"Deal {(60 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate} Damage twice. Gain {(200 + Bscript.HPLevel * 20) * StrengthRate} Shield.";
                DebuffName[0].text = "Refrect";
                DebuffDesc[0].text = $"This turn, deal {Refrect} counter-damage each time damage is taken.";
                break;
        }
        DebuffStuck[0].text = Refrect.ToString();
        if (Refrect > 0)
        {
            DebuffCG[0].alpha += Time.deltaTime * 2f;
            DebuffCG[0].interactable = true;
            DebuffCG[0].blocksRaycasts = true;
        }
        else
        {
            DebuffCG[0].alpha -= Time.deltaTime * 2f;
            DebuffCG[0].interactable = false;
            DebuffCG[0].blocksRaycasts = false;
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
            Refrect = 0;
            Action();
            Bscript.IsR = false;
        }
        if(Bscript.IsDefeat)
        {
            IsForecast = false;
        }
        if(IsForecast && !Bscript.IsDefeat)
        {
            ActForecast[(Bscript.CurrentRound - 1) % 2].alpha += Time.deltaTime * 2f;
            ActForecast[(Bscript.CurrentRound - 1) % 2].interactable = true;
            ActForecast[(Bscript.CurrentRound - 1) % 2].blocksRaycasts = true;
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
        switch((Bscript.CurrentRound - 1) % 2)
        {
            case 0:
                IsChat = true;
                switch (Language)
                {
                    case 1:
                        ChatText.text = "攻撃してみろ！";
                        break;
                    case 2:
                        ChatText.text = "Go ahead and attack!";
                        break;
                }
                Invoke("OutChat", 1.5f);
                Invoke("Act1_1", 1.5f);
                Invoke("Act1_2", 2.5f);
                Invoke("ActEnd", 3.5f);
                break;
            case 1:
                Act2_1();
                Invoke("Act2_2", 0.4f);
                Invoke("Act2_2", 0.5f);
                Invoke("Act2_3", 0.7f);
                Invoke("ActEnd", 1.7f);
                break;
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((140 + Bscript.AttackLevel * 10) * StrengthRate);
        Refrect = Mathf.FloorToInt((4 + Bscript.AbilityLevel + Bscript.CurrentRound) * StrengthRate);
        GameObject g2 = Instantiate(Counter);
        g2.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g2.GetComponent<InfoDisplay_Counter>().Thisnum = "反射";
                break;
            case 2:
                g2.GetComponent<InfoDisplay_Counter>().Thisnum = "Refrect";
                break;
        }
        g2.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g2.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g2.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g2.SetActive(true);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((60 + Bscript.AttackLevel * 10) * StrengthRate);
    }
    void Act2_3()
    {
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = false;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((200 + Bscript.HPLevel * 20) * StrengthRate);
    }
}
