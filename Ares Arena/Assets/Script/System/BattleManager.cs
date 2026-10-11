using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if !UNITY_WEBGL
using Steamworks;
#endif

public class BattleManager : MonoBehaviour
{
    SaveData data;
    public PuzzleManager Pscript;
    public InfoDisplay Iscript;
    public int CurrentRound;
    public int PlayerHP;
    public int EnemyHP;
    public int EnemyMaxHP;
    public int PlayerShield;
    public int EnemyShield;
    public Slider PlayerHPSlider;
    public Slider EnemyHPSlider;
    public Slider PlayerHLSlider;
    public Slider EnemyHLSlider;
    public TMP_Text PlayerHPText;
    public TMP_Text EnemyHPText;
    public TMP_Text PlayerShieldText;
    public TMP_Text EnemyShieldText;
    public Slider RevengeSlider;
    public CanvasGroup RevengeFlash;
    public GameObject RevengeGo;
    public bool IsG;
    float HitStop;

    public int PatternNum;

    public Transform PlayerPos;
    public Transform EnemyPos;
    Vector3 DefaultPos_P;
    Vector3 DefaultPos_E;
    float PlayerForward;
    float EnemyForward;

    public GameObject NumberCounter;
    public CanvasGroup PlayerTurnEffect;
    public CanvasGroup EnemyTurnEffect;
    bool IsP;
    bool IsE;
    public bool IsR;
    public CanvasGroup TurnEndButton;
    public bool IsDead;
    public bool IsDefeat;
    public CanvasGroup[] GameOverCG;
    bool D2;
    public GameObject[] FlashObj;
    public Fadein[] CharaFade;
    public GameObject RewardObj;
    public GameObject RestObj;
    float StrengthRate = 1f;

    int Language;
    public Animator Saintanim;
    public TMP_Text SaintName;
    public int RewardMedal = 3;
    public TMP_Text MedalText;

    public int HPLevel;
    public int AttackLevel;
    public int AbilityLevel;

    public AudioClip StartSE;
    public AudioClip DefeatSE;
    public AudioClip DeadSE;
    public AudioClip PlayerTurnSE;
    public AudioClip EnemyTurnSE;

    public AudioClip DeadBGM;
    public AudioClip DefeatBGM;

    public int Bless22;

    public GameObject AttensionObj;

    void Start()
    {
        data = Iscript.GetComponent<DataManager>().Dscript;
        Iscript.SE.PlayOneShot(StartSE);
        if (Iscript.CurrentRound == 7)
        {
            if (Iscript.Boss == 6)
            {
                Iscript.BGMnum = 4;
                Iscript.AresBGM.Play();
            }
            else
            {
                Iscript.BGMnum = 3;
                Iscript.BossBGM.Play();
            }
        }
        else
        {
            Iscript.BGMnum = 1;
        }
        Invoke("RoundStart", 1.5f);
        DefaultPos_P = PlayerPos.position;
        DefaultPos_E = EnemyPos.position;
        StrengthRate = 1f + (Iscript.CurrentRound - 1) * 0.2f;
        RevengeSlider.maxValue = Mathf.FloorToInt(100 * Iscript.PlayerHPRate);
        Language = PlayerPrefs.GetInt("Language", 2);
        Saintanim.Play($"Saint{PlayerPrefs.GetInt("Saint1", 1)}");
        switch(PlayerPrefs.GetInt("Saint1", 1))
        {
            case 1:
                switch(Language)
                {
                    case 1:
                        SaintName.text = "ヴァルキリー";
                        break;
                    case 2:
                        SaintName.text = "The Valkyrie";
                        break;
                }
                break;
            case 2:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "ウォッチャー";
                        break;
                    case 2:
                        SaintName.text = "The Watcher";
                        break;
                }
                break;
            case 3:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "シアー";
                        break;
                    case 2:
                        SaintName.text = "The Sear";
                        break;
                }
                break;
            case 4:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "フラクタル";
                        break;
                    case 2:
                        SaintName.text = "The Fractal";
                        break;
                }
                break;
            case 5:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "セントリー";
                        break;
                    case 2:
                        SaintName.text = "The Sentry";
                        break;
                }
                break;
            case 6:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "ファントム";
                        break;
                    case 2:
                        SaintName.text = "The Phantom";
                        break;
                }
                break;
            case 7:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "コレクター";
                        break;
                    case 2:
                        SaintName.text = "The Collector";
                        break;
                }
                break;
            case 8:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "ノーヴル";
                        break;
                    case 2:
                        SaintName.text = "The Noble";
                        break;
                }
                break;
            case 9:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "ゴーレム";
                        break;
                    case 2:
                        SaintName.text = "The Golem";
                        break;
                }
                break;
            case 10:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "オーダー";
                        break;
                    case 2:
                        SaintName.text = "The Order";
                        break;
                }
                break;
            case 11:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "クリエイター";
                        break;
                    case 2:
                        SaintName.text = "The Creator";
                        break;
                }
                break;
            case 12:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "マトリックス";
                        break;
                    case 2:
                        SaintName.text = "The Matrix";
                        break;
                }
                break;
            case 13:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "レヴナント";
                        break;
                    case 2:
                        SaintName.text = "The Revenant";
                        break;
                }
                break;
            case 14:
                switch (Language)
                {
                    case 1:
                        SaintName.text = "フォーミュラ";
                        break;
                    case 2:
                        SaintName.text = "The Formula";
                        break;
                }
                break;
        }
        HPLevel = PlayerPrefs.GetInt("EnemyHPLevel", 0);
        AttackLevel = PlayerPrefs.GetInt("EnemyAttackLevel", 0);
        AbilityLevel = PlayerPrefs.GetInt("EnemyAbilityLevel", 0);
        if (Iscript.CurrentRound == 7 && (Iscript.Saint == 1 && Iscript.Crown >= 5) || (Iscript.Saint == 8 && Iscript.Crown >= 5) || (Iscript.Saint == 14 && Iscript.Crown >= 5))
        {
            EnemyMaxHP = Mathf.FloorToInt(EnemyMaxHP * 1.25f);
            EnemyHP = EnemyMaxHP;
        }
    }
    void Update()
    {
        PlayerHP = Iscript.PlayerHP;
        PlayerHPSlider.value = PlayerHP;
        PlayerHPSlider.maxValue = Iscript.PlayerMaxHP;
        EnemyHPSlider.value = EnemyHP;
        EnemyHPSlider.maxValue = EnemyMaxHP;
        PlayerHLSlider.maxValue = Iscript.PlayerMaxHP;
        EnemyHLSlider.maxValue = EnemyMaxHP;
        PlayerHPText.text = PlayerHP.ToString("0") + "/" + Iscript.PlayerMaxHP;
        EnemyHPText.text = EnemyHP.ToString("0") + "/" + EnemyMaxHP;
        PlayerShieldText.text = PlayerShield.ToString("0") + " Shield";
        EnemyShieldText.text = EnemyShield.ToString("0") + " Shield";
        RevengeSlider.value = Iscript.Revenge;
        if(RevengeSlider.value == RevengeSlider.maxValue)
        {
            RevengeGo.SetActive(true);
        }
        else
        {
            RevengeGo.SetActive(false);
        }
        if(IsG)
        {
            RevengeFlash.alpha = 1f;
            IsG = false;
        }
        else
        {
            RevengeFlash.alpha -= Time.deltaTime;
        }
        if(IsP)
        {
            PlayerTurnEffect.alpha += Time.deltaTime * 2f;
        }
        else
        {
            PlayerTurnEffect.alpha -= Time.deltaTime * 2f;
        }
        if (IsE)
        {
            EnemyTurnEffect.alpha += Time.deltaTime * 2f;
        }
        else
        {
            EnemyTurnEffect.alpha -= Time.deltaTime * 2f;
        }
        if(IsDead)
        {
            GameOverCG[0].gameObject.SetActive(true);
            GameOverCG[0].alpha += Time.deltaTime;
        }
        if(D2)
        {
            GameOverCG[1].gameObject.SetActive(true);
            GameOverCG[1].alpha += Time.deltaTime;
        }

        if (PlayerShield > 0)
        {
            PlayerShieldText.gameObject.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 4f;
        }
        else
        {
            PlayerShieldText.gameObject.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 4f;
        }
        if (EnemyShield > 0)
        {
            EnemyShieldText.gameObject.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 4f;
        }
        else
        {
            EnemyShieldText.gameObject.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 4f;
        }
        if (HitStop > 0f)
        {
            HitStop -= Time.deltaTime;
        }
        else
        {
            if(PlayerHLSlider.value > PlayerHPSlider.value)
            {
                PlayerHLSlider.value -= Time.deltaTime * (10 + PlayerHLSlider.value - PlayerHPSlider.value);
            }
            else
            {
                PlayerHLSlider.value = PlayerHPSlider.value;
            }
            if (EnemyHLSlider.value > EnemyHPSlider.value)
            {
                EnemyHLSlider.value -= Time.deltaTime * (10 + EnemyHLSlider.value - EnemyHPSlider.value);
            }
            else
            {
                EnemyHLSlider.value = EnemyHPSlider.value;
            }
        }
        PlayerPos.position = DefaultPos_P + new Vector3(PlayerForward, 0f, 0f);
        EnemyPos.position = DefaultPos_E - new Vector3(EnemyForward, 0f, 0f);
        if(PlayerForward > 0f)
        {
            PlayerForward -= Time.deltaTime;
        }
        if (EnemyForward > 0f)
        {
            EnemyForward -= Time.deltaTime;
        }
        if(Pscript.PlayerRound)
        {
            TurnEndButton.alpha += Time.deltaTime * 2f;
            TurnEndButton.interactable = true;
        }
        else
        {
            TurnEndButton.alpha -= Time.deltaTime * 2f;
            TurnEndButton.interactable = false;
        }
    }
    public void DeadEffect()
    {
        if (Iscript.Bless[20] == 1 && Iscript.Bless20 == 0)
        {
            GameObject g = Instantiate(Pscript.HealEffect);
            g.transform.position = Pscript.gameObject.transform.position;
            g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.2f * (1 + Iscript.Bless[54]));
            g.GetComponent<BlockTrail>().GoPlayer = true;
            g.SetActive(true);
            Iscript.Bless20 = 1;
            Iscript.SE.PlayOneShot(DeadSE);
        }
        else
        {
            if (!IsDead)
            {
                IsDead = true;
                CharaFade[0].fade = true;
                FlashObj[0].SetActive(true);
                Invoke("D2On", 1.5f);
                Iscript.SE.PlayOneShot(DeadSE);
                Iscript.SE.PlayOneShot(DeadBGM);
                Iscript.BGMnum = 0;
            }
        }
    }
    public void DefeatEffect()
    {
        IsDefeat = true;
        Iscript.SE.PlayOneShot(DefeatSE);
        CharaFade[1].fade = true;
        FlashObj[1].SetActive(true);
        Invoke("S2On", 1.5f);
        if (Iscript.Bless[4] == 1)
        {
            Iscript.PlayerHP += Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.12f * (1 + Iscript.Bless[54]));
            if(Iscript.PlayerHP > Iscript.PlayerMaxHP)
            {
                Iscript.PlayerHP = Iscript.PlayerMaxHP;
            }
        }
        if (Iscript.Bless[9] == 1 && Iscript.CurrentRound <= 3)
        {
            Iscript.PlayerHP += Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.18f * (1 + Iscript.Bless[54]));
            if (Iscript.PlayerHP > Iscript.PlayerMaxHP)
            {
                Iscript.PlayerHP = Iscript.PlayerMaxHP;
            }
        }
        if (Iscript.Bless[13] == 1 && Iscript.PlayerHP <= Iscript.PlayerMaxHP * 0.4f)
        {
            Iscript.PlayerHP = Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.4f * (1 + Iscript.Bless[54]));
        }
        if(Iscript.CurrentRound == 7)
        {
            Iscript.SE.PlayOneShot(DefeatBGM);
            Iscript.BGMnum = 0;
        }
        #if !UNITY_WEBGL

        if(Iscript.CurrentRound == 7)
        {
            if (SteamManager.Initialized)
            {
                SteamUserStats.GetAchievement($"Achieve{Iscript.Boss + 7}", out bool isUnlocked);
                if (!isUnlocked)
                {
                    SteamUserStats.SetAchievement($"Achieve{Iscript.Boss + 7}");
                }

                if (PlayerPrefs.GetInt("Damaged", 0) == 0)
                {
                    SteamUserStats.GetAchievement("Achieve21", out bool isUnlocked2);
                    if (!isUnlocked2)
                    {
                        SteamUserStats.SetAchievement("Achieve21");
                    }
                }
            }
            SteamUserStats.StoreStats();
        }
        if(CurrentRound == 1)
        {
            if (SteamManager.Initialized)
            {
                SteamUserStats.GetAchievement("Achieve15", out bool isUnlocked);
                if (!isUnlocked)
                {
                    SteamUserStats.SetAchievement("Achieve15");
                }
                SteamUserStats.StoreStats();
            }
        }
        if (Iscript.CurrentRound == 7 && Iscript.BlessList[1] == 0)
        {
            if (SteamManager.Initialized)
            {
                SteamUserStats.GetAchievement("Achieve17", out bool isUnlocked);
                if (!isUnlocked)
                {
                    SteamUserStats.SetAchievement("Achieve17");
                }
                SteamUserStats.StoreStats();
            }
        }
        if (Iscript.CurrentRound == 3 && PlayerPrefs.GetInt("A18", 0) == 0)
        {
            if (SteamManager.Initialized)
            {
                SteamUserStats.GetAchievement("Achieve18", out bool isUnlocked);
                if (!isUnlocked)
                {
                    SteamUserStats.SetAchievement("Achieve18");
                }
                SteamUserStats.StoreStats();
            }
        }
        if (PlayerPrefs.GetInt("Skilled", 0) == 0)
        {
            if (SteamManager.Initialized)
            {
                SteamUserStats.GetAchievement("Achieve24", out bool isUnlocked);
                if (!isUnlocked)
                {
                    SteamUserStats.SetAchievement("Achieve24");
                }
                SteamUserStats.StoreStats();
            }
        }
#endif
    }
    public void RoundStart()
    {
        if (!IsDead)
        {
            CurrentRound++;
            IsP = true;
            Invoke("R", 1f);
            Pscript.Gem54 = 32;
            PlayerPrefs.SetInt("Gem54", 32);
            PlayerPrefs.SetInt("HPLose", 0);
            PlayerPrefs.Save();
            Iscript.SE.PlayOneShot(PlayerTurnSE);
            if(Pscript.MetalBody)
            {
                Pscript.MetalBody = false;
            }
            else if (Iscript.Bless[51] == 1)
            {
                if(PlayerShield > 100)
                {
                    PlayerShield = 100;
                }
            }
            else
            {
                PlayerShield = 0;
            }
            if (Iscript.Tutorial == 1)
            {
                Iscript.TutorialObj[0].SetActive(true);
                Iscript.Tutorial = 2;
            }
            else if (Iscript.Tutorial == 2)
            {
                Iscript.TutorialObj[1].SetActive(true);
                Iscript.Tutorial = 3;
            }
        }
    }
    public void RoundEnd()
    {
        if (!IsDefeat && !IsDead && (Iscript.Saint != 12 || Pscript.ActiveSkill == 0 || Iscript.Crown <= 1))
        {
            Invoke("R2", 1f);
            IsE = true;
            Pscript.PlayerRound = false;
            EnemyShield = 0;
            Pscript.Debuff_Lightning = 0;
            for(int i = 0; i < 49; i++)
            {
                if (Pscript.JewelNum[i] == 14)
                {
                    Pscript.JewelVanish(i);
                }
            }

            Pscript.CollectorPut = -1;
            for (int j = 0; j < 5; j++)
            {
                Pscript.CollectorPutCG[j].alpha = 0;
            }
            Iscript.SE.PlayOneShot(EnemyTurnSE);
            if(Iscript.Bless[47] == 1)
            {
                GameObject g3 = Instantiate(Pscript.ShieldEffect);
                g3.transform.position = Pscript.gameObject.transform.position;
                g3.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(PlayerShield * 0.08f);
                g3.GetComponent<BlockTrail>().GoPlayer = true;
                g3.SetActive(true);
            }
            if (Iscript.Bless[78] == 1 && RevengeSlider.value == RevengeSlider.maxValue)
            {
                GameObject g = Instantiate(Pscript.HealEffect);
                g.transform.position = this.transform.position;
                g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.05f);
                g.GetComponent<BlockTrail>().GoPlayer = true;
                g.SetActive(true);
                if (Iscript.Bless[3] == 1)
                {
                    Pscript.Bless3 += Iscript.PlayerMaxHP * 0.05f * 0.1f;
                    if (Pscript.Bless3 >= 1f)
                    {
                        Iscript.PlayerMaxHP += Mathf.FloorToInt(Pscript.Bless3 * (1 + Iscript.Bless[54]));
                        Iscript.PlayerHP += Mathf.FloorToInt(Pscript.Bless3 * (1 + Iscript.Bless[54]));
                        Pscript.Bless3 -= Mathf.FloorToInt(Pscript.Bless3 * (1 + Iscript.Bless[54]));
                    }
                }
            }
            if (Pscript.IsFilamentMilitar)
            {
                if(Pscript.Fscript.Bind > 0)
                {
                    GameObject g3 = Instantiate(Pscript.AttackEffect);
                    g3.transform.position = Pscript.gameObject.transform.position;
                    g3.GetComponent<EffectScript>().EffectNum = Pscript.Fscript.Bind;
                    g3.GetComponent<BlockTrail>().GoPlayer = true;
                    g3.SetActive(true);
                }
            }
            if(Iscript.Saint == 14)
            {
                Pscript.DroidActivate();
            }
            AttensionOff();
        }
    }
    void R()
    {
        Pscript.RoundStart();
        Pscript.PlayerRound = true;
        IsP = false;
    }
    void R2()
    {
        IsE = false;
        IsR = true;
    }
    void D2On()
    {
        D2 = true;
    }
    void S2On()
    {
        if (Iscript.Bless[32] == 1)
        {
            RewardMedal += 1;
        }
        if (Iscript.Bless[74] == 1)
        {
            RewardMedal += 4;
            Iscript.Bless[74] = 2;
        }
        for (int j = 0;j < 5; j++)
        {
            if (Pscript.EquipJewel[j] == 89)
            {
                RewardMedal -= 1;
                break;
            }
        }
        MedalText.text = "x" + RewardMedal.ToString();
        RewardObj.SetActive(true);
        PlayerPrefs.SetInt("Medal", PlayerPrefs.GetInt("Medal", 0) + RewardMedal);
        PlayerPrefs.Save();
    }
    public void GoRest()
    {
        Iscript.Fade = true;
        Invoke("Rest", 1f);
        Iscript.SE.PlayOneShot(Iscript.OKSE);
        for(int j = 0; j < 5; j++)
        {
            if (Iscript.JewelNum[j] == 133)
            {
                Pscript.Gem133 += 5;
                PlayerPrefs.SetInt("Gem133", Pscript.Gem133);
                PlayerPrefs.Save();
                break;
            }
        }
    }
    void Rest()
    {
        GameObject g = Instantiate(RestObj);
        g.transform.position = RestObj.transform.position;
        g.SetActive(true);
        Iscript.CurrentRound += 1;
        Pscript.Probcalc();
        Destroy(this.gameObject);
    }
    public void GoTitle()
    {
        if(Iscript.Saint == data.SaintUnlock + 1)
        {
            data.SaintUnlock = Iscript.Saint;
        }
        GameOverCG[2].gameObject.SetActive(true);
        Invoke("T", 1.5f);
    }
    private void T()
    {
        SceneManager.LoadScene("Title");
    }
    public void AttensionOn()
    {
        if(Pscript.CurrentHand > 0 || Pscript.ActiveSkill > 0)
        {
            AttensionObj.SetActive(true);
        }
    }
    public void AttensionOff()
    {
        AttensionObj?.SetActive(false);
    }
}
