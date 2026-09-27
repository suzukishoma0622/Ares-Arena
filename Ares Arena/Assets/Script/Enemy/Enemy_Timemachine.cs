using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_TimeMachine : MonoBehaviour
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

    public TMP_Text MomentStuck;
    public TMP_Text MomentDesc;
    public int Moment = 10;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 3500;
                break;
            case 2:
                Bscript.EnemyMaxHP = 3800;
                break;
        }
        Bscript.EnemyHP = Bscript.EnemyMaxHP;
        Moment = 10 + Bscript.AbilityLevel * 5;
        MomentStuck.text = Moment.ToString();
        switch (Language)
        {
            case 1:
                MomentDesc.text = "ハンドする毎に、" + Moment.ToString() + "ダメージを受ける。";
                break;
            case 2:
                MomentDesc.text = $"Take {Moment} damage each time you play a card from your hand.";
                break;
        }
    }
    void Update()
    {
        switch (Language)
        {
            case 1:
                AttackText[0].text = ((300 + Bscript.AttackLevel * 40) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。";
                AttackText[1].text = "刻一刻の効果が10増加する。";
                AttackText[2].text = $"{(130 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate}ダメージを与える。HPを{500 + Bscript.HPLevel * 50}回復する。";
                break;
            case 2:
                AttackText[0].text = "Deal " + ((300 + Bscript.AttackLevel * 40) * AttackRate * StrengthRate).ToString("0") + " Damage.";
                AttackText[1].text = "The effect of Moment by Moment increases by 10.";
                AttackText[2].text = "Deal " + ((130 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate).ToString("0") + $" Damage. Restore {500 + Bscript.HPLevel * 50} HP.";
                break;
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
        if(IsForecast && !Bscript.IsDefeat)
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
        switch((Bscript.CurrentRound - 1) % 3)
        {
            case 0:
                Act1_1();
                Invoke("Act1_2", 1f);
                Invoke("ActEnd", 2f);
                break;
            case 1:
                Act2_1();
                Invoke("Act2_2", 1.5f);
                Invoke("ActEnd", 2.5f);
                break;
            case 2:
                Act3_1();
                Invoke("Act3_2", 1f);
                Invoke("ActEnd", 2f);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((300 + Bscript.AttackLevel * 40) * AttackRate * StrengthRate);
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
        Moment += 10;
        MomentStuck.text = Moment.ToString();
        switch (Language)
        {
            case 1:
                MomentDesc.text = "ハンドする毎に、" + Moment.ToString() + "ダメージを受ける。";
                break;
            case 2:
                MomentDesc.text = $"Take {Moment} damage each time you play a card from your hand.";
                break;
        }
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "刻一刻 +10";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Moment by Moment +10";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
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
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((130 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate);
        GameObject g2 = Instantiate(AttackObj[1]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = false;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((500 + Bscript.HPLevel * 50) * AttackRate * StrengthRate);
    }
    public void MomentHand()
    {
        Invoke("M", 0.3f);
    }
    void M()
    {
        if (Pscript.CurrentHand > 0)
        {
            GameObject g = Instantiate(AttackObj[0]);
            g.transform.position = this.transform.position;
            g.GetComponent<BlockTrail>().GoPlayer = true;
            g.GetComponent<EffectScript>().EffectNum = Moment;
        }
    }
}
