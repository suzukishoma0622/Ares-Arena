using UnityEngine;
using TMPro;

public class InfoDisplay_Skill : MonoBehaviour
{
    public GameObject DisplayObj;
    int Saint;
    public TMP_Text NameText;
    public TMP_Text DescriptionText;
    int Language;
    public int Bless22 = 1;
    int Crown;
    public void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Saint = PlayerPrefs.GetInt("Saint1", 1);
        Crown = PlayerPrefs.GetInt("Crown", 0);
        switch (Saint)
        {
            case 1:
                switch (Language)
                {
                    case 1:
                        NameText.text = "覚醒";
                        DescriptionText.text = $"ランダムな宝石{Bless22}種類を全て消す。";
                        break;
                    case 2:
                        NameText.text = "Awakening";
                        DescriptionText.text = $"Cast all of {Bless22} random gem type.";
                        break;
                }
                break;
            case 2:
                switch (Language)
                {
                    case 1:
                        NameText.text = "狙撃";
                        if (Crown >= 4)
                        {
                            DescriptionText.text = $"任意の宝石{Bless22 * 4}つを消去する。";
                        }
                        else if (Crown >= 2)
                        {
                            DescriptionText.text = $"任意の宝石{Bless22 * 7}つを消去する。";
                        }
                        else
                        {
                            DescriptionText.text = $"任意の宝石{Bless22 * 10}つを消去する。";
                        }
                        break;
                    case 2:
                        NameText.text = "Sniper";
                        DescriptionText.text = $"Cast any {Bless22 * 10} gems.";
                        break;
                }
                break;
            case 3:
                switch (Language)
                {
                    case 1:
                        NameText.text = "バーニングハンド";
                        DescriptionText.text = $"次のハンド時、宝石を消去する毎にリベンジを{Bless22 * 4}%チャージする。";
                        break;
                    case 2:
                        NameText.text = "Burning Hand";
                        DescriptionText.text = $"During the next hand, charge Revenge by {Bless22 * 4}% each time a gem is cast.";
                        break;
                }
                break;
            case 4:
                switch (Language)
                {
                    case 1:
                        NameText.text = "万華鏡";
                        if (Crown >= 2)
                        {
                            DescriptionText.text = $"任意の宝石{Bless22 * 3}つをプリズムに変化させる。";
                        }
                        else
                        {
                            DescriptionText.text = $"任意の宝石{Bless22 * 4}つをプリズムに変化させる。";
                        }
                        break;
                    case 2:
                        NameText.text = "Kaleidoscope";
                        if (Crown >= 2)
                        {
                            DescriptionText.text = $"Transform any {Bless22 * 3} gems into Prism.";
                        }
                        else
                        {
                            DescriptionText.text = $"Transform any {Bless22 * 4} gems into Prism.";
                        }
                        break;
                }
                break;
            case 5:
                switch (Language)
                {
                    case 1:
                        NameText.text = "凝視";
                        DescriptionText.text = $"次のハンド時に与えるダメージが{Bless22 + 1}倍になる。";
                        break;
                    case 2:
                        NameText.text = "Gaze";
                        DescriptionText.text = $"The damage dealt by the next hand is multiplied by {Bless22 + 1}.";
                        break;
                }
                break;
            case 6:
                switch (Language)
                {
                    case 1:
                        NameText.text = "侵蝕";
                        if (Crown >= 2)
                        {
                            DescriptionText.text = $"盤上の{Bless22}箇所に触媒15を付与する。触媒はハンドする毎に該当箇所にある宝石を消す。";
                        }
                        else
                        {
                            DescriptionText.text = $"盤上の{Bless22}箇所に触媒20を付与する。触媒はハンドする毎に該当箇所にある宝石を消す。";
                        }
                        break;
                    case 2:
                        NameText.text = "Erosion";
                        if (Crown >= 2)
                        {
                            DescriptionText.text = $"Grant Catalyst 15 to {Bless22} location on the board. Each time you hand, Catalyst casts gem located at that spot.";
                        }
                        else
                        {
                            DescriptionText.text = $"Grant Catalyst 20 to {Bless22} location on the board. Each time you hand, Catalyst casts gem located at that spot.";
                        }
                        break;
                }
                break;
            case 7:
                switch (Language)
                {
                    case 1:
                        NameText.text = "収集";
                        if (Crown >= 2)
                        {
                            DescriptionText.text = $"宝石{Bless22 * 2}つを消去し、スロットに消した宝石を追加する。スロット内の宝石は任意に盤上に設置できる。";
                        }
                        else
                        {
                            DescriptionText.text = $"宝石{Bless22 * 3}つを消去し、スロットに消した宝石を追加する。スロット内の宝石は任意に盤上に設置できる。";
                        }
                        break;
                    case 2:
                        NameText.text = "Collection";
                        if (Crown >= 2)
                        {
                            DescriptionText.text = $"Cast any {Bless22 * 2} gems and adds the cast gems to the slots. Gems in the slots can be placed anywhere on the board.";
                        }
                        else
                        {
                            DescriptionText.text = $"Cast any {Bless22 * 3} gems and adds the cast gems to the slots. Gems in the slots can be placed anywhere on the board.";
                        }
                        break;
                }
                break;
            case 8:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ミダスの手";
                        if (Crown >= 3)
                        {
                            DescriptionText.text = $"ハンド数+{Bless22 * 3}。ランダムな宝石20つを効果なしの黄金に変化させる。";
                        }
                        else
                        {
                            DescriptionText.text = $"ハンド数+{Bless22 * 4}。ランダムな宝石20つを効果なしの黄金に変化させる。";
                        }
                        break;
                    case 2:
                        NameText.text = "Midas Hand";
                        if (Crown >= 3)
                        {
                            DescriptionText.text = $"Hand +{Bless22 * 3}. Transforms 20 random gems into Royal Gold with no effect.";
                        }
                        else
                        {
                            DescriptionText.text = $"Hand +{Bless22 * 4}. Transforms 20 random gems into Royal Gold with no effect.";
                        }
                        break;
                }
                break;
            case 9:
                switch (Language)
                {
                    case 1:
                        NameText.text = "シールドバッシュ";
                        if (Crown >= 3)
                        {
                            DescriptionText.text = $"現在のシールド値の{Bless22 * 100}%に等しいダメージを与え、シールドの40%を失う。";
                        }
                        else
                        {
                            DescriptionText.text = $"現在のシールド値の{Bless22 * 100}%に等しいダメージを与え、シールドの30%を失う。";
                        }
                        break;
                    case 2:
                        NameText.text = "Shield Bash";
                        if (Crown >= 3)
                        {
                            DescriptionText.text = $"Deals damage equal to the {Bless22 * 100}% of current shield value and consumes 40% of the shield.";
                        }
                        else
                        {
                            DescriptionText.text = $"Deals damage equal to the {Bless22 * 100}% of current shield value and consumes 30% of the shield.";
                        }
                        break;
                }
                break;
            case 10:
                switch (Language)
                {
                    case 1:
                        NameText.text = "弱点探知";
                        DescriptionText.text = $"ランダムな{Bless22 * 4}箇所をマーキングする。順番通りに宝石を消去する毎に、70ダメージを追加で与える。";
                        break;
                    case 2:
                        NameText.text = "Weak Detection";
                        DescriptionText.text = $"Mark {Bless22 * 4} random locations. Deal an additional 70 damage each time cast gems in the specified order.";
                        break;
                }
                break;
            case 11:
                switch (Language)
                {
                    case 1:
                        NameText.text = "創始";
                        DescriptionText.text = $"宝石{Bless22}つをセルに変化させる。セルはターン経過で成長し、ハンド時に宝石を放出する。";
                        break;
                    case 2:
                        NameText.text = "Creation";
                        DescriptionText.text = $"Transforms {Bless22} gems into Cell. Cell grow over the course of turns and release gems when hand.";
                        break;
                }
                break;
            case 12:
                switch (Language)
                {
                    case 1:
                        NameText.text = "念写";
                        DescriptionText.text = $"盤上の任意の3x3マスの宝石配列を記憶する。記憶した配列は任意の場所に再設置出来る。";
                        break;
                    case 2:
                        NameText.text = "Spirit Graphy";
                        DescriptionText.text = $"Memorize the arrangement of gems in any 3x3 area. The arrangement can be placed again.";
                        break;
                }
                break;
            case 13:
                switch (Language)
                {
                    case 1:
                        NameText.text = "大釜";
                        DescriptionText.text = $"ランダムなポーションを{Bless22}つ調合する。";
                        break;
                    case 2:
                        NameText.text = "Cauldron";
                        DescriptionText.text = $"Brew {Bless22} random potion.";
                        break;
                }
                break;
            case 14:
                switch (Language)
                {
                    case 1:
                        NameText.text = "センチネル";
                        DescriptionText.text = $"選択したドロイドを{Bless22}つ生成する。同時に生成出来るのは5つまで。";
                        break;
                    case 2:
                        NameText.text = "Sentinel";
                        DescriptionText.text = $"Generate {Bless22 * 4} selected droid. You can generate up to 5 at a time.";
                        break;
                }
                break;
        }
    }
    void Update()
    {
        
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
