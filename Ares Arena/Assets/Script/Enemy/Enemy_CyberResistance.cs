using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_CyberResistance : MonoBehaviour
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
    public GameObject NoiseEffect1;
    public GameObject NoiseEffect2;
    GameObject[] NoiseDisplay = new GameObject[10];
    int[] Noisenum = new int[49];
    int[] NoiseDict = new int[10];
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1400;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1500;
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
                AttackText[0].text = "炎壁を付与する。";
                AttackText[1].text = $"盤上に残っているノイズの数x{10 + Bscript.AbilityLevel * 5}%の攻撃激化を得る。{Mathf.FloorToInt((160 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate)}ダメージを与える。";
                DebuffName.text = "炎壁";
                DebuffDesc.text = "ターン開始時、盤上の10箇所にノイズが付与される。ノイズはハンドにより除去可能。";
                BuffName.text = "攻撃激化";
                BuffDesc.text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = "Grants Firewall.";
                AttackText[1].text = $"Gain {10 + Bscript.AbilityLevel * 5}% Intensified for each Noise remaining on the board. Deal {Mathf.FloorToInt((160 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate)} damage.";
                DebuffName.text = "Firewall";
                DebuffDesc.text = "At the start of the turn, Noise is applied to 10 locations on the board. Noise can be removed by hand.";
                BuffName.text = "Intensified";
                BuffDesc.text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        BuffStuck.text = ((AttackRate - 1f) * 100f).ToString("0") + "%";
        if(IsDebuff)
        {
            DebuffCG[0].alpha += Time.deltaTime * 2f;
            DebuffCG[0].interactable = true;
            DebuffCG[0].blocksRaycasts = true;
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
            int j = 0;
            for(int i = 0; i < 49; i++)
            {
                if (Noisenum[i] == 1)
                {
                    Noisenum[i] = 0;
                    j += 10 + Bscript.AbilityLevel * 5;
                }
            }
            if (j > 0)
            {
                GameObject g = Instantiate(Counter);
                g.transform.position = this.transform.position;
                switch (Language)
                {
                    case 1:
                        g.GetComponent<InfoDisplay_Counter>().Thisnum = $"攻撃激化 +{j}%";
                        break;
                    case 2:
                        g.GetComponent<InfoDisplay_Counter>().Thisnum = $"Attack Power +{j}%";
                        break;
                }
                g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
                g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
                g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
                g.SetActive(true);
                AttackRate += j * 0.01f;
                IsBuff = true;
                j = 0;
            }
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
                case >= 1:
                    ActForecast[1].alpha += Time.deltaTime * 2f;
                    ActForecast[1].interactable = true;
                    ActForecast[1].blocksRaycasts = true;
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
        for (int i = 0; i < 10; i++)
        {
            Destroy(NoiseDisplay[i]);
            int Judge = Random.Range(0, 49);
            for (; Noisenum[Judge] == 1;)
            {
                Judge = Random.Range(0, 49);
            }
            Noisenum[Judge] = 1;
            GameObject g = Instantiate(NoiseEffect2);
            g.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g.SetActive(true);
            g.transform.SetParent(Pscript.gameObject.transform, true);
            GameObject g2 = Instantiate(NoiseEffect1);
            g2.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g2.SetActive(true);
            g2.transform.SetParent(Pscript.gameObject.transform, true);
            NoiseDisplay[i] = g2;
            NoiseDict[i] = Judge;
        }
    }
    public void DisNoise(int i)
    {
        if(Noisenum[i] == 1)
        {
            for(int j = 0; j < 10; j++)
            {
                if(i == NoiseDict[j])
                {
                    Destroy(NoiseDisplay[j]);
                    GameObject g = Instantiate(NoiseEffect2);
                    g.transform.position = Pscript.JewelDisplay[NoiseDict[j]].transform.position;
                    g.SetActive(true);
                    g.transform.SetParent(Pscript.gameObject.transform, true);
                    Noisenum[i] = 0;
                }
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
                Invoke("Act1_2", 0.8f);
                Invoke("ActEnd", 1.8f);
                break;
            case >= 1:
                Act2_1();
                Invoke("Act2_2", 0.6f);
                Invoke("ActEnd", 1.6f);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((160 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate);
    }
}
