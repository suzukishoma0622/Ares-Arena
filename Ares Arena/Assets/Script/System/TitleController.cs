using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TitleController : MonoBehaviour
{
    public bool[] IsSwitch;
    public float[] SwitchNum;

    public GameObject TitleButtonObj;
    public CanvasGroup TitleButtonCG;
    public GameObject StartModeObj;
    public CanvasGroup StartModeCG;
    public GameObject OptionObj;
    public CanvasGroup OptionCG;
    public GameObject CreditCG;
    public GameObject LibraryCG;
    public GameObject QuitCG;
    public TMP_Text[] VolumeText;
    public Slider[] VolumeSlider;
    public TMP_Text LanguageText;
    public TMP_Text FullScreenText;
    public TMP_Text VSnycText;
    public TMP_Text ResolutionText;
    public Slider DeleteSlider;
    public CanvasGroup DeleteCG;
    bool IsDelete;
    public GameObject FadeOut;

    int TitleNum = 0;
    int Difficulty = 0;
    int Language;
    int FullScreen;
    bool IsFS;
    int Vsnyc;
    int Resolution;

    public AudioMixer Mixer;
    public AudioSource BGM;
    public AudioSource SE;
    public AudioClip OkSE;
    public AudioClip RunStartSE;
    bool IsVolumeFade;

    bool IsCamera;
    public RectTransform TitleBG;
    public RectTransform FocusPos;

    void Start()
    {
        PlayerPrefs.SetInt("CurrentDifficulty", 0);
        PlayerPrefs.SetInt("Tutorial", 0);
        PlayerPrefs.Save();
        Language = PlayerPrefs.GetInt("Language", 2);
        FullScreen = PlayerPrefs.GetInt("FullScreen", 1);
        Vsnyc = PlayerPrefs.GetInt("Vsnyc", 1);
        Resolution = PlayerPrefs.GetInt("Resolution", 3);
        Mixer.GetFloat("Master_Volume", out float mastervolume);
        VolumeSlider[0].value = Mathf.Pow(10, mastervolume / 20);
        Mixer.GetFloat("BGM_Volume", out float bgmvolume);
        VolumeSlider[1].value = Mathf.Pow(10, bgmvolume / 20);
        Mixer.GetFloat("SE_Volume", out float sevolume);
        VolumeSlider[2].value = Mathf.Pow(10, sevolume / 20);
        switch (Language)
        {
            case 1:
                LanguageText.text = "“ú–{Œê";
                break;
            case 2:
                LanguageText.text = "English";
                break;
        }
        if(FullScreen == 1)
        {
            Screen.fullScreen = true;
            FullScreenText.text = "ON";
            
        }
        else
        {
            Screen.fullScreen = false;
            FullScreenText.text = "OFF";
        }
        if(Vsnyc == 1)
        {
            QualitySettings.vSyncCount = 1;
            VSnycText.text = "ON";
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            VSnycText.text = "OFF";
        }
        switch (Resolution)
        {
            case 1:
                ResolutionText.text = "960x540";
                Screen.SetResolution(960, 540, Screen.fullScreen);
                break;
            case 2:
                ResolutionText.text = "1280x720";
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 3:
                ResolutionText.text = "1920x1080";
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 4:
                ResolutionText.text = "3840x2160";
                Screen.SetResolution(3840, 2160, Screen.fullScreen);
                break;
        }
    }
    void Update()
    {
        if (!IsSwitch[0])
        {
            if (SwitchNum[0] > 2)
            {
                SwitchOn(0);
            }
            else
            {
                SwitchNum[0] += Time.deltaTime;
            }
        }
        if (!IsSwitch[1])
        {
            if (SwitchNum[1] > 0.5f)
            {
                SwitchOn(1);
            }
            else
            {
                SwitchNum[1] += Time.deltaTime;
            }
        }
        if (IsSwitch[1])
        {
            switch(TitleNum)
            {
                case 0:
                    TitleButtonObj.SetActive(true);
                    if(TitleButtonCG.alpha < 1f)
                    {
                        TitleButtonCG.alpha += Time.deltaTime * 3f;
                    }
                    if (StartModeCG.alpha > 0f)
                    {
                        StartModeCG.alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        StartModeObj.SetActive(false);
                    }
                    if (OptionCG.alpha > 0f)
                    {
                        OptionCG.alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        OptionObj.SetActive(false);
                    }
                    if (QuitCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        QuitCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        QuitCG.SetActive(false);
                    }
                    if (CreditCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        CreditCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        CreditCG.SetActive(false);
                    }
                    if (LibraryCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        LibraryCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        LibraryCG.SetActive(false);
                    }
                    break;
                case 1:
                    StartModeObj.SetActive(true);
                    if (StartModeCG.alpha < 1f)
                    {
                        StartModeCG.alpha += Time.deltaTime * 3f;
                    }
                    if (TitleButtonCG.alpha > 0f)
                    {
                        TitleButtonCG.alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        TitleButtonObj.SetActive(false);
                    }
                    if (QuitCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        QuitCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        QuitCG.SetActive(false);
                    }
                    if (CreditCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        CreditCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        CreditCG.SetActive(false);
                    }
                    if (LibraryCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        LibraryCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        LibraryCG.SetActive(false);
                    }
                    break;
                case 2:
                    OptionObj.SetActive(true);
                    if (OptionCG.alpha < 1f)
                    {
                        OptionCG.alpha += Time.deltaTime * 3f;
                    }
                    if (TitleButtonCG.alpha > 0f)
                    {
                        TitleButtonCG.alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        TitleButtonObj.SetActive(false);
                    }
                    if (QuitCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        QuitCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        QuitCG.SetActive(false);
                    }
                    if (CreditCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        CreditCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        CreditCG.SetActive(false);
                    }
                    if (LibraryCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        LibraryCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        LibraryCG.SetActive(false);
                    }
                    break;
                case 3:
                    QuitCG.SetActive(true);
                    if (QuitCG.GetComponent<CanvasGroup>().alpha < 1f)
                    {
                        QuitCG.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 3f;
                    }
                    if (TitleButtonCG.alpha > 0f)
                    {
                        TitleButtonCG.alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        TitleButtonObj.SetActive(false);
                    }
                    if (CreditCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        CreditCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        CreditCG.SetActive(false);
                    }
                    if (LibraryCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        LibraryCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        LibraryCG.SetActive(false);
                    }
                    break;
                case 4:
                    CreditCG.SetActive(true);
                    if (CreditCG.GetComponent<CanvasGroup>().alpha < 1f)
                    {
                        CreditCG.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 3f;
                    }
                    if (TitleButtonCG.alpha > 0f)
                    {
                        TitleButtonCG.alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        TitleButtonObj.SetActive(false);
                    }
                    if (OptionCG.alpha > 0f)
                    {
                        OptionCG.alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        OptionObj.SetActive(false);
                    }
                    if (QuitCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        QuitCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        QuitCG.SetActive(false);
                    }
                    if (LibraryCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        LibraryCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        LibraryCG.SetActive(false);
                    }
                    break;
                case 5:
                    LibraryCG.SetActive(true);
                    if (LibraryCG.GetComponent<CanvasGroup>().alpha < 1f)
                    {
                        LibraryCG.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 3f;
                    }
                    if (TitleButtonCG.alpha > 0f)
                    {
                        TitleButtonCG.alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        TitleButtonObj.SetActive(false);
                    }
                    if (OptionCG.alpha > 0f)
                    {
                        OptionCG.alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        OptionObj.SetActive(false);
                    }
                    if (QuitCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        QuitCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        QuitCG.SetActive(false);
                    }
                    if (CreditCG.GetComponent<CanvasGroup>().alpha > 0f)
                    {
                        CreditCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3f;
                    }
                    else
                    {
                        CreditCG.SetActive(false);
                    }
                    break;
            }
        }
        for(int i = 0; i < 3; i++)
        {
            VolumeText[i].text = (VolumeSlider[i].value * 100f).ToString("0") + "%";
        }
        if(IsDelete)
        {
            DeleteSlider.value += Time.deltaTime * 0.33f;
            DeleteCG.alpha += Time.deltaTime * 3f;
            if(DeleteSlider.value == 1f)
            {
                SE.PlayOneShot(OkSE);
                FadeOut.SetActive(true);
                Invoke("DeleteData", 1.5f);
                PlayerPrefs.DeleteAll();
                IsVolumeFade = true;
                IsDelete = false;
            }
        }
        else
        {
            DeleteSlider.value -= Time.deltaTime * 2f;
            DeleteCG.alpha -= Time.deltaTime * 1f;
        }
        if(IsVolumeFade)
        {
            BGM.volume -= Time.deltaTime * 2f;
        }
        if(IsCamera)
        {
            TitleBG.position = Vector3.MoveTowards(TitleBG.position, FocusPos.position, Time.deltaTime * 1000f);
            TitleBG.transform.localScale += new Vector3(Time.deltaTime * 3f, Time.deltaTime * 3f, 0f);
        }
    }
    void SwitchOn(int i)
    {
        IsSwitch[i] = true;
    }
    public void PageMove(int i)
    {
        TitleNum = i;
        SE.PlayOneShot(OkSE);
        FullScreen = PlayerPrefs.GetInt("FullScreen", 1);
        Vsnyc = PlayerPrefs.GetInt("VSnyc", 1);
        Resolution = PlayerPrefs.GetInt("Resolution", 3);
        if (FullScreen == 1)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
        if (Vsnyc == 1)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        switch(Resolution)
        {
            case 1:
                Screen.SetResolution(960, 540, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 3:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 4:
                Screen.SetResolution(3840, 2160, Screen.fullScreen);
                break;
        }
    }
    public void ModeChoose(int i)
    {
        PlayerPrefs.SetInt("CurrentGamemode", i);
        PlayerPrefs.Save();
        SE.PlayOneShot(OkSE);
    }
    public void DifficultyAscend()
    {
        if (Difficulty < 0)
        {
            Difficulty += 1;
        }
        PlayerPrefs.SetInt("CurrentDifficulty", Difficulty);
        PlayerPrefs.Save();
    }
    public void DifficultyDescend()
    {
        if (Difficulty > -1)
        {
            Difficulty -= 1;
        }
        PlayerPrefs.SetInt("CurrentDifficulty", Difficulty);
        PlayerPrefs.Save();
    }
    public void RunStart()
    {
        SE.PlayOneShot(OkSE);
        SE.PlayOneShot(RunStartSE);
        FadeOut.SetActive(true);
        Invoke("SceneMove", 2f);
        IsCamera = true;
        IsVolumeFade = true;
    }
    public void EndGame()
    {
        SE.PlayOneShot(OkSE);
        Application.Quit();
    }
    void SceneMove()
    {
        SceneManager.LoadScene("SaintSelect");
        IsVolumeFade = true;
    }
    void DeleteData()
    {
        SceneManager.LoadScene("TitleLogo");
        IsVolumeFade = true;
    }
    public void LanguageChange()
    {
        switch(Language)
        {
            case 1:
                Language = 2;
                LanguageText.text = "English";
                break;
            case 2:
                Language = 1;
                LanguageText.text = "“ú–{Œê";
                break;
        }
        PlayerPrefs.SetInt("Language", Language);
        PlayerPrefs.Save();
        SE.PlayOneShot(OkSE);
    }
    public void FullScreenChange()
    {
        switch(PlayerPrefs.GetInt("FullScreen", 1))
        {
            case 0:
                PlayerPrefs.SetInt("FullScreen", 1);
                FullScreenText.text = "ON";
                break;
            case 1:
                PlayerPrefs.SetInt("FullScreen", 0);
                FullScreenText.text = "OFF";
                break;
        }
        PlayerPrefs.Save();
    }
    public void VSnycChange()
    {
        switch (PlayerPrefs.GetInt("VSnyc", 1))
        {
            case 0:
                PlayerPrefs.SetInt("VSnyc", 1);
                VSnycText.text = "ON";
                break;
            case 1:
                PlayerPrefs.SetInt("VSnyc", 0);
                VSnycText.text = "OFF";
                break;
        }
        PlayerPrefs.Save();
    }
    public void ResolutionUP()
    {
        if(PlayerPrefs.GetInt("Resolution", 3) < 4)
        {
            PlayerPrefs.SetInt("Resolution", PlayerPrefs.GetInt("Resolution", 3) + 1);
            PlayerPrefs.Save();
        }
        switch (PlayerPrefs.GetInt("Resolution", 3))
        {
            case 1:
                ResolutionText.text = "960x540";
                break;
            case 2:
                ResolutionText.text = "1280x720";
                break;
            case 3:
                ResolutionText.text = "1920x1080";
                break;
            case 4:
                ResolutionText.text = "3840x2160";
                break;
        }
    }
    public void ResolutionDown()
    {
        if (PlayerPrefs.GetInt("Resolution", 3) > 0)
        {
            PlayerPrefs.SetInt("Resolution", PlayerPrefs.GetInt("Resolution", 3) - 1);
            PlayerPrefs.Save();
        }
        switch (PlayerPrefs.GetInt("Resolution", 3))
        {
            case 1:
                ResolutionText.text = "960x540";
                break;
            case 2:
                ResolutionText.text = "1280x720";
                break;
            case 3:
                ResolutionText.text = "1920x1080";
                break;
            case 4:
                ResolutionText.text = "3840x2160";
                break;
        }
    }
    public void InDelete()
    {
        IsDelete = true;
    }
    public void OutDelete()
    {
        IsDelete = false;
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
}
