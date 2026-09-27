using TMPro;
using UnityEngine;

public class Enemy_ZapKnight : MonoBehaviour
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
                Bscript.EnemyMaxHP = 1230;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1320;
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
                AttackText[0].text = ((150 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。麻痺" + Mathf.Min(Bscript.CurrentRound + 2 + Bscript.AbilityLevel, 7).ToString("0") + "を付与する。";
                DebuffName[0].text = "麻痺";
                DebuffDesc[0].text = "このターン、ハンド数が" + Pscript.Debuff_Lightning + "減少する。";
                break;
            case 2:
                AttackText[0].text = "Deal " + ((150 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate).ToString("0") + " Damage. Inflicts Paralisys " + Mathf.Min(Bscript.CurrentRound + 2 + Bscript.AbilityLevel, 7).ToString("0") + " Shield.";
                DebuffName[0].text = "Paralysis";
                DebuffDesc[0].text = "This turn, the number of hand decreases by " + Pscript.Debuff_Lightning + ".";
                break;
        }
        DebuffStuck[0].text = Pscript.Debuff_Lightning.ToString();
        if (Pscript.Debuff_Lightning > 0)
        {
            DebuffCG[0].alpha += Time.deltaTime * 2f;
        }
        else
        {
            DebuffCG[0].alpha -= Time.deltaTime * 2f;
        }
        if (Bscript.IsDefeat)
        {
            Effect[1].SetActive(false);
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
        if(Bscript.IsDefeat)
        {
            IsForecast = false;
        }
        if(IsForecast && !Bscript.IsDefeat)
        {
            switch (Bscript.CurrentRound % 1)
            {
                case 0:
                    ActForecast[0].alpha += Time.deltaTime * 2f;
                    ActForecast[0].interactable = true;
                    ActForecast[0].blocksRaycasts = true;
                    break;
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
        switch(Bscript.CurrentRound % 1)
        {
            case 0:
                int Judge = Random.Range(0, 2);
                switch(Judge)
                {
                    case 0:
                        Act1_1();
                        Invoke("Act1_2", 1f);
                        Invoke("Act1_3", 1.2f);
                        Invoke("ActEnd", 2.2f);
                        break;
                    case 1:
                        IsChat = true;
                        int j = Random.Range(0, 2);
                        switch (Language)
                        {
                            case 1:
                                switch (j)
                                {
                                    case 0:
                                        ChatText.text = "動けるかしら？";
                                        break;
                                    case 1:
                                        ChatText.text = "攻撃？そうはいかないわよ！";
                                        break;
                                }
                                break;
                            case 2:
                                switch (j)
                                {
                                    case 0:
                                        ChatText.text = "Can you move?";
                                        break;
                                    case 1:
                                        ChatText.text = "Attack? Not a chance!";
                                        break;
                                }
                                break;
                        }
                        Invoke("OutChat", 1.5f);
                        Invoke("Act1_1", 1.5f);
                        Invoke("Act1_2", 2.5f);
                        Invoke("Act1_3", 2.7f);
                        Invoke("ActEnd", 3.7f);
                        break;
                }
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((150 + Bscript.AttackLevel * 10) * StrengthRate);
    }
    void Act1_3()
    {
        Pscript.Debuff_Lightning = Mathf.Min(Bscript.CurrentRound + 2 + Bscript.AbilityLevel, 7);
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
    }
}
