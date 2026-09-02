using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_StoneCastle : MonoBehaviour
{
    public BattleManager Bscript;
    public PuzzleManager Pscript;
    public CanvasGroup[] ActForecast;
    int ActNum1;
    int ActNum2;
    bool[] ActCheck = new bool[8];
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
    bool IsDebuff;
    public CanvasGroup[] BuffCG;
    public TMP_Text BuffStuck;
    public TMP_Text BuffDesc;
    bool IsBuff;
    public GameObject RubbleGem;
    public GameObject RubbleEffect;
    public AudioClip[] EnemySE;

    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyStatusLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 3200;
                break;
            case 2:
                Bscript.EnemyMaxHP = 3400;
                break;
            case 3:
                Bscript.EnemyMaxHP = 3600;
                break;
            case 4:
                Bscript.EnemyMaxHP = 3800;
                break;
            case 5:
                Bscript.EnemyMaxHP = 4000;
                break;
        }
        Bscript.EnemyHP = Bscript.EnemyMaxHP;
    }
    void Update()
    {
        switch (Language)
        {
            case 1:
                AttackText[0].text = ((360 + Bscript.Iscript.Crown * 30) * AttackRate).ToString("0") + "ダメージを与える。";
                AttackText[1].text = ((210 + Bscript.Iscript.Crown * 20) * AttackRate).ToString("0") + "ダメージを与える。弱体化" + (30 + Bscript.AbilityLevel * 5).ToString() + "を付与する。";
                AttackText[2].text = $"ランダムな宝石{8 + Bscript.AbilityLevel * 2}つを瓦礫に変化させる。";
                AttackText[3].text = $"{400 + Bscript.Iscript.Crown * 20}シールドを得る。10%の攻撃激化を得る。";
                AttackText[4].text = ((250 + Bscript.Iscript.Crown * 20) * AttackRate).ToString("0") + "ダメージを与える。";
                AttackText[5].text = $"{150 + Bscript.Iscript.Crown * 20}シールドを得る。HPを{300 + Bscript.Iscript.Crown * 30}回復する。";
                AttackText[6].text = $"{500 + Bscript.Iscript.Crown * 50}シールドを得る。";
                AttackText[7].text = $"20%の攻撃激化を得る。";
                DebuffDesc.text = "次に消去する" + Pscript.Debuff_Weak + "個の宝石の効果が50%減少する。";
                BuffDesc.text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = $"Deal {(360 + Bscript.Iscript.Crown * 30) * AttackRate} Damage.";
                AttackText[1].text = $"Deal {(210 + Bscript.Iscript.Crown * 20) * AttackRate} Damage. Inflict Weak {30 + (Bscript.AbilityLevel * 5)}.";
                AttackText[2].text = $"Transforms {8 + Bscript.AbilityLevel * 2} random gems into Rubble.";
                AttackText[3].text = $"Gain {(400 + Bscript.Iscript.Crown * 20) * AttackRate} Shield. Gain a 20% Intensified.";
                AttackText[4].text = $"Deal {(250 + Bscript.Iscript.Crown * 30) * AttackRate} Damage.";
                AttackText[5].text = $"Gain {(150 + Bscript.Iscript.Crown * 20) * AttackRate} Shield. Restores {300 + Bscript.Iscript.Crown * 30} HP.";
                AttackText[6].text = $"Gain {(500 + Bscript.Iscript.Crown * 50) * AttackRate} Shield.";
                AttackText[7].text = "Gain a 20% Intensified.";
                DebuffDesc.text = "The effect of the next " + Pscript.Debuff_Weak + " gems you cast will be reduced by 50%.";
                BuffDesc.text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        DebuffStuck.text = Pscript.Debuff_Weak.ToString();
        BuffStuck.text = ((AttackRate - 1f) * 100f).ToString("0") + "%";
        if (Bscript.IsDefeat)
        {
            IsForecast = false;
            Effect[9].SetActive(false);
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
        if (IsDebuff)
        {
            DebuffCG[1].alpha += Time.deltaTime * 2f;
            DebuffCG[1].interactable = true;
            DebuffCG[1].blocksRaycasts = true;
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
            ActForecast[ActNum1].alpha += Time.deltaTime * 2f;
            ActForecast[ActNum1].interactable = true;
            ActForecast[ActNum1].blocksRaycasts = true;
            ActForecast[ActNum2].alpha += Time.deltaTime * 2f;
            ActForecast[ActNum2].interactable = true;
            ActForecast[ActNum2].blocksRaycasts = true;
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
        if(Bscript.CurrentRound % 4 == 1)
        {
            for(int i = 0; i < ActCheck.Length; i++)
            {
                ActCheck[i] = false;
            }
        }
        IsForecast = true;
        ActNum1 = Random.Range(0, 4);
        ActNum2 = Random.Range(4, 8);
        for(;ActCheck[ActNum1]; )
        {
            ActNum1 = Random.Range(0, 4);
        }
        for (; ActCheck[ActNum2];)
        {
            ActNum2 = Random.Range(4, 8);
        }
        ActCheck[ActNum1] = true;
        ActCheck[ActNum2] = true;
    }
    void ActEnd()
    {
        Bscript.RoundStart();
        F();
    }
    public void Action()
    {
        IsForecast = false;
        switch(ActNum1)
        {
            case 0:
                Act1_1();
                Invoke("Act1_2", 0.2f);
                break;
            case 1:
                Act2_1();
                Invoke("Act2_2", 0.6f);
                break;
            case 2:
                Act3_1();
                Invoke("Act3_2", 1f);
                break;
            case 3:
                Act4_1();
                Invoke("Act4_2", 0.6f);
                break;
        }
        switch (ActNum2)
        {
            case 4:
                Invoke("Act5_1", 2f);
                Invoke("Act5_2", 2.3f);
                Invoke("ActEnd", 3.3f);
                break;
            case 5:
                Invoke("Act6_1", 2f);
                Invoke("Act6_2", 3f);
                Invoke("ActEnd", 4f);
                break;
            case 6:
                Invoke("Act7_1", 2f);
                Invoke("Act7_2", 2.5f);
                Invoke("ActEnd", 3.5f);
                break;
            case 7:
                Invoke("Act8_1", 2f);
                Invoke("Act8_2", 2.6f);
                Invoke("ActEnd", 3.6f);
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
        GameObject g = Instantiate(Effect[1]);
        g.transform.position = Effect[1].transform.position;
        g.SetActive(true);
        GameObject g2 = Instantiate(AttackObj[0]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = true;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((360 + Bscript.Iscript.Crown * 30) * AttackRate * StrengthRate);
    }
    void Act2_1()
    {
        GameObject g = Instantiate(Effect[2]);
        g.transform.position = Effect[2].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[1]);
    }
    void Act2_2()
    {
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((210 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate);
        Pscript.Debuff_Weak += 30 + Bscript.AbilityLevel * 5;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
    }
    void Act3_1()
    {
        GameObject g = Instantiate(Effect[3]);
        g.transform.position = Effect[3].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[2]);
    }
    void Act3_2()
    {
        for (int i = 0; i < 8; i++)
        {
            int Judge = Random.Range(0, 49);
            for (; Pscript.JewelNum[Judge] == 305;)
            {
                Judge = Random.Range(0, 49);
            }
            Pscript.JewelNum[Judge] = 305;
            GameObject g2 = Instantiate(RubbleGem);
            g2.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g2.transform.SetParent(Pscript.gameObject.transform, true);
            Destroy(Pscript.JewelDisplay[Judge]);
            Pscript.JewelDisplay[Judge] = g2;
            GameObject g3 = Instantiate(RubbleEffect);
            g3.transform.position = Pscript.JewelDisplay[Judge].transform.position;
        }
        IsDebuff = true;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
    }
    void Act4_1()
    {
        GameObject g = Instantiate(Effect[4]);
        g.transform.position = Effect[4].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[3]);
    }
    void Act4_2()
    {
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = false;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((400 + Bscript.Iscript.Crown * 20) * StrengthRate);
        GameObject g2 = Instantiate(Counter);
        g2.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g2.GetComponent<InfoDisplay_Counter>().Thisnum = "攻撃激化 +10%";
                break;
            case 2:
                g2.GetComponent<InfoDisplay_Counter>().Thisnum = "Intensified +10%";
                break;
        }
        g2.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g2.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g2.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g2.SetActive(true);
        AttackRate += 0.1f;
        IsBuff = true;
    }
    void Act5_1()
    {
        GameObject g = Instantiate(Effect[5]);
        g.transform.position = Effect[5].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[4]);
    }
    void Act5_2()
    {
        GameObject g2 = Instantiate(AttackObj[0]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = true;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((250 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate);
    }
    void Act6_1()
    {
        GameObject g = Instantiate(Effect[6]);
        g.transform.position = Effect[6].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[5]);
    }
    void Act6_2()
    {
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = false;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((150 + Bscript.Iscript.Crown * 20) * StrengthRate);
        GameObject g2 = Instantiate(AttackObj[2]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = false;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((300 + Bscript.Iscript.Crown * 30) * StrengthRate);
    }
    void Act7_1()
    {
        GameObject g = Instantiate(Effect[7]);
        g.transform.position = Effect[7].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[6]);
    }
    void Act7_2()
    {
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = false;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((150 + Bscript.Iscript.Crown * 20) * StrengthRate);
    }
    void Act8_1()
    {
        GameObject g = Instantiate(Effect[8]);
        g.transform.position = Effect[8].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[7]);
    }
    void Act8_2()
    {
        GameObject g2 = Instantiate(Counter);
        g2.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g2.GetComponent<InfoDisplay_Counter>().Thisnum = "攻撃激化 +20%";
                break;
            case 2:
                g2.GetComponent<InfoDisplay_Counter>().Thisnum = "Intensified +20%";
                break;
        }
        g2.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g2.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g2.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g2.SetActive(true);
        AttackRate += 0.2f;
        IsBuff = true;
    }
}
