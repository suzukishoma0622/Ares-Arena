using UnityEngine;
using TMPro;

public class InfoDisplay_Gem : MonoBehaviour
{
    public GameObject DisplayObj;
    public int GemNum;
    public TMP_Text NameText;
    public TMP_Text DescriptionText;
    InfoDisplay Iscript;
    int Language;
    int Gem53;
    int Gem54;
    int Gem70;
    int Gem133;
    int Gem144;
    int Gem152;
    private void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        if (GameObject.Find("InfoCanvas") != null)
        {
            Iscript = GameObject.Find("InfoCanvas").GetComponent<InfoDisplay>();
        }
    }
    void Update()
    {
        switch(GemNum)
        {
            case 0:
                switch(Language)
                {
                    case 1:
                        NameText.text = "ルビー";
                        DescriptionText.text = $"{10 + Iscript.Bless[8]}ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Ruby";
                        DescriptionText.text = $"Deals {10 + Iscript.Bless[8]} Damage.";
                        break;
                }
                break;
            case 1:
                switch (Language)
                {
                    case 1:
                        NameText.text = "エメラルド";
                        DescriptionText.text = $"{10 + Iscript.Bless[8]}ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Emerald";
                        DescriptionText.text = $"Deals {10 + Iscript.Bless[8]} Damage.";
                        break;
                }
                break;
            case 2:
                if(Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "クォーツ";
                            DescriptionText.text = $"{15 + Iscript.Bless[8] * 1.5}ダメージを与える。";
                            break;
                        case 2:
                            NameText.text = "Quartz";
                            DescriptionText.text = $"Deals {15 + Iscript.Bless[8] * 1.5} Damage.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "クォーツ";
                            DescriptionText.text = $"{10 + Iscript.Bless[8]}ダメージを与える。";
                            break;
                        case 2:
                            NameText.text = "Quartz";
                            DescriptionText.text = $"Deals {10 + Iscript.Bless[8]} Damage.";
                            break;
                    }
                }
                break;
            case 3:
                switch (Language)
                {
                    case 1:
                        NameText.text = "サファイア";
                        DescriptionText.text = $"{5 + Iscript.Bless[8]}シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Sapphire";
                        DescriptionText.text = $"Gain {5 + Iscript.Bless[8]} Shield.";
                        break;
                }
                break;
            case 4:
                if (Iscript != null && Iscript.Bless[30] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "アメシスト";
                            DescriptionText.text = $"{10 + Iscript.Bless[8] * 2}シールドを与える。";
                            break;
                        case 2:
                            NameText.text = "Amethyst";
                            DescriptionText.text = $"Gain {10 + Iscript.Bless[8] * 2} Shield.";
                            break;
                    }
                    break;
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "アメシスト";
                            DescriptionText.text = $"{5 + Iscript.Bless[8]}シールドを与える。";
                            break;
                        case 2:
                            NameText.text = "Amethyst";
                            DescriptionText.text = $"Gain {5 + Iscript.Bless[8]} Shield.";
                            break;
                    }
                    break;
                }
            case 5:
                if (Iscript != null && Iscript.Bless[54] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ガーネット";
                            DescriptionText.text = "32ダメージを与える。";
                            break;
                        case 2:
                            NameText.text = "Garnet";
                            DescriptionText.text = "Deals 32 Damage.";
                            break;
                    }
                    break;
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ガーネット";
                            DescriptionText.text = "16ダメージを与える。";
                            break;
                        case 2:
                            NameText.text = "Garnet";
                            DescriptionText.text = "Deals 16 Damage.";
                            break;
                    }
                    break;
                }
            case 6:
                if (Iscript != null && Iscript.Bless[54] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "セレスタイト";
                            DescriptionText.text = "16シールドを得る。";
                            break;
                        case 2:
                            NameText.text = "Celestite";
                            DescriptionText.text = "Gain 16 Shield.";
                            break;
                    }
                    break;
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "セレスタイト";
                            DescriptionText.text = "8シールドを得る。";
                            break;
                        case 2:
                            NameText.text = "Celestite";
                            DescriptionText.text = "Gain 8 Shield.";
                            break;
                    }
                    break;
                }
            case 7:
                if (Iscript != null && Iscript.Bless[54] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ペリドット";
                            DescriptionText.text = "24ダメージを与える。\n" +
                                "4シールドを得る。";
                            break;
                        case 2:
                            NameText.text = "Peridot";
                            DescriptionText.text = "Deals 24 Damage.\n" +
                                "Gain 4 Shield.";
                            break;
                    }
                    break;
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ペリドット";
                            DescriptionText.text = "12ダメージを与える。\n" +
                                "2シールドを得る。";
                            break;
                        case 2:
                            NameText.text = "Peridot";
                            DescriptionText.text = "Deals 12 Damage.\n" +
                                "Gain 2 Shield.";
                            break;
                    }
                    break;
                }
            case 8:
                switch (Language)
                {
                    case 1:
                        NameText.text = "スピネル";
                        DescriptionText.text = "20ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Spinel";
                        DescriptionText.text = "Deals 20 Damage.";
                        break;
                }
                break;
            case 9:
                switch (Language)
                {
                    case 1:
                        NameText.text = "オブシディアン";
                        DescriptionText.text = "10シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Obsidian";
                        DescriptionText.text = "Gain 10 Shield.";
                        break;
                }
                break;
            case 10:
                switch (Language)
                {
                    case 1:
                        NameText.text = "サンストーン";
                        DescriptionText.text = "15ダメージを与える。1チェーン目はダメージが3倍になる。";
                        break;
                    case 2:
                        NameText.text = "Sunstone";
                        DescriptionText.text = "Deals 15 Damage. The first chain deals triple Damage.";
                        break;
                }
                break;
            case 11:
                switch (Language)
                {
                    case 1:
                        NameText.text = "コバルト";
                        DescriptionText.text = "13シールドを得る。2チェーン目までは効果は0になる。";
                        break;
                    case 2:
                        NameText.text = "Cobalt";
                        DescriptionText.text = "Gain 13 Shield. The effect is 0 for the first 2 chains.";
                        break;
                }
                break;
            case 12:
                switch (Language)
                {
                    case 1:
                        NameText.text = "パール";
                        DescriptionText.text = "HPを5回復する。";
                        break;
                    case 2:
                        NameText.text = "Pearl";
                        DescriptionText.text = "Restore 5 HP.";
                        break;
                }
                break;
            case 13:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アンバー";
                        DescriptionText.text = "7シールドを得る。リベンジを3ダメージ分チャージする。";
                        break;
                    case 2:
                        NameText.text = "Amber";
                        DescriptionText.text = "Gain 7 Shield. Charge Revenge by 3 damage.";
                        break;
                }
                break;
            case 14:
                switch (Language)
                {
                    case 1:
                        NameText.text = "マラカイト";
                        DescriptionText.text = "6シールドを得る。ターン終了時に自動で消える。";
                        break;
                    case 2:
                        NameText.text = "Malachite";
                        DescriptionText.text = "Gain 6 Shield. Cast automatically at the end of the turn.";
                        break;
                }
                break;
            case 15:
                switch (Language)
                {
                    case 1:
                        NameText.text = "フローライト";
                        DescriptionText.text = "10ダメージを与える。この宝石には3倍のチェーンボーナスが適用される。";
                        break;
                    case 2:
                        NameText.text = "Fluorite";
                        DescriptionText.text = "Deals 10 Damage. This gem receives a 3x chain bonus.";
                        break;
                }
                break;
            case 16:
                switch (Language)
                {
                    case 1:
                        NameText.text = "タイガーアイ";
                        DescriptionText.text = "12ダメージを与える。7チェーン以上繋げると、ハンド数+1。";
                        break;
                    case 2:
                        NameText.text = "Tigereye";
                        DescriptionText.text = "Deals 12 Damage. If you chain 7 or more, hand +1.";
                        break;
                }
                break;
            case 17:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アポフィライト";
                        DescriptionText.text = "8ダメージを与える。現在のターンでハンドした回数x2ダメージを追加で与える。";
                        break;
                    case 2:
                        NameText.text = "Apophylite";
                        DescriptionText.text = "Deals 8 damage. Deals an additional Damage equal to 2 times the number of times you have been handed this turn.";
                        break;
                }
                break;
            case 18:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ハイパーライト";
                        DescriptionText.text = "28ダメージを与える。この宝石はチェーンの影響を受けない。";
                        break;
                    case 2:
                        NameText.text = "Hyperlite";
                        DescriptionText.text = "Deals 28 Damage. This gem is unaffected by chains.";
                        break;
                }
                break;
            case 19:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ダイヤモンド";
                        DescriptionText.text = "17シールドを得る。この宝石は通常の50%の確率で降ってくる。";
                        break;
                    case 2:
                        NameText.text = "Diamond";
                        DescriptionText.text = "Gain 17 Shield. This gem appears with a 50% probability compared to normal.";
                        break;
                }
                break;
            case 20:
                switch (Language)
                {
                    case 1:
                        NameText.text = "インビジブライト";
                        DescriptionText.text = "5シールドを得る。この宝石は通常の20%の確率で降ってくる。";
                        break;
                    case 2:
                        NameText.text = "Invisiblight";
                        DescriptionText.text = "Gain 5 Shield. This gem appears with a 20% probability compared to normal.";
                        break;
                }
                break;
            case 21:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ソーサラーストーン";
                        DescriptionText.text = "16シールドを得る。6チェーン目以降は効果が消える。";
                        break;
                    case 2:
                        NameText.text = "Sorcererstone";
                        DescriptionText.text = "Gain 16 Shield. The effect disappears after the 6th chain.";
                        break;
                }
                break;
            case 22:
                switch (Language)
                {
                    case 1:
                        NameText.text = "スペクトル";
                        DescriptionText.text = "16ダメージを与える。出現時に30%の確率でプリズムに変化する。";
                        break;
                    case 2:
                        NameText.text = "Spectre";
                        DescriptionText.text = "Deals 16 Damage. Has a 30% chance of transforming into a prism upon appearance.";
                        break;
                }
                break;
            case 23:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ジオード";
                        DescriptionText.text = "前回のハンドのチェーン数x4ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Geode";
                        DescriptionText.text = "Deals damage equal to 4 times the number of chains recorded in the previous hand.";
                        break;
                }
                break;
            case 24:
                switch (Language)
                {
                    case 1:
                        NameText.text = "オニキス";
                        DescriptionText.text = "10ダメージを与える。5シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Onyx";
                        DescriptionText.text = "Deals 10 Damage. Gain 5 Shield.";
                        break;
                }
                break;
            case 25:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ダイナモライト";
                        DescriptionText.text = "盤面にあるこの宝石の数と同値のシールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Dynamolite";
                        DescriptionText.text = "Gain a Shield equal to the number of these gems on the board.";
                        break;
                }
                break;
            case 26:
                switch (Language)
                {
                    case 1:
                        NameText.text = "トパーズ";
                        DescriptionText.text = "14ダメージを与える。この宝石は通常の2倍の確率で出現する。";
                        break;
                    case 2:
                        NameText.text = "Topaz";
                        DescriptionText.text = "Deals 14 Damage. This gem appears with a 2x probability compared to normal.";
                        break;
                }
                break;
            case 27:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ベリル";
                        DescriptionText.text = "6シールドを得る。HPを2回復する。";
                        break;
                    case 2:
                        NameText.text = "Beryl";
                        DescriptionText.text = "Gain 6 Shield. Restore 2 HP.";
                        break;
                }
                break;
            case 28:
                switch (Language)
                {
                    case 1:
                        NameText.text = "サルファー";
                        DescriptionText.text = "26ダメージを与える。HPを2失う。";
                        break;
                    case 2:
                        NameText.text = "Sulfer";
                        DescriptionText.text = "Deals 26 Damage. Lose 2 HP.";
                        break;
                }
                break;
            case 29:
                switch (Language)
                {
                    case 1:
                        NameText.text = "シルバー";
                        DescriptionText.text = "現在のシールド値の10%にあたるダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Silver";
                        DescriptionText.text = "Deals damage equal to 10% of the current shield value.";
                        break;
                }
                break;
            case 30:
                switch (Language)
                {
                    case 1:
                        NameText.text = "スフェーン";
                        DescriptionText.text = "14ダメージを与える。残りハンド数が奇数のとき、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Sphene";
                        DescriptionText.text = "Deal 14 damage. If the number of hand remaining is odd, the effect is doubled.";
                        break;
                }
                break;
            case 31:
                switch (Language)
                {
                    case 1:
                        NameText.text = "トリフェーン";
                        DescriptionText.text = "7シールドを得る。残りハンド数が偶数のとき、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Triphane";
                        DescriptionText.text = "Gain 7 Shield. If the number of hand remaining is even, the effect is doubled.";
                        break;
                }
                break;
            case 32:
                switch (Language)
                {
                    case 1:
                        NameText.text = "トルマリン";
                        DescriptionText.text = "5～40ダメージを与える。効果値はランダム。";
                        break;
                    case 2:
                        NameText.text = "Tormaline";
                        DescriptionText.text = "Deals 5~40 damage. The damage value is random.";
                        break;
                }
                break;
            case 33:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ビスマス";
                        DescriptionText.text = "12シールドを得る。HPを1失う。";
                        break;
                    case 2:
                        NameText.text = "Bismuth";
                        DescriptionText.text = "Gain 12 Shield. Lose 1 HP.";
                        break;
                }
                break;
            case 34:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ラブラドライト";
                        DescriptionText.text = "28ダメージを与える。7チェーン以上繋げると、ハンド数-2。";
                        break;
                    case 2:
                        NameText.text = "Labradorite";
                        DescriptionText.text = "Deals 28 damage. If you chain 7 or more, hand -2.";
                        break;
                }
                break;
            case 35:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ラピスラズリ";
                        DescriptionText.text = "リベンジを11ダメージ分チャージする。";
                        break;
                    case 2:
                        NameText.text = "Lapis Lazuli";
                        DescriptionText.text = "Charge Revenge by 11 damage.";
                        break;
                }
                break;
            case 36:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ヒスイ";
                        DescriptionText.text = "HPを3回復する。リベンジを4ダメージ分チャージする。";
                        break;
                    case 2:
                        NameText.text = "Jade";
                        DescriptionText.text = "Restore 3 HP. Charge Revenge by 4 damage.";
                        break;
                }
                break;
            case 37:
                switch (Language)
                {
                    case 1:
                        NameText.text = "グラスワーク";
                        DescriptionText.text = "16ダメージを与える。出現確率は現在のターン数で除算される。";
                        break;
                    case 2:
                        NameText.text = "Glass Work";
                        DescriptionText.text = "Deals 16 damage. The appearance probability is divided by the current turn number.";
                        break;
                }
                break;
            case 38:
                switch (Language)
                {
                    case 1:
                        NameText.text = "リビアングラス";
                        DescriptionText.text = "14ダメージを与える。16チェーン以上繋げると、スキルが回復する。";
                        break;
                    case 2:
                        NameText.text = "Libyanglass";
                        DescriptionText.text = "Deals 14 damage. If you chain 16 or more, restores the skill.";
                        break;
                }
                break;
            case 39:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アレキサンドライト";
                        DescriptionText.text = "30ダメージを与える。最大HPを2失う。";
                        break;
                    case 2:
                        NameText.text = "Alexandrite";
                        DescriptionText.text = "Deal 30 damage. Lose 2 max HP.";
                        break;
                }
                break;
            case 40:
                switch (Language)
                {
                    case 1:
                        NameText.text = "シトリン";
                        DescriptionText.text = "16ダメージを与える。5チェーン以下だった場合、消えた宝石が再出現する。";
                        break;
                    case 2:
                        NameText.text = "Citrine";
                        DescriptionText.text = "Deals 16 damage. If the chain is 5 or less, the cleared gems reappear.";
                        break;
                }
                break;
            case 41:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ギベオン";
                        DescriptionText.text = "最大HPが2増加する。";
                        break;
                    case 2:
                        NameText.text = "Gibeon";
                        DescriptionText.text = "Maximum HP increases by 2.";
                        break;
                }
                break;
            case 42:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ジルコン";
                        DescriptionText.text = "13シールドを得る。2ダメージ分のリベンジを失う。";
                        break;
                    case 2:
                        NameText.text = "Zircon";
                        DescriptionText.text = "Gain 13 Shield. Lose 2 damage of Revenge.";
                        break;
                }
                break;
            case 43:
                switch (Language)
                {
                    case 1:
                        NameText.text = "コーラル";
                        DescriptionText.text = "16ダメージを与える。HPが100%のとき、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Coral";
                        DescriptionText.text = "Deals 16 damage. The effect is doubled when HP is at 100%.";
                        break;
                }
                break;
            case 44:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アマゾナイト";
                        DescriptionText.text = "8シールドを得る。HPが25%以下のとき、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Amazonite";
                        DescriptionText.text = "Gain 8 Shield. The effect is doubled when HP is 25% or less.";
                        break;
                }
                break;
            case 45:
                switch (Language)
                {
                    case 1:
                        NameText.text = "クリスタル";
                        DescriptionText.text = "7シールドを得る。チェーンが追加で1増加する。";
                        break;
                    case 2:
                        NameText.text = "Crystal";
                        DescriptionText.text = "Gain 7 Shield. Increase Chain by an additional 1.";
                        break;
                }
                break;
            case 46:
                switch (Language)
                {
                    case 1:
                        NameText.text = "コランダム";
                        DescriptionText.text = "17ダメージを与える。弱体化を追加で4スタック解除する。";
                        break;
                    case 2:
                        NameText.text = "Corundum";
                        DescriptionText.text = "Deals 17 damage. Removes 4 additional stacks of Weak.";
                        break;
                }
                break;
            case 47:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ローゼライト";
                        DescriptionText.text = "5シールドを得る。9チェーン以上繋げると、ハンド数+2。";
                        break;
                    case 2:
                        NameText.text = "Roselight";
                        DescriptionText.text = "Gain 5 Shield. If you chain 9 or more, hand +2.";
                        break;
                }
                break;
            case 48:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ヘリオドール";
                        DescriptionText.text = "現在のターン数×6ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Heliodor";
                        DescriptionText.text = "Deals damage equal to the current turn count x6.";
                        break;
                }
                break;
            case 49:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アクアマリン";
                        DescriptionText.text = "7シールドを得る。出現確率は現在のターン数で乗算される。";
                        break;
                    case 2:
                        NameText.text = "Aquamarine";
                        DescriptionText.text = "Gain 7 Shield. The appearance rate is multiplied by the current turn count.";
                        break;
                }
                break;
            case 50:
                if (Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ローズクォーツ";
                            DescriptionText.text = "19ダメージを与える。リベンジを6ダメージ分チャージする。";
                            break;
                        case 2:
                            NameText.text = "Rose Quartz";
                            DescriptionText.text = "Deals 19 Damage. Charge Revenge by 6 damage.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ローズクォーツ";
                            DescriptionText.text = "13ダメージを与える。リベンジを4ダメージ分チャージする。";
                            break;
                        case 2:
                            NameText.text = "Rose Quartz";
                            DescriptionText.text = "Deals 13 Damage. Charge Revenge by 4 damage.";
                            break;
                    }
                }
                break;
            case 51:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ミラージュ";
                        DescriptionText.text = "14シールドを得る。敵に14シールドを与える。";
                        break;
                    case 2:
                        NameText.text = "Mirage";
                        DescriptionText.text = "Gain 14 Shield. Grant the enemy 14 Shield.";
                        break;
                }
                break;
            case 52:
                switch (Language)
                {
                    case 1:
                        NameText.text = "シンハライト";
                        DescriptionText.text = $"{Gem53}シールドを得る。12チェーン以上繋げると、効果が永続的に1増加する。";
                        break;
                    case 2:
                        NameText.text = "Sinhalite";
                        DescriptionText.text = $"Gain {Gem53} Shield. If you chain 12 or more, the effect permanently increases by 1.";
                        break;
                }
                break;
            case 53:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ラリマー";
                        DescriptionText.text = $"{Gem54}ダメージを与える。ターン終了まで効果が1減少する。";
                        break;
                    case 2:
                        NameText.text = "Larimar";
                        DescriptionText.text = $"Deal {Gem54} damage. The effect is reduced by 1 until the end of the turn.";
                        break;
                }
                break;
            case 54:
                switch (Language)
                {
                    case 1:
                        NameText.text = "モルダバイト";
                        DescriptionText.text = "15ダメージを与える。17チェーン以上繋げると、出現確率が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Moldavite";
                        DescriptionText.text = "Deal 15 damage. If you chain 17 or more, doubles the appearance rate.";
                        break;
                }
                break;
            case 55:
                switch (Language)
                {
                    case 1:
                        NameText.text = "シェル";
                        DescriptionText.text = "現在のターンでHPを失った回数の2倍に等しいダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Shell";
                        DescriptionText.text = "Deal damage equal to twice the number of times HP was lost during the current turn.";
                        break;
                }
                break;
            case 56:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ゴールド";
                        DescriptionText.text = "消去不可。この宝石は通常の10%の確率で出現する。";
                        break;
                    case 2:
                        NameText.text = "Gold";
                        DescriptionText.text = "Cannot be cast. This gem appears with a 10% probability compared to normal.";
                        break;
                }
                break;
            case 57:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ジャスパー";
                        DescriptionText.text = "19シールドを得る。HPが50%以上ならば、効果は0になる。";
                        break;
                    case 2:
                        NameText.text = "Jasper";
                        DescriptionText.text = "Gain 19 Shield. If HP is 50% or higher, the effect becomes 0.";
                        break;
                }
                break;
            case 58:
                switch (Language)
                {
                    case 1:
                        NameText.text = "セレナイト";
                        DescriptionText.text = "29ダメージを与える。4チェーン目までは効果が0になる。";
                        break;
                    case 2:
                        NameText.text = "Selenite";
                        DescriptionText.text = "Deals 29 Damage. The effect is 0 for the first 4 chains.";
                        break;
                }
                break;
            case 59:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ロードナイト";
                        DescriptionText.text = "リベンジを16ダメージ分チャージする。HPを3失う。";
                        break;
                    case 2:
                        NameText.text = "Rhodonite";
                        DescriptionText.text = "Charge Revenge by 16 damage. Lose 3 HP.";
                        break;
                }
                break;
            case 60:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アクアオーラ";
                        DescriptionText.text = "18シールドを得る。消去時、追加でハンドを1失う。";
                        break;
                    case 2:
                        NameText.text = "Aqua Aura";
                        DescriptionText.text = "Gain 18 Shield. When cast, lose an additional hand.";
                        break;
                }
                break;
            case 61:
                switch (Language)
                {
                    case 1:
                        NameText.text = "カルサイト";
                        DescriptionText.text = "14ダメージを与える。残りハンド数が5以上ならば、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Calcite";
                        DescriptionText.text = "Deals 14 damage. If you have 5 or more hand, the effect is doubled.";
                        break;
                }
                break;
            case 62:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ターコイズ";
                        DescriptionText.text = "7シールドを得る。残りハンド数が4以下ならば、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Turquoise";
                        DescriptionText.text = "Gain 7 Shield. If you have 4 or less hand, the effect is doubled.";
                        break;
                }
                break;
            case 63:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ブラックダイヤモンド";
                        DescriptionText.text = "17ダメージを与える。この宝石の出現確率が15%以下ならば、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Black Diamond";
                        DescriptionText.text = "Deals 17 damage. If the appearance rate of this gem is 15% or less, the effect is doubled.";
                        break;
                }
                break;
            case 64:
                switch (Language)
                {
                    case 1:
                        NameText.text = "テクタイト";
                        DescriptionText.text = "8シールドを得る。この宝石の出現確率が30%以上ならば、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Tektite";
                        DescriptionText.text = "Gain 8 Shield. If the appearance rate of this gem is 30% or more, the effect is doubled.";
                        break;
                }
                break;
            case 65:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ハウライト";
                        DescriptionText.text = "4の倍数チェーンを繋げる毎にハンド数+1。";
                        break;
                    case 2:
                        NameText.text = "Howlite";
                        DescriptionText.text = "Hand +1 for every chain that is a multiple of 4.";
                        break;
                }
                break;
            case 66:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アマルガム";
                        DescriptionText.text = "5～40ダメージを与える。効果は残りHP割合が少ない程増加する。";
                        break;
                    case 2:
                        NameText.text = "Amalgam";
                        DescriptionText.text = "Deals 5-40 damage. The effect increases as the percentage of remaining HP decreases.";
                        break;
                }
                break;
            case 67:
                switch (Language)
                {
                    case 1:
                        NameText.text = "プラチナ";
                        DescriptionText.text = "5シールドを得る。出現時、40%の確率でプリズムに変化する。";
                        break;
                    case 2:
                        NameText.text = "Platinum";
                        DescriptionText.text = "Gain 5 Shield. Has a 40% chance of transforming into a prism upon appearance.";
                        break;
                }
                break;
            case 68:
                switch (Language)
                {
                    case 1:
                        NameText.text = "カイヤナイト";
                        DescriptionText.text = "13ダメージを与える。3ターン目以降は効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Kyanite";
                        DescriptionText.text = "Deals 13 damage. The effect doubles from 3 turn onwards.";
                        break;
                }
                break;
            case 69:
                switch (Language)
                {
                    case 1:
                        NameText.text = "カーネリアン";
                        DescriptionText.text = "8シールドを得る。2ターン目までは効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Carnelian";
                        DescriptionText.text = "Gain 8 Shield. The effect is doubled until the second turn.";
                        break;
                }
                break;
            case 70:
                switch (Language)
                {
                    case 1:
                        NameText.text = "フォッシル";
                        DescriptionText.text = $"{Gem70}ダメージを与える。この宝石の効果が永続的に1減少する。";
                        break;
                    case 2:
                        NameText.text = "Fossil";
                        DescriptionText.text = $"Deals {Gem70} damage. This gem's effect is permanently reduced by 1.";
                        break;
                }
                break;
            case 71:
                switch (Language)
                {
                    case 1:
                        NameText.text = "カルセドニー";
                        DescriptionText.text = "4～16シールドを得る。効果は残りHPが多い程増加する。";
                        break;
                    case 2:
                        NameText.text = "Chalcedony";
                        DescriptionText.text = "Gain 4-16 Shield. The effect increases based on remaining HP.";
                        break;
                }
                break;
            case 72:
                switch (Language)
                {
                    case 1:
                        NameText.text = "カメレオンダイヤモンド";
                        DescriptionText.text = "8ダメージを与える。スロット内の名前に「ダイヤモンド」を含む宝石1つにつき、追加で8ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Chameleon Diamond";
                        DescriptionText.text = "Deals 8 damage. Deal an additional 8 damage for each gem in the slots with \"Diamond\" in its name.";
                        break;
                }
                break;
            case 73:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ヴァーダイト";
                        DescriptionText.text = "13ダメージを与える。10チェーン目は効果が10倍になる。";
                        break;
                    case 2:
                        NameText.text = "Verdite";
                        DescriptionText.text = "Deals 13 damage. At the 10 chain, the effect is multiplied by 10.";
                        break;
                }
                break;
            case 74:
                switch (Language)
                {
                    case 1:
                        NameText.text = "シェブロンアメシスト";
                        DescriptionText.text = "15ダメージを与える。8シールドを得る。HPを2失う。";
                        break;
                    case 2:
                        NameText.text = "Chevron Amethyst";
                        DescriptionText.text = "Deals 15 damage. Gain 8 Shield. Lose 2 HP.";
                        break;
                }
                break;
            case 75:
                if (Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ミルキークォーツ";
                            DescriptionText.text = "HPを10回復する。4シールドを失う。";
                            break;
                        case 2:
                            NameText.text = "Milky Quartz";
                            DescriptionText.text = "Restore 10 HP. Lose 4 Shield.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ミルキークォーツ";
                            DescriptionText.text = "HPを7回復する。4シールドを失う。";
                            break;
                        case 2:
                            NameText.text = "Milky Quartz";
                            DescriptionText.text = "Restore 7 HP. Lose 4 Shield.";
                            break;
                    }
                }
                break;
            case 76:
                switch (Language)
                {
                    case 1:
                        NameText.text = "イエローダイヤモンド";
                        DescriptionText.text = "17ダメージを与える。この宝石によって敵を倒すと、追加でメダルを1枚獲得する。";
                        break;
                    case 2:
                        NameText.text = "Tellow Diamond";
                        DescriptionText.text = "Deals 17 damage. Defeating an enemy with this gem grants one additional medal.";
                        break;
                }
                break;
            case 77:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アズライト";
                        DescriptionText.text = "17ダメージを与える。シールドを持つ敵に対しては効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Azurite";
                        DescriptionText.text = "Deals 17 damage. The effect is doubled against enemies with shields.";
                        break;
                }
                break;
            case 78:
                if (Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "スモーキークォーツ";
                            DescriptionText.text = "10シールドを得る。次のハンドにチェーンが引き継がれる。";
                            break;
                        case 2:
                            NameText.text = "Smoky Quartz";
                            DescriptionText.text = "Gain 10 Shield. The chain carries over to the next hand.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "スモーキークォーツ";
                            DescriptionText.text = "7シールドを得る。次のハンドにチェーンが引き継がれる。";
                            break;
                        case 2:
                            NameText.text = "Smoky Quartz";
                            DescriptionText.text = "Gain 7 Shield. The chain carries over to the next hand.";
                            break;
                    }
                }
                break;
            case 79:
                if (Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ルチルクォーツ";
                            DescriptionText.text = "13シールドを得る。1ターン目のみ出現確率が3倍になる。";
                            break;
                        case 2:
                            NameText.text = "Rutilated Quartz";
                            DescriptionText.text = "Gain 13 Shield. The appearance rate is tripled only on the first turn.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ルチルクォーツ";
                            DescriptionText.text = "9シールドを得る。1ターン目のみ出現確率が3倍になる。";
                            break;
                        case 2:
                            NameText.text = "Rutilated Quartz";
                            DescriptionText.text = "Gain 9 Shield. The appearance rate is tripled only on the first turn.";
                            break;
                    }
                }
                break;
            case 80:
                switch (Language)
                {
                    case 1:
                        NameText.text = "マグネタイト";
                        DescriptionText.text = "12ダメージを与える。スロット内のスターター宝石1つにつき6ダメージを追加で与える。";
                        break;
                    case 2:
                        NameText.text = "Magnetite";
                        DescriptionText.text = "Deals 12 damage. Deal an additional 6 damage for each starter gem in the slot.";
                        break;
                }
                break;
            case 81:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ブロンズ";
                        DescriptionText.text = "1ダメージを受ける。";
                        break;
                    case 2:
                        NameText.text = "Bronze";
                        DescriptionText.text = "Take 1 Damage.";
                        break;
                }
                break;
            case 82:
                switch (Language)
                {
                    case 1:
                        NameText.text = "レッドダイヤモンド";
                        DescriptionText.text = "15ダメージを与える。ボスに対しては効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Red Diamond";
                        DescriptionText.text = "Deals 15 damage. The effect is doubled against bosses.";
                        break;
                }
                break;
            case 83:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アメシストエレスチャル";
                        DescriptionText.text = "8シールドを与える。7チェーン目以降は効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Amethyst Elestial";
                        DescriptionText.text = "Gain 8 Shield. The effect is doubled at 7 Chain or higher.";
                        break;
                }
                break;
            case 84:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ベラクルスアメシスト";
                        DescriptionText.text = "スターター宝石が1つも装備されていない場合、14シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Veracruz Amethyst";
                        DescriptionText.text = "If no starter gems are equipped, gain 14 Shield.";
                        break;
                }
                break;
            case 85:
                switch (Language)
                {
                    case 1:
                        NameText.text = "チャロアイト";
                        DescriptionText.text = "HPを7回復する。最大HPを1失う。";
                        break;
                    case 2:
                        NameText.text = "Charoite";
                        DescriptionText.text = "Restore 7 HP. Lose 1 max HP.";
                        break;
                }
                break;
            case 86:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ジェット";
                        DescriptionText.text = "25ダメージを与える。2ダメージ分のリベンジを失う。";
                        break;
                    case 2:
                        NameText.text = "Jet";
                        DescriptionText.text = "Deals 25 damage. Lose 2 damages of Revenge.";
                        break;
                }
                break;
            case 87:
                switch (Language)
                {
                    case 1:
                        NameText.text = "グリーンダイヤモンド";
                        DescriptionText.text = "30シールドを得る。2チェーン目以降は効果が消える。";
                        break;
                    case 2:
                        NameText.text = "Green Diamond";
                        DescriptionText.text = "Gain 30 Shield. The effect is lost after the 2 chain.";
                        break;
                }
                break;
            case 88:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ホワイトダイヤモンド";
                        DescriptionText.text = "25ダメージを与える。この宝石の出現確率は常に20%で固定される。";
                        break;
                    case 2:
                        NameText.text = "White Diamond";
                        DescriptionText.text = "Deals 25 damage. The appearance rate of this gem is fixed at 20%.";
                        break;
                }
                break;
            case 89:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アイアン";
                        DescriptionText.text = "15シールドを得る。装備中は戦闘終了時に得られるメダルが1枚減る。";
                        break;
                    case 2:
                        NameText.text = "Iron";
                        DescriptionText.text = "Gain 15 Shield. While equipped, you receive 1 fewer medal at the end of combat.";
                        break;
                }
                break;
            case 90:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ラベンダーアメシスト";
                        DescriptionText.text = "13シールドを得る。ターン開始時からスキルを使用するまでは効果が消える。";
                        break;
                    case 2:
                        NameText.text = "Lavender Amethyst";
                        DescriptionText.text = "Gain 13 Shield. The effect wears off if a skill is used after the start of the turn.";
                        break;
                }
                break;
            case 91:
                switch (Language)
                {
                    case 1:
                        NameText.text = "オリハルコン";
                        DescriptionText.text = "前回のハンドのチェーン数が7以上の場合、42ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Orichalcum";
                        DescriptionText.text = "If the chain count of the previous hand was 7 or higher, deals 42 damage.";
                        break;
                }
                break;
            case 92:
                if (Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ストロベリークォーツ";
                            DescriptionText.text = "13ダメージを与える。HPを4回復する。";
                            break;
                        case 2:
                            NameText.text = "Strawberry Quartz";
                            DescriptionText.text = "Deal 13 damage. Restore 4 HP.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ストロベリークォーツ";
                            DescriptionText.text = "9ダメージを与える。HPを3回復する。";
                            break;
                        case 2:
                            NameText.text = "Strawberry Quartz";
                            DescriptionText.text = "Deal 9 damage. Restore 3 HP.";
                            break;
                    }
                }
                break;
            case 93:
                switch (Language)
                {
                    case 1:
                        NameText.text = "スイートテンダイヤモンド";
                        DescriptionText.text = "HPを7回復する。4ダメージ分のリベンジを失う。";
                        break;
                    case 2:
                        NameText.text = "Sweet Ten Diamond";
                        DescriptionText.text = "Restore 7 HP. Lose 4 damages of Revenge.";
                        break;
                }
                break;
            case 94:
                if (Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ガーデンクォーツ";
                            DescriptionText.text = "24ダメージを与える。この宝石を装備している間、全てのスターター宝石の効果が3増加する。";
                            break;
                        case 2:
                            NameText.text = "Garden Quartz";
                            DescriptionText.text = "Deal 24 damage. While this gem is equipped, the effects of all starter gems are increased by 3.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "ガーデンクォーツ";
                            DescriptionText.text = "16ダメージを与える。この宝石を装備している間、全てのスターター宝石の効果が2増加する。";
                            break;
                        case 2:
                            NameText.text = "Garden Quartz";
                            DescriptionText.text = "Deal 16 damage. While this gem is equipped, the effects of all starter gems are increased by 2.";
                            break;
                    }
                }
                break;
            case 95:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ケープアメシスト";
                        DescriptionText.text = "8シールドを得る。現在HPの下1桁が5だった場合、効果が3倍になる。";
                        break;
                    case 2:
                        NameText.text = "Cape Amethyst";
                        DescriptionText.text = "Gain 8 Shield. If the last digit of your current HP is 5, the effect is tripled.";
                        break;
                }
                break;
            case 96:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ミスリル";
                        DescriptionText.text = "18ダメージを与える。現在HPの下2桁が00だった場合、効果が5倍になる。";
                        break;
                    case 2:
                        NameText.text = "Mithril";
                        DescriptionText.text = "Deal 18 damage. If the last two digits of the current HP are 00, the effect is multiplied by 5.";
                        break;
                }
                break;
            case 97:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ライト・フラグメント";
                        DescriptionText.text = "16ダメージを与える。「レフト・フラグメント」と共に装備した場合、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Right Fragment";
                        DescriptionText.text = "Deal 16 damage. If equipped alongside \"Left Fragment,\" the effect is doubled.";
                        break;
                }
                break;
            case 98:
                switch (Language)
                {
                    case 1:
                        NameText.text = "レフト・フラグメント";
                        DescriptionText.text = "8シールドを得る。「ライト・フラグメント」と共に装備した場合、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Left Fragment";
                        DescriptionText.text = "Gain 8 Shield. If equipped alongside \"Right Fragment,\" the effect is doubled.";
                        break;
                }
                break;
            case 99:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アベンチュリン";
                        DescriptionText.text = "30ダメージを与える。スキルを使用するとターン終了まで効果が消える。";
                        break;
                    case 2:
                        NameText.text = "Aventurine";
                        DescriptionText.text = "Deal 30 damage. Using a skill will cause its effect to disappear until the end of the turn.";
                        break;
                }
                break;
            case 100:
                switch (Language)
                {
                    case 1:
                        NameText.text = "グラファイト";
                        DescriptionText.text = "10ダメージを与える。右隣に装備した宝石の出現確率を2倍にする。";
                        break;
                    case 2:
                        NameText.text = "Graphite";
                        DescriptionText.text = "Deal 10 damage. Doubles the appearance rate of the gem equipped to the immediate right.";
                        break;
                }
                break;
            case 101:
                switch (Language)
                {
                    case 1:
                        NameText.text = "チタン";
                        DescriptionText.text = "5シールドを得る。左隣に装備した宝石の出現確率を半減させる。";
                        break;
                    case 2:
                        NameText.text = "Titanium";
                        DescriptionText.text = "Gain 5 Shield. Halves the appearance rate of the gem equipped to the immediate left.";
                        break;
                }
                break;
            case 102:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アウイナイト";
                        DescriptionText.text = "16ダメージを与える。チェーンが4の状態から始まる。";
                        break;
                    case 2:
                        NameText.text = "Hauyne";
                        DescriptionText.text = "Deal 16 damage. It starts with the chain at a state of 4.";
                        break;
                }
                break;
            case 103:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ドロマイト";
                        DescriptionText.text = "前回のハンドのチェーン数x2シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Dolomite";
                        DescriptionText.text = "Gain Shield equal to twice the number of chains from the previous hand.";
                        break;
                }
                break;
            case 104:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ジェムシリカ";
                        DescriptionText.text = "7シールドを得る。前回のチェーン数が10以上の場合、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Gem Silica";
                        DescriptionText.text = "Gain 7 Shield. If the previous chain count was 10 or higher, the effect is doubled.";
                        break;
                }
                break;
            case 105:
                switch (Language)
                {
                    case 1:
                        NameText.text = "モアッサナイト";
                        DescriptionText.text = "14ダメージを与える。敵のHPが50%以上残っている場合、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Moissanite";
                        DescriptionText.text = "Deal 14 damage. The effect is doubled if the enemy has 50% or more of their HP remaining.";
                        break;
                }
                break;
            case 106:
                switch (Language)
                {
                    case 1:
                        NameText.text = "リバーストーン";
                        DescriptionText.text = "23ダメージを与える。この宝石は1度装備すると外せなくなる。";
                        break;
                    case 2:
                        NameText.text = "Riverstone";
                        DescriptionText.text = "Deal 23 damage. Once equipped, this gem cannot be removed.";
                        break;
                }
                break;
            case 107:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アパタイト";
                        DescriptionText.text = "HPを4回復する。HPが100%の場合、7シールドを追加で得る。";
                        break;
                    case 2:
                        NameText.text = "Apatite";
                        DescriptionText.text = "Restore 4 HP. If HP is at 100%, gain an additional 7 Shield.";
                        break;
                }
                break;
            case 108:
                switch (Language)
                {
                    case 1:
                        NameText.text = "プレナイト";
                        DescriptionText.text = "HPが50%以上の時、21ダメージを与える。そうでない場合、11シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Prehnite";
                        DescriptionText.text = "If HP is 50% or higher, deal 21 damage. Otherwise, gain 11 Shield.";
                        break;
                }
                break;
            case 109:
                switch (Language)
                {
                    case 1:
                        NameText.text = "イーグルアイ";
                        DescriptionText.text = "所持している祝福の数x4ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Eagle Eye";
                        DescriptionText.text = "Deal damage equal to the number of Blessings you possess multiplied by 4.";
                        break;
                }
                break;
            case 110:
                switch (Language)
                {
                    case 1:
                        NameText.text = "メタモルフォーゼス";
                        DescriptionText.text = "7シールドを得る。ターン開始時、ランダムな装備中の宝石に変化する。";
                        break;
                    case 2:
                        NameText.text = "Metamorphoses";
                        DescriptionText.text = "Gain 7 Shield. At the start of the turn, transform into a random equipped Gem.";
                        break;
                }
                break;
            case 111:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ネフライト";
                        DescriptionText.text = "13ダメージを与える。この宝石のチェーン数は10で固定される。";
                        break;
                    case 2:
                        NameText.text = "Nephrite";
                        DescriptionText.text = "Deals 13 damage. The number of chains for this gem is fixed at 10.";
                        break;
                }
                break;
            case 112:
                switch (Language)
                {
                    case 1:
                        NameText.text = "グラニット";
                        DescriptionText.text = "5シールドを得る。ターン終了時、この宝石の効果が2増加する。";
                        break;
                    case 2:
                        NameText.text = "Granite";
                        DescriptionText.text = "Gain 5 Shield. At the end of the turn, the effect of this gem increases by 2.";
                        break;
                }
                break;
            case 113:
                switch (Language)
                {
                    case 1:
                        NameText.text = "スーパーセブン";
                        DescriptionText.text = "自分と敵のHPを7回復する。";
                        break;
                    case 2:
                        NameText.text = "Super Seven";
                        DescriptionText.text = "Restore 7 HP to yourself and the enemy.";
                        break;
                }
                break;
            case 114:
                switch (Language)
                {
                    case 1:
                        NameText.text = "インディゴライト";
                        DescriptionText.text = "シールド値が250以下の場合、13シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Indigolite";
                        DescriptionText.text = "If your shield value is 250 or less, gain 13 shield.";
                        break;
                }
                break;
            case 115:
                switch (Language)
                {
                    case 1:
                        NameText.text = "タングステン";
                        DescriptionText.text = "現在のターンでリベンジを発動していない場合、リベンジを14ダメージ分チャージする。";
                        break;
                    case 2:
                        NameText.text = "Tungsten";
                        DescriptionText.text = "If Revenge has not been activated during the current turn, charge Revenge for 14 damage.";
                        break;
                }
                break;
            case 116:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ウラン";
                        DescriptionText.text = "現在の残りハンド数x3ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Uranium";
                        DescriptionText.text = "Deal damage equal to the number of current hand.";
                        break;
                }
                break;
            case 117:
                switch (Language)
                {
                    case 1:
                        NameText.text = "コール";
                        DescriptionText.text = "リベンジを6ダメージ分チャージする。リベンジを発動時、この宝石を消去する。";
                        break;
                    case 2:
                        NameText.text = "Coal";
                        DescriptionText.text = "Charge Revenge for 6 damage. This gem is removed when Revenge is activated.";
                        break;
                }
                break;
            case 118:
                switch (Language)
                {
                    case 1:
                        NameText.text = "パイライト";
                        DescriptionText.text = "15ダメージを与える。各ターンで最初にこの宝石をハンドした時、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Pyrite";
                        DescriptionText.text = "Deal 15 damage. The effect doubles the first time you hand this gem each turn.";
                        break;
                }
                break;
            case 119:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ソーダライト";
                        DescriptionText.text = "7シールドを得る。前回のハンドで消去した宝石がこの宝石ならば、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Sodalite";
                        DescriptionText.text = "Gain 7 Shield. If this gem is the same type as the gem cast in the previous hand, the effect is doubled.";
                        break;
                }
                break;
            case 120:
                switch (Language)
                {
                    case 1:
                        NameText.text = "オルゴナイト";
                        DescriptionText.text = "15ダメージを与える。5%の確率で効果が10倍になる。";
                        break;
                    case 2:
                        NameText.text = "Orgonite";
                        DescriptionText.text = "Deal 15 damage. Has a 5% chance to multiply the effect by 10.";
                        break;
                }
                break;
            case 121:
                switch (Language)
                {
                    case 1:
                        NameText.text = "フリント";
                        DescriptionText.text = "45ダメージを与える。消去時、追加でハンドを4失う。";
                        break;
                    case 2:
                        NameText.text = "Flint";
                        DescriptionText.text = "Deal 45 damage. When cleared, additionally lose 4 hand.";
                        break;
                }
                break;
            case 122:
                switch (Language)
                {
                    case 1:
                        NameText.text = "オーロベルディ";
                        DescriptionText.text = "7シールドを得る。ターン開始時、30%の確率でプリズムに変化する。";
                        break;
                    case 2:
                        NameText.text = "Auroverdi";
                        DescriptionText.text = "Gain 7 Shield. At the start of the turn, there is a 30% chance to transform into a Prism.";
                        break;
                }
                break;
            case 123:
                switch (Language)
                {
                    case 1:
                        NameText.text = "マディラ";
                        DescriptionText.text = "盤上にあるこの宝石の数x2ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Madeira";
                        DescriptionText.text = "Deal damage equal to twice the number of these gems on the board.";
                        break;
                }
                break;
            case 124:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アンデサイト";
                        DescriptionText.text = "24ダメージを与える。3シールドを失う。";
                        break;
                    case 2:
                        NameText.text = "Andesite";
                        DescriptionText.text = "Deal 24 damage. Lose 3 Shield.";
                        break;
                }
                break;
            case 125:
                switch (Language)
                {
                    case 1:
                        NameText.text = "セラフィナイト";
                        DescriptionText.text = "14ダメージを与える。9チェーン以上繋げると、盤上にあるこの宝石を全て消す。";
                        break;
                    case 2:
                        NameText.text = "Seraphinite";
                        DescriptionText.text = "Deal 14 damage. If you chain 9 or more, cast all gems of this type from the board.";
                        break;
                }
                break;
            case 126:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ティファニーストーン";
                        DescriptionText.text = "16ダメージを与える。盤上の一番上の行で消去した場合、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Tiffany Stone";
                        DescriptionText.text = "Deal 16 damage. The effect is doubled if cast from the top row of the board.";
                        break;
                }
                break;
            case 127:
                switch (Language)
                {
                    case 1:
                        NameText.text = "マリアライト";
                        DescriptionText.text = "HPを2～10回復する。残りHPが少ない程効果が上がる。";
                        break;
                    case 2:
                        NameText.text = "Marialite";
                        DescriptionText.text = "Restore 2～10 HP. The effect increases as remaining HP decreases.";
                        break;
                }
                break;
            case 128:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ゼオライト";
                        DescriptionText.text = "7シールドを得る。毎ターン最初にこの宝石を消去時、再出現する。";
                        break;
                    case 2:
                        NameText.text = "Zeolite";
                        DescriptionText.text = "Gain 7 Shield. Reappears the first time this gem is cast each turn.";
                        break;
                }
                break;
            case 129:
                switch (Language)
                {
                    case 1:
                        NameText.text = "バーミキュライト";
                        DescriptionText.text = "次のターン、12シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Vermiculite";
                        DescriptionText.text = "Gain 12 Shield next turn.";
                        break;
                }
                break;
            case 130:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アイスクリスタル";
                        DescriptionText.text = "通常の敵及びエリートにのみ25ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Ice Crystal";
                        DescriptionText.text = "Deal 25 damage only to normal enemies and elites.";
                        break;
                }
                break;
            case 131:
                if (Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "オーロラクォーツ";
                            DescriptionText.text = "9シールドを得る。消去時、ランダムな宝石3つをプリズムに変化させる。";
                            break;
                        case 2:
                            NameText.text = "Aurora Quartz";
                            DescriptionText.text = "Gain 9 Shield. When cast, transform 3 random Gems into Prism.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "オーロラクォーツ";
                            DescriptionText.text = "6シールドを得る。消去時、ランダムな宝石2つをプリズムに変化させる。";
                            break;
                        case 2:
                            NameText.text = "Aurora Quartz";
                            DescriptionText.text = "Gain 6 Shield. When cast, transform 2 random Gems into Prism.";
                            break;
                    }
                }
                break;
            case 132:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ピンクアメシスト";
                        DescriptionText.text = "8シールドを得る。盤上の一番下の行で消去した場合、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Pink Amethyst";
                        DescriptionText.text = "Gain 8 Shield. The effect is doubled if cast from the bottom row of the board.";
                        break;
                }
                break;
            case 133:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ルベライト";
                        DescriptionText.text = $"{Gem133}ダメージを与える。この宝石を装備して戦闘を終了した時、効果が永続的に5増加する。";
                        break;
                    case 2:
                        NameText.text = "Rubellite";
                        DescriptionText.text = $"Deal {Gem133} damage. When battle ends while this gem is equipped, the effect increases by 5 permanently.";
                        break;
                }
                break;
            case 134:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ブラッドストーン";
                        DescriptionText.text = "40ダメージを与える。この宝石を取得時、最大HPを50%失う。";
                        break;
                    case 2:
                        NameText.text = "Bloodstone";
                        DescriptionText.text = "Deal 40 damage. Lose 50% of your maximum HP upon acquiring this gem.";
                        break;
                }
                break;
            case 135:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ラーヴァ";
                        DescriptionText.text = "14ダメージを与える。この宝石をハンドする毎に、ターン終了まで与える全てのダメージが2増加する。";
                        break;
                    case 2:
                        NameText.text = "Lava";
                        DescriptionText.text = "Deal 14 damage. Each time this gem is handed, all damage dealt increases by 2 until the end of the turn.";
                        break;
                }
                break;
            case 136:
                switch (Language)
                {
                    case 1:
                        NameText.text = "バイオタイト";
                        DescriptionText.text = "24シールドを得る。ターン終了時までシールドを得られなくなる。";
                        break;
                    case 2:
                        NameText.text = "Biotite";
                        DescriptionText.text = "Gain 24 Shield. You cannot gain Shield until the end of the turn.";
                        break;
                }
                break;
            case 137:
                switch (Language)
                {
                    case 1:
                        NameText.text = "イリジウム";
                        DescriptionText.text = "13ダメージを与える。4ターン目以降、この宝石は出現しなくなる。";
                        break;
                    case 2:
                        NameText.text = "Iridium";
                        DescriptionText.text = "Deal 13 damage. This gem will no longer appear from the 4th turn onwards.";
                        break;
                }
                break;
            case 138:
                switch (Language)
                {
                    case 1:
                        NameText.text = "セカンダリアメシスト";
                        DescriptionText.text = "5シールドを得る。「アメシスト」とチェーンを繋げられる。";
                        break;
                    case 2:
                        NameText.text = "Secondary Amethyst";
                        DescriptionText.text = "Gain 5 Shield. Can link a chain to Amethyst.";
                        break;
                }
                break;
            case 139:
                if (Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "セカンダリクォーツ";
                            DescriptionText.text = "15ダメージを与える。「クォーツ」とチェーンを繋げられる。";
                            break;
                        case 2:
                            NameText.text = "Secondary Quartz";
                            DescriptionText.text = "Deal 15 Damage. Can link a chain to Quartz.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "セカンダリクォーツ";
                            DescriptionText.text = "10ダメージを与える。「クォーツ」とチェーンを繋げられる。";
                            break;
                        case 2:
                            NameText.text = "Secondary Quartz";
                            DescriptionText.text = "Deal 10 Damage. Can link a chain to Quartz.";
                            break;
                    }
                }
                break;
            case 140:
                switch (Language)
                {
                    case 1:
                        NameText.text = "マーブル";
                        DescriptionText.text = "25チェーン目に1000ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Marble";
                        DescriptionText.text = "Deal 1000 damage at the 25th chain.";
                        break;
                }
                break;
            case 141:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ムーンストーン";
                        DescriptionText.text = "16ダメージを与える。毎ターン最初に消去時、ハンド数+1。";
                        break;
                    case 2:
                        NameText.text = "Moonstone";
                        DescriptionText.text = "Deal 16 damage. the first time this gem is cast each turn, Hand +1.";
                        break;
                }
                break;
            case 142:
                switch (Language)
                {
                    case 1:
                        NameText.text = "カクタスアメシスト";
                        DescriptionText.text = "6シールドを得る。ターン開始時、全てのスターター宝石をこの宝石に変化させる。";
                        break;
                    case 2:
                        NameText.text = "Cactus Amethyst";
                        DescriptionText.text = "Gain 6 Shield. At the start of the turn, transform all Starter Gems into this gem.";
                        break;
                }
                break;
            case 143:
                switch (Language)
                {
                    case 1:
                        NameText.text = "パラジウム";
                        DescriptionText.text = "15シールドを得る。最大HPを1失う。";
                        break;
                    case 2:
                        NameText.text = "Paradium";
                        DescriptionText.text = "Gain 15 Shield. Lose 1 Max HP.";
                        break;
                }
                break;
            case 144:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アイオライト";
                        DescriptionText.text = $"{6 + Gem144}シールドを得る。リベンジを発動する毎に戦闘終了まで効果が3増加する。";
                        break;
                    case 2:
                        NameText.text = "Iolite";
                        DescriptionText.text = $"Gain {6 + Gem144} Shield. Each time Revenge triggers, the effect increases by 3 until the end of battle.";
                        break;
                }
                break;
            case 145:
                if (Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "レモンクォーツ";
                            DescriptionText.text = "シールドを持たない敵にのみ36ダメージを与える。";
                            break;
                        case 2:
                            NameText.text = "Lemon Quartz";
                            DescriptionText.text = "Deals 36 damage only to enemies without a shield.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "レモンクォーツ";
                            DescriptionText.text = "シールドを持たない敵にのみ24ダメージを与える。";
                            break;
                        case 2:
                            NameText.text = "Lemon Quartz";
                            DescriptionText.text = "Deals 24 damage only to enemies without a shield.";
                            break;
                    }
                }
                break;
            case 146:
                switch (Language)
                {
                    case 1:
                        NameText.text = "スターダスト";
                        DescriptionText.text = "17ダメージを与える。1番下の行に到達したとき、自動で消去される。";
                        break;
                    case 2:
                        NameText.text = "Stardust";
                        DescriptionText.text = "Deal 17 damage. It is automatically cleared when it reaches the bottom row.";
                        break;
                }
                break;
            case 147:
                if (Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "レインボークォーツ";
                            DescriptionText.text = "12ダメージを与える。3シールドを得る。HPを3回復する。リベンジを3ダメージ分チャージする。";
                            break;
                        case 2:
                            NameText.text = "Rainbow Quartz";
                            DescriptionText.text = "Deal 12 damage. Gain 3 Shield. Restore 3 HP. Charge Revenge by 3 damage.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "レインボークォーツ";
                            DescriptionText.text = "8ダメージを与える。2シールドを得る。HPを2回復する。リベンジを2ダメージ分チャージする。";
                            break;
                        case 2:
                            NameText.text = "Rainbow Quartz";
                            DescriptionText.text = "Deal 8 damage. Gain 2 Shield. Restore 2 HP. Charge Revenge by 2 damage.";
                            break;
                    }
                }
                break;
            case 148:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ヘミモルファイト";
                        DescriptionText.text = "7シールドを得る。消去時、ランダムな宝石4つをこの宝石に変化させる。";
                        break;
                    case 2:
                        NameText.text = "Hemimorphite";
                        DescriptionText.text = "Gain 7 Shield. When removed, transform 4 random gems into this gem.";
                        break;
                }
                break;
            case 149:
                switch (Language)
                {
                    case 1:
                        NameText.text = "セラミック";
                        DescriptionText.text = "スターター宝石が2つ以上装備されている場合、16シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Ceramic";
                        DescriptionText.text = "Gain 16 Shield if two or more Starter Gems are equipped.";
                        break;
                }
                break;
            case 150:
                switch (Language)
                {
                    case 1:
                        NameText.text = "リード";
                        DescriptionText.text = "HPが25%以下の敵にのみ60ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Lead";
                        DescriptionText.text = "Deal 60 damage only to enemies with 25% or less HP.";
                        break;
                }
                break;
            case 151:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アメシストドーム";
                        DescriptionText.text = "7シールドを得る。次のターン、5シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Amethyst Dome";
                        DescriptionText.text = "Gain 7 Shield. Gain 5 Shield next turn.";
                        break;
                }
                break;
            case 152:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アラゴナイト";
                        DescriptionText.text = $"{Gem152}ダメージを与える。ターン終了時までこの宝石の効果が1増加する。";
                        break;
                    case 2:
                        NameText.text = "Aragonite";
                        DescriptionText.text = $"Deal {Gem152} damage. Increase the effect of this gem by 1 until the end of the turn.";
                        break;
                }
                break;
            case 153:
                switch (Language)
                {
                    case 1:
                        NameText.text = "エピドート";
                        DescriptionText.text = "15ダメージを与える。一番下の行に到達すると、プリズムに変化する。";
                        break;
                    case 2:
                        NameText.text = "Epidote";
                        DescriptionText.text = "Deal 15 damage. Transforms into a Prism upon reaching the bottom row.";
                        break;
                }
                break;
            case 154:
                switch (Language)
                {
                    case 1:
                        NameText.text = "トリプライト";
                        DescriptionText.text = "14ダメージを与える。1ターン目は効果が3倍になる。";
                        break;
                    case 2:
                        NameText.text = "Triplite";
                        DescriptionText.text = "Deal 14 damage. The effect is tripled on the first turn.";
                        break;
                }
                break;
            case 155:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アーティファクト";
                        DescriptionText.text = "10チェーン以上繋げると、スキルが回復する。";
                        break;
                    case 2:
                        NameText.text = "Artifact";
                        DescriptionText.text = "Connecting 10 or more chains restores your skill.";
                        break;
                }
                break;
            case 156:
                switch (Language)
                {
                    case 1:
                        NameText.text = "カドミウム";
                        DescriptionText.text = "32ダメージを与える。5ダメージを受ける。";
                        break;
                    case 2:
                        NameText.text = "Cadmium";
                        DescriptionText.text = "Deal 32 damage. Take 5 Damage.";
                        break;
                }
                break;
            case 157:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ハーキマーダイヤモンド";
                        DescriptionText.text = "6シールドを得る。最大HPが1増加する。";
                        break;
                    case 2:
                        NameText.text = "Herkimer Diamond";
                        DescriptionText.text = "Gain 6 Shield. Increase Max HP by 1.";
                        break;
                }
                break;
            case 158:
                switch (Language)
                {
                    case 1:
                        NameText.text = "オスミウム";
                        DescriptionText.text = "効果なし。この宝石は通常の15%の確率で出現する。";
                        break;
                    case 2:
                        NameText.text = "Osmium";
                        DescriptionText.text = "No effect. This gem appears with a 15% probability.";
                        break;
                }
                break;
            case 159:
                switch (Language)
                {
                    case 1:
                        NameText.text = "タンザナイト";
                        DescriptionText.text = "奇数チェーンのみ、40ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Tanzanite";
                        DescriptionText.text = "Deal 40 damage only on odd-numbered chains.";
                        break;
                }
                break;
            case 160:
                switch (Language)
                {
                    case 1:
                        NameText.text = "キャストライト";
                        DescriptionText.text = "偶数チェーンのみ、22シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Castlight";
                        DescriptionText.text = "Gain 22 Shield. only on even-numbered chains.";
                        break;
                }
                break;
            case 161:
                if (Iscript != null && Iscript.Bless[29] == 1)
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "エレスチャルクォーツ";
                            DescriptionText.text = "25ダメージを与える。戦闘開始時、プリズムに変化する。";
                            break;
                        case 2:
                            NameText.text = "Elestial Quartz";
                            DescriptionText.text = "Deal 25 damage. At the start of battle, transform into a Prism.";
                            break;
                    }
                }
                else
                {
                    switch (Language)
                    {
                        case 1:
                            NameText.text = "エレスチャルクォーツ";
                            DescriptionText.text = "17ダメージを与える。戦闘開始時、プリズムに変化する。";
                            break;
                        case 2:
                            NameText.text = "Elestial Quartz";
                            DescriptionText.text = "Deal 17 damage. At the start of battle, transform into a Prism.";
                            break;
                    }
                }
                break;
            case 162:
                switch (Language)
                {
                    case 1:
                        NameText.text = "クリムゾンストーン";
                        DescriptionText.text = "14ダメージを与える。HPを2回復する。";
                        break;
                    case 2:
                        NameText.text = "Crimson Stone";
                        DescriptionText.text = "Deal 14 damage. Restore 2 HP.";
                        break;
                }
                break;
            case 163:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ファースタイト";
                        DescriptionText.text = "16ダメージを与える。取得時、「セカンダイト」を入手する。";
                        break;
                    case 2:
                        NameText.text = "Firstite";
                        DescriptionText.text = "Deal 16 damage. Upon acquisition, you obtain \"Secondite.\"";
                        break;
                }
                break;
            case 164:
                switch (Language)
                {
                    case 1:
                        NameText.text = "セカンダイト";
                        DescriptionText.text = "8シールドを得る。取得時、「ファースタイト」を入手する。";
                        break;
                    case 2:
                        NameText.text = "Secondite";
                        DescriptionText.text = "Gain 8 Shield. Upon acquisition, you obtain \"Firstite.\"";
                        break;
                }
                break;
            case 165:
                switch (Language)
                {
                    case 1:
                        NameText.text = "キュープライト";
                        DescriptionText.text = "16ダメージを与える。盤上のこの宝石の数が12個以上の場合、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Cuprite";
                        DescriptionText.text = "Deal 16 damage. If there are 12 or more gems of this type on the board, the effect is doubled.";
                        break;
                }
                break;
            case 166:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ツァボライト";
                        DescriptionText.text = "7シールドを得る。盤上のこの宝石の数が8個以下の場合、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Tsavorite";
                        DescriptionText.text = "Gain 7 shields. If there are 8 or fewer gems of this type on the board, the effect is doubled.";
                        break;
                }
                break;
            case 167:
                switch (Language)
                {
                    case 1:
                        NameText.text = "バリサイト";
                        DescriptionText.text = "リベンジを4ダメージ分チャージする。7チェーン以上繋げると、ハンド数+2。";
                        break;
                    case 2:
                        NameText.text = "Variscite";
                        DescriptionText.text = "Charge 4 points of damage for Revenge. If you chain 7 or more, increase your hand size by 2.";
                        break;
                }
                break;
            case 168:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ユーディアライト";
                        DescriptionText.text = "リベンジを7ダメージ分チャージする。11チェーン以上繋げると、リベンジに必要なダメージを5減らす。";
                        break;
                    case 2:
                        NameText.text = "Eudialyte";
                        DescriptionText.text = "Charge 7 damage toward Revenge. If you chain 11 or more, the damage required for Revenge is reduced by 5.";
                        break;
                }
                break;
            case 169:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ベスビアナイト";
                        DescriptionText.text = "リベンジを5ダメージ分チャージする。リベンジが発動可能ならば、16ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Vesuvianite";
                        DescriptionText.text = "Charge 5 damage toward Revenge. If Revenge is ready to activate, deal 16 damage.";
                        break;
                }
                break;
            case 170:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ダイオプサイド";
                        DescriptionText.text = "15ダメージを与える。14チェーン以上繋げると、ランダムな宝石1種類を全て消去する。";
                        break;
                    case 2:
                        NameText.text = "Diopside";
                        DescriptionText.text = "Deal 15 damage. If you chain 14 or more, all gems of one random type are cleared.";
                        break;
                }
                break;
            case 171:
                switch (Language)
                {
                    case 1:
                        NameText.text = "グランディディエライト";
                        DescriptionText.text = "36ダメージを与える。この宝石の価格は通常よりも+2される。";
                        break;
                    case 2:
                        NameText.text = "Grandidierite";
                        DescriptionText.text = "Deal 36 damage. The price of this gem is increased by 2 over its usual cost.";
                        break;
                }
                break;
            case 172:
                switch (Language)
                {
                    case 1:
                        NameText.text = "サーペンティン";
                        DescriptionText.text = "16ダメージを与える。所持している祝福が1つのみならば、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Serpentine";
                        DescriptionText.text = "Deal 16 damage. If you possess only one blessing, the effect is doubled.";
                        break;
                }
                break;
            case 173:
                switch (Language)
                {
                    case 1:
                        NameText.text = "フェナカイト";
                        DescriptionText.text = "40ダメージを与える。出現時、50%の確率でクォーツに変化する。";
                        break;
                    case 2:
                        NameText.text = "Phenakite";
                        DescriptionText.text = "Deal 40 damage. Upon appearing, has a 50% chance to transform into a Quartz.";
                        break;
                }
                break;
            case 174:
                switch (Language)
                {
                    case 1:
                        NameText.text = "スキャポライト";
                        DescriptionText.text = "20シールドを得る。出現時、50%の確率でアメシストに変化する。";
                        break;
                    case 2:
                        NameText.text = "Scapolite";
                        DescriptionText.text = "Gain 20 Shield. Upon appearing, has a 50% chance to transform into an Amethyst.";
                        break;
                }
                break;
            case 175:
                switch (Language)
                {
                    case 1:
                        NameText.text = "フェルスパー";
                        DescriptionText.text = "8シールドを得る。7チェーン目以降は、24ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Feldspar";
                        DescriptionText.text = "Gain 8 Shield. If you chain 7 or more, deal 24 damage.";
                        break;
                }
                break;
            case 176:
                switch (Language)
                {
                    case 1:
                        NameText.text = "グロッシュラー";
                        DescriptionText.text = "この宝石の出現確率に等しいダメージを与える。HPを3失う。";
                        break;
                    case 2:
                        NameText.text = "Grossular";
                        DescriptionText.text = "Deal damage equal to the appearance probability of this gem. Lose 3 HP.";
                        break;
                }
                break;
            case 177:
                switch (Language)
                {
                    case 1:
                        NameText.text = "デマントイド";
                        DescriptionText.text = "ダメージを受ける毎にこの宝石はプリズムに変化する。";
                        break;
                    case 2:
                        NameText.text = "Demantoid";
                        DescriptionText.text = "Each time it takes damage, this gem transforms into a prism.";
                        break;
                }
                break;
            case 178:
                switch (Language)
                {
                    case 1:
                        NameText.text = "キャッツアイ";
                        DescriptionText.text = "現在のシールド値を1.04倍にする。";
                        break;
                    case 2:
                        NameText.text = "Cat's Eye";
                        DescriptionText.text = "Multiplies the current shield value by 1.04.";
                        break;
                }
                break;
            case 179:
                switch (Language)
                {
                    case 1:
                        NameText.text = "パイロープ";
                        DescriptionText.text = "リベンジを14ダメージ分チャージする。消去時、リベンジに必要なダメージが5増加する。";
                        break;
                    case 2:
                        NameText.text = "Pyrope";
                        DescriptionText.text = "Charge 14 damage toward Revenge. When cleared, the damage required for Revenge increases by 5.";
                        break;
                }
                break;
            case 180:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アンモライト";
                        DescriptionText.text = "1チェーン目のみ80ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Ammolite";
                        DescriptionText.text = "Deal 80 damage only on the first chain.";
                        break;
                }
                break;
            case 181:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ダイオライト";
                        DescriptionText.text = $"{7 + Iscript.Gem181}シールドを得る。休憩所で鍛える毎にこの宝石の効果が2増加する。";
                        break;
                    case 2:
                        NameText.text = "Diorite";
                        DescriptionText.text = $"Gain {7 + Iscript.Gem181} Shield. The effect of this gem increases by 2 each time you train at a rest area.";
                        break;
                }
                break;
            case 182:
                switch (Language)
                {
                    case 1:
                        NameText.text = "マイカ";
                        DescriptionText.text = "HPを3回復する。最大HPが1増加する。";
                        break;
                    case 2:
                        NameText.text = "Mica";
                        DescriptionText.text = "Restore 3 HP. Increase maximum HP by 1.";
                        break;
                }
                break;
            case 183:
                switch (Language)
                {
                    case 1:
                        NameText.text = "イルメナイト";
                        DescriptionText.text = "現在の戦闘における最大チェーン数に等しいダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Ilmenite";
                        DescriptionText.text = "Deal damage equal to the maximum chain in the current battle.";
                        break;
                }
                break;
            case 184:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アルミニウム";
                        DescriptionText.text = "現在のハンド数に等しいシールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Aluminum";
                        DescriptionText.text = "Gain Shield equal to your current hand.";
                        break;
                }
                break;
            case 185:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ペロブスカイト";
                        DescriptionText.text = "16ダメージを与える。この宝石によって敵を倒すと、最大HPが50増加する。";
                        break;
                    case 2:
                        NameText.text = "Perovskite";
                        DescriptionText.text = "Deal 16 damage. If an enemy is defeated by this gem, your maximum HP increases by 50.";
                        break;
                }
                break;
            case 186:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アラバスター";
                        DescriptionText.text = "7シールドを得る。前回のターンでダメージを受けていた場合、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Alabaster";
                        DescriptionText.text = "Gain 7 Shield. If you took damage during the previous turn, the effect is doubled.";
                        break;
                }
                break;
            case 187:
                switch (Language)
                {
                    case 1:
                        NameText.text = "サンダーエッグ";
                        DescriptionText.text = "14ダメージを与える。この宝石を装備中は戦闘終了時に貰えるメダルが1枚増える。";
                        break;
                    case 2:
                        NameText.text = "Thunder egg";
                        DescriptionText.text = "Deal 14 damage. While this gem is equipped, you receive one additional medal at the end of battle.";
                        break;
                }
                break;
            case 188:
                switch (Language)
                {
                    case 1:
                        NameText.text = "スコリア";
                        DescriptionText.text = "25シールドを得る。この宝石を装備中にダメージを受けると即死する。";
                        break;
                    case 2:
                        NameText.text = "Scoria";
                        DescriptionText.text = "Gain 25 Shield. If you take damage while this gem is equipped, you die instantly.";
                        break;
                }
                break;
            case 189:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ドゥルージー";
                        DescriptionText.text = "23ダメージを与える。ターン開始時、この宝石の出現確率がランダムに変化する。";
                        break;
                    case 2:
                        NameText.text = "Druzy";
                        DescriptionText.text = "Deal 23 damage. At the start of each turn, the appearance rate of this gem changes randomly.";
                        break;
                }
                break;
            case 190:
                switch (Language)
                {
                    case 1:
                        NameText.text = "パープルダイヤモンド";
                        DescriptionText.text = $"{Iscript.Gem190}ダメージを与える。休憩所で休憩するとこの宝石の効果が0になる。";
                        break;
                    case 2:
                        NameText.text = "Purple Diamond";
                        DescriptionText.text = $"Deal {Iscript.Gem190} damage. Resting at a rest area negates the effect of this gem.";
                        break;
                }
                break;
            case 191:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ニッケル";
                        DescriptionText.text = "5シールドを失う。次のターン、17シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Nickel";
                        DescriptionText.text = "Lose 5 Shield. Gain 17 Shield next turn.";
                        break;
                }
                break;
            case 192:
                switch (Language)
                {
                    case 1:
                        NameText.text = "テラヘルツ";
                        DescriptionText.text = "最大HPが4増加する。HPを6失う。";
                        break;
                    case 2:
                        NameText.text = "Terahertz";
                        DescriptionText.text = "Maximum HP increases by 4. Lose 6 HP.";
                        break;
                }
                break;
            case 193:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ケセラストーン";
                        DescriptionText.text = "最大HPの3%に等しいダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Quesera Stone";
                        DescriptionText.text = "Deal damage equal to 3% of maximum HP.";
                        break;
                }
                break;
            case 194:
                switch (Language)
                {
                    case 1:
                        NameText.text = "オーピメント";
                        DescriptionText.text = "7ターン目以降、60ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Orpiment";
                        DescriptionText.text = "From turn 7 onwards, deal 60 damage.";
                        break;
                }
                break;
            case 195:
                switch (Language)
                {
                    case 1:
                        NameText.text = "レピドライト";
                        DescriptionText.text = "消去時、ハンドを追加で1失い、盤上にあるこの宝石を全て消す。";
                        break;
                    case 2:
                        NameText.text = "Lepidolite";
                        DescriptionText.text = "Upon cast, lose an additional 1 hand and remove all gems of this type from the board.";
                        break;
                }
                break;
            case 196:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ワイルドホース";
                        DescriptionText.text = "状態異常を除くランダムな宝石2つを消去する。";
                        break;
                    case 2:
                        NameText.text = "Wild Horse";
                        DescriptionText.text = "Cast 2 random gems, excluding those affected by status ailments.";
                        break;
                }
                break;
            case 197:
                switch (Language)
                {
                    case 1:
                        NameText.text = "グレーダイヤモンド";
                        DescriptionText.text = "15ダメージを与える。盤上にプリズムが存在する場合、効果が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Gray diamond";
                        DescriptionText.text = "Deal 15 damage. If Prism is on the board, this effect is doubled.";
                        break;
                }
                break;
            case 198:
                switch (Language)
                {
                    case 1:
                        NameText.text = "スティブナイト";
                        DescriptionText.text = "盤上にあるプリズムの数x3シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Stibnite";
                        DescriptionText.text = "Gain Shield equal to 3 times the number of Prism on the board.";
                        break;
                }
                break;
            case 199:
                switch (Language)
                {
                    case 1:
                        NameText.text = "シナバー";
                        DescriptionText.text = "50ダメージを与える。1%の確率で死亡する。";
                        break;
                    case 2:
                        NameText.text = "Cinnabar";
                        DescriptionText.text = "Deal 50 damage. Has a 1% chance to cause death.";
                        break;
                }
                break;

            case 300:
                switch (Language)
                {
                    case 1:
                        NameText.text = "致死毒";
                        DescriptionText.text = "ターン終了時、盤面にある致死毒の数x4%のHPを失う。";
                        break;
                    case 2:
                        NameText.text = "Poison";
                        DescriptionText.text = "At the end of the turn, you lose HP equal to 4% for each Poison on the board.";
                        break;
                }
                break;
            case 301:
                switch (Language)
                {
                    case 1:
                        NameText.text = "メノウ";
                        break;
                    case 2:
                        NameText.text = "Agate";
                        break;
                }
                break;
            case 302:
                switch (Language)
                {
                    case 1:
                        NameText.text = "粘液";
                        DescriptionText.text = "効果なし。";
                        break;
                    case 2:
                        NameText.text = "Mucus";
                        DescriptionText.text = "No effect.";
                        break;
                }
                break;
            case 303:
                switch (Language)
                {
                    case 1:
                        NameText.text = "極光";
                        break;
                    case 2:
                        NameText.text = "Daybreak";
                        break;
                }
                break;
            case 304:
                switch (Language)
                {
                    case 1:
                        NameText.text = "血のオーブ";
                        DescriptionText.text = "弱体化5を得る。";
                        break;
                    case 2:
                        NameText.text = "Blood Orb";
                        DescriptionText.text = "Receive Weak 5.";
                        break;
                }
                break;
            case 305:
                switch (Language)
                {
                    case 1:
                        NameText.text = "瓦礫";
                        DescriptionText.text = "消去時、追加でハンドを1失う。";
                        break;
                    case 2:
                        NameText.text = "Rubble";
                        DescriptionText.text = "When cast, lose an additional hand.";
                        break;
                }
                break;
            case 306:
                switch (Language)
                {
                    case 1:
                        NameText.text = "氷塊";
                        DescriptionText.text = "プレイヤーのターン開始時、ランダムな宝石に変化する。";
                        break;
                    case 2:
                        NameText.text = "Ice";
                        DescriptionText.text = "At the start of the player's turn, transforms into a random gem.";
                        break;
                }
                break;
            case 307:
                switch (Language)
                {
                    case 1:
                        NameText.text = "王家のゴールド";
                        DescriptionText.text = "効果なし。";
                        break;
                    case 2:
                        NameText.text = "Royal Gold";
                        DescriptionText.text = "No Effects.";
                        break;
                }
                break;
            case 308:
                switch (Language)
                {
                    case 1:
                        NameText.text = "フレッシュジェム";
                        DescriptionText.text = "20ダメージを受ける。";
                        break;
                    case 2:
                        NameText.text = "Fresh Gem";
                        DescriptionText.text = "Take 20 Damage.";
                        break;
                }
                break;
            case 309:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ダミージェム";
                        DescriptionText.text = "効果なし。";
                        break;
                    case 2:
                        NameText.text = "Dummy Gem";
                        DescriptionText.text = "No Effects.";
                        break;
                }
                break;
            case 310:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ブラックスター";
                        DescriptionText.text = "10ダメージを受ける。";
                        break;
                    case 2:
                        NameText.text = "Black Star";
                        DescriptionText.text = "Take 10 Damage.";
                        break;
                }
                break;
        }
        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().Play($"Gem{GemNum}");
        }
    }
    public void OnDisplay()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Gem53 = PlayerPrefs.GetInt("Gem53", 5);
        Gem54 = PlayerPrefs.GetInt("Gem54", 32);
        Gem70 = PlayerPrefs.GetInt("Gem70", 50);
        Gem133 = PlayerPrefs.GetInt("Gem133", 10);
        Gem144 = PlayerPrefs.GetInt("Gem144", 0);
        Gem152 = PlayerPrefs.GetInt("Gem152", 0);
        if (GemNum >= 0)
        {
            DisplayObj.SetActive(true);
        }
    }
    public void OffDisplay()
    {
        DisplayObj.SetActive(false);
    }
}
