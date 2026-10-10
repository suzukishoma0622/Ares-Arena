using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_Ares : MonoBehaviour
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
    public TMP_Text[] BuffStuck;
    public TMP_Text[] BuffDesc;
    bool IsBuff;
    public CanvasGroup[] DebuffCG;
    public TMP_Text[] DebuffStuck;
    public TMP_Text[] DebuffDesc;
    bool IsDebuff;
    public GameObject BlackstarGem;
    public GameObject BlackstarEffect;
    public int Blackstar;
    public AudioClip[] EnemySE;

    public int Mastering = 2000;
    public bool IsRigid;
    bool Phase2;
    int Phase2Count;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 9800;
                break;
            case 2:
                Bscript.EnemyMaxHP = 10600;
                break;
        }
        Bscript.EnemyMaxHP = Mathf.FloorToInt(Bscript.EnemyMaxHP);
        Bscript.EnemyHP = Bscript.EnemyMaxHP;
    }
    void Update()
    {
        switch (Language)
        {
            case 1:
                AttackText[0].text = "燦然を付与する。";
                AttackText[1].text = $"{Mathf.FloorToInt((700 + Bscript.AttackLevel * 60) * AttackRate)}ダメージを与える。";
                AttackText[2].text = $"弱体化{30 + Bscript.AbilityLevel * 10}を付与する。麻痺3を付与する。消尽1を付与する。";
                AttackText[3].text = $"{Mathf.FloorToInt((350 + Bscript.AttackLevel * 30) * AttackRate)}ダメージを与える。剛体を付与する。";
                AttackText[4].text = "10%の攻撃激化を得る。";
                AttackText[5].text = $"{Mathf.FloorToInt((1300 + Bscript.AttackLevel * 100) * AttackRate)}ダメージを与える。";
                AttackText[6].text = "10%の攻撃激化を得る。燦然の効果が5%増加する。";
                DebuffDesc[0].text = "宝石が出現時、" + Blackstar + "%の確率でブラックスターに変化する。";
                DebuffDesc[1].text = $"次に消去する{Pscript.Debuff_Weak}個の宝石の効果が50%減少する。";
                DebuffDesc[2].text = $"このターン、ハンド数が{Pscript.Debuff_Lightning}減少する。";
                DebuffDesc[3].text = $"次の{Pscript.Debuff_Exhaustion}回、ダメージを受けてもリベンジがチャージされない。";
                DebuffDesc[4].text = "このターン、HPを回復できない。";
                BuffDesc[0].text = $"2500ダメージを受ける毎に1000シールドを得る。";
                BuffDesc[1].text = $"与えるダメージが{Mathf.FloorToInt((AttackRate - 1f) * 100f)}%増加する。";
                break;
            case 2:
                AttackText[0].text = "Inflict Brilliance.";
                AttackText[1].text = $"Deal {Mathf.FloorToInt((700 + Bscript.AttackLevel * 60) * AttackRate)} Damage.";
                AttackText[2].text = $"Inflict {30 + Bscript.AbilityLevel * 10} Weak. Inflict 3 Paralysis. Inflict 1 Exhaustion.";
                AttackText[3].text = $"Deal {Mathf.FloorToInt((350 + Bscript.AttackLevel * 30) * AttackRate)} Damage. Inflict Rigidbody.";
                AttackText[4].text = "Gain 10% Intensified.";
                AttackText[5].text = $"Deal {Mathf.FloorToInt((1300 + Bscript.AttackLevel * 100) * AttackRate)} Damage.";
                AttackText[6].text = "Gain 10% Intensified. The effect of Brilliance increases 5%.";
                DebuffDesc[0].text = "When a gem appears, there is a " + Blackstar + "% chance it will transform into a Daybreak.";
                DebuffDesc[1].text = $"The effect of the next {Pscript.Debuff_Weak} gems you cast will be reduced by 50%.";
                DebuffDesc[2].text = $"This turn, the number of hand decreases by {Pscript.Debuff_Lightning}.";
                DebuffDesc[3].text = $"Revenge will not charge when taking damage for the next {Pscript.Debuff_Exhaustion} instances.";
                DebuffDesc[4].text = "You cannot restore HP this turn.";
                BuffDesc[0].text = "Gain 1000 Shield for every 2500 damage taken.";
                BuffDesc[1].text = $"Damage dealt is increased by{Mathf.FloorToInt((AttackRate - 1f) * 100f)}%.";
                break;
        }
        DebuffStuck[0].text = Blackstar.ToString() + "%";
        DebuffStuck[1].text = Pscript.Debuff_Weak.ToString();
        DebuffStuck[2].text = Pscript.Debuff_Lightning.ToString();
        DebuffStuck[3].text = Pscript.Debuff_Exhaustion.ToString();
        BuffStuck[0].text = Mastering.ToString();
        BuffStuck[1].text = $"{Mathf.FloorToInt((AttackRate - 1f) * 100f)}%";

        if(IsDebuff)
        {
            DebuffCG[0].alpha += Time.deltaTime * 2f;
            DebuffCG[0].interactable = true;
            DebuffCG[0].blocksRaycasts = true;
            DebuffCG[5].alpha += Time.deltaTime * 2f;
            DebuffCG[5].interactable = true;
            DebuffCG[5].blocksRaycasts = true;
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
        if (Pscript.Debuff_Lightning > 0)
        {
            DebuffCG[2].alpha += Time.deltaTime * 2f;
            DebuffCG[2].interactable = true;
            DebuffCG[2].blocksRaycasts = true;
        }
        else
        {
            DebuffCG[2].alpha -= Time.deltaTime * 2f;
            DebuffCG[2].interactable = false;
            DebuffCG[2].blocksRaycasts = false;
        }
        if (Pscript.Debuff_Exhaustion > 0)
        {
            DebuffCG[3].alpha += Time.deltaTime * 2f;
            DebuffCG[3].interactable = true;
            DebuffCG[3].blocksRaycasts = true;
        }
        else
        {
            DebuffCG[3].alpha -= Time.deltaTime * 2f;
            DebuffCG[3].interactable = false;
            DebuffCG[3].blocksRaycasts = false;
        }
        if (IsRigid)
        {
            DebuffCG[4].alpha += Time.deltaTime * 2f;
            DebuffCG[4].interactable = true;
            DebuffCG[4].blocksRaycasts = true;
        }
        else
        {
            DebuffCG[4].alpha -= Time.deltaTime * 2f;
            DebuffCG[4].interactable = false;
            DebuffCG[4].blocksRaycasts = false;
        }
        if (IsBuff)
        {
            BuffCG[1].alpha += Time.deltaTime * 2f;
            BuffCG[1].interactable = true;
            BuffCG[1].blocksRaycasts = true;
        }

        if (Bscript.IsDefeat)
        {
            IsForecast = false;
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
        if (IsForecast && !Bscript.IsDefeat)
        {
            if (Phase2)
            {
                if (Phase2Count <= 2)
                {
                    ActForecast[Phase2Count + 4].alpha += Time.deltaTime * 2f;
                    ActForecast[Phase2Count + 4].interactable = true;
                    ActForecast[Phase2Count + 4].blocksRaycasts = true;
                }
                else
                {
                    ActForecast[(Phase2Count - 3) % 4 + 1].alpha += Time.deltaTime * 2f;
                    ActForecast[(Phase2Count - 3) % 4 + 1].interactable = true;
                    ActForecast[(Phase2Count - 3) % 4 + 1].blocksRaycasts = true;
                }
            }
            else
            {
                if (Bscript.CurrentRound == 1)
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
        if (Bscript.EnemyHP <= Bscript.EnemyMaxHP / 2)
        {
            Phase2 = true;
            Phase2Count += 1;
        }
    }
    public void Action()
    {
        IsForecast = false;
        if(Bscript.CurrentRound == 1)
        {
            Act1_1();
            Invoke("Act1_2", 1f);
            Invoke("ActEnd", 2f);
        }
        else if (Phase2)
        {
            if (Phase2Count <= 2)
            {
                switch (Phase2Count)
                {
                    case 1:
                        Act6_1();
                        Invoke("Act6_2", 0.6f);
                        Invoke("ActEnd", 1.6f);
                        break;
                    case 2:
                        Act7_1();
                        Invoke("Act5_2", 1f);
                        Invoke("Act7_2", 1.3f);
                        Invoke("ActEnd", 2.3f);
                        break;
                }
            }
            else
            {
                switch ((Phase2Count - 3) % 4)
                {
                    case 0:
                        Act2_1();
                        Invoke("Act2_2", 0.3f);
                        Invoke("ActEnd", 1.3f);
                        break;
                    case 1:
                        Act3_1();
                        Invoke("Act3_2", 0.8f);
                        Invoke("ActEnd", 1.8f);
                        break;
                    case 2:
                        Act4_1();
                        Invoke("Act4_2", 0.8f);
                        Invoke("ActEnd", 1.8f);
                        break;
                    case 3:
                        Act5_1();
                        Invoke("Act5_2", 1f);
                        Invoke("ActEnd", 2f);
                        break;
                }
            }
        }
        else
        {
            switch ((Bscript.CurrentRound - 2) % 4)
            {
                case 0:
                    Act2_1();
                    Invoke("Act2_2", 0.3f);
                    Invoke("ActEnd", 1.3f);
                    break;
                case 1:
                    Act3_1();
                    Invoke("Act3_2", 0.8f);
                    Invoke("ActEnd", 1.8f);
                    break;
                case 2:
                    Act4_1();
                    Invoke("Act4_2", 0.8f);
                    Invoke("ActEnd", 1.8f);
                    break;
                case 3:
                    Act5_1();
                    Invoke("Act5_2", 1f);
                    Invoke("ActEnd", 2f);
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
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "燦然";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Briliance";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        Blackstar += 5;
        Pscript.Blackstar += 5;
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((700 + Bscript.AttackLevel * 60) * AttackRate * StrengthRate);
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
        Pscript.Debuff_Weak = 30 + Bscript.AbilityLevel * 10;
        Pscript.Debuff_Lightning = 3;
        Pscript.Debuff_Exhaustion = 1;
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((350 + Bscript.AttackLevel * 30) * AttackRate * StrengthRate);
        IsRigid = true;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
    }
    void Act5_1()
    {
        IsRigid = false;
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
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "攻撃激化 +10%";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Brilliance +10%";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        AttackRate += 0.1f;
        IsBuff = true;
    }
    void Act6_1()
    {
        IsRigid = false;
        GameObject g = Instantiate(Effect[5]);
        g.transform.position = Effect[5].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[5]);
    }
    void Act6_2()
    {
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((1300 + Bscript.AttackLevel * 100) * AttackRate * StrengthRate);
    }
    void Act7_1()
    {
        GameObject g = Instantiate(Effect[6]);
        g.transform.position = Effect[6].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[6]);
    }
    void Act7_2()
    {
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "燦然 +5%";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Brilliance +5%";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        Blackstar += 5;
        Pscript.Blackstar += 5;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
    }
}
