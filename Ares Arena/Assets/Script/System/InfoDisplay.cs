using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class InfoDisplay : MonoBehaviour
{
    SaveData data;
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
    public int Casual;
    public int Boss;

    public AudioSource BGM;
    public AudioSource SE;
    public AudioSource BattleBGM;
    public AudioSource SilentBGM;
    public AudioSource BossBGM;
    public AudioSource AresBGM;
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

    bool IsPause;
    public GameObject PauseObj;
    public TMP_Text[] VolumeText;
    public Slider[] VolumeSlider;
    public AudioMixer Mixer;
    bool IsVolumeFade;
    public GameObject FadeObj;

    public int Bless20;
    public int Bless24;
    public int Bless65;
    public int Bless69;
    public bool Bless70;
    public int Bless81;

    void Start()
    {
        data = GetComponent<DataManager>().Dscript;
        Crown = PlayerPrefs.GetInt("Crown", 0);
        Casual = PlayerPrefs.GetInt("Casual", 0);
        Boss = Random.Range(0, 5);
        if (Crown == 0)
        {
            if(Casual == 1)
            {
                Crownanim.Play("Casual");
            }
            else
            {
                Crownanim.gameObject.SetActive(false);
            }
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
            case 14:
                PlayerMaxHP = 380;
                break;
        }
        if(Casual == 1)
        {
            PlayerMaxHP = Mathf.FloorToInt(PlayerMaxHP * 1.25f);
        }
        if((Saint == 1 && Crown >= 2) || (Saint == 5 && Crown >= 3) || (Saint == 6 && Crown >= 4) || (Saint == 9 && Crown >= 5) || (Saint == 13 && Crown >= 5))
        {
            PlayerMaxHP = Mathf.FloorToInt(PlayerMaxHP * 0.9f);
        }
        if ((Saint == 1 && Crown >= 3) || (Saint == 3 && Crown >= 4))
        {
            PlayerHP = Mathf.FloorToInt(PlayerMaxHP * 0.75f);
        }
        else
        {
            PlayerHP = PlayerMaxHP;
        }
        if ((Saint == 3 && Crown >= 2) || (Saint == 5 && Crown >= 4) || (Saint == 8 && Crown >= 4) || (Saint == 10 && Crown >= 4) || (Saint == 11 && Crown >= 2)
            || (Saint == 13 && Crown >= 3) || (Saint == 14 && Crown >= 3))
        {
            PlayerHPRate *= 1.2f;
        }
        HP2 = PlayerHP;
        for (int i = 0; i < 20; i++)
        {
            PlayerPrefs.SetInt($"GemBox{i}", -1);
        }
        PlayerPrefs.SetInt("Medal", 0);
        PlayerPrefs.SetInt("StarterCount", 0);
        PlayerPrefs.SetInt("Gem53", 5);
        PlayerPrefs.SetInt("Gem70", 60);
        PlayerPrefs.SetInt("Gem133", 10);
        PlayerPrefs.SetInt("SentryRevenge", 0);
        PlayerPrefs.SetInt("RestCount", 0);
        PlayerPrefs.SetInt("TrainCount", 0);
        PlayerPrefs.SetInt("A18", 0);
        for (int i = 0; i < 4; i++)
        {
            PlayerPrefs.SetInt($"Potion{i}", 0);
        }
        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt($"Droid{i}", 1);
        }
        PlayerPrefs.Save();
        if(PlayerPrefs.GetInt("Tutorial5", 0) == 2 && PlayerPrefs.GetInt("Casual", 0) == 0)
        {
            Bless81 = Random.Range(2, 7);
        }
        BGnum = Random.Range(0, BGMPool1.Length);
        BGanim[0].Play($"GameBG1_{BGnum + 1}");
        BGanim[1].Play($"GameBG2_{BGnum + 1}");
        BattleBGM.generator = BGMPool1[BGnum];
        SilentBGM.generator = BGMPool2[BGnum];
        BossBGM.generator = BGMPool3[BGnum];
        Mixer.GetFloat("Master_Volume", out float mastervolume);
        VolumeSlider[0].value = Mathf.Pow(10, mastervolume / 20);
        Mixer.GetFloat("BGM_Volume", out float bgmvolume);
        VolumeSlider[1].value = Mathf.Pow(10, bgmvolume / 20);
        Mixer.GetFloat("SE_Volume", out float sevolume);
        VolumeSlider[2].value = Mathf.Pow(10, sevolume / 20);
    }
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            VolumeText[i].text = (VolumeSlider[i].value * 100f).ToString("0") + "%";
        }
        if (IsVolumeFade)
        {
            BGM.volume -= Time.deltaTime * 2f;
        }
        switch (BGMnum)
        {
            case 0:
                BattleBGM.volume -= Time.deltaTime;
                SilentBGM.volume -= Time.deltaTime;
                BossBGM.volume -= Time.deltaTime * 2f;
                AresBGM.volume -= Time.deltaTime * 2f;
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
            case 4:
                BattleBGM.volume -= Time.deltaTime;
                SilentBGM.volume -= Time.deltaTime;
                AresBGM.volume = 1f;
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
        if(Input.GetMouseButtonDown(1))
        {
            if(IsPause)
            {
                IsPause = false;
                PauseObj.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                IsPause = true;
                PauseObj.SetActive(true);
                Time.timeScale = 0f;
            }
            SE.PlayOneShot(OKSE);
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
        data.BlessUnlock[i] = 1;
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
                PlayerMaxHP = Mathf.FloorToInt(PlayerMaxHP * 1.3f);
                PlayerHP = Mathf.FloorToInt(PlayerHP * 0.65f);
                PlayerHPRate *= 1.3f;
                break;
            case 15:
                JewelNum[0] = 5;
                break;
            case 18:
                PlayerHPRate *= 0.85f;
                break;
            case 24:
                Bless24 += 2;
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
                if (Bless[24] == 1)
                {
                    Bless24 += 2;
                }
                if (Bless[65] == 1)
                {
                    Bless65 += 1;
                }
                if (Bless[69] == 1)
                {
                    Bless69 += 25;
                }
                break;
            case 65:
                Bless65 = 1;
                break;
            case 69:
                Bless69 = 25;
                break;
            case 71:
                if (Bless[3] == 1)
                {
                    PlayerMaxHP += Mathf.FloorToInt((PlayerMaxHP - PlayerHP) * 0.1f);
                }
                PlayerHP = PlayerMaxHP;
                break;
            case 81:
                Boss = 6;
                break;
        }
    }
    public void SetMaster()
    {
        if (VolumeSlider[0].value <= 0f)
        {
            Mixer.SetFloat("Master_Volume", -80f);
        }
        else
        {
            Mixer.SetFloat("Master_Volume", Mathf.Log10(VolumeSlider[0].value) * 20f);
        }
    }
    public void SetBGM()
    {
        if (VolumeSlider[1].value <= 0f)
        {
            Mixer.SetFloat("BGM_Volume", -80f);
        }
        else
        {
            Mixer.SetFloat("BGM_Volume", Mathf.Log10(VolumeSlider[1].value) * 20f);
        }
    }
    public void SetSE()
    {
        if (VolumeSlider[2].value <= 0f)
        {
            Mixer.SetFloat("SE_Volume", -80f);
        }
        else
        {
            Mixer.SetFloat("SE_Volume", Mathf.Log10(VolumeSlider[2].value) * 20f);
        }
    }
    public void GiveUp()
    {
        SE.PlayOneShot(OKSE);
        FadeObj.SetActive(true);
        Invoke("SceneMove", 2f);
        IsVolumeFade = true;
        Time.timeScale = 1f;
    }
    void SceneMove()
    {
        SceneManager.LoadScene("Title");
    }
    public void Resume()
    {
        IsPause = false;
        PauseObj.SetActive(false);
        Time.timeScale = 1f;
    }
}
