using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_DarkMage : MonoBehaviour
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
    public CanvasGroup[] BuffCG;
    public TMP_Text BuffStuck;
    public TMP_Text BuffName;
    public TMP_Text BuffDesc;
    bool IsDebuff;
    bool IsBuff;
    public GameObject BlindEffect;
    int[] Blindnum = new int[49];
    GameObject[] BlindObj = new GameObject[10];

    int AJ;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyStatusLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1310;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1360;
                break;
            case 3:
                Bscript.EnemyMaxHP = 1410;
                break;
            case 4:
                Bscript.EnemyMaxHP = 1460;
                break;
            case 5:
                Bscript.EnemyMaxHP = 1510;
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
                AttackText[0].text = "盤上の" + (10 + Bscript.AbilityLevel * 2).ToString() + "箇所を暗闇状態にする。";
                AttackText[1].text = ((180 + Bscript.Iscript.Crown * 15) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。弱体化" + (15 + Bscript.AbilityLevel * 5).ToString() + "を付与する。";
                AttackText[2].text = (100 * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。20%の攻撃激化を得る。";
                DebuffName.text = "弱体化";
                DebuffDesc.text = "次に消去する" + Pscript.Debuff_Weak + "個の宝石の効果が50%減少する。";
                BuffName.text = "攻撃激化";
                BuffDesc.text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = (10 + Bscript.AbilityLevel * 2).ToString() + " locations on the board makes blind.";
                AttackText[1].text = "Deal " + ((180 + Bscript.Iscript.Crown * 15) * AttackRate * StrengthRate).ToString("0") + " Damage. Inflict Weak " + (15 + Bscript.AbilityLevel * 5).ToString() +  ".";
                AttackText[2].text = "Deal " + (100 * AttackRate * StrengthRate).ToString("0") + " Damage. Gain a 20% Intensified.";
                DebuffName.text = "Weak";
                DebuffDesc.text = "The effect of the next " + Pscript.Debuff_Weak + " gems you cast will be reduced by 50%.";
                BuffName.text = "Intensified";
                BuffDesc.text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        DebuffStuck.text = Pscript.Debuff_Weak.ToString();
        BuffStuck.text = ((AttackRate - 1f) * 100f).ToString("0") + "%";
        if (Bscript.IsDefeat)
        {
            Effect[3].SetActive(false);
            IsForecast = false;
            for (int i = 0; i < 10; i++)
            {
                if (BlindObj[i] != null)
                {
                    Destroy(BlindObj[i]);
                }
            }
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
            IsChat = true;
            int j = Random.Range(0, 2);
            switch (Language)
            {
                case 1:
                    ChatText.text = "こっちへおいで…";
                    break;
                case 2:
                    ChatText.text = "Come over here...";
                    break;
            }
            Invoke("OutChat", 1.5f);
            Invoke("Act1_1", 1.5f);
            Invoke("Act1_2", 2.5f);
            Invoke("ActEnd", 3.5f);
        }
        else
        {
            switch(AJ)
            {
                case 0:
                    Act2_1();
                    Act2_2();
                    Invoke("Act2_3", 0.5f);
                    Invoke("ActEnd", 1.5f);
                    break;
                case 1:
                    Act3_1();
                    Invoke("Act3_2", 0.5f);
                    Invoke("Act3_3", 0.7f);
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
    }
    void Act1_2()
    {
        IsDebuff = true;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
        for (int i = 0; i < 10 + Bscript.AbilityLevel * 2; i++)
        {
            int Judge = Random.Range(0, 49);
            for(; Blindnum[Judge] == 1; )
            {
                Judge = Random.Range(0, 49);
            }
            Blindnum[Judge] = 1;
            GameObject g2 = Instantiate(BlindEffect);
            g2.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g2.SetActive(true);
            g2.transform.SetParent(this.transform, true);
            BlindObj[i] = g2;
        }
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((180 + Bscript.Iscript.Crown * 15) * AttackRate * StrengthRate);
    }
    void Act2_3()
    {
        Pscript.Debuff_Weak += 15 + Bscript.AbilityLevel * 5;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
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
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(100 * AttackRate * StrengthRate);
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
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Attack Power +20%";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        AttackRate += 0.2f;
        IsBuff = true;
        AJ = Random.Range(0, 2);
    }
}
