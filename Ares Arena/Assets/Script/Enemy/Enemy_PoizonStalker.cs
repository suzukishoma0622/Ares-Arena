using System.Linq;
using TMPro;
using UnityEngine;

public class Enemy_PoizonStalker : MonoBehaviour
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

    public CanvasGroup[] DebuffCG;
    bool IsDebuff;
    public GameObject PoizonGem;
    public GameObject PoizonEffect;
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch (PlayerPrefs.GetInt("EnemyHPLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1430;
                break;
            case 2:
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
                AttackText[0].text = ((160 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。ランダムな宝石" + (7 + Bscript.CurrentRound + Bscript.AbilityLevel * 2).ToString("0") + "つを致死毒に変化させる。";
                AttackText[1].text = ((110 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。";
                break;
            case 2:
                AttackText[0].text = "Deal " + ((160 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate).ToString("0") + " Damage. Transforms " + (7 + Bscript.CurrentRound + Bscript.AbilityLevel * 2).ToString("0") + " random gems into Poison.";
                AttackText[1].text = "Deal " + ((110 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate).ToString("0") + " Damage.";
                break;
        }
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
            switch (Bscript.CurrentRound % 2)
            {
                case 1:
                    ActForecast[0].alpha += Time.deltaTime * 2f;
                    ActForecast[0].interactable = true;
                    ActForecast[0].blocksRaycasts = true;
                    break;
                case 0:
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
    }
    public void Action()
    {
        IsForecast = false;
        switch(Bscript.CurrentRound % 2)
        {
            case 1:
                Act1_1();
                Invoke("Act1_2", 1.5f);
                Invoke("ActEnd", 2.5f);
                break;
            case 0:
                Invoke("Act2_1", 0.2f);
                Invoke("Act2_1", 0.4f);
                Invoke("Act2_1", 0.6f);
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
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((160 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate);
        IsDebuff = true;
        Bscript.Iscript.SE.PlayOneShot(Bscript.Iscript.DebuffSE);
        for (int i = 0; i < 7 + Bscript.CurrentRound + Bscript.AbilityLevel * 2; i++)
        {
            int Judge = Random.Range(0, 49);
            for(;Pscript.JewelNum[Judge] == 300 ; )
            {
                Judge = Random.Range(0, 49);
            }
            Pscript.JewelNum[Judge] = 300;
            GameObject g2 = Instantiate(PoizonGem);
            g2.transform.position = Pscript.JewelDisplay[Judge].transform.position;
            g2.transform.SetParent(Pscript.gameObject.transform, true);
            Destroy(Pscript.JewelDisplay[Judge]);
            Pscript.JewelDisplay[Judge] = g2;
            GameObject g3 = Instantiate(PoizonEffect);
            g3.transform.position = Pscript.JewelDisplay[Judge].transform.position;
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
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((110 + Bscript.AttackLevel * 10) * AttackRate * StrengthRate);
    }
    public void Poizon()
    {
        for(int i = 0; i < 49; i++)
        {
            if (Pscript.JewelNum[i] == 300 && !Bscript.IsDefeat)
            {
                GameObject g = Instantiate(AttackObj[2]);
                g.transform.position = Pscript.JewelDisplay[i].transform.position;
                g.GetComponent<BlockTrail>().GoPlayer = true;
                g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(0.04f * Bscript.Iscript.PlayerMaxHP);
                g.SetActive(true);
            }
        }
    }
}
