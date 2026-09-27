using TMPro;
using UnityEngine;

public class Enemy_Swordmaster : MonoBehaviour
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
    public TMP_Text DebuffDesc;
    public CanvasGroup[] BuffCG;
    public TMP_Text BuffStuck;
    public TMP_Text BuffDesc;
    bool IsBuff;
    bool IsDebuff;
    public TMP_Text CounterStuck;
    public TMP_Text CounterDesc;
    public int CounterPerc = 5;

    public GameObject BloodOrbGem;
    public GameObject BloodOrbEffect;

    bool Phase2;
    int Phase2Count;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 7000;
                break;
            case 2:
                Bscript.EnemyMaxHP = 7600;
                break;
        }
        Bscript.EnemyHP = Bscript.EnemyMaxHP;
        CounterPerc = 5;
    }
    void Update()
    {
        switch (Language)
        {
            case 1:
                AttackText[0].text = ((280 + Bscript.AttackLevel * 40) * AttackRate * StrengthRate).ToString("0") + $"ダメージを与える。ランダムな宝石{10 + Bscript.AbilityLevel * 2}つを血のオーブに変化させる。";
                AttackText[1].text = (300 * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。弱体化のスタック1つにつき、追加で" + (10 + Bscript.AttackLevel * 2).ToString() + "ダメージを与える。";
                AttackText[2].text = "カウンターの効果が5増加する。";
                AttackText[3].text = "20%の攻撃激化を得る。HPを50%まで回復する。";
                AttackText[4].text = ((340 + Bscript.AttackLevel * 30) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。この攻撃を防ぎきれなかった場合、即死する。";
                DebuffDesc.text = "次に消去する" + Pscript.Debuff_Weak + "個の宝石の効果が50%減少する。";
                CounterDesc.text = "スキルを使用する毎に、" + CounterPerc + "%の攻撃激化を得る。";
                BuffDesc.text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = "Deal " + ((280 + Bscript.AttackLevel * 40) * AttackRate * StrengthRate).ToString("0") + $" Damage.Transform {10 + Bscript.AbilityLevel * 2} random gems into Blood Orb.";
                AttackText[1].text = "Deal " + (300 * AttackRate * StrengthRate).ToString("0") + " Damage. Deals an additional " + (10 + Bscript.AttackLevel * 2).ToString() + "damage for each stack of Weak.";
                AttackText[2].text = "Gain Counter 5.";
                AttackText[3].text = "Gain 20% Intensified. Restores HP to 50%.";
                AttackText[4].text = $"Deal {(340 + Bscript.AttackLevel * 30) * AttackRate * StrengthRate} Damage. If you fail to fully block this attack, you will die instantly.";
                DebuffDesc.text = "The effect of the next " + Pscript.Debuff_Weak + " gems you cast will be reduced by 50%.";
                CounterDesc.text = "Gain " + CounterPerc + "% Intensified each time a skill is used.";
                BuffDesc.text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        DebuffStuck.text = Pscript.Debuff_Weak.ToString();
        BuffStuck.text = ((AttackRate - 1f) * 100f).ToString("0") + "%";
        if (Bscript.IsDefeat)
        {
            IsForecast = false;
        }
        if (Pscript.Debuff_Weak > 0)
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
            BuffCG[0].alpha += Time.deltaTime * 2f;
            BuffCG[0].interactable = true;
            BuffCG[0].blocksRaycasts = true;
        }
        if (IsDebuff)
        {
            DebuffCG[1].alpha += Time.deltaTime * 2f;
            DebuffCG[1].interactable = true;
            DebuffCG[1].blocksRaycasts = true;
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
            if (Phase2)
            {
                if(Phase2Count <= 2)
                {
                    ActForecast[Phase2Count + 2].alpha += Time.deltaTime * 2f;
                    ActForecast[Phase2Count + 2].interactable = true;
                    ActForecast[Phase2Count + 2].blocksRaycasts = true;
                }
                else
                {
                    switch(Phase2Count % 3)
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
                        case 2:
                            ActForecast[4].alpha += Time.deltaTime * 2f;
                            ActForecast[4].interactable = true;
                            ActForecast[4].blocksRaycasts = true;
                            break;
                    }
                }
            }
            else
            {
                ActForecast[(Bscript.CurrentRound - 1) % 3].alpha += Time.deltaTime * 2f;
                ActForecast[(Bscript.CurrentRound - 1) % 3].interactable = true;
                ActForecast[(Bscript.CurrentRound - 1) % 3].blocksRaycasts = true;
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
        if(Phase2)
        {
            if (Phase2Count <= 2)
            {
                switch(Phase2Count)
                {
                    case 1:
                        IsChat = true;
                        switch (Language)
                        {
                            case 1:
                                ChatText.text = "防いでみせよ……";
                                break;
                            case 2:
                                ChatText.text = "Try and block this...";
                                break;
                        }
                        Invoke("OutChat", 1.5f);
                        Invoke("Act4_1", 1.5f);
                        Invoke("Act4_2", 2.5f);
                        Invoke("ActEnd", 3.5f);
                        break;
                    case 2:
                        Act5_1();
                        Invoke("Act5_2", 1f);
                        Invoke("ActEnd", 2f);
                        break;
                }
            }
            else
            {
                switch (Phase2Count % 3)
                {
                    case 0:
                        Act1_1();
                        Invoke("Act1_2", 0.5f);
                        Invoke("ActEnd", 1.5f);
                        break;
                    case 1:
                        Act2_1();
                        Invoke("Act2_2", 0.4f);
                        Invoke("Act2_3", 0.6f);
                        Invoke("ActEnd", 1.6f);
                        break;
                    case 2:
                        Act5_1();
                        Invoke("Act5_2", 1f);
                        Invoke("ActEnd", 2f);
                        break;
                }
            }
        }
        else
        {
            switch ((Bscript.CurrentRound - 1) % 3)
            {
                case 0:
                    if (Bscript.CurrentRound == 1)
                    {
                        IsChat = true;
                        switch (Language)
                        {
                            case 1:
                                if (Bscript.Iscript.Saint == 1)
                                {
                                    ChatText.text = "勝負だ、ヴァルキリー！";
                                }
                                else
                                {
                                    ChatText.text = "かかって来い！";
                                }
                                break;
                            case 2:
                                if (Bscript.Iscript.Saint == 1)
                                {
                                    ChatText.text = "It's a showdown, Valkyrie!";
                                }
                                else
                                {
                                    ChatText.text = "Bring it on!";
                                }
                                break;
                        }
                        Invoke("OutChat", 1.5f);
                        Invoke("Act1_1", 1.5f);
                        Invoke("Act1_2", 2f);
                        Invoke("ActEnd", 3f);
                    }
                    else
                    {
                        Act1_1();
                        Invoke("Act1_2", 0.5f);
                        Invoke("ActEnd", 1.5f);
                    }
                    break;
                case 1:
                    Act2_1();
                    Invoke("Act2_2", 0.4f);
                    Invoke("Act2_3", 0.6f);
                    Invoke("ActEnd", 1.6f);
                    break;
                case 2:
                    IsChat = true;
                    switch (Language)
                    {
                        case 1:
                            ChatText.text = "本気で戦え！";
                            break;
                        case 2:
                            ChatText.text = "Fight with all your might!";
                            break;
                    }
                    Invoke("OutChat", 1.5f);
                    Invoke("Act3_1", 1.5f);
                    Invoke("Act3_2", 2f);
                    Invoke("ActEnd", 3f);
                    break;
            }
        }
    }
    void OutChat()
    {
        IsChat = false;
    }
    public void CounterEffect()
    {
        if (Pscript.ActiveSkill >= 1)
        {
            GameObject g = Instantiate(Counter);
            g.transform.position = this.transform.position;
            switch (Language)
            {
                case 1:
                    g.GetComponent<InfoDisplay_Counter>().Thisnum = $"攻撃激化 +{CounterPerc}%";
                    break;
                case 2:
                    g.GetComponent<InfoDisplay_Counter>().Thisnum = $"Intensified +{CounterPerc}%";
                    break;
            }
            g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
            g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
            g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
            g.SetActive(true);
            AttackRate += 0.01f * CounterPerc;
            IsBuff = true;
        }
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((280 + Bscript.AttackLevel * 40) * AttackRate * StrengthRate);
        for (int i = 0; i < 10 + Bscript.AbilityLevel * 2; i++)
        {
            int Judge = Random.Range(0, 49);
            for (; Pscript.JewelNum[Judge] == 304;)
            {
                Judge = Random.Range(0, 49);
            }
            Pscript.JewelNum[Judge] = 304;
            GameObject g2 = Instantiate(BloodOrbGem);
            g2.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g2.transform.SetParent(Pscript.gameObject.transform, true);
            Destroy(Pscript.JewelDisplay[Judge]);
            Pscript.JewelDisplay[Judge] = g2;
            GameObject g3 = Instantiate(BloodOrbEffect);
            g3.transform.position = Pscript.JewelDisplay[Judge].transform.position;
        }
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
        GameObject g = Instantiate(Effect[2]);
        g.transform.position = Effect[2].transform.position;
        g.SetActive(true);
    }
    void Act2_3()
    {
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(300 * AttackRate * StrengthRate + Pscript.Debuff_Weak * (10 + Bscript.AttackLevel * 2));
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
        CounterPerc += 5;
        CounterStuck.text = CounterPerc.ToString();
        switch(Language)
        {
            case 1:
                CounterDesc.text = "スキルを使用する毎に、" + CounterPerc.ToString() + "%の攻撃激化を得る。";
                break;
            case 2:
                CounterDesc.text = "Gain " + CounterPerc.ToString() + "% Intensified each time a skill is used.";
                break;
        }
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "カウンター +5%";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Counter +5%";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
    }
    void Act4_1()
    {
        GameObject g = Instantiate(Effect[4]);
        g.transform.position = Effect[4].transform.position;
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
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "攻撃激化 +20%";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Intensified +20%";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        AttackRate += 0.2f;
        Bscript.EnemyHP = Mathf.FloorToInt(Bscript.EnemyMaxHP * 0.5f);
        IsBuff = true;
    }
    void Act5_1()
    {
        GameObject g = Instantiate(Effect[5]);
        g.transform.position = Effect[5].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[4]);
    }
    void Act5_2()
    {
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((340 + Bscript.AttackLevel * 30) * AttackRate * StrengthRate);
        g.GetComponent<EffectScript>().Attack_Execution = true;
    }
}
