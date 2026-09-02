using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_JewelryFish : MonoBehaviour
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

    public int StaticElectricity = 2;
    public TMP_Text DebuffStuck;
    public TMP_Text DebuffName;
    public TMP_Text DebuffDesc;
    public TMP_Text BuffStuck;
    public TMP_Text BuffName;
    public TMP_Text BuffDesc;
    public GameObject StaticEffect1;
    public GameObject StaticEffect2;
    public GameObject[] StaticDisplay = new GameObject[49];
    public int[] Staticnum = new int[49];
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyStatusLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1300;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1360;
                break;
            case 3:
                Bscript.EnemyMaxHP = 1420;
                break;
            case 4:
                Bscript.EnemyMaxHP = 1480;
                break;
            case 5:
                Bscript.EnemyMaxHP = 1540;
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
                AttackText[0].text = $"{Mathf.FloorToInt((140 + Bscript.Iscript.Crown * 10) * StrengthRate)}ダメージを与える。{Mathf.FloorToInt((200 + Bscript.Iscript.Crown * 20) * StrengthRate)}シールドを得る。";
                AttackText[1].text = "誘導電流2を得る。";
                AttackText[2].text = $"{Mathf.FloorToInt((120 + Bscript.Iscript.Crown * 5) * StrengthRate)}ダメージを与える。";
                DebuffName.text = "静電気";
                DebuffDesc.text = $"対象となったマスの宝石を消すと、{10 + Bscript.AbilityLevel * 5}シールドを失う。";
                BuffName.text = "誘導電流";
                BuffDesc.text = $"ハンドする毎に、盤上の{StaticElectricity}箇所に静電気を付与する。";
                break;
            case 2:
                AttackText[0].text = $"Deals {Mathf.FloorToInt((140 + Bscript.Iscript.Crown * 10) * StrengthRate)} damage. Gain {Mathf.FloorToInt((300 + Bscript.Iscript.Crown * 40) * StrengthRate)} Shield.";
                AttackText[1].text = $"Gain 2 InducedCurrent.";
                AttackText[2].text = $"Deals {Mathf.FloorToInt((120 + Bscript.Iscript.Crown * 5) * StrengthRate)} damage.";
                DebuffName.text = "Static Electricity";
                DebuffDesc.text = $"Casting the gem on the targeted tile causes you to lose {10 + Bscript.AbilityLevel * 5} Shield.";
                BuffName.text = "Induced Current";
                BuffDesc.text = $"Each time you hand, apply Static Electricity to {StaticElectricity} spots on the board.";
                break;
        }
        BuffStuck.text = StaticElectricity.ToString();
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
            switch(Bscript.CurrentRound - 1)
            {
                case 0:
                    ActForecast[0].alpha += Time.deltaTime * 2f;
                    ActForecast[0].interactable = true;
                    ActForecast[0].blocksRaycasts = true;
                    break;
                case 1:
                    ActForecast[1].alpha += Time.deltaTime * 2f;
                    ActForecast[1].interactable = true;
                    ActForecast[1].blocksRaycasts = true;
                    break;
                case >= 2:
                    ActForecast[2].alpha += Time.deltaTime * 2f;
                    ActForecast[2].interactable = true;
                    ActForecast[2].blocksRaycasts = true;
                    break;
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
    public void DisNoise(int i)
    {
        if(Staticnum[i] == 1)
        {
            GameObject g = Instantiate(StaticEffect2);
            g.transform.position = Pscript.JewelDisplay[i].transform.position;
            g.SetActive(true);
            g.transform.SetParent(Pscript.gameObject.transform, true);
            Staticnum[i] = 0;
            Destroy(StaticDisplay[i]);
            Bscript.Iscript.SE.PlayOneShot(EnemySE[3]);
            Bscript.PlayerShield -= 10 + Bscript.AbilityLevel * 5;
            if(Bscript.PlayerShield < 0)
            {
                Bscript.PlayerShield = 0;
            }
        }
    }
    public void Action()
    {
        IsForecast = false;
        switch (Bscript.CurrentRound - 1)
        {
            case 0:
                Act1_1();
                Invoke("Act1_2", 0.3f);
                Invoke("ActEnd", 1.3f);
                break;
            case 1:
                Act2_1();
                Invoke("Act2_2", 0.8f);
                Invoke("ActEnd", 1.8f);
                break;
            case >= 2:
                Act3_1();
                Invoke("Act3_2", 0.7f);
                Invoke("ActEnd", 1.7f);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((140 + Bscript.Iscript.Crown * 10) * StrengthRate);
        GameObject g2 = Instantiate(AttackObj[1]);
        g2.transform.position = this.transform.position;
        g2.GetComponent<BlockTrail>().GoPlayer = false;
        g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((200 + Bscript.Iscript.Crown * 20) * StrengthRate);
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
        StaticElectricity += 2;
        GameObject g2 = Instantiate(Counter);
        g2.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g2.GetComponent<InfoDisplay_Counter>().Thisnum = "誘導電流 +2";
                break;
            case 2:
                g2.GetComponent<InfoDisplay_Counter>().Thisnum = "Induced Current +2";
                break;
        }
        g2.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g2.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g2.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g2.SetActive(true);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((120 + Bscript.Iscript.Crown * 5) * StrengthRate);
    }
}
