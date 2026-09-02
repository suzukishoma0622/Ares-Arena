using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoDisplay : MonoBehaviour
{
    public int PlayerMaxHP;
    public int PlayerHP;
    int HP2;
    public int[] JewelNum = { 0, 1, 2, 3, 4 };
    public int Revenge;
    public InfoDisplay_Gem[] Gscript;
    public bool Fade;
    public CanvasGroup FadeCG;
    public int CurrentRound;
    public float PlayerHPRate = 1;
    public int Saint;
    public int[] EnemyPool = new int[32];
    public int[] ElitePool = new int[32];

    public int[] Bless;
    public int[] BlessList;
    public GameObject[] BlessObj;
    int BlessGain;
    public GameObject[] StarterObj;
    public Animator Crownanim;

    public int Crown;

    public AudioSource BGM;
    public AudioSource SE;
    public AudioSource BattleBGM;
    public AudioSource SilentBGM;
    public AudioSource BossBGM;
    public int BGMnum;
    public AudioClip OKSE;
    public AudioClip BlessSE;
    public AudioClip BuffSE;
    public AudioClip DebuffSE;

    public int Tutorial;
    public GameObject[] TutorialObj;

    int BGnum;
    public Animator[] BGanim;
    public AudioClip[] BGMPool1;
    public AudioClip[] BGMPool2;
    public AudioClip[] BGMPool3;

    float ExitNum;
    void Start()
    {
        Crown = PlayerPrefs.GetInt("Crown", 0);
        if (Crown == 0)
        {
            Crownanim.gameObject.SetActive(false);
        }
        else
        {
            Crownanim.Play($"Crown{Crown}");
        }
        AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 1f);

        if (PlayerPrefs.GetInt("FirstStarter", 0) == 0)
        {
            StarterObj[0].SetActive(true);
            PlayerPrefs.SetInt("FirstStarter", 1);
            PlayerPrefs.Save();
            Tutorial = 1;
        }
        else
        {
            int Judge = Random.Range(0, StarterObj.Length);
            StarterObj[Judge].SetActive(true);
        }
        Saint = PlayerPrefs.GetInt("Saint1", 1);
        switch(Saint)
        {
            case 1:
                PlayerMaxHP = 400;
                break;
            case 2:
                PlayerMaxHP = 350;
                break;
            case 3:
                PlayerMaxHP = 450;
                break;
            case 4:
                PlayerMaxHP = 360;
                break;
            case 5:
                PlayerMaxHP = 420;
                break;
            case 6:
                PlayerMaxHP = 360;
                break;
            case 7:
                PlayerMaxHP = 370;
                break;
            case 8:
                PlayerMaxHP = 400;
                break;
            case 9:
                PlayerMaxHP = 500;
                break;
            case 10:
                PlayerMaxHP = 380;
                break;
            case 11:
                PlayerMaxHP = 300;
                break;
            case 12:
                PlayerMaxHP = 400;
                break;
            case 13:
                PlayerMaxHP = 350;
                break;

        }
        PlayerHP = PlayerMaxHP;
        HP2 = PlayerHP;
        for (int i = 0; i < 20; i++)
        {
            PlayerPrefs.SetInt($"GemBox{i}", -1);
        }
        if (Crown > 0)
        {
            PlayerPrefs.SetInt("Medal", Mathf.FloorToInt(Crown / 2) + 1);
        }
        else
        {
            PlayerPrefs.SetInt("Medal", 0);
        }
        PlayerPrefs.SetInt("StarterCount", 0);
        PlayerPrefs.SetInt("Gem53", 5);
        PlayerPrefs.SetInt("Gem70", 50);
        PlayerPrefs.SetInt("SentryRevenge", 0);
        for(int i = 0; i < 4; i++)
        {
            PlayerPrefs.SetInt($"Potion{i}", 0);
        }
        PlayerPrefs.Save();
        BGnum = Random.Range(0, BGMPool1.Length);
        BGanim[0].Play($"GameBG1_{BGnum + 1}");
        BGanim[1].Play($"GameBG2_{BGnum + 1}");
        BattleBGM.generator = BGMPool1[BGnum];
        SilentBGM.generator = BGMPool2[BGnum];
        BossBGM.generator = BGMPool3[BGnum];
    }
    void Update()
    {
        switch(BGMnum)
        {
            case 0:
                BattleBGM.volume -= Time.deltaTime;
                SilentBGM.volume -= Time.deltaTime;
                BossBGM.volume -= Time.deltaTime * 2f;
                break;
            case 1:
                BattleBGM.volume += Time.deltaTime;
                SilentBGM.volume -= Time.deltaTime;
                BossBGM.volume -= Time.deltaTime * 2f;
                break;
            case 2:
                BattleBGM.volume -= Time.deltaTime;
                SilentBGM.volume += Time.deltaTime;
                BossBGM.volume -= Time.deltaTime * 2f;
                break;
            case 3:
                BattleBGM.volume -= Time.deltaTime;
                SilentBGM.volume -= Time.deltaTime;
                BossBGM.volume = 1f;
                break;
        }
        for(int i = 0; i < JewelNum.Length; i++)
        {
            Gscript[i].GemNum = JewelNum[i];
        }
        if (Fade)
        {
            FadeCG.alpha += Time.deltaTime;
            if (FadeCG.alpha == 1f)
            {
                Fade = false;
            }
        }
        else
        {
            FadeCG.alpha -= Time.deltaTime;
        }
        if(HP2 > PlayerHP)
        {
            PlayerPrefs.SetInt("HPLose", PlayerPrefs.GetInt("HPLose", 0) + 1);
            PlayerPrefs.Save();
            HP2 = PlayerHP;
        }
        else
        {
            HP2 = PlayerHP;
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            ExitNum += Time.deltaTime;
            if(ExitNum >= 1f)
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
    public void BlessAdd(int i)
    {
        Bless[i] = 1;
        for(int j = 0; j < 12; j++)
        {
            if (BlessList[j] == 0)
            {
                BlessList[j] = i;
                break;
            }
        }
        BlessObj[BlessGain].SetActive(true);
        BlessObj[BlessGain].GetComponent<InfoDisplay_Bless>().BlessNum = i;
        BlessGain += 1;
        SE.PlayOneShot(BlessSE);
        switch(i)
        {
            case 1:
                PlayerMaxHP = Mathf.FloorToInt(PlayerMaxHP * 1.15f);
                PlayerHP = Mathf.FloorToInt(PlayerHP * 1.15f);
                PlayerHPRate *= 1.15f;
                break;
            case 5:
                JewelNum[3] = 6;
                break;
            case 7:
                JewelNum[1] = 7;
                break;
            case 12:
                PlayerPrefs.SetInt("Medal", PlayerPrefs.GetInt("Medal", 0) + 2);
                PlayerPrefs.Save();
                break;
            case 14:
                PlayerMaxHP = Mathf.FloorToInt(PlayerMaxHP * 1.25f);
                PlayerHP = Mathf.FloorToInt(PlayerHP * 0.625f);
                PlayerHPRate *= 1.25f;
                break;
            case 15:
                JewelNum[0] = 5;
                break;
            case 18:
                PlayerHPRate *= 0.85f;
                break;
            case 45:
                PlayerMaxHP += 150;
                PlayerHP += 150;
                PlayerHPRate *= (PlayerMaxHP + 150) / PlayerMaxHP;
                break;
            case 54:
                if (Bless[1] == 1)
                {
                    PlayerMaxHP = Mathf.FloorToInt(PlayerMaxHP * 1.15f);
                    PlayerHP = Mathf.FloorToInt(PlayerHP * 1.15f);
                    PlayerHPRate *= 1.15f;
                }
                if (Bless[12] == 1)
                {
                    PlayerPrefs.SetInt("Medal", PlayerPrefs.GetInt("Medal", 0) + 2);
                    PlayerPrefs.Save();
                }
                if (Bless[14] == 1)
                {
                    PlayerMaxHP = Mathf.FloorToInt(PlayerMaxHP * 1.25f);
                    PlayerHP = Mathf.FloorToInt(PlayerHP * 1.25f);
                    PlayerHPRate *= 1.25f;
                }
                if (Bless[18] == 1)
                {
                    PlayerHPRate *= 0.85f;
                }
                break;
        }
    }
}
