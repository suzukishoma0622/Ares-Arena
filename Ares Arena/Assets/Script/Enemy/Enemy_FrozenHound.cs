using TMPro;
using UnityEngine;

public class Enemy_FrozenHound : MonoBehaviour
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
    bool IsBuff;
    public GameObject IceGem;
    public GameObject IceEffect;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 2400;
                break;
            case 2:
                Bscript.EnemyMaxHP = 2600;
                break;
        }
        Bscript.EnemyHP = Bscript.EnemyMaxHP;
    }
    void Update()
    {
        switch (Language)
        {
            case 1:
                AttackText[0].text = $"{Mathf.FloorToInt((320 + Bscript.AttackLevel * 30) * AttackRate)}ダメージを与える。";
                AttackText[1].text = $"{Mathf.FloorToInt(400 + Bscript.HPLevel * 50)}シールドを得る。麻痺{4 + Bscript.AbilityLevel}を付与する。";
                AttackText[2].text = $"{Mathf.FloorToInt((150 + Bscript.AttackLevel * 10) * AttackRate)}ダメージを与える。20%の攻撃激化を得る。";
                DebuffDesc[0].text = "このターン、ハンド数が" + Pscript.Debuff_Lightning + "減少する。";
                BuffDesc.text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = $"Deals {Mathf.FloorToInt((320 + Bscript.AttackLevel * 30) * AttackRate)} Damage.";
                AttackText[1].text = $"Gain {Mathf.FloorToInt(400 + Bscript.HPLevel * 50)} Shield. Inflict {4 + Bscript.AbilityLevel} Paralysis.";
                AttackText[2].text = $"Deals {Mathf.FloorToInt((150 + Bscript.AttackLevel * 10) * AttackRate)} Damage. Gain 20% Intensified.";
                DebuffDesc[0].text = "This turn, the number of hand decreases by " + Pscript.Debuff_Lightning + ".";
                BuffDesc.text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        DebuffStuck[0].text = Pscript.Debuff_Lightning.ToString();
        BuffStuck.text = ((AttackRate - 1f) * 100f).ToString("0") + "%";
        if (Bscript.IsDefeat)
        {
            IsForecast = false;
        }
        if (Pscript.Debuff_Lightning > 0)
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
            ActForecast[(Bscript.CurrentRound - 1) % 3].alpha += Time.deltaTime * 2f;
            ActForecast[(Bscript.CurrentRound - 1) % 3].interactable = true;
            ActForecast[(Bscript.CurrentRound - 1) % 3].blocksRaycasts = true;
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
        switch (Bscript.CurrentRound % 3)
        {
            case 1:
                Act1_1();
                Invoke("Act1_2", 1f);
                Invoke("ActEnd", 2f);
                break;
            case 2:
                Act2_1();
                Invoke("Act2_2", 1.5f);
                Invoke("ActEnd", 2.5f);
                break;
            case 0:
                Act3_1();
                Invoke("Act3_2", 0.6f);
                Invoke("Act3_3", 1f);
                Invoke("ActEnd", 2f);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((320 + Bscript.AttackLevel * 30) * AttackRate);
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
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = false;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(400 + Bscript.HPLevel * 50);
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
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((150 + Bscript.AttackLevel * 10) * AttackRate);
    }
    void Act3_3()
    {
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "攻撃激化 +20%";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Intensified +20%";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        AttackRate += 0.2f;
        IsBuff = true;
    }
}
