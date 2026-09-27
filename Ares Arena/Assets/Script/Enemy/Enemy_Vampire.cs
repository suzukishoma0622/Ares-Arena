using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_Vampire : MonoBehaviour
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
    public CanvasGroup[] BuffCG;
    public TMP_Text BuffStuck;
    public TMP_Text BuffDesc;
    bool IsDebuff;
    bool IsBuff;
    public GameObject AgateGem;
    public GameObject AgateEffect;
    public int Agate;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 3000;
                break;
            case 2:
                Bscript.EnemyMaxHP = 3300;
                break;
        }
        Bscript.EnemyHP = Bscript.EnemyMaxHP;
    }
    void Update()
    {
        for(int i = 42; i < 49; i++)
        {
            if (Pscript.JewelNum[i] == 301)
            {
                Pscript.IsAgate = true;
                Pscript.JewelVanish(i);
                GameObject g = Instantiate(AttackObj[0]);
                g.transform.position = this.transform.position;
                g.GetComponent<BlockTrail>().GoPlayer = true;
                g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(Agate);
            }
        }
        switch (Language)
        {
            case 1:
                AttackText[0].text = "盤上の宝石7つをメノウに変化させる。";
                AttackText[1].text = ((400 + Bscript.AttackLevel * 50) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。麻痺" + (5 + Bscript.AbilityLevel).ToString() + "を付与する。";
                AttackText[2].text = "弱体化" + (100 + Bscript.AbilityLevel * 20).ToString() + "を付与する。";
                AttackText[3].text = "30%の攻撃激化を得る。メノウの効果が50増加する。";
                DebuffDesc[0].text = "消去後に再出現する。一番下の行に到達したとき、" + Agate + "ダメージを受け、自動で消去される。";
                DebuffDesc[1].text = "次に消去する" + Pscript.Debuff_Weak + "個の宝石の効果が50%減少する。";
                DebuffDesc[2].text = "このターン、ハンド数が" + Pscript.Debuff_Lightning + "減少する。";
                BuffDesc.text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = "Transform the 7 gems on the board into Agate.";
                AttackText[1].text = "Deal " + ((400 + Bscript.AttackLevel * 50) * AttackRate * StrengthRate).ToString("0") + " Damage. Inflict Paralysis " + (5 + Bscript.AbilityLevel).ToString() + ".";
                AttackText[2].text = "Inflict Weak " + (100 + Bscript.AbilityLevel * 20).ToString() + ".";
                AttackText[3].text = "Gain a 30% Intensified. The effect of agate increases by 50.";
                DebuffDesc[0].text = "It reappears after being cast. When it reaches the bottom row, take " + Agate + " Damage.";
                DebuffDesc[1].text = "The effect of the next " + Pscript.Debuff_Weak + " gems you cast will be reduced by 50%.";
                DebuffDesc[2].text = "This turn, the number of hand decreases by " + Pscript.Debuff_Lightning + ".";
                BuffDesc.text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        DebuffStuck[0].text = Pscript.Debuff_Weak.ToString();
        DebuffStuck[1].text = Pscript.Debuff_Lightning.ToString();
        BuffStuck.text = ((AttackRate - 1f) * 100f).ToString("0") + "%";
        if (Bscript.IsDefeat)
        {
            IsForecast = false;
            Effect[5].SetActive(false);
            Effect[6].SetActive(false);
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
            IsChat = true;
            switch (Language)
            {
                case 1:
                    ChatText.text = "喉が渇いた……";
                    break;
                case 2:
                    ChatText.text = "I'm thirsty...";
                    break;
            }
            Invoke("OutChat", 1.5f);
            Invoke("Act1_1", 1.5f);
            Invoke("Act1_2", 2.5f);
            Invoke("ActEnd", 3.5f);
        }
        else
        {
            switch((Bscript.CurrentRound - 1) % 3)
            {
                case 1:
                    Act2_1();
                    Invoke("Act2_2", 0.5f);
                    Invoke("Act2_3", 0.8f);
                    Invoke("ActEnd", 1.8f);
                    break;
                case 2:
                    Act3_1();
                    Invoke("Act3_2", 0.7f);
                    Invoke("ActEnd", 1.7f);
                    break;
                case 0:
                    IsChat = true;
                    if (Bscript.EnemyHP < Bscript.EnemyMaxHP * 0.5f)
                    {
                        switch (Language)
                        {
                            case 1:
                                ChatText.text = "もっと…必要だ！";
                                break;
                            case 2:
                                ChatText.text = "I need more...!";
                                break;
                        }
                    }
                    else
                    {
                        switch (Language)
                        {
                            case 1:
                                ChatText.text = "ケチらないで！";
                                break;
                            case 2:
                                ChatText.text = "Don't be stingy!";
                                break;
                        }
                    }
                    Invoke("OutChat", 1.5f);
                    Invoke("Act4_1", 1.5f);
                    Invoke("Act4_2", 2.5f);
                    Invoke("ActEnd", 3.5f);
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
        IsDebuff = true;
        for(int i = 0; i < 7; i++)
        {
            GameObject g = Instantiate(AgateEffect);
            g.transform.position = Pscript.JewelDisplay[i].transform.position;
            g.SetActive(true);
            g.transform.SetParent(this.transform, true);
            Pscript.JewelNum[i] = 301;
            GameObject g2 = Instantiate(AgateGem);
            g2.transform.position = Pscript.JewelDisplay[i].transform.position;
            g2.transform.SetParent(Pscript.gameObject.transform, true);
            Destroy(Pscript.JewelDisplay[i]);
            Pscript.JewelDisplay[i] = g2;
        }
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((400 + Bscript.AttackLevel * 50) * AttackRate * StrengthRate);
    }
    void Act2_3()
    {
        Pscript.Debuff_Lightning = 5 + Bscript.AbilityLevel;
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
        Pscript.Debuff_Weak += 100 + Bscript.AbilityLevel * 20;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
    }
    void Act4_1()
    {
        GameObject g = Instantiate(Effect[3]);
        g.transform.position = Effect[3].transform.position;
        g.SetActive(true);
        GameObject g2 = Instantiate(Effect[4]);
        g2.transform.position = Effect[4].transform.position;
        g2.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[3]);
    }
    void Act4_2()
    {
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "攻撃激化 +30%";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Intensified +30%";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        AttackRate += 0.3f;
        Agate += 50;
        IsBuff = true;
    }
}
