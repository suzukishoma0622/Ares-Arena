using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoDisplay_Revenge : MonoBehaviour
{
    public GameObject DisplayObj;
    int Saint;
    public TMP_Text NameText;
    public TMP_Text DescriptionText;
    public Slider RevengeSlider;
    int Language;

    public int SentryRevenge;
    private void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Saint = PlayerPrefs.GetInt("Saint1", 1);
    }
    void Update()
    {
        switch (Saint)
        {
            case 1:
                switch (Language)
                {
                    case 1:
                        NameText.text = "プライムハンド" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "ハンド数 +5。";
                        break;
                    case 2:
                        NameText.text = "Prime Hand" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "Hand +5.";
                        break;
                }
                break;
            case 2:
                switch (Language)
                {
                    case 1:
                        NameText.text = "矢筒拡張" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "この戦闘中、スキルの効果が3増加する。";
                        break;
                    case 2:
                        NameText.text = "Quiver Expansion" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "During this battle, the effect of skills increases by 3.";
                        break;
                }
                break;
            case 3:
                switch (Language)
                {
                    case 1:
                        NameText.text = "噴火" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "下から3行目までの状態異常以外の宝石を全て消去する。";
                        break;
                    case 2:
                        NameText.text = "Eruption" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "Cast all gems on the board except those affected by status ailments.";
                        break;
                }
                break;
            case 4:
                switch (Language)
                {
                    case 1:
                        NameText.text = "乱反射" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "ランダムな宝石8つをプリズムに変化させる。";
                        break;
                    case 2:
                        NameText.text = "Diffuse Reflection" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "Transforms 8 random gems into Prism.";
                        break;
                }
                break;
            case 5:
                switch (Language)
                {
                    case 1:
                        NameText.text = "一斉射撃" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = $"{300 + SentryRevenge}ダメージを与える。この効果が永続的に60増加する。";
                        break;
                    case 2:
                        NameText.text = "Broadside" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = $"Deals {300 + SentryRevenge} damage. This effect increases by 60 permanently.";
                        break;
                }
                break;
            case 6:
                switch (Language)
                {
                    case 1:
                        NameText.text = "支配" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "盤上のランダムな6箇所に触媒5を付与する。";
                        break;
                    case 2:
                        NameText.text = "Domination" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "Grant Catalyst 5 to 6 random locations on the board.";
                        break;
                }
                break;
            case 7:
                switch (Language)
                {
                    case 1:
                        NameText.text = "展覧会" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "全ての種類の宝石をスロットに2つずつ追加する。";
                        break;
                    case 2:
                        NameText.text = "Exhibition" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "Adds 2 of every type of gem to the slots.";
                        break;
                }
                break;
            case 8:
                switch (Language)
                {
                    case 1:
                        NameText.text = "黄金の血" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "戦闘終了時に得られるメダルが1枚増える。";
                        break;
                    case 2:
                        NameText.text = "Golden Blood" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "Receive 1 additional medal at the end of battle.";
                        break;
                }
                break;
            case 9:
                switch (Language)
                {
                    case 1:
                        NameText.text = "金属体" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "200シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Metal Body" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "Gain 200 Shield.";
                        break;
                }
                break;
            case 10:
                switch (Language)
                {
                    case 1:
                        NameText.text = "剣の舞" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "ランダムな6箇所をマーキングする。このターン中、マーキングの順番は無視される。";
                        break;
                    case 2:
                        NameText.text = "Sword Dance" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "Mark 6 random locations. The order of marking is ignored during this turn.";
                        break;
                }
                break;
            case 11:
                switch (Language)
                {
                    case 1:
                        NameText.text = "増殖" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "全てのセルを1段階成長させる。";
                        break;
                    case 2:
                        NameText.text = "Prosperity" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "Grow all Cell by 1 stages.";
                        break;
                }
                break;
            case 12:
                switch (Language)
                {
                    case 1:
                        NameText.text = "記憶改竄" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "記憶した配列内の宝石を2箇所に設置する。";
                        break;
                    case 2:
                        NameText.text = "Alteration" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "Place the gems from the memorized arrangement at 2 locations.";
                        break;
                }
                break;
            case 13:
                switch (Language)
                {
                    case 1:
                        NameText.text = "禁断の調合" + $"({RevengeSlider.maxValue - RevengeSlider.value}被ダメージ必要)";
                        DescriptionText.text = "空のポーションスロットをランダムなポーションで埋めつくす。";
                        break;
                    case 2:
                        NameText.text = "Forbidden Brewing" + $"(Need {RevengeSlider.maxValue - RevengeSlider.value} Damage)";
                        DescriptionText.text = "Fill all empty potion slots with random potions.";
                        break;
                }
                break;
        }
    }
    public void OnDisplay()
    {
        DisplayObj.SetActive(true);
        SentryRevenge = PlayerPrefs.GetInt("SentryRevenge", 0);
    }
    public void OffDisplay()
    {
        DisplayObj.SetActive(false);
    }
}
