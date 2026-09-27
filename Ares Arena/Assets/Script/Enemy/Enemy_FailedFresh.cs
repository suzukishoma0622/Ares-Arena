using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_FailedFresh : MonoBehaviour
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
    public CanvasGroup[] BuffCG;
    public TMP_Text BuffStuck;
    public TMP_Text BuffDesc;
    bool IsBuff;
    public CanvasGroup[] DebuffCG;
    public TMP_Text DebuffStuck;
    public TMP_Text[] DebuffDesc;
    bool IsDebuff;
    bool IsDebuff2;
    public GameObject FreshGem;
    public GameObject FreshEffect;
    public int Corruption;
    bool IsC;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 6900;
                break;
            case 2:
                Bscript.EnemyMaxHP = 7400;
                break;
        }
    }
    void Update()
    {
        switch (Language)
        {
            case 1:
                AttackText[0].text = "腐敗を付与する。";
                AttackText[1].text = $"{Mathf.FloorToInt((400 + Bscript.AttackLevel * 40) * AttackRate)}ダメージを与える。";
                AttackText[2].text = $"ランダムな宝石{10 + Bscript.AbilityLevel * 2}つをフレッシュジェムに変化させる。";
                AttackText[3].text = $"{Mathf.FloorToInt((280 + Bscript.AttackLevel * 20) * AttackRate)}ダメージを与える。弱体化{40 + Bscript.AbilityLevel * 10}を付与する。";
                AttackText[4].text = $"HPを{Mathf.FloorToInt(800 + Bscript.HPLevel * 100)}回復する。20%の攻撃激化を得る。";
                DebuffDesc[0].text = "この戦闘中、HPの最大値が70%減少する。";
                DebuffDesc[1].text = "次に消去する" + Pscript.Debuff_Weak + "個の宝石の効果が50%減少する。";
                BuffDesc.text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = "Inflict Corruption.";
                AttackText[1].text = $"Deal {Mathf.FloorToInt((400 + Bscript.AttackLevel * 40) * AttackRate)} Damage.";
                AttackText[2].text = $"Transforms {10 + Bscript.AbilityLevel * 2} random gems into Fresh Gems.";
                AttackText[3].text = $"Deal {Mathf.FloorToInt((28 + Bscript.AttackLevel * 20) * AttackRate)} Damage. Inflict {40 + Bscript.AbilityLevel * 10} Weak.";
                AttackText[4].text = $"Restore {Mathf.FloorToInt(800 + Bscript.HPLevel * 100)} HP. Gain 20% Intensified.";
                DebuffDesc[0].text = "During this battle, maximum HP is reduced by 70%.";
                DebuffDesc[1].text = "The effect of the next " + Pscript.Debuff_Weak + " gems you cast will be reduced by 50%.";
                BuffDesc.text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        if (Bscript.IsDefeat)
        {
            IsForecast = false;
            if(!IsC)
            {
                Pscript.Iscript.PlayerMaxHP += Corruption;
                Pscript.Iscript.PlayerHP += Corruption;
                IsC = true;
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
        if (IsDebuff2)
        {
            DebuffCG[2].alpha += Time.deltaTime * 2f;
            DebuffCG[2].interactable = true;
            DebuffCG[2].blocksRaycasts = true;
        }
        if (IsBuff)
        {
            BuffCG[0].alpha += Time.deltaTime * 2f;
            BuffCG[0].interactable = true;
            BuffCG[0].blocksRaycasts = true;
        }
        DebuffStuck.text = Pscript.Debuff_Weak.ToString();
        BuffStuck.text = ((AttackRate - 1f) * 100f).ToString("0") + "%";
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
                ActForecast[(Bscript.CurrentRound - 2) % 4 + 1].alpha += Time.deltaTime * 2f;
                ActForecast[(Bscript.CurrentRound - 2) % 4 + 1].interactable = true;
                ActForecast[(Bscript.CurrentRound - 2) % 4 + 1].blocksRaycasts = true;
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
            Invoke("Act1_2", 2f);
            Invoke("ActEnd", 3f);
        }
        else
        {
            switch((Bscript.CurrentRound - 1) % 4)
            {
                case 1:
                    Act2_1();
                    Invoke("Act2_2", 0.4f);
                    Invoke("ActEnd", 1.4f);
                    break;
                case 2:
                    Act3_1();
                    Invoke("Act3_2", 1f);
                    Invoke("ActEnd", 2f);
                    break;
                case 3:
                    Act4_1();
                    Invoke("Act4_2", 0.8f);
                    Invoke("ActEnd", 1.8f);
                    break;
                case 0:
                    Act5_1();
                    Invoke("Act5_2", 0.4f);
                    Invoke("ActEnd", 1.4f);
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
        Corruption = Mathf.FloorToInt(Pscript.Iscript.PlayerMaxHP * 0.7f);
        Pscript.Iscript.PlayerMaxHP -= Corruption;
        if(Pscript.Iscript.PlayerMaxHP < Pscript.Iscript.PlayerHP)
        {
            Pscript.Iscript.PlayerHP = Pscript.Iscript.PlayerMaxHP;
        }
        IsDebuff = true;
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((400 + Bscript.AttackLevel * 40) * AttackRate * StrengthRate);
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
        for (int i = 0; i < 10 + Bscript.AbilityLevel * 2; i++)
        {
            int Judge = Random.Range(0, 49);
            for (; Pscript.JewelNum[Judge] == 308;)
            {
                Judge = Random.Range(0, 49);
            }
            Pscript.JewelNum[Judge] = 308;
            GameObject g2 = Instantiate(FreshGem);
            g2.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g2.transform.SetParent(Pscript.gameObject.transform, true);
            Destroy(Pscript.JewelDisplay[Judge]);
            Pscript.JewelDisplay[Judge] = g2;
            GameObject g3 = Instantiate(FreshEffect);
            g3.transform.position = Pscript.JewelDisplay[Judge].transform.position;
        }
        IsDebuff2 = true;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((280 + Bscript.AttackLevel * 20) * AttackRate * StrengthRate);
        Pscript.Debuff_Weak += 40 + Bscript.AbilityLevel * 10;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
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
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = false;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((800 + Bscript.HPLevel * 100) * AttackRate * StrengthRate);
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
