using UnityEngine;
using TMPro;

public class InfoDisplay_Potion : MonoBehaviour
{
    public GameObject DisplayObj;
    public int PotionNum;
    public TMP_Text NameText;
    public TMP_Text DescriptionText;
    public Animator anim;
    int Language;
    private void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
    }
    void Update()
    {
        switch(PotionNum)
        {
            case 1:
                switch (Language)
                {
                    case 1:
                        NameText.text = "治療のポーション";
                        DescriptionText.text = "HPを10%回復する。";
                        break;
                    case 2:
                        NameText.text = "Potion of Heal";
                        DescriptionText.text = "Restore 10% HP.";
                        break;
                }
                break;
            case 2:
                switch (Language)
                {
                    case 1:
                        NameText.text = "守護のポーション";
                        DescriptionText.text = "最大HPの20%に等しいシールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Potion of Defense";
                        DescriptionText.text = "Gain Shield equal to 20% of player's max HP.";
                        break;
                }
                break;
            case 3:
                switch (Language)
                {
                    case 1:
                        NameText.text = "力のポーション";
                        DescriptionText.text = "ハンド数+2。";
                        break;
                    case 2:
                        NameText.text = "Potion of Force";
                        DescriptionText.text = "Hand +2.";
                        break;
                }
                break;
            case 4:
                switch (Language)
                {
                    case 1:
                        NameText.text = "邪悪のポーション";
                        DescriptionText.text = "最大HPの40%に等しいダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Potion of Evil";
                        DescriptionText.text = "Deal damage equal to 40% of player's max HP.";
                        break;
                }
                break;
        }
        anim.Play($"Potion{PotionNum}");
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
