using UnityEngine;
using TMPro;

public class InfoDisplay_Bless : MonoBehaviour
{
    public InfoDisplay Iscript;
    public GameObject DisplayObj;
    public int BlessNum;
    public TMP_Text NameText;
    public TMP_Text DescriptionText;
    int Language;
    private void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
    }
    void Update()
    {
        switch (BlessNum)
        {
            case 1:
                switch (Language)
                {
                    case 1:
                        NameText.text = "守護者";
                        DescriptionText.text = $"最大HPが{15 * (1 + Iscript.Bless[54])}%増加する。";
                        break;
                    case 2:
                        NameText.text = "Guardian";
                        DescriptionText.text = $"Maximum HP increases by {15 * (1 + Iscript.Bless[54])}%.";
                        break;
                }
                break;
            case 2:
                switch (Language)
                {
                    case 1:
                        NameText.text = "皮膚硬化";
                        DescriptionText.text = $"戦闘開始時、最大HPの{30 * (1 + Iscript.Bless[54])}%にあたるシールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Skin Hardening";
                        DescriptionText.text = $"At the start of battle, gain a shield equal to {30 * (1 + Iscript.Bless[54])}% of maximum HP.";
                        break;
                }
                break;
            case 3:
                switch (Language)
                {
                    case 1:
                        NameText.text = "超回復体";
                        DescriptionText.text = $"HPを回復するたび、回復量の{10 * (1 + Iscript.Bless[54])}%にあたる最大HP増加を得る。";
                        break;
                    case 2:
                        NameText.text = "Super Recovering";
                        DescriptionText.text = $"Each time recover HP, gain a maximum HP increase equal to {10 * (1 + Iscript.Bless[54])}% of the amount recovered.";
                        break;
                }
                break;
            case 4:
                switch (Language)
                {
                    case 1:
                        NameText.text = "頑強なる肉体";
                        DescriptionText.text = $"戦闘終了時、最大HPの{12 * (1 + Iscript.Bless[54])}%を回復する。";
                        break;
                    case 2:
                        NameText.text = "Robust Body";
                        DescriptionText.text = $"At the end of battle, restore {12 * (1 + Iscript.Bless[54])}% of your maximum HP.";
                        break;
                }
                break;
            case 5:
                switch (Language)
                {
                    case 1:
                        NameText.text = "深淵の石";
                        DescriptionText.text = "サファイアをセレスタイトと置き換える。";
                        break;
                    case 2:
                        NameText.text = "Abyssal Stone";
                        DescriptionText.text = "Replace Sapphire with Celestite.";
                        break;
                }
                break;
            case 6:
                switch (Language)
                {
                    case 1:
                        NameText.text = "第六指";
                        DescriptionText.text = $"ターン開始時、ハンド数+{1 * (1 + Iscript.Bless[54])}。";
                        break;
                    case 2:
                        NameText.text = "Sixth finger";
                        DescriptionText.text = $"At the start of your turn, Hand +{1 * (1 + Iscript.Bless[54])}.";
                        break;
                }
                break;
            case 7:
                switch (Language)
                {
                    case 1:
                        NameText.text = "小さな宝石箱";
                        DescriptionText.text = "エメラルドをペリドットと置き換える。";
                        break;
                    case 2:
                        NameText.text = "Small Jewelry box";
                        DescriptionText.text = "Replace Emerald with Peridot.";
                        break;
                }
                break;
            case 8:
                switch (Language)
                {
                    case 1:
                        NameText.text = "研磨";
                        DescriptionText.text = $"全てのスターター宝石の効果が{1 * (1 + Iscript.Bless[54])}増加する。";
                        break;
                    case 2:
                        NameText.text = "Polishing";
                        DescriptionText.text = $"The effect of all starter gems increases by {1 * (1 + Iscript.Bless[54])}.";
                        break;
                }
                break;
            case 9:
                switch (Language)
                {
                    case 1:
                        NameText.text = "恍惚";
                        DescriptionText.text = $"3回目までの戦闘終了時、HPを{18 * (1 + Iscript.Bless[54])}%回復する。";
                        break;
                    case 2:
                        NameText.text = "Ecstasy";
                        DescriptionText.text = $"After the first 3 battles, recover {18 * (1 + Iscript.Bless[54])}% of your HP.";
                        break;
                }
                break;
            case 10:
                switch (Language)
                {
                    case 1:
                        NameText.text = "第三の眼";
                        DescriptionText.text = $"ハンドする毎にHPを{2 * (1 + Iscript.Bless[54])}回復する。";
                        break;
                    case 2:
                        NameText.text = "Third Eye";
                        DescriptionText.text = $"Restores {2 * (1 + Iscript.Bless[54])} HP each time handed.";
                        break;
                }
                break;
            case 11:
                switch (Language)
                {
                    case 1:
                        NameText.text = "啓示";
                        DescriptionText.text = $"毎回ショップのランダムな商品{1 * (1 + Iscript.Bless[54])}つに割引が発生する。";
                        break;
                    case 2:
                        NameText.text = "Revelation";
                        DescriptionText.text = $"A discount is applied to {1 * (1 + Iscript.Bless[54])} random item in the shop each time.";
                        break;
                }
                break;
            case 12:
                switch (Language)
                {
                    case 1:
                        NameText.text = "富豪";
                        DescriptionText.text = $"メダルを{2 * (1 + Iscript.Bless[54])}枚獲得する。";
                        break;
                    case 2:
                        NameText.text = "Rich";
                        DescriptionText.text = $"Gain {2 * (1 + Iscript.Bless[54])} Medals.";
                        break;
                }
                break;
            case 13:
                switch (Language)
                {
                    case 1:
                        NameText.text = "肉体制御";
                        DescriptionText.text = $"HPが40%以下の状態で戦闘を終了した時、HPを{40 * (1 + Iscript.Bless[54])}%まで回復する。";
                        break;
                    case 2:
                        NameText.text = "Body control";
                        DescriptionText.text = $"When a battle ends with HP at 40% or less, HP is restored to {40 * (1 + Iscript.Bless[54])}%.";
                        break;
                }
                break;
            case 14:
                switch (Language)
                {
                    case 1:
                        NameText.text = "狂戦士";
                        DescriptionText.text = $"最大HPが{30 * (1 + Iscript.Bless[54])}%増加する。HPを50%失う。";
                        break;
                    case 2:
                        NameText.text = "Berserker";
                        DescriptionText.text = $"Maximum HP increases by {30 * (1 + Iscript.Bless[54])}%. Lose 50% of HP.";
                        break;
                }
                break;
            case 15:
                switch (Language)
                {
                    case 1:
                        NameText.text = "暴虐の赤石";
                        DescriptionText.text = "ルビーをガーネットと置き換える。";
                        break;
                    case 2:
                        NameText.text = "Redstone of Tyranny";
                        DescriptionText.text = "Replace Ruby with Garnet.";
                        break;
                }
                break;
            case 16:
                switch (Language)
                {
                    case 1:
                        NameText.text = "怪力";
                        DescriptionText.text = $"敵にダメージを与えた時、その値が{1 * (1 + Iscript.Bless[54])}増加する。";
                        break;
                    case 2:
                        NameText.text = "Superhuman Strength";
                        DescriptionText.text = $"When dealing damage to an enemy, that value increases by {1 * (1 + Iscript.Bless[54])}.";
                        break;
                }
                break;
            case 17:
                switch (Language)
                {
                    case 1:
                        NameText.text = "破砕";
                        DescriptionText.text = $"シールドを持つ敵に与えるダメージが{2 + Iscript.Bless[54]}倍になる。";
                        break;
                    case 2:
                        NameText.text = "Crushing";
                        DescriptionText.text = $"Damage dealt to shielded enemies is x{2 + Iscript.Bless[54]}.";
                        break;
                }
                break;
            case 18:
                switch (Language)
                {
                    case 1:
                        NameText.text = "復讐の炎";
                        DescriptionText.text = $"リベンジに必要なダメージが{15 * (1 + Iscript.Bless[54])}%減少する。";
                        break;
                    case 2:
                        NameText.text = "Flames of Revenge";
                        DescriptionText.text = $"The damage required for Revenge is reduced by {15 * (1 + Iscript.Bless[54])}%.";
                        break;
                }
                break;
            case 19:
                switch (Language)
                {
                    case 1:
                        NameText.text = "深淵の声";
                        DescriptionText.text = $"休憩する毎に最大HPが{50 * (1 + Iscript.Bless[54])}増加する。";
                        break;
                    case 2:
                        NameText.text = "Voice of the Abyss";
                        DescriptionText.text = $"Maximum HP increases by {50 * (1 + Iscript.Bless[54])} each time you rest.";
                        break;
                }
                break;
            case 20:
                switch (Language)
                {
                    case 1:
                        NameText.text = "不死";
                        if(Iscript.Bless20 == 1)
                        {
                            DescriptionText.text = "この祝福の能力は発動済み。";
                        }
                        else
                        {
                            DescriptionText.text = $"HPが0になると、一度のみHP{20 * (1 + Iscript.Bless[54])}%で復活する。";
                        }
                        break;
                    case 2:
                        NameText.text = "Undead";
                        if (Iscript.Bless20 == 1)
                        {
                            DescriptionText.text = "This bless's ability has already been activated.";
                        }
                        else
                        {
                            DescriptionText.text = $"When HP reaches 0, you revive once with HP equal to {20 * (1 + Iscript.Bless[54])}%.";
                        }
                        break;
                }
                break;
            case 21:
                switch (Language)
                {
                    case 1:
                        NameText.text = "巧妙";
                        DescriptionText.text = $"各戦闘で最初にスキルを使用したとき、その効果は{2 + Iscript.Bless[54]}倍になる。";
                        break;
                    case 2:
                        NameText.text = "Ingenious";
                        DescriptionText.text = $"When a skill is used for the first time in each battle, its effect is multiplied by {2 + Iscript.Bless[54]}.";
                        break;
                }
                break;
            case 22:
                switch (Language)
                {
                    case 1:
                        NameText.text = "血塗れの契約";
                        DescriptionText.text = $"戦闘開始時、リベンジを{30 * (1 + Iscript.Bless[54])}%チャージする。";
                        break;
                    case 2:
                        NameText.text = "Bloody contract";
                        DescriptionText.text = $"At the start of battle, charge Revenge by {30 * (1 + Iscript.Bless[54])}%.";
                        break;
                }
                break;
            case 23:
                switch (Language)
                {
                    case 1:
                        NameText.text = "交渉術";
                        DescriptionText.text = $"ショップに追加で{1 * (1 + Iscript.Bless[54])}つの宝石と祝福が並ぶ。";
                        break;
                    case 2:
                        NameText.text = "Negotiation Techniques";
                        DescriptionText.text = $"An additional {1 * (1 + Iscript.Bless[54])} gems and blessings will appear in the shop.";
                        break;
                }
                break;
            case 24:
                switch (Language)
                {
                    case 1:
                        NameText.text = "転禍";
                        DescriptionText.text = $"ショップの内容を{2 * (1 + Iscript.Bless[54])}回までリロール出来るようになる。";
                        break;
                    case 2:
                        NameText.text = "Turning Misfortune";
                        DescriptionText.text = $"The shop contents can be rerolled up to {2 * (1 + Iscript.Bless[54])} times.";
                        break;
                }
                break;
            case 25:
                switch (Language)
                {
                    case 1:
                        NameText.text = "免疫力";
                        DescriptionText.text = "弱体化の解除速度が2倍になる。";
                        break;
                    case 2:
                        NameText.text = "Immunity";
                        DescriptionText.text = "The speed at Weak are removed is doubled.";
                        break;
                }
                break;
            case 26:
                switch (Language)
                {
                    case 1:
                        NameText.text = "激昂";
                        DescriptionText.text = "ダメージを受ける毎にリベンジを追加で25%チャージする。";
                        break;
                    case 2:
                        NameText.text = "Rage";
                        DescriptionText.text = "Charge Revenge by an additional 25% each time damage is taken.";
                        break;
                }
                break;
            case 27:
                switch (Language)
                {
                    case 1:
                        NameText.text = "錬金術";
                        DescriptionText.text = "取得時、ランダムな宝石3つを入手する。";
                        break;
                    case 2:
                        NameText.text = "Alchemy";
                        DescriptionText.text = "Obtain three random gems upon acquisition.";
                        break;
                }
                break;
            case 28:
                switch (Language)
                {
                    case 1:
                        NameText.text = "背水の陣";
                        DescriptionText.text = "HPが50%以下でターンを開始したとき、ハンド数+2。";
                        break;
                    case 2:
                        NameText.text = "Back to the wall";
                        DescriptionText.text = "When starting a turn with 50% or less HP, hand +2.";
                        break;
                }
                break;
            case 29:
                switch (Language)
                {
                    case 1:
                        NameText.text = "情熱";
                        DescriptionText.text = "名前に「クォーツ」を含む宝石の効果が1.5倍になる。";
                        break;
                    case 2:
                        NameText.text = "Passion";
                        DescriptionText.text = "The effects of gemstones with \"Quartz\" in their name are increased by 1.5 times.";
                        break;
                }
                break;
            case 30:
                switch (Language)
                {
                    case 1:
                        NameText.text = "神聖";
                        DescriptionText.text = "名前に「アメシスト」を含む宝石を消去する毎に、HPを3回復する。";
                        break;
                    case 2:
                        NameText.text = "Sacred";
                        DescriptionText.text = "Restore 3 HP each time you clear a gemstone with \"Amethyst\" in its name.";
                        break;
                }
                break;
            case 31:
                switch (Language)
                {
                    case 1:
                        NameText.text = "深呼吸";
                        DescriptionText.text = "ダメージを受けた次のターン、最大HPの10%にあたるシールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Deep Breath";
                        DescriptionText.text = "On the turn after taking damage, gain a shield equal to 10% of the maximum HP.";
                        break;
                }
                break;
            case 32:
                switch (Language)
                {
                    case 1:
                        NameText.text = "富と栄光";
                        DescriptionText.text = "戦闘終了時、追加で1枚のメダルを獲得できる。";
                        break;
                    case 2:
                        NameText.text = "Wealth and Glory";
                        DescriptionText.text = "Gain one additional medal at the end of the battle.";
                        break;
                }
                break;
            case 33:
                switch (Language)
                {
                    case 1:
                        NameText.text = "渇望";
                        DescriptionText.text = "トランジションレベルで鍛えた時、追加で最大HP+10%。";
                        break;
                    case 2:
                        NameText.text = "Craving";
                        DescriptionText.text = "When training at the transition level, gain an additional +10% Max HP.";
                        break;
                }
                break;
            case 34:
                switch (Language)
                {
                    case 1:
                        NameText.text = "先読み";
                        DescriptionText.text = "スキルを使用せずにターンを終了すると、次のターン、ハンド数+4。";
                        break;
                    case 2:
                        NameText.text = "Foresight";
                        DescriptionText.text = "If you end your turn without using a skill, hand +4.";
                        break;
                }
                break;
            case 35:
                switch (Language)
                {
                    case 1:
                        NameText.text = "縫合";
                        DescriptionText.text = "ターン開始時、HPを3%回復する。";
                        break;
                    case 2:
                        NameText.text = "Suture";
                        DescriptionText.text = "At the start of the turn, restore 3% HP.";
                        break;
                }
                break;
            case 36:
                switch (Language)
                {
                    case 1:
                        NameText.text = "加速";
                        DescriptionText.text = "6チェーン以上繋げると、チェーンが追加で2増加する。";
                        break;
                    case 2:
                        NameText.text = "Acceleration";
                        DescriptionText.text = "Connecting a chain of 6 or more increases the chain count by an additional 2.";
                        break;
                }
                break;
            case 37:
                switch (Language)
                {
                    case 1:
                        NameText.text = "稀有";
                        DescriptionText.text = "一番左のスロットに装備された宝石の出現率が半分に減少する。";
                        break;
                    case 2:
                        NameText.text = "Rarefall";
                        DescriptionText.text = "The appearance rate of the gem equipped in the leftmost slot is reduced by half.";
                        break;
                }
                break;
            case 38:
                switch (Language)
                {
                    case 1:
                        NameText.text = "五月雨";
                        DescriptionText.text = "一番右のスロットに装備された宝石の出現率が2倍に増加する。";
                        break;
                    case 2:
                        NameText.text = "May rain";
                        DescriptionText.text = "The appearance rate of the gem equipped in the rightmost slot is doubled.";
                        break;
                }
                break;
            case 39:
                switch (Language)
                {
                    case 1:
                        NameText.text = "補強";
                        DescriptionText.text = "シールドを得る毎に、追加で1シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Reinforcement";
                        DescriptionText.text = "Whenever you gain a shield, gain an additional 1 shield.";
                        break;
                }
                break;
            case 40:
                switch (Language)
                {
                    case 1:
                        NameText.text = "地平線";
                        DescriptionText.text = "5ハンドまで次のターンに持ち越すことが出来るようになる。";
                        break;
                    case 2:
                        NameText.text = "Horizon";
                        DescriptionText.text = "You will be able to carry over up to 5 hand to the next turn.";
                        break;
                }
                break;
            case 41:
                switch (Language)
                {
                    case 1:
                        NameText.text = "瞬発";
                        DescriptionText.text = "チェーンが2の状態から始まる。";
                        break;
                    case 2:
                        NameText.text = "Momentum";
                        DescriptionText.text = "It starts with the chain at a state of 2.";
                        break;
                }
                break;
            case 42:
                switch (Language)
                {
                    case 1:
                        NameText.text = "狂奔";
                        DescriptionText.text = "常にHPが1として見なされる。";
                        break;
                    case 2:
                        NameText.text = "Madness";
                        DescriptionText.text = "HP is always treated as 1.";
                        break;
                }
                break;
            case 43:
                switch (Language)
                {
                    case 1:
                        NameText.text = "鍛造";
                        DescriptionText.text = "ダメージを受ける毎に最大HPが10増加する。";
                        break;
                    case 2:
                        NameText.text = "Forging";
                        DescriptionText.text = "Maximum HP increases by 10 each time you take damage.";
                        break;
                }
                break;
            case 44:
                switch (Language)
                {
                    case 1:
                        NameText.text = "成金";
                        DescriptionText.text = "休憩する毎にメダルを2枚獲得する。";
                        break;
                    case 2:
                        NameText.text = "Nouveau riche";
                        DescriptionText.text = "Gain 2 medals each time you take a rest.";
                        break;
                }
                break;
            case 45:
                switch (Language)
                {
                    case 1:
                        NameText.text = "鋼体";
                        DescriptionText.text = "取得時、最大HPが150増加する。";
                        break;
                    case 2:
                        NameText.text = "Steel Body";
                        DescriptionText.text = "Increases maximum HP by 150 upon acquisition.";
                        break;
                }
                break;
            case 46:
                switch (Language)
                {
                    case 1:
                        NameText.text = "熱変換";
                        DescriptionText.text = "敵の攻撃をシールドで防ぎきる毎に、HPを4%回復する。";
                        break;
                    case 2:
                        NameText.text = "Heat Conversion";
                        DescriptionText.text = "Recover 4% of your HP each time you fully block an enemy attack with your shield.";
                        break;
                }
                break;
            case 47:
                switch (Language)
                {
                    case 1:
                        NameText.text = "安全装置";
                        DescriptionText.text = "ターン終了時、シールド値が8%増加する。";
                        break;
                    case 2:
                        NameText.text = "Safety Device";
                        DescriptionText.text = "At the end of the turn, the shield value increases by 8%.";
                        break;
                }
                break;
            case 48:
                switch (Language)
                {
                    case 1:
                        NameText.text = "調律";
                        DescriptionText.text = "5の倍数チェーンを達成する毎に、4シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Tuning";
                        DescriptionText.text = "Gain 4 Shield each time you achieve a chain that is a multiple of 5.";
                        break;
                }
                break;
            case 49:
                switch (Language)
                {
                    case 1:
                        NameText.text = "万能薬";
                        DescriptionText.text = "HPの回復効果が40%増加する。";
                        break;
                    case 2:
                        NameText.text = "Panacea";
                        DescriptionText.text = "HP recovery effects are increased by 40%.";
                        break;
                }
                break;
            case 50:
                switch (Language)
                {
                    case 1:
                        NameText.text = "奇策";
                        DescriptionText.text = "次の戦闘において、敵のHPが50%減少する。ボスとエリートにはこの効果が適用されない。\r\n";
                        break;
                    case 2:
                        NameText.text = "Clever Scheme";
                        DescriptionText.text = "In the next battle, the enemy's HP is reduced by 50%. This effect does not apply to boss or elites.";
                        break;
                }
                break;
            case 51:
                switch (Language)
                {
                    case 1:
                        NameText.text = "安定性";
                        DescriptionText.text = "100シールドまで次のターンに持ち越すことが出来るようになる。";
                        break;
                    case 2:
                        NameText.text = "Stability";
                        DescriptionText.text = "You will be able to carry over up to 100 shield to the next turn.";
                        break;
                }
                break;
            case 52:
                switch (Language)
                {
                    case 1:
                        NameText.text = "集光";
                        DescriptionText.text = "ターン開始時、ランダムな宝石2つをプリズムに変化させる。";
                        break;
                    case 2:
                        NameText.text = "Light Focusing";
                        DescriptionText.text = "At the start of the turn, transform two random gems into Prisms.";
                        break;
                }
                break;
            case 53:
                switch (Language)
                {
                    case 1:
                        NameText.text = "明媚";
                        DescriptionText.text = "プリズムを6つ生成した状態で戦闘を開始する。";
                        break;
                    case 2:
                        NameText.text = "Mesmerizing";
                        DescriptionText.text = "Start the battle with six prisms generated.";
                        break;
                }
                break;
            case 54:
                switch (Language)
                {
                    case 1:
                        NameText.text = "天賦";
                        DescriptionText.text = "スターター祝福の効果を2倍にする。";
                        break;
                    case 2:
                        NameText.text = "Natural Talent";
                        DescriptionText.text = "Doubles the effect of the Starter Blessing.";
                        break;
                }
                break;
            case 55:
                switch (Language)
                {
                    case 1:
                        NameText.text = "万全";
                        DescriptionText.text = "ボスとの戦闘開始時、HPを全回復する。";
                        break;
                    case 2:
                        NameText.text = "Fulfillment";
                        DescriptionText.text = "Fully restores HP at the start of the battle with the boss.";
                        break;
                }
                break;
            case 56:
                switch (Language)
                {
                    case 1:
                        NameText.text = "緊急回避";
                        DescriptionText.text = "残りHPが50%以上の状態で致命の一撃を受けた場合、HP1で生き残る。";
                        break;
                    case 2:
                        NameText.text = "Emergency Avoidance";
                        DescriptionText.text = "If you receive a fatal blow while your remaining HP is 50% or higher, you survive with 1 HP.";
                        break;
                }
                break;
            case 57:
                switch (Language)
                {
                    case 1:
                        NameText.text = "助走";
                        DescriptionText.text = "前のハンドのチェーンが2以下だった場合、次のハンドのチェーンは4の状態から始まる。";
                        break;
                    case 2:
                        NameText.text = "Approach Run";
                        DescriptionText.text = "If the chain of the previous hand was 2 or less, the chain of the next hand starts at 4.";
                        break;
                }
                break;
            case 58:
                switch (Language)
                {
                    case 1:
                        NameText.text = "好奇心";
                        DescriptionText.text = "次のトランジションレベルにおいて、ショップの全ての商品価格が半額になる。";
                        break;
                    case 2:
                        NameText.text = "Curiosity";
                        DescriptionText.text = "During the next transition level, the prices of all items in the shop will be cut in half.";
                        break;
                }
                break;
            case 59:
                switch (Language)
                {
                    case 1:
                        NameText.text = "先導";
                        DescriptionText.text = "戦闘開始時、敵に200ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Leading";
                        DescriptionText.text = "At the start of battle, deal 200 damage to the enemy.";
                        break;
                }
                break;
            case 60:
                switch (Language)
                {
                    case 1:
                        NameText.text = "衝動";
                        DescriptionText.text = "HPが100%の状態でダメージを受けると、数値に関わらずリベンジが使用可能になる。";
                        break;
                    case 2:
                        NameText.text = "Impulse";
                        DescriptionText.text = "If you take damage while at 100% HP, Revenge becomes available regardless of the damage amount.";
                        break;
                }
                break;
            case 61:
                switch (Language)
                {
                    case 1:
                        NameText.text = "器用";
                        DescriptionText.text = "戦闘開始時、ハンド数+2。";
                        break;
                    case 2:
                        NameText.text = "Handy";
                        DescriptionText.text = "At the start of battle, Hand +2.";
                        break;
                }
                break;
            case 62:
                switch (Language)
                {
                    case 1:
                        NameText.text = "好戦";
                        DescriptionText.text = "ターン開始時、リベンジを10%チャージする。";
                        break;
                    case 2:
                        NameText.text = "Belligerence";
                        DescriptionText.text = "At the start of the turn, charge Revenge by 10%.";
                        break;
                }
                break;
            case 63:
                switch (Language)
                {
                    case 1:
                        NameText.text = "減退";
                        DescriptionText.text = "スターター宝石の出現確率が通常の2分の1になる。";
                        break;
                    case 2:
                        NameText.text = "Ebb";
                        DescriptionText.text = "The appearance rate of starter gems is reduced to half the normal rate.";
                        break;
                }
                break;
            case 64:
                switch (Language)
                {
                    case 1:
                        NameText.text = "鉄人";
                        DescriptionText.text = "リベンジを発動する毎に、50シールドを得る。";
                        break;
                    case 2:
                        NameText.text = "Ironman";
                        DescriptionText.text = "Gain 50 Shield each time Revenge is activated.";
                        break;
                }
                break;
            case 65:
                switch (Language)
                {
                    case 1:
                        NameText.text = "アビスの恩寵";
                        if (Iscript.Bless65 == 0)
                        {
                            DescriptionText.text = "この祝福の能力は発動済み。";
                        }
                        else
                        {
                            DescriptionText.text = $"最初に受ける{200 * (1 + Iscript.Bless[54])}以上のダメージを無効化する。";
                        }
                        break;
                    case 2:
                        NameText.text = "Grace of the Abyss";
                        if (Iscript.Bless65 == 0)
                        {
                            DescriptionText.text = "This bless's ability has already been activated.";
                        }
                        else
                        {
                            DescriptionText.text = $"Negates the first damage taken equal to or greater than {200 * (1 + Iscript.Bless[54])}.";
                        }
                        break;
                }
                break;
            case 66:
                switch (Language)
                {
                    case 1:
                        NameText.text = "漆黒の護符";
                        DescriptionText.text = $"{2 * (1 + Iscript.Bless[54])}回目までの戦闘において、敵のHPが25%減少する。";
                        break;
                    case 2:
                        NameText.text = "Jet-black Amulet";
                        DescriptionText.text = $"In battles up to the {2 * (1 + Iscript.Bless[54])} one, the enemy's HP is reduced by 25%.";
                        break;
                }
                break;
            case 67:
                switch (Language)
                {
                    case 1:
                        NameText.text = "ほろ酔い";
                        DescriptionText.text = $"最初のターンにおいて、ランダムな宝石{1 + Iscript.Bless[54]}種類の出現確率が0%になる。";
                        break;
                    case 2:
                        NameText.text = "Tipsy";
                        DescriptionText.text = $"On the first turn, the appearance probability of {1 + Iscript.Bless[54]} random type of gem becomes 0%.";
                        break;
                }
                break;
            case 68:
                switch (Language)
                {
                    case 1:
                        NameText.text = "賭博師";
                        DescriptionText.text = $"スキル使用時、{10 + Iscript.Bless[54]}%の確率で再度スキルが使用可能になる。";
                        break;
                    case 2:
                        NameText.text = "Gambler";
                        DescriptionText.text = $"When using a skill, there is a {10 + Iscript.Bless[54]}% chance that the skill becomes available for use again.";
                        break;
                }
                break;
            case 69:
                switch (Language)
                {
                    case 1:
                        NameText.text = "虐殺者";
                        DescriptionText.text = $"与えるダメージが{Iscript.Bless69}%増加する。ダメージを受ける毎に効果が5%ずつ減少する。";
                        break;
                    case 2:
                        NameText.text = "Slaughterer";
                        DescriptionText.text = $"Damage dealt increases by {Iscript.Bless69}%. The effect decreases by 5% each time damage is taken.";
                        break;
                }
                break;
            case 70:
                switch (Language)
                {
                    case 1:
                        NameText.text = "一触即発";
                        DescriptionText.text = $"ダメージを受けた次のターン、ハンド数+{2 + Iscript.Bless[54]}。";
                        break;
                    case 2:
                        NameText.text = "Critical Situation";
                        DescriptionText.text = $"The turn after taking damage, Hand +{2 + Iscript.Bless[54]}.";
                        break;
                }
                break;
            case 71:
                switch (Language)
                {
                    case 1:
                        NameText.text = "楽園";
                        DescriptionText.text = "取得時、HPを全回復する。";
                        break;
                    case 2:
                        NameText.text = "Paradise";
                        DescriptionText.text = "Fully restores HP when obtained.";
                        break;
                }
                break;
            case 72:
                switch (Language)
                {
                    case 1:
                        NameText.text = "要塞";
                        DescriptionText.text = "シールドを得る毎に、HPを1回復する。";
                        break;
                    case 2:
                        NameText.text = "Fortress";
                        DescriptionText.text = "Restore 1 HP each time you gain a shield.";
                        break;
                }
                break;
            case 73:
                switch (Language)
                {
                    case 1:
                        NameText.text = "真理";
                        DescriptionText.text = "ボスのHPが15%減少する。";
                        break;
                    case 2:
                        NameText.text = "Verity";
                        DescriptionText.text = "The boss's HP decreases by 15%.";
                        break;
                }
                break;
            case 74:
                switch (Language)
                {
                    case 1:
                        NameText.text = "投資家";
                        DescriptionText.text = "次の戦闘終了時、追加で4枚のメダルを得る。";
                        break;
                    case 2:
                        NameText.text = "Investor";
                        DescriptionText.text = "At the start of the turn, restore 2% HP.";
                        break;
                }
                break;
            case 75:
                switch (Language)
                {
                    case 1:
                        NameText.text = "供物";
                        DescriptionText.text = "取得時、ランダムな祝福を2つ獲得する。";
                        break;
                    case 2:
                        NameText.text = "Offering";
                        DescriptionText.text = "Gain 2 random blessings when obtained.";
                        break;
                }
                break;
            case 76:
                switch (Language)
                {
                    case 1:
                        NameText.text = "繚乱";
                        DescriptionText.text = "リベンジを使用する毎に、ランダムな宝石4つをプリズムに変化させる。";
                        break;
                    case 2:
                        NameText.text = "Riot of Bloom";
                        DescriptionText.text = "Each time Revenge is used, random 4 gems transform into Prism.";
                        break;
                }
                break;
            case 77:
                switch (Language)
                {
                    case 1:
                        NameText.text = "反射";
                        DescriptionText.text = "ダメージを受ける毎に、敵に50ダメージを与える。";
                        break;
                    case 2:
                        NameText.text = "Reflect";
                        DescriptionText.text = "Deals 50 damage to the enemy each time damage is taken.";
                        break;
                }
                break;
            case 78:
                switch (Language)
                {
                    case 1:
                        NameText.text = "洞察";
                        DescriptionText.text = "ターン終了時、リベンジが発動可能だった場合、HPを5%回復する。";
                        break;
                    case 2:
                        NameText.text = "Insight";
                        DescriptionText.text = "At the end of the turn, if Revenge could be activated, restore 5% HP.";
                        break;
                }
                break;
            case 79:
                switch (Language)
                {
                    case 1:
                        NameText.text = "柔軟";
                        DescriptionText.text = "20以上のHPを失うとき、その値を10軽減する。";
                        break;
                    case 2:
                        NameText.text = "Flexiblity";
                        DescriptionText.text = "When you would lose 20 or more HP, reduce that amount by 10.";
                        break;
                }
                break;
            case 80:
                switch (Language)
                {
                    case 1:
                        NameText.text = "激闘";
                        DescriptionText.text = "与えるダメージが8%増加する。";
                        break;
                    case 2:
                        NameText.text = "Fierce battle";
                        DescriptionText.text = "Damage dealt increases by 8%.";
                        break;
                }
                break;
            case 81:
                switch (Language)
                {
                    case 1:
                        NameText.text = "永劫の忠誠";
                        DescriptionText.text = "？？？";
                        break;
                    case 2:
                        NameText.text = "Eternal Loyalty";
                        DescriptionText.text = "???";
                        break;
                }
                break;
        }
        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().Play($"Bless{BlessNum}");
        }
    }
    public void OnDisplay()
    {
        DisplayObj.SetActive(true);
        Language = PlayerPrefs.GetInt("Language", 2);
    }
    public void OffDisplay()
    {
        DisplayObj.SetActive(false);
    }
}
