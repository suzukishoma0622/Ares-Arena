using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_CrafterSmith : MonoBehaviour
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

    public CanvasGroup BuffCG;
    public TMP_Text BuffStuck;
    public TMP_Text BuffDesc;
    public AudioClip[] EnemySE;

    int Sharpness;
    int Judge = 1;
    int ForgeNum;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1240;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1320;
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
                AttackText[0].text = $"{(160 + Bscript.AttackLevel * 20) * StrengthRate + Sharpness}ダメージを与える。";
                AttackText[1].text = $"鋭利{(120 + Bscript.AbilityLevel * 20) * StrengthRate}を得る。{(250 + Bscript.HPLevel * 20) * StrengthRate}シールドを得る。";
                BuffDesc.text = $"次の攻撃で与えるダメージが{Sharpness}増加する。";
                break;
            case 2:
                AttackText[0].text = $"Deal {(160 + Bscript.AttackLevel * 20) * StrengthRate + Sharpness} Damage.";
                AttackText[1].text = $"Gain {(120 + Bscript.AbilityLevel * 20) * StrengthRate} Sharpness. Gain {(250 + Bscript.HPLevel * 20) * StrengthRate} Shield.";
                BuffDesc.text = $"Increases the damage dealt by the next attack by {Sharpness}.";
                break;
        }
        BuffStuck.text = Sharpness.ToString();
        if (Sharpness > 0)
        {
            BuffCG.alpha += Time.deltaTime * 2f;
            BuffCG.interactable = true;
            BuffCG.blocksRaycasts = true;
        }
        else
        {
            BuffCG.alpha -= Time.deltaTime * 2f;
            BuffCG.interactable = false;
            BuffCG.blocksRaycasts = false;
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
            ActForecast[Judge].alpha += Time.deltaTime * 2f;
            ActForecast[Judge].interactable = true;
            ActForecast[Judge].blocksRaycasts = true;
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
        Judge = Random.Range(0, 2);
        if(Judge == 1)
        {
            if(ForgeNum >= 2)
            {
                Judge = 0;
                ForgeNum = 0;
            }
        }
    }
    public void Action()
    {
        IsForecast = false;
        switch (Judge)
        {
            case 0:
                Act1_1();
                Invoke("Act1_2", 0.3f);
                Invoke("ActEnd", 1.3f);
                break;
            case 1:
                Act2_1();
                Invoke("Act2_1", 0.4f);
                Invoke("Act2_2", 0.8f);
                Invoke("ActEnd", 1.8f);
                break;
        }
    }
    void OutChat()
    {
        IsChat = false;
    }
    void Act1_1()
    {
        GameObject g = Instantiate(Effect[2]);
        g.transform.position = Effect[2].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[2]);
    }
    void Act1_2()
    {
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((160 + Bscript.Iscript.Crown * 10) * StrengthRate + Sharpness);
        Sharpness = 0;
    }
    void Act2_1()
    {
        GameObject g = Instantiate(Effect[0]);
        g.transform.position = Effect[0].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[0]);
    }
    void Act2_2()
    {
        Sharpness += Mathf.FloorToInt((120 + Bscript.AbilityLevel * 20) * StrengthRate);
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = $"鋭利 +{(120 + Bscript.AbilityLevel * 20) * StrengthRate}";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = $"Sharpness +{(120 + Bscript.AbilityLevel * 20) * StrengthRate}";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        GameObject g2 = Instantiate(AttackObj[1]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = false;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((250 + Bscript.Iscript.Crown * 20) * StrengthRate);
        ForgeNum += 1;
        GameObject g3 = Instantiate(Effect[1]);
        g3.transform.position = Effect[1].transform.position;
        g3.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[1]);
    }
}
