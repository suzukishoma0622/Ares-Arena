using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_GemSlasher : MonoBehaviour
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
    public AudioClip[] EnemySE;

    public GameObject DummyGem;
    public GameObject DummyEffect;
    public int StolenGem;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyStatusLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1440;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1510;
                break;
            case 3:
                Bscript.EnemyMaxHP = 1580;
                break;
            case 4:
                Bscript.EnemyMaxHP = 1650;
                break;
            case 5:
                Bscript.EnemyMaxHP = 1720;
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
                AttackText[0].text = $"{(140 + Bscript.Iscript.Crown * 10) * AttackRate * StrengthRate}ダメージを与える。ランダムな宝石1つを盗む。";
                AttackText[1].text = $"{(50 + Bscript.Iscript.Crown * 4) * AttackRate * StrengthRate}ダメージを3回与える。弱体化{25 + Bscript.AbilityLevel * 5}を付与する。";
                DebuffName.text = "弱体化";
                DebuffDesc.text = "次に消去する" + Pscript.Debuff_Weak + "個の宝石の効果が50%減少する。";
                break;
            case 2:
                AttackText[0].text = $"Deal {(140 + Bscript.Iscript.Crown * 10) * AttackRate * StrengthRate} Damage. Steal 1 type of Gem.";
                AttackText[1].text = $"Deal {(50 + Bscript.Iscript.Crown * 4) * AttackRate * StrengthRate} Damage 3 times. Inflict Weak {25 + Bscript.AbilityLevel * 5}.";
                DebuffName.text = "Weak";
                DebuffDesc.text = "The effect of the next " + Pscript.Debuff_Weak + " gems you cast will be reduced by 50%.";
                break;
        }
        DebuffStuck.text = Pscript.Debuff_Weak.ToString();
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
        if (Pscript.Debuff_Weak > 0)
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
            ActForecast[(Bscript.CurrentRound + 1) % 2].alpha += Time.deltaTime * 2f;
            ActForecast[(Bscript.CurrentRound + 1) % 2].interactable = true;
            ActForecast[(Bscript.CurrentRound + 1) % 2].blocksRaycasts = true;
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
        switch (Bscript.CurrentRound % 2)
        {
            case 1:
                Act1_1();
                Invoke("Act1_2", 0.5f);
                Invoke("ActEnd", 1.5f);
                break;
            case 0:
                Act2_1();
                for (int i = 0; i < 3; i++)
                {
                    Invoke("Act2_2", 0.5f + i * 0.2f);
                }
                Invoke("Act2_3", 0.9f);
                Invoke("ActEnd", 1.9f);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((140 + Bscript.Iscript.Crown * 10) * AttackRate * StrengthRate);
        IsDebuff = true;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
        if(StolenGem >= 0)
        {
            for (int i = 0; i < 49; i++)
            {
                if (Pscript.JewelNum[i] == 309)
                {
                    Pscript.JewelNum[i] = Pscript.EquipJewel[StolenGem];
                    GameObject g2 = Instantiate(Pscript.JewelObj[Pscript.EquipJewel[StolenGem]]);
                    g2.transform.position = Pscript.JewelDisplay[i].transform.position;
                    g2.transform.SetParent(Pscript.gameObject.transform, true);
                    Destroy(Pscript.JewelDisplay[i]);
                    Pscript.JewelDisplay[i] = g2;
                    GameObject g3 = Instantiate(Pscript.JewelFlash[Pscript.EquipJewel[StolenGem]]);
                    g3.transform.position = Pscript.JewelDisplay[i].transform.position;
                }
            }
            Act1_3();
        }
        else
        {
            Act1_3();
        }
    }
    void Act1_3()
    {
        StolenGem = Random.Range(0, 5);
        for (int i = 0; i < 49; i++)
        {
            if (Pscript.JewelNum[i] == Pscript.EquipJewel[StolenGem])
            {
                Pscript.JewelNum[i] = 309;
                GameObject g2 = Instantiate(DummyGem);
                g2.transform.position = Pscript.JewelDisplay[i].transform.position;
                g2.transform.SetParent(Pscript.gameObject.transform, true);
                Destroy(Pscript.JewelDisplay[i]);
                Pscript.JewelDisplay[i] = g2;
                GameObject g3 = Instantiate(DummyEffect);
                g3.transform.position = Pscript.JewelDisplay[i].transform.position;
            }
        }
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((50 + Bscript.Iscript.Crown * 4) * AttackRate * StrengthRate);
    }
    void Act2_3()
    {
        Pscript.Debuff_Weak += 25 + Bscript.AbilityLevel * 5;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
    }
}
