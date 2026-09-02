using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_SlimeParasite : MonoBehaviour
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
    bool IsDebuff;
    public GameObject MucusGem;
    public GameObject MucusEffect;

    public CanvasGroup[] BuffCG;
    public TMP_Text BuffStuck;
    public TMP_Text BuffDesc;
    bool IsBuff;

    int AJ;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyStatusLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1420;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1480;
                break;
            case 3:
                Bscript.EnemyMaxHP = 1540;
                break;
            case 4:
                Bscript.EnemyMaxHP = 1600;
                break;
            case 5:
                Bscript.EnemyMaxHP = 1660;
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
                AttackText[0].text = "ランダムな宝石25つを粘液に変化させる。";
                AttackText[1].text = ((180 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。ランダムな宝石10つを粘液に変化させる。";
                AttackText[2].text = "25%の攻撃激化を得る。ランダムな宝石20つを粘液に変化させる。";
                BuffDesc.text = "与えるダメージが" + ((AttackRate - 1f) * 100f).ToString("0") + "%増加する。";
                break;
            case 2:
                AttackText[0].text = "Transforms 25 random gems into Poison.";
                AttackText[1].text = "Deal " + ((180 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate).ToString("0") + " Damage. Transforms 10 random gems into Poison.";
                AttackText[1].text = "Gain a 25% Intensified. Transforms 20 random gems into Poison.";
                BuffDesc.text = "Damage dealt is increased by " + ((AttackRate - 1f) * 100f).ToString("0") + "%.";
                break;
        }
        BuffStuck.text = ((AttackRate - 1f) * 100f).ToString("0") + "%";
        if (Bscript.IsDefeat)
        {
            Effect[2].SetActive(false);
        }
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
            Action();
            Bscript.IsR = false;
        }
        if(Bscript.IsDefeat)
        {
            IsForecast = false;
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
                ActForecast[1 + AJ].alpha += Time.deltaTime * 2f;
                ActForecast[1 + AJ].interactable = true;
                ActForecast[1 + AJ].blocksRaycasts = true;
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
        if (Bscript.CurrentRound == 1)
        {
            IsChat = true;
            switch (Language)
            {
                case 1:
                    ChatText.text = "やってしまえ！";
                    break;
                case 2:
                    ChatText.text = "Go get 'em!";
                    break;
            }
            Invoke("OutChat", 1.5f);
            Invoke("Act1_1", 1.5f);
            Invoke("Act1_2", 3f);
            Invoke("ActEnd", 4f);
        }
        else
        {
            switch (AJ)
            {
                case 0:
                    Act2_1();
                    Invoke("Act2_2", 0.5f);
                    Invoke("ActEnd", 1.5f);
                    break;
                case 1:
                    Act3_1();
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
        for (int i = 0; i < 25; i++)
        {
            int Judge = Random.Range(0, 49);
            for(;Pscript.JewelNum[Judge] == 302 ; )
            {
                Judge = Random.Range(0, 49);
            }
            Pscript.JewelNum[Judge] = 302;
            GameObject g2 = Instantiate(MucusGem);
            g2.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g2.transform.SetParent(Pscript.gameObject.transform, true);
            Destroy(Pscript.JewelDisplay[Judge]);
            Pscript.JewelDisplay[Judge] = g2;
            GameObject g3 = Instantiate(MucusEffect);
            g3.transform.position = Pscript.JewelDisplay[Judge].transform.position;
        }
        if (AJ == 1)
        {
            AJ = 0;
        }
        else
        {
            AJ = Random.Range(0, 2);
        }
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((180 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate);
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
        for (int i = 0; i < 10; i++)
        {
            int Judge = Random.Range(0, 49);
            for (; Pscript.JewelNum[Judge] == 302;)
            {
                Judge = Random.Range(0, 49);
            }
            Pscript.JewelNum[Judge] = 302;
            GameObject g2 = Instantiate(MucusGem);
            g2.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g2.transform.SetParent(Pscript.gameObject.transform, true);
            Destroy(Pscript.JewelDisplay[Judge]);
            Pscript.JewelDisplay[Judge] = g2;
            GameObject g3 = Instantiate(MucusEffect);
            g3.transform.position = Pscript.JewelDisplay[Judge].transform.position;
        }
        AJ = Random.Range(0, 2);
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
        GameObject g = Instantiate(Counter);
        g.transform.position = this.transform.position;
        switch (Language)
        {
            case 1:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "攻撃激化 + 25%";
                break;
            case 2:
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "Attack Power +25%";
                break;
        }
        g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
        g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
        g.SetActive(true);
        AttackRate += 0.25f;
        IsBuff = true;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
        for (int i = 0; i < 20; i++)
        {
            int Judge = Random.Range(0, 49);
            for (; Pscript.JewelNum[Judge] == 302;)
            {
                Judge = Random.Range(0, 49);
            }
            Pscript.JewelNum[Judge] = 302;
            GameObject g2 = Instantiate(MucusGem);
            g2.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g2.transform.SetParent(Pscript.gameObject.transform, true);
            Destroy(Pscript.JewelDisplay[Judge]);
            Pscript.JewelDisplay[Judge] = g2;
            GameObject g3 = Instantiate(MucusEffect);
            g3.transform.position = Pscript.JewelDisplay[Judge].transform.position;
        }
        AJ = 0;
    }
}
