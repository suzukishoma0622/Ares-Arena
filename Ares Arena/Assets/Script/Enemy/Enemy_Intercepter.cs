using TMPro;
using UnityEngine;

public class Enemy_Intercepter : MonoBehaviour
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

    int VoidNum;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        if (Bscript.Iscript.CurrentRound <= 5)
        {
            StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        }
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyStatusLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1360;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1420;
                break;
            case 3:
                Bscript.EnemyMaxHP = 1480;
                break;
            case 4:
                Bscript.EnemyMaxHP = 1540;
                break;
            case 5:
                Bscript.EnemyMaxHP = 1600;
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
                AttackText[0].text = $"虚空{15 + Bscript.AbilityLevel * 5}を付与する。";
                AttackText[1].text = ((190 + Bscript.Iscript.Crown * 10) * AttackRate).ToString("0") + "ダメージを与える。";
                DebuffDesc[0].text = "毎ターン、最初に消去する" + VoidNum + "個の宝石の効果が消える。";
                break;
            case 2:
                AttackText[0].text = $"Inflicts Void {15 + Bscript.AbilityLevel * 5}.";
                AttackText[1].text = $"Deal {(190 + Bscript.Iscript.Crown * 10) * AttackRate} Damage.";
                DebuffDesc[0].text = "At the start of each turn, the effects of the first " + VoidNum + " gems cast are removed.";
                break;
        }
        DebuffStuck[0].text = Pscript.Debuff_Void.ToString();
        if (VoidNum > 0)
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
        Pscript.Debuff_Void = VoidNum;
    }
    public void Action()
    {
        IsForecast = false;
        switch((Bscript.CurrentRound - 1) % 2)
        {
            case 0:
                if(Bscript.CurrentRound == 1)
                {
                    IsChat = true;
                    int j = Random.Range(0, 2);
                    switch (Language)
                    {
                        case 1:
                            ChatText.text = "その宝石を奪い取ってやる！";
                            break;
                        case 2:
                            ChatText.text = "I'm going to snatch that jewel away!";
                            break;
                    }
                    Invoke("OutChat", 1.5f);
                    Invoke("Act1_1", 1.5f);
                    Invoke("Act1_2", 2.5f);
                    Invoke("ActEnd", 3.5f);
                    break;
                }
                else
                {
                    Act1_1();
                    Invoke("Act1_2", 1f);
                    Invoke("ActEnd", 2f);
                }
                break;
            case 1:
                Act2_1();
                Invoke("Act2_2", 0.3f);
                Invoke("ActEnd", 1.3f);
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
        VoidNum += 15 + Bscript.AbilityLevel * 5;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
    }
    void Act2_1()
    {
        GameObject g = Instantiate(Effect[1]);
        g.transform.position = Effect[1].transform.position;
        g.SetActive(true);
        GameObject g2 = Instantiate(Effect[2]);
        g2.transform.position = Effect[2].transform.position;
        g2.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[1]);
    }
    void Act2_2()
    {
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((190 + Bscript.Iscript.Crown * 10) * StrengthRate);
    }
}
