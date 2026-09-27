using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_BlackSniper : MonoBehaviour
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
    public TMP_Text[] DebuffDesc;
    public CanvasGroup[] BuffCG;
    public TMP_Text[] BuffStuck;
    public TMP_Text[] BuffDesc;
    bool IsBuff;
    public GameObject TrackEffect1;
    public GameObject TrackEffect2;
    GameObject[] TrackDisplay = new GameObject[8];
    int[] Tracknum = new int[49];
    public AudioClip[] EnemySE;

    public int TrackNum;
    public EnemyHealth Escript;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1030;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1100;
                break;
        }
        Bscript.EnemyMaxHP = Mathf.FloorToInt(Bscript.EnemyMaxHP * StrengthRate);
        Bscript.EnemyHP = Bscript.EnemyMaxHP;
        Escript.Evasion = 8 + Bscript.Iscript.CurrentRound * 2;
    }
    void Update()
    {
        switch (Language)
        {
            case 1:
                AttackText[0].text = $"{(140 + Bscript.AttackLevel * 10) * StrengthRate}ダメージを与える。麻痺{5 + Bscript.AbilityLevel}を付与する。";
                AttackText[1].text = $"盤上のランダムな{6 + Bscript.AbilityLevel}マスに追尾を付与する。";
                AttackText[2].text = $"{(200 + Bscript.AttackLevel * 20) * StrengthRate + TrackNum}ダメージを与える。";
                BuffDesc[0].text = $"{8 + Bscript.Iscript.CurrentRound * 2}以上の受けるダメージを{8 + Bscript.Iscript.CurrentRound * 2}に軽減する。";
                BuffDesc[1].text = $"対象マスの宝石を消す毎に、次の攻撃で与えるダメージが{20 * StrengthRate}増加する。";
                DebuffDesc[0].text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = $"Deal {(140 + Bscript.AttackLevel * 10) * StrengthRate} Damage. Inflicts Paralysis {5 + Bscript.AbilityLevel}.";
                AttackText[1].text = $"Grant Tracking to {6 + Bscript.AbilityLevel} random squares on the board.";
                AttackText[2].text = $"Deal {(200 + Bscript.AttackLevel * 20) * StrengthRate + TrackNum} Damage.";
                BuffDesc[0].text = $"Reduces incoming damage of {8 + Bscript.Iscript.CurrentRound * 2} or more to {8 + Bscript.Iscript.CurrentRound * 2}.";
                BuffDesc[1].text = $"Each time you cast a gem on a target tile, the damage dealt by the next attack increases by {20 * StrengthRate}.";
                DebuffDesc[0].text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        BuffStuck[0].text = (8 + Bscript.Iscript.CurrentRound * 2).ToString();
        BuffStuck[1].text = (20 * StrengthRate).ToString();
        DebuffStuck.text = Pscript.Debuff_Lightning.ToString();
        if(Pscript.Debuff_Lightning > 0)
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
        if (IsBuff)
        {
            BuffCG[1].alpha += Time.deltaTime * 2f;
            BuffCG[1].interactable = true;
            BuffCG[1].blocksRaycasts = true;
        }
        else
        {
            BuffCG[1].alpha -= Time.deltaTime * 2f;
            BuffCG[1].interactable = false;
            BuffCG[1].blocksRaycasts = false;
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
    public void TrackDetect(int i)
    {
        if(Tracknum[i] == 1)
        {
            GameObject g = Instantiate(TrackEffect2);
            g.transform.position = Pscript.JewelDisplay[i].transform.position;
            g.SetActive(true);
            g.transform.SetParent(Pscript.gameObject.transform, true);
            TrackNum += Mathf.FloorToInt(20 * StrengthRate);
        }
    }
    public void Action()
    {
        IsForecast = false;
        switch (Bscript.CurrentRound % 3)
        {
            case 1:
                Act1_1();
                Invoke("Act1_2", 0.5f);
                Invoke("ActEnd", 1.5f);
                break;
            case 2:
                Act2_1();
                Invoke("Act2_2", 0.8f);
                Invoke("ActEnd", 1.8f);
                break;
            case 0:
                Act3_1();
                Invoke("Act3_2", 0.2f);
                Invoke("ActEnd", 1.2f);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((140 + Bscript.AttackLevel * 10) * StrengthRate);
        Pscript.Debuff_Lightning = 5 + Bscript.AbilityLevel;
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
        IsBuff = true;
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "追尾";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Tracking";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        for (int i = 0; i < 6 + Bscript.AbilityLevel; i++)
        {
            Destroy(TrackDisplay[i]);
            int Judge = Random.Range(0, 49);
            for (; Tracknum[Judge] == 1;)
            {
                Judge = Random.Range(0, 49);
            }
            Tracknum[Judge] = 1;
            GameObject g3 = Instantiate(TrackEffect2);
            g3.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g3.SetActive(true);
            g3.transform.SetParent(Pscript.gameObject.transform, true);
            GameObject g2 = Instantiate(TrackEffect1);
            g2.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g2.SetActive(true);
            g2.transform.SetParent(Pscript.gameObject.transform, true);
            TrackDisplay[i] = g2;
        }
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((200 + Bscript.AttackLevel * 20) * StrengthRate + TrackNum);
        IsBuff = false;
        for (int i = 0; i < 6 + Bscript.AbilityLevel; i++)
        {
            Destroy(TrackDisplay[i]);
        }
        for (int i = 0; i < 49; i++)
        {
            Tracknum[i] = 0;
        }
        TrackNum = 0;
    }
}
