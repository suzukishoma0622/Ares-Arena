using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_BusterConstruct : MonoBehaviour
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
    public TMP_Text DebuffDesc;
    public CanvasGroup[] BuffCG;
    public TMP_Text BuffStuck;
    public TMP_Text BuffDesc;
    bool IsBuff;
    public TMP_Text MetalStuck;
    public TMP_Text MetalDesc;
    public int MetalBoby = 400;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 5300;
                break;
            case 2:
                Bscript.EnemyMaxHP = 5600;
                break;
        }
        Bscript.EnemyHP = Bscript.EnemyMaxHP;
        MetalBoby = 400 + PlayerPrefs.GetInt("EnemyHPLevel", 0) * 50;
    }
    void Update()
    {
        switch (Language)
        {
            case 1:
                AttackText[0].text = ((450 + Bscript.AttackLevel * 30) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。";
                AttackText[1].text = ((180 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。弱体化" + (50 + Bscript.AbilityLevel * 10).ToString() + "を付与する。";
                AttackText[2].text = "金属体の効果が200増加する。";
                AttackText[3].text = ((1200 + Bscript.AttackLevel * 100) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。";
                AttackText[4].text = "20%の攻撃激化を得る。";
                DebuffDesc.text = "次に消去する" + Pscript.Debuff_Weak + "個の宝石の効果が50%減少する。";
                MetalDesc.text = "ターン終了時、" + MetalBoby + "シールドを得る。";
                BuffDesc.text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = "Deal " + ((450 + Bscript.AttackLevel * 30) * AttackRate * StrengthRate).ToString("0") + " Damage.";
                AttackText[1].text = "Deal " + ((180 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate).ToString("0") + " Damage. Inflict Weak " + (50 + Bscript.AbilityLevel * 10).ToString() + ".";
                AttackText[2].text = "Gain Metal Body 200.";
                AttackText[3].text = "Deal " + ((1200 + Bscript.AttackLevel * 40) * AttackRate * StrengthRate).ToString("0") + " Damage.";
                AttackText[4].text = "Gain a 20% Intensified.";
                DebuffDesc.text = "The effect of the next " + Pscript.Debuff_Weak + " gems you cast will be reduced by 50%.";
                MetalDesc.text = "At the end of turn, gain " + MetalBoby + " Shield.";
                BuffDesc.text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        DebuffStuck.text = Pscript.Debuff_Weak.ToString();
        BuffStuck.text = ((AttackRate - 1f) * 100f).ToString("0") + "%";
        if (Bscript.IsDefeat)
        {
            IsForecast = false;
        }
        if (Pscript.Debuff_Weak > 0)
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
            ActForecast[(Bscript.CurrentRound - 1) % 5].alpha += Time.deltaTime * 2f;
            ActForecast[(Bscript.CurrentRound - 1) % 5].interactable = true;
            ActForecast[(Bscript.CurrentRound - 1) % 5].blocksRaycasts = true;
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
        MetalShield();
        Bscript.RoundStart();
        IsForecast = true;
    }
    public void Action()
    {
        IsForecast = false;
        switch((Bscript.CurrentRound - 1) % 5)
        {
            case 0:
                Act1_1();
                Invoke("Act1_2", 0.2f);
                Invoke("ActEnd", 1.5f);
                break;
            case 1:
                Act2_1();
                Invoke("Act2_2", 0.4f);
                Invoke("Act2_3", 0.6f);
                Invoke("ActEnd", 1.6f);
                break;
            case 2:
                Act3_1();
                Invoke("Act3_2", 1.2f);
                Invoke("ActEnd", 2.2f);
                break;
            case 3:
                Act4_1();
                Invoke("Act4_2", 1f);
                Invoke("ActEnd", 2.3f);
                break;
            case 4:
                Act5_1();
                Invoke("Act5_2", 0.5f);
                Invoke("ActEnd", 1.5f);
                break;
        }
    }
    void OutChat()
    {
        IsChat = false;
    }
    void MetalShield()
    {
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = false;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(MetalBoby);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((450 + Bscript.AttackLevel * 30) * AttackRate * StrengthRate);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((180 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate);
    }
    void Act2_3()
    {
        Pscript.Debuff_Weak += 50 + Bscript.AbilityLevel * 10;
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
        MetalBoby += 200;
        MetalStuck.text = MetalBoby.ToString();
        switch(Language)
        {
            case 1:
                MetalDesc.text = "ターン終了時、" + MetalBoby.ToString() + "シールドを得る。";
                break;
            case 2:
                MetalDesc.text = "At the end of turn, gain " + MetalBoby.ToString() + " Shield.";
                break;
        }
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "金属体 +200";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Metal Body +200";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
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
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((1200 + Bscript.AttackLevel * 100) * AttackRate * StrengthRate);
    }
    void Act5_1()
    {
        GameObject g = Instantiate(Effect[4]);
        g.transform.position = Effect[4].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[4]);
    }
    void Act5_2()
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
