using TMPro;
using UnityEngine;

public class Enemy_FilamentMilitar : MonoBehaviour
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
    public TMP_Text DebuffStuck;
    public TMP_Text DebuffName;
    public TMP_Text DebuffDesc;
    bool IsDebuff;
    public int Bind;

    int AJ;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1400;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1500;
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
                AttackText[0].text = $"{(90 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate}ダメージを与える。捕縛{Mathf.FloorToInt((60 + Bscript.AbilityLevel * 10) * StrengthRate)}を付与する。";
                AttackText[1].text = $"{20 * AttackRate * StrengthRate}ダメージを{7 + Bscript.AttackLevel}回与える。";
                AttackText[2].text = $"捕縛{Mathf.FloorToInt((50 + Bscript.AbilityLevel * 10) * StrengthRate)}を付与する。";
                DebuffName.text = "捕縛";
                DebuffDesc.text = "ターン終了時、" + Bind + "ダメージを受ける。";
                break;
            case 2:
                AttackText[0].text = $"Deal {(90 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate} Damage. Inflict {Mathf.FloorToInt((60 + Bscript.AbilityLevel * 10) * StrengthRate)} Bind.";
                AttackText[1].text = $"Deal {20 * AttackRate * StrengthRate} Damage {7 + Bscript.AttackLevel} times.";
                AttackText[2].text = $"Inflict {Mathf.FloorToInt((50 + Bscript.AbilityLevel * 10) * StrengthRate)} Bind.";
                DebuffName.text = "Bind";
                DebuffDesc.text = "At the end of turn, take " + Bind + " Damage.";
                break;
        }
        DebuffStuck.text = Bind.ToString();
        if (Bscript.IsDefeat)
        {
            IsForecast = false;
        }
        if(IsDebuff)
        {
            DebuffCG[0].alpha += Time.deltaTime * 2f;
            DebuffCG[0].interactable = true;
            DebuffCG[0].blocksRaycasts = true;
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
                ActForecast[1 + AJ].alpha += Time.deltaTime * 2f;
                ActForecast[1 + AJ].interactable = true;
                ActForecast[1 + AJ].blocksRaycasts = true;
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
            Act1_1();
            Invoke("Act1_2", 0.6f);
            Invoke("ActEnd", 1.6f);
        }
        else
        {
            switch(AJ)
            {
                case 0:
                    Act2_1();
                    for(int i = 0; i < 7 + Bscript.AttackLevel; i++)
                    {
                        Invoke("Act2_2", 0.3f + i * 0.1f);
                    }
                    Invoke("ActEnd", 1.9f);
                    break;
                case 1:
                    Act3_1();
                    Invoke("Act3_2", 0.7f);
                    Invoke("ActEnd", 1.7f);
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
        GameObject g2 = Instantiate(AttackObj[0]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = true;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((90 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate);
    }
    void Act1_2()
    {
        IsDebuff = true;
        Bind += Mathf.FloorToInt((60 + Bscript.AbilityLevel * 10) * StrengthRate);
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
        AJ = Random.Range(0, 2);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(20 * AttackRate * StrengthRate);
        AJ = Random.Range(0, 2);
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
        Bind += Mathf.FloorToInt((50 + Bscript.AbilityLevel * 10) * StrengthRate);
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
        AJ = Random.Range(0, 2);
    }
}
