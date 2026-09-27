using UnityEngine;
using TMPro;

public class InfoDisplay_Droid : MonoBehaviour
{
    public GameObject DisplayObj;
    public int DroidNum;
    public int DroidLevel = 1;
    public TMP_Text NameText;
    public TMP_Text DescriptionText;
    public TMP_Text LevelText;
    int Language;
    private void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
    }
    void Update()
    {
        LevelText.text = "Lv" + DroidLevel;
        switch(DroidNum)
        {
            case 1:
                switch (Language)
                {
                    case 1:
                        NameText.text = $"レーザー Lv{DroidLevel}";
                        DescriptionText.text = $"{15 + 15 * DroidLevel}ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = $"Lazer Lv{DroidLevel}";
                        DescriptionText.text = $"Deal {15 + 15 * DroidLevel} Damage.";
                        break;
                }
                break;
            case 2:
                switch (Language)
                {
                    case 1:
                        NameText.text = $"ホログラム Lv{DroidLevel}";
                        DescriptionText.text = $"{8 + 7 * DroidLevel}シールドを得る。";
                        break;
                    case 2:
                        NameText.text = $"Hologram Lv{DroidLevel}";
                        DescriptionText.text = $"Gain {8 + 7 * DroidLevel} Shield.";
                        break;
                }
                break;
            case 3:
                switch (Language)
                {
                    case 1:
                        NameText.text = $"テンペスト Lv{DroidLevel}";
                        DescriptionText.text = $"ランダムな宝石{2 + DroidLevel}個を消去する。";
                        break;
                    case 2:
                        NameText.text = $"Tempest Lv{DroidLevel}";
                        DescriptionText.text = $"Cast {2 + DroidLevel} Random Gems.";
                        break;
                }
                break;
        }
    }
    public void OnDisplay()
    {
        DisplayObj.SetActive(true);
    }
    public void OffDisplay()
    {
        DisplayObj.SetActive(false);
    }
}
