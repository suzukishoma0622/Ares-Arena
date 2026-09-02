using TMPro;
using UnityEngine;

public class Enemy_LaserRanger : MonoBehaviour
{
    public BattleManager Bscript;
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
    public AudioClip[] EnemySE;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        StrengthRate = 1f + (Bscript.Iscript.CurrentRound - 1) * 0.2f;
        Invoke("F", 1.5f);
        switch(PlayerPrefs.GetInt("EnemyStatusLevel", 0))
        {
            case 1:
                Bscript.EnemyMaxHP = 1220;
                break;
            case 2:
                Bscript.EnemyMaxHP = 1300;
                break;
            case 3:
                Bscript.EnemyMaxHP = 1380;
                break;
            case 4:
                Bscript.EnemyMaxHP = 1460;
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
                AttackText[0].text = (100 * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。" + ((200 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate).ToString("0") + "シールドを得る。";
                AttackText[1].text = ((240 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate).ToString("0") + "ダメージを与える。";
                break;
            case 2:
                AttackText[0].text = "Deal " + (100 * AttackRate * StrengthRate).ToString("0") + " Damage. Gain " + ((200 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate).ToString("0") + " Shield.";
                AttackText[1].text = "Deal " + ((240 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate).ToString("0") + " Damage.";
                break;
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
                Invoke("Act1_2", 0.5f);
                Invoke("Act1_3", 1f);
                Invoke("ActEnd", 2.5f);
                break;
            case 0:
                IsChat = true;
                int j = Random.Range(0, 2);
                switch(Language)
                {
                    case 1:
                        switch(j)
                        {
                            case 0:
                                ChatText.text = "吹き飛ばしてやる！";
                                break;
                            case 1:
                                ChatText.text = "これでも喰らえ！";
                                break;
                        }
                        break;
                    case 2:
                        switch (j)
                        {
                            case 0:
                                ChatText.text = "Get blown away！";
                                break;
                            case 1:
                                ChatText.text = "Take this！";
                                break;
                        }
                        break;
                }
                Invoke("OutChat", 1.5f);
                Invoke("Act2_1", 1.5f);
                Invoke("Act2_2", 2f);
                Invoke("ActEnd", 3f);
                break;
        }
    }
    void OutChat()
    {
        IsChat = false;
    }
    void Act1_1()
    {
        GameObject g = Instantiate(AttackObj[0]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = false;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((200 + Bscript.Iscript.Crown * 20) * StrengthRate);
    }
    void Act1_2()
    {
        GameObject g = Instantiate(Effect[0]);
        g.transform.position = Effect[0].transform.position;
        g.SetActive(true);
        Bscript.Iscript.SE.PlayOneShot(EnemySE[0]);
    }
    void Act1_3()
    {
        GameObject g = Instantiate(AttackObj[1]);
        g.transform.position = this.transform.position;
        g.GetComponent<BlockTrail>().GoPlayer = true;
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(100 * StrengthRate);
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
        g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((240 + Bscript.Iscript.Crown * 20) * AttackRate * StrengthRate);
    }
}
