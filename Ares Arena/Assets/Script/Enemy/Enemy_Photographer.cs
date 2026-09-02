using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy_Photographer : MonoBehaviour
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
    public Volume Monochrome;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyStatusLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1240;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1300;
                break;
            case 3:
                Bscript.EnemyMaxHP = 1360;
                break;
            case 4:
                Bscript.EnemyMaxHP = 1420;
                break;
            case 5:
                Bscript.EnemyMaxHP = 1490;
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
                AttackText[0].text = ((150 + Bscript.Iscript.Crown * 20) * StrengthRate).ToString("0") + "シールドを得る。失魂を付与する。";
                AttackText[1].text = ((210 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。与えたダメージに等しいHPを回復する。";
                AttackText[2].text = "弱体化" + (40 + Bscript.AbilityLevel * 10).ToString() + $"を付与する。{(200 + Bscript.Iscript.Crown * 20) * StrengthRate}シールドを得る。";
                AttackText[3].text = $"最大HPを{40 * StrengthRate}奪う。HPを{(40 + Bscript.Iscript.Crown * 10) * StrengthRate}回復する。";
                DebuffName.text = "弱体化";
                DebuffDesc.text = "次に消去する" + Pscript.Debuff_Weak + "個の宝石の効果が50%減少する。";
                break;
            case 2:
                AttackText[0].text = $"Gain {(150 + Bscript.Iscript.Crown * 20) * StrengthRate} Shield. Inflict LostSoul.";
                AttackText[1].text = $"Deal {(210 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate} Damage. Restores HP equal to the damage dealt.";
                AttackText[2].text = $"Inflict {(40 + Bscript.AbilityLevel * 10) * StrengthRate} Weak. Gain {(200 + Bscript.Iscript.Crown * 30) * StrengthRate} Shield.";
                AttackText[3].text = $"Steals {40 * StrengthRate} Max HP. Restores {(40 + Bscript.Iscript.Crown * 10) * StrengthRate} HP.";
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
            if (!Bscript.IsDefeat && !Bscript.IsDead)
            {
                if (Monochrome.weight < 1f)
                {
                    Monochrome.weight += Time.deltaTime;
                }
            }
            else
            {
                Monochrome.weight -= Time.deltaTime;
            }
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
            if (Bscript.CurrentRound == 1)
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
            IsChat = true;
            switch (Language)
            {
                case 1:
                    ChatText.text = "ポーズを決めて！";
                    break;
                case 2:
                    ChatText.text = "Strike a pose!";
                    break;
            }
            Invoke("OutChat", 1.5f);
            Invoke("Act1_1", 1.5f);
            Invoke("Act1_2", 2f);
            Invoke("InChat", 2.5f);
            Invoke("OutChat", 4f);
            Invoke("ActEnd", 4f);
        }
        else
        {
            switch((Bscript.CurrentRound - 2) % 3 + 1)
            {
                case 1:
                    Act2_1();
                    Invoke("Act2_2", 1.9f);
                    Invoke("ActEnd", 2.9f);
                    break;
                case 2:
                    Act3_1();
                    Invoke("Act3_2", 0.5f);
                    Invoke("ActEnd", 1.5f);
                    break;
                case 3:
                    Act4_1();
                    Invoke("Act4_2", 0.7f);
                    Invoke("ActEnd", 1.7f);
                    break;
            }
        }
    }
    void InChat()
    {
        IsChat = true;
        switch (Language)
        {
            case 1:
                ChatText.text = "始めましょう。";
                break;
            case 2:
                ChatText.text = "Let's begin.";
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
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = false;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((150 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((210 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate);
        GameObject g2 = Instantiate(AttackObj[2]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = false;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.Max(Mathf.FloorToInt(((210 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate) - Bscript.PlayerShield), 0);
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
        Pscript.Debuff_Weak += 40 + Bscript.AbilityLevel * 10;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = false;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((200 + Bscript.Iscript.Crown * 30) * AttackRate * StrengthRate);
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
        Bscript.Iscript.PlayerMaxHP -= Mathf.FloorToInt(40 * StrengthRate);
        if(Bscript.Iscript.PlayerMaxHP <= 0)
        {
            Bscript.Iscript.PlayerMaxHP = 1;
        }
        if(Bscript.Iscript.PlayerHP > Bscript.Iscript.PlayerMaxHP)
        {
            Bscript.Iscript.PlayerHP = Bscript.Iscript.PlayerMaxHP;
        }
        GameObject g2 = Instantiate(AttackObj[2]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = false;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((40 + Bscript.Iscript.Crown * 10) * StrengthRate);
    }
}
