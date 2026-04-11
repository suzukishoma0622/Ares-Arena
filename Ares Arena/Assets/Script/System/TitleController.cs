using TMPro;
using UnityEngine;
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
    public TMP_Text VolumeText;
    public Slider VolumeSlider;
    public TMP_Text LanguageText;
    public Slider DeleteSlider;
    public CanvasGroup DeleteCG;
    bool IsDelete;
    public GameObject FadeOut;

    int TitleNum = 0;
    int Difficulty = 0;
    int Language;

    public AudioSource BGM;
    public AudioSource SE;
    public AudioClip OkSE;
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
        VolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        VolumeText.text = (VolumeSlider.value * 100f).ToString("0") + "%";
        switch (Language)
        {
            case 1:
                LanguageText.text = "“ú–{Œê";
                break;
            case 2:
                LanguageText.text = "English";
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
                    break;
            }
        }
        VolumeText.text = (VolumeSlider.value * 100f).ToString("0") + "%";
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
        AudioListener.volume = VolumeSlider.value;
        if(IsVolumeFade)
        {
            BGM.volume -= Time.deltaTime * 2f;
        }
        if(IsCamera)
        {
            TitleBG.position = Vector3.MoveTowards(TitleBG.position, FocusPos.position, Time.deltaTime * 2800f);
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
        FadeOut.SetActive(true);
        Invoke("SceneMove", 2f);
        IsCamera = true;
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
    public void VolumeSave()
    {
        PlayerPrefs.SetFloat("MasterVolume", VolumeSlider.value);
        PlayerPrefs.Save();
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
    }
    public void InDelete()
    {
        IsDelete = true;
    }
    public void OutDelete()
    {
        IsDelete = false;
    }
}
