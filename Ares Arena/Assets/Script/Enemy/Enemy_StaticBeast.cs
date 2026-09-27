using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_StaticBeast : MonoBehaviour
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

    public CanvasGroup DebuffCG;
    public TMP_Text DebuffStuck;
    public TMP_Text DebuffDesc;
    public CanvasGroup BuffCG;
    public TMP_Text BuffStuck;
    public TMP_Text BuffDesc;
    public AudioClip[] EnemySE;

    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1620;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1740;
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
                AttackText[0].text = $"{Mathf.FloorToInt((50 + Bscript.AttackLevel * 10) * StrengthRate * AttackRate)}ダメージを与える。弱体化{30 + 10 * Bscript.AbilityLevel}を付与する。";
                AttackText[1].text = $"{Mathf.FloorToInt((80 + Bscript.AttackLevel * 10) * StrengthRate * AttackRate)}ダメージを与える。";
                AttackText[2].text = $"{Mathf.FloorToInt((130 + Bscript.AttackLevel * 10) * StrengthRate * AttackRate)}ダメージを与える。攻撃激化の値が半減する。";
                DebuffDesc.text = "次に消去する" + Pscript.Debuff_Weak + "個の宝石の効果が50%減少する。";
                BuffDesc.text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = $"Deal {Mathf.FloorToInt((50 + Bscript.AttackLevel * 10) * StrengthRate * AttackRate)} Damage. Inflict {30 + 10 * Bscript.AbilityLevel} Weak.";
                AttackText[1].text = $"Deal {Mathf.FloorToInt((80 + Bscript.AttackLevel * 10) * StrengthRate * AttackRate)} Damage.";
                AttackText[2].text = $"Deal {Mathf.FloorToInt((130 + Bscript.AttackLevel * 10) * StrengthRate * AttackRate)} Damage. The value of the attack intensification is halved.";
                DebuffDesc.text = "The effect of the next " + Pscript.Debuff_Weak + " gems you cast will be reduced by 50%.";
                BuffDesc.text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        DebuffStuck.text = Pscript.Debuff_Weak.ToString();
        BuffStuck.text = ((AttackRate - 1f) * 100f).ToString("0") + "%";
        if (Pscript.Debuff_Weak > 0)
        {
            DebuffCG.alpha += Time.deltaTime * 2f;
            DebuffCG.interactable = true;
            DebuffCG.blocksRaycasts = true;
        }
        else
        {
            DebuffCG.alpha -= Time.deltaTime * 2f;
            DebuffCG.interactable = false;
            DebuffCG.blocksRaycasts = false;
        }
        if (AttackRate > 1f)
        {
            BuffCG.alpha += Time.deltaTime * 2f;
            BuffCG.interactable = true;
            BuffCG.blocksRaycasts = true;
        }
        if (IsChat)
        {
            EnemyChat.alpha += Time.deltaTime * 2f;
        }
        else
        {
            EnemyChat.alpha -= Time.deltaTime * 2f;
        }
        if (Bscript.IsR)
        {
            Action();
            Bscript.IsR = false;
        }
        if (IsForecast && !Bscript.IsDefeat)
        {
            ActForecast[(Bscript.CurrentRound - 1) % 3].alpha += Time.deltaTime * 2f;
            ActForecast[(Bscript.CurrentRound - 1) % 3].interactable = true;
            ActForecast[(Bscript.CurrentRound - 1) % 3].blocksRaycasts = true;
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
        switch ((Bscript.CurrentRound - 1) % 3)
        {
            case 0:
                Act1_1();
                Invoke("Act1_2", 0.4f);
                Invoke("ActEnd", 1.4f);
                break;
            case 1:
                Act2_1();
                Invoke("Act2_2", 0.3f);
                Invoke("ActEnd", 1.3f);
                break;
            case 2:
                Act3_1();
                Invoke("Act3_2", 0.5f);
                Invoke("ActEnd", 1.5f);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((50 + Bscript.AttackLevel * 10) * StrengthRate * AttackRate);
        Pscript.Debuff_Weak += 30 + Bscript.AbilityLevel * 10;
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((80 + Bscript.AttackLevel * 10) * StrengthRate * AttackRate);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((130 + Bscript.AttackLevel * 10) * StrengthRate * AttackRate);
        AttackRate = Mathf.FloorToInt((AttackRate + 1f) * 50f) / 100f;
        GameObject g2 = Instantiate(Effect[3]);
        g2.transform.position = Effect[3].transform.position;
        g2.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[3]);
    }
}
