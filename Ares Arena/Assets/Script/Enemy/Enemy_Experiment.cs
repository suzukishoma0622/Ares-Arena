using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_Experiment : MonoBehaviour
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
    bool IsDebuff;
    public GameObject DaybreakGem;
    public GameObject DaybreakEffect;
    public int Daybreak;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyStatusLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 5600;
                break;
            case 2:
                Bscript.EnemyMaxHP = 5800;
                break;
            case 3:
                Bscript.EnemyMaxHP = 6000;
                break;
            case 4:
                Bscript.EnemyMaxHP = 6200;
                break;
            case 5:
                Bscript.EnemyMaxHP = 6400;
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
                AttackText[0].text = ((300 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。光輝を付与する。";
                AttackText[1].text = ((640 + Bscript.Iscript.Crown * 40) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。";
                AttackText[2].text = (600 + Bscript.Iscript.Crown * 40).ToString() + "シールドを得る。HPを" + (600 + Bscript.Iscript.Crown * 40).ToString() + "回復する。";
                AttackText[3].text = "光輝の効果が10%加算される。";
                DebuffDesc[0].text = "宝石が出現時、" + Daybreak + "%の確率で極光に変化する。";
                DebuffDesc[1].text = "効果なし。";
                break;
            case 2:
                AttackText[0].text = "Deal " + ((300 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate).ToString("0") + " Damage. Inflict Radiance.";
                AttackText[1].text = "Deal " + ((640 + Bscript.Iscript.Crown * 40) * AttackRate * StrengthRate).ToString("0") + " Damage.";
                AttackText[2].text = "Gain " + (600 + Bscript.Iscript.Crown * 40).ToString() + " Shield. Restore " + (600 + Bscript.Iscript.Crown * 40).ToString() + " HP.";
                AttackText[3].text = "The effect of Radiance is increased by 10%.";
                DebuffDesc[0].text = "It reappears after being cast. When it reaches the bottom row, take " + Daybreak + " Damage.";
                DebuffDesc[1].text = "No effects.";
                break;
        }
        DebuffStuck[0].text = Daybreak.ToString() + "%";
        if (Bscript.IsDefeat)
        {
            IsForecast = false;
            Effect[5].SetActive(false);
        }
        if(IsDebuff)
        {
            for (int i = 0; i < 2; i++)
            {
                DebuffCG[i].alpha += Time.deltaTime * 2f;
                DebuffCG[i].interactable = true;
                DebuffCG[i].blocksRaycasts = true;
            }
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
                ActForecast[(Bscript.CurrentRound - 2) % 3 + 1].alpha += Time.deltaTime * 2f;
                ActForecast[(Bscript.CurrentRound - 2) % 3 + 1].interactable = true;
                ActForecast[(Bscript.CurrentRound - 2) % 3 + 1].blocksRaycasts = true;
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
            switch((Bscript.CurrentRound - 1) % 3)
            {
                case 1:
                    Act2_1();
                    Invoke("Act2_2", 1f);
                    Invoke("ActEnd", 2f);
                    break;
                case 2:
                    Act3_1();
                    Invoke("Act3_2", 1.5f);
                    Invoke("ActEnd", 2.5f);
                    break;
                case 0:
                    Act4_1();
                    Invoke("Act4_2", 2f);
                    Invoke("ActEnd", 3f);
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
        Effect[1].SetActive(true);
        GameObject g = Instantiate(Effect[0]);
        g.transform.position = Effect[0].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[0]);
    }
    void Act1_2()
    {
        GameObject g2 = Instantiate(AttackObj[0]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = true;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((300 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate);
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "光輝";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Radiance";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        Daybreak += 10 + Bscript.AbilityLevel * 5;
        Pscript.DayBreak += 10 + Bscript.AbilityLevel * 5;
        IsDebuff = true;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((640 + Bscript.Iscript.Crown * 40) * AttackRate * StrengthRate);
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
        GameObject g = Instantiate(Effect[4]);
        g.transform.position = Effect[4].transform.position;
        g.SetActive(true);
        GameObject g2 = Instantiate(AttackObj[1]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = false;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((600 + Bscript.Iscript.Crown * 40) * AttackRate * StrengthRate);
        GameObject g3 = Instantiate(AttackObj[2]);
        g3.transform.position = this.transform.position;
        g3.GetComponent<BlockTrail>().GoPlayer = false;
        g3.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((600 + Bscript.Iscript.Crown * 40) * AttackRate * StrengthRate);
    }
    void Act4_1()
    {
        GameObject g = Instantiate(Effect[0]);
        g.transform.position = Effect[0].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[3]);
    }
    void Act4_2()
    {
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "光輝 +10%";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Radiance +10%";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        Daybreak += 10;
        Pscript.DayBreak += 10;
    }
}
