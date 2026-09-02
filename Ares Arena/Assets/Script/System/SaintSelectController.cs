using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaintSelectController : MonoBehaviour
{
    public TMP_Text SaintName;
    public TMP_Text SaintExplain;
    public TMP_Text SaintHP;
    public TMP_Text SkillName;
    public TMP_Text SkillDesc;
    public TMP_Text RevengeName;
    public TMP_Text RevengeDesc;
    public GameObject FadeOut;
    public Animator Saintanim;
    public Animator[] SaintCrownanim;
    public GameObject[] SaintLock;

    int Choosing;
    int Saint1;
    int Saint2;
    int Played;

    public AudioSource BGM;
    public AudioSource SE;
    public AudioClip OkSE;

    bool IsVolumeFade;

    int Language;
    int Crown;
    public TMP_Text CrownName;
    public TMP_Text CrownDesc;
    public Animator Crownanim;
    int MaxCrown;
    int SaintCrown;
    public GameObject CrownObj;

    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Played = PlayerPrefs.GetInt("Played", 0);
        Select(1);
        for(int i = 0; i < SaintCrownanim.Length; i++)
        {
            if (PlayerPrefs.GetInt($"MaxCrown{i + 1}", 0) == 0)
            {
                SaintCrownanim[i].gameObject.SetActive(false);
            }
            else
            {
                SaintCrownanim[i].Play($"Crown{PlayerPrefs.GetInt($"MaxCrown{i + 1}", 0)}");
            }
            if (Played >= i)
            {
                SaintLock[i].SetActive(false);
            }
        }
    }
    void Update()
    {
        if (IsVolumeFade)
        {
            BGM.volume -= Time.deltaTime * 2f;
        }
    }
    void CrownDisplay()
    {
        Crownanim.Play($"Crown{Crown}");
        switch (Crown)
        {
            case 0:
                switch(Language)
                {
                    case 1:
                        CrownName.text = "スタンダード";
                        CrownDesc.text = "デフォルトの難易度。";
                        break;
                    case 2:
                        CrownName.text = "Standard";
                        CrownDesc.text = "Default difficulty.";
                        break;
                }
                PlayerPrefs.SetInt("EnemyStatusLevel", 0);
                PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                break;
            case 1:
                switch (Language)
                {
                    case 1:
                        CrownName.text = "クラウン I";
                        CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。(Lv.1)\n" +
                            "メダルを1枚所持した状態でランを開始する。";
                        break;
                    case 2:
                        CrownName.text = "Crown I";
                        CrownDesc.text = "Enemy durability increases, and attacks intensify. (Lv.1)\n" +
                            "Start the run with 1 medal in your possession.";
                        break;
                }
                PlayerPrefs.SetInt("EnemyStatusLevel", 1);
                PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                break;
            case 2:
                switch (Language)
                {
                    case 1:
                        CrownName.text = "クラウン II";
                        CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。(Lv.2)\n" +
                            "メダルを1枚所持した状態でランを開始する。\n" +
                            "ショップにより多くの宝石と祝福が並ぶ。";
                        break;
                    case 2:
                        CrownName.text = "Crown II";
                        CrownDesc.text = "Enemy durability increases, and attacks intensify. (Lv.2)\n" +
                            "Start the run with 1 medals in your possession.\n" +
                            "More gems and blessings are available in the shop.";
                        break;
                }
                PlayerPrefs.SetInt("EnemyStatusLevel", 2);
                PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                break;
            case 3:
                switch (Language)
                {
                    case 1:
                        CrownName.text = "クラウン III";
                        CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。(Lv.3)\n" +
                            "敵が使用する特殊能力が強化される。(Lv.1)\n" +
                            "メダルを2枚所持した状態でランを開始する。\n" +
                            "ショップにより多くの宝石と祝福が並ぶ。\n" +
                            "ラン開始時、スターター祝福を2つ獲得する。";
                        break;
                    case 2:
                        CrownName.text = "Crown III";
                        CrownDesc.text = "Enemy durability increases, and attacks intensify. (Lv.3)\n" +
                            "Special abilities used by enemies are enhanced. (Lv.1)\n" +
                            "Start the run with 2 medals in your possession." +
                            "More gems and blessings are available in the shop.\n" +
                            "Gain 2 Starter Blessings at the start of the run.";
                        break;
                }
                PlayerPrefs.SetInt("EnemyStatusLevel", 3);
                PlayerPrefs.SetInt("EnemyAbilityLevel", 1);
                break;
            case 4:
                switch (Language)
                {
                    case 1:
                        CrownName.text = "クラウン IV";
                        CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。(Lv.4)\n" +
                            "敵が使用する特殊能力が強化される。(Lv.1)\n" +
                            "2体のエリートと戦闘する。\n" +
                            "メダルを2枚所持した状態でランを開始する。\n" +
                            "ショップにより多くの宝石と祝福が並ぶ。\n" +
                            "ラン開始時、スターター祝福を2つ獲得する。";
                        break;
                    case 2:
                        CrownName.text = "Crown IV";
                        CrownDesc.text = "Enemy durability increases, and attacks intensify. (Lv.4)\n" +
                            "Special abilities used by enemies are enhanced. (Lv.1)\n" +
                            "Fight 2 Elites.\n" +
                            "Start the run with 2 medals in your possession.\n" +
                            "More gems and blessings are available in the shop.\n" +
                            "Gain 2 Starter Blessings at the start of the run.";
                        break;
                }
                PlayerPrefs.SetInt("EnemyStatusLevel", 4);
                PlayerPrefs.SetInt("EnemyAbilityLevel", 1);
                break;
            case 5:
                switch (Language)
                {
                    case 1:
                        CrownName.text = "クラウン V";
                        CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。(Lv.5)\n" +
                            "敵が使用する特殊能力が強化される。(Lv.2)\n" +
                            "2体のエリートと戦闘する。\n" +
                            "メダルを3枚所持した状態でランを開始する。\n" +
                            "ショップにより多くの宝石と祝福が並ぶ。\n" +
                            "ラン開始時、スターター祝福を2つ獲得する。";
                        break;
                    case 2:
                        CrownName.text = "Crown V";
                        CrownDesc.text = "Enemy durability increases, and attacks intensify. (Lv.5)\n" +
                            "Special abilities used by enemies are enhanced. (Lv.2)\n" +
                            "Fight 2 Elites.\n" +
                            "Start the run with 3 medals in your possession.\n" +
                            "More gems and blessings are available in the shop.\n" +
                            "Gain 2 Starter Blessings at the start of the run.";
                        break;
                }
                PlayerPrefs.SetInt("EnemyStatusLevel", 5);
                PlayerPrefs.SetInt("EnemyAbilityLevel", 2);
                break;
        }
    }
    public void Select(int i)
    {
        if (Played >= i - 1)
        {
            switch (Language)
            {
                case 1:
                    switch (i)
                    {
                        case 1:
                            SaintName.text = "ヴァルキリー";
                            SaintExplain.text = "まどろみの祈りから目覚めた聖騎士。\n" +
                                "絶えなき天との交信が神の心を動かした。";
                            SkillName.text = "覚醒";
                            SkillDesc.text = "ランダムな宝石1種類を全て消去する。";
                            RevengeName.text = "プライムハンド";
                            RevengeDesc.text = "ハンド数 +5。";
                            break;
                        case 2:
                            SaintName.text = "ウォッチャー";
                            SaintExplain.text = "監視の一族の最後の生き残り。\n" +
                                "形見の懐中時計を片手に使命を全うする。";
                            SkillName.text = "狙撃";
                            SkillDesc.text = "任意の宝石10つを消去する。";
                            RevengeName.text = "矢筒拡張";
                            RevengeDesc.text = "この戦闘中、スキルの効果が3増加する。";
                            break;
                        case 3:
                            SaintName.text = "シアー";
                            SaintExplain.text = "溶融剣を携えた狂乱の戦士。\n" +
                                "炎と一体になるべく身を焦がし続ける。";
                            SkillName.text = "バーニングハンド";
                            SkillDesc.text = "次のハンド時、宝石を消去する毎にリベンジを4%チャージする。";
                            RevengeName.text = "噴火";
                            RevengeDesc.text = "下から3行目までの状態異常以外の宝石を全て消去する。";
                            break;
                        case 4:
                            SaintName.text = "フラクタル";
                            SaintExplain.text = "汚染された虹を内包する実験体。\n" +
                                "身体の崩壊と引き換えにその虹彩を保っている。";
                            SkillName.text = "万華鏡";
                            SkillDesc.text = "任意の宝石4つをプリズムに変化させる。";
                            RevengeName.text = "乱反射";
                            RevengeDesc.text = "ランダムな宝石8つをプリズムに変化させる。";
                            break;
                        case 5:
                            SaintName.text = "セントリー";
                            SaintExplain.text = "戦の亡霊に取りつかれた召喚術士。\n" +
                                "霊の耳鳴りに思考を操られている。";
                            SkillName.text = "凝視";
                            SkillDesc.text = "次のハンド時に与えるダメージが2倍になる。";
                            RevengeName.text = "一斉射撃";
                            RevengeDesc.text = "300ダメージを与える。この効果が永続的に60増加する。";
                            break;
                        case 6:
                            SaintName.text = "ファントム";
                            SaintExplain.text = "深淵の霧にさいなまれし悪魔。\n" +
                                "影と一体化し冷酷なる力を行使する。";
                            SkillName.text = "侵蝕";
                            SkillDesc.text = "盤上の1箇所に触媒20を付与する。触媒はハンドする毎に該当箇所にある宝石を消す。";
                            RevengeName.text = "支配";
                            RevengeDesc.text = "盤上のランダムな6箇所に触媒5を付与する。";
                            break;
                        case 7:
                            SaintName.text = "コレクター";
                            SaintExplain.text = "珍しい品を集めて回る探検家。\n" +
                                "宝石の噂を聞きつけ遠い国からやって来た。";
                            SkillName.text = "収集";
                            SkillDesc.text = "宝石3つを消去し、スロットに消した宝石を追加する。スロット内の宝石は任意に盤上に設置できる。";
                            RevengeName.text = "展覧会";
                            RevengeDesc.text = "全ての種類の宝石をスロットに2つずつ追加する。";
                            break;
                        case 8:
                            SaintName.text = "ノーヴル";
                            SaintExplain.text = "黄金の手を持つ王家の錬金術師。\n" +
                                "無限の財を携え、高貴なる力を行使する。";
                            SkillName.text = "ミダスの手";
                            SkillDesc.text = "ハンド数+4。ランダムな宝石20つを効果なしの黄金に変化させる。";
                            RevengeName.text = "黄金の血";
                            RevengeDesc.text = "戦闘終了時に得られるメダルが1枚増える。";
                            break;
                        case 9:
                            SaintName.text = "ゴーレム";
                            SaintExplain.text = "制御を失った防衛ドロイド。\n" +
                                "守るものもなく、無痛の盾として永遠に立ち尽くす。";
                            SkillName.text = "シールドバッシュ";
                            SkillDesc.text = "現在のシールド値に等しいダメージを与え、シールドの30%を失う。";
                            RevengeName.text = "金属体";
                            RevengeDesc.text = "200シールドを得る。";
                            break;
                        case 10:
                            SaintName.text = "オーダー";
                            SaintExplain.text = "剣の達人を志す貴族の造反者。\n" +
                                "果てしない憎しみを冷たい刃に変えている。\r\n";
                            SkillName.text = "弱点探知";
                            SkillDesc.text = "ランダムな4箇所をマーキングする。順番通りに宝石を消去する毎に、70ダメージを追加で与える。";
                            RevengeName.text = "剣の舞";
                            RevengeDesc.text = "ランダムな6箇所をマーキングする。このターン中、マーキングの順番は無視される。";
                            break;
                        case 11:
                            SaintName.text = "クリエイター";
                            SaintExplain.text = "片手から命を生み出す治癒師。\n" +
                                "生命エネルギーからあらゆる物質を創り出す。";
                            SkillName.text = "創始";
                            SkillDesc.text = "宝石1つをセルに変化させる。セルはターン経過で成長し、ハンド時に宝石を放出する。";
                            RevengeName.text = "増殖";
                            RevengeDesc.text = "全てのセルを1段階成長させる。";
                            break;
                        case 12:
                            SaintName.text = "マトリックス";
                            SaintExplain.text = "かつての姿を掘り起こす時の橋掛け人。\n" +
                                "録画のような超記憶能力は己の過去をも具現化させた。";
                            SkillName.text = "念写";
                            SkillDesc.text = "盤上の任意の3x3マスの宝石配列を記憶する。記憶した配列は任意の場所に再設置出来る。";
                            RevengeName.text = "記憶改竄";
                            RevengeDesc.text = "記憶した配列内の宝石を2箇所に設置する。";
                            break;
                        case 13:
                            SaintName.text = "レヴナント";
                            SaintExplain.text = "錬金術の研究に明け暮れる王家の醸造技師。\n" +
                                "禁じられた実験により、邪悪な姿へと変貌した。";
                            SkillName.text = "大釜";
                            SkillDesc.text = "ランダムなポーションを1つ調合する。";
                            RevengeName.text = "禁断の調合";
                            RevengeDesc.text = "空のポーションスロットをランダムなポーションで埋めつくす。";
                            break;
                    }
                    break;
                case 2:
                    switch (i)
                    {
                        case 1:
                            SaintName.text = "The Valkyrie";
                            SaintExplain.text = "A Holy Knight awakened from slumbering prayer.\n" +
                                "Ceaseless communication with the heavens moved the heart of God.";
                            SkillName.text = "Awakening";
                            SkillDesc.text = "Cast all of one random gem type.";
                            RevengeName.text = "Prime Hand";
                            RevengeDesc.text = "Hand +5。";
                            break;
                        case 2:
                            SaintName.text = "The Watcher";
                            SaintExplain.text = "The last surviving knight of the surveillance family.\n" +
                                "Fulfills own mission, clutching a watch that served as a memento.";
                            SkillName.text = "Sniper";
                            SkillDesc.text = "Cast any 10 gems.";
                            RevengeName.text = "Quiver Expansion";
                            RevengeDesc.text = "During this battle, the effect of skills increases by 3.";
                            break;
                        case 3:
                            SaintName.text = "The Sear";
                            SaintExplain.text = "A frenzied warrior wielding a molten sword.\n" +
                                "Continually scorches own body, seeking to become one with the flames.";
                            SkillName.text = "Burning Hand";
                            SkillDesc.text = "During the next hand, charge Revenge by 4% each time a gem is cast.";
                            RevengeName.text = "Eruption";
                            RevengeDesc.text = "Remove all gems except those with status effects from the bottom 3 rows.";
                            break;
                        case 4:
                            SaintName.text = "The Fractal";
                            SaintExplain.text = "An experiment harboring a contaminated rainbow.\n" +
                                "Maintains those irises at the cost of its body's disintegration.";
                            SkillName.text = "Kaleidoscope";
                            SkillDesc.text = "Transform any 4 gems into Prism.";
                            RevengeName.text = "Diffuse Reflection";
                            RevengeDesc.text = "Transforms 8 random gems into Prism.";
                            break;
                        case 5:
                            SaintName.text = "The Sentry";
                            SaintExplain.text = "A summoner possessed by the specter of a warrior.\n" +
                                "His thoughts are being manipulated by the spirit's ringing in his ears.";
                            SkillName.text = "Gaze";
                            SkillDesc.text = "The damage dealt by the next hand is doubled.";
                            RevengeName.text = "Broadside";
                            RevengeDesc.text = "Deals 300 damage. This effect increases by 60 permanently.";
                            break;
                        case 6:
                            SaintName.text = "The Phantom";
                            SaintExplain.text = "A demon tormented by the mist of the abyss.\n" +
                                "Merge with the shadows and wield ruthless power.";
                            SkillName.text = "Erosion";
                            SkillDesc.text = "Grant Catalyst 20 to 1 location on the board. Each time you hand, Catalyst casts gem located at that spot.";
                            RevengeName.text = "Domination";
                            RevengeDesc.text = "Grant Catalyst 5 to 6 random locations on the board.";
                            break;
                        case 7:
                            SaintName.text = "The Collector";
                            SaintExplain.text = "An explorer who travels the world collecting rare items.\n" +
                                "Arrived from a distant land after hearing rumors of the gems.";
                            SkillName.text = "Collection";
                            SkillDesc.text = "Cast any 3 gems and adds the cast gems to the slots. Gems in the slots can be placed anywhere on the board.";
                            RevengeName.text = "Exhibition";
                            RevengeDesc.text = "Adds 2 of every type of gem to the slots.";
                            break;
                        case 8:
                            SaintName.text = "The Noble";
                            SaintExplain.text = "A royal alchemist possessing the Golden Hand.\n" +
                                "Wielding aristocratic power, commands boundless wealth.";
                            SkillName.text = "Midas Touch";
                            SkillDesc.text = "Hand +4. Transforms 20 random gems into Royal Gold with no effect.";
                            RevengeName.text = "Golden Blood";
                            RevengeDesc.text = "Receive 1 additional medal at the end of battle.";
                            break;
                        case 9:
                            SaintName.text = "The Golem";
                            SaintExplain.text = "A defense droid that has lost all control." +
                                "With nothing left to protect, it stands eternally as a painless shield.";
                            SkillName.text = "Shield Bash";
                            SkillDesc.text = "Deals damage equal to the current shield value and consumes 30% of the shield.";
                            RevengeName.text = "Metal Body";
                            RevengeDesc.text = "Gain 200 Shield.";
                            break;
                        case 10:
                            SaintName.text = "The Order";
                            SaintExplain.text = "A royal alchemist possessing the Golden Hand.\n" +
                                "Wielding aristocratic power, commands boundless wealth.";
                            SkillName.text = "Weak Detection";
                            SkillDesc.text = "Mark 4 random locations. Deal an additional 70 damage each time cast gems in the specified order.";
                            RevengeName.text = "Sword Dance";
                            RevengeDesc.text = "Mark 6 random locations. The order of marking is ignored during this turn.";
                            break;
                        case 11:
                            SaintName.text = "The Creator";
                            SaintExplain.text = "A healer who creates life from a single hand.\n" +
                                "Multiply all manner of matter using life energy.";
                            SkillName.text = "Creation";
                            SkillDesc.text = "Transforms 1 gems into Cell. Cell grow over the course of turns and release gems when hand.";
                            RevengeName.text = "Prosperity";
                            RevengeDesc.text = "Grow all Cell by 1 stages.";
                            break;
                        case 12:
                            SaintName.text = "The Matrix";
                            SaintExplain.text = "A bridge-builder who unearths the form of the past.\n" +
                                "A photographic memory manifested even their own past.";
                            SkillName.text = "Spirit Graphy";
                            SkillDesc.text = "Memorize the arrangement of gems in any 3x3 area. The arrangement can be placed again.";
                            RevengeName.text = "Alteration";
                            RevengeDesc.text = "Place the gems from the memorized arrangement at 2 locations.";
                            break;
                        case 13:
                            SaintName.text = "The Revenant";
                            SaintExplain.text = "A royal brewer who devoted herself to the study of alchemy.\n" +
                                "Transformed into a wicked being through a forbidden experiment.";
                            SkillName.text = "Cauldron";
                            SkillDesc.text = "Brew 1 random potion.";
                            RevengeName.text = "Forbidden Brewing";
                            RevengeDesc.text = "Fill all empty potion slots with random potions.";
                            break;
                    }
                    break;
            }
            switch (i)
            {
                case 1:
                    SaintHP.text = "HP: 400";
                    break;
                case 2:
                    SaintHP.text = "HP: 350";
                    break;
                case 3:
                    SaintHP.text = "HP: 450";
                    break;
                case 4:
                    SaintHP.text = "HP: 360";
                    break;
                case 5:
                    SaintHP.text = "HP: 420";
                    break;
                case 6:
                    SaintHP.text = "HP: 360";
                    break;
                case 7:
                    SaintHP.text = "HP: 370";
                    break;
                case 8:
                    SaintHP.text = "HP: 400";
                    break;
                case 9:
                    SaintHP.text = "HP: 500";
                    break;
                case 10:
                    SaintHP.text = "HP: 380";
                    break;
                case 11:
                    SaintHP.text = "HP: 300";
                    break;
                case 12:
                    SaintHP.text = "HP: 400";
                    break;
                case 13:
                    SaintHP.text = "HP: 350";
                    break;
            }
            Choosing = i;
            Saint1 = Choosing;
            SaintChoose(1);
            Saintanim.Play($"Saint{i}");
            MaxCrown = PlayerPrefs.GetInt($"MaxCrown{i}", 0);
            SaintCrown = PlayerPrefs.GetInt($"SaintCrown{i}", 0);
            Crown = SaintCrown;
            PlayerPrefs.SetInt("Crown", SaintCrown);
            PlayerPrefs.Save();
            if (MaxCrown == 0)
            {
                CrownObj.SetActive(false);
            }
            else
            {
                CrownObj.SetActive(true);
                CrownDisplay();
            }
            SE.PlayOneShot(OkSE);
        }
    }
    public void CrownUp()
    {
        if(Crown < MaxCrown && Saint1 <= 7)
        {
            Crown += 1;
            PlayerPrefs.SetInt($"SaintCrown{Saint1}", Crown);
            PlayerPrefs.SetInt("Crown", Crown);
            PlayerPrefs.Save();
            CrownDisplay();
        }
    }
    public void CrownDown()
    {
        if (Crown > 0)
        {
            Crown -= 1;
            PlayerPrefs.SetInt($"SaintCrown{Saint1}", Crown);
            PlayerPrefs.SetInt("Crown", Crown);
            PlayerPrefs.Save();
            CrownDisplay();
        }
    }
    public void SaintChoose(int i)
    {
        switch(i)
        {
            case 1:
                if (Choosing != Saint2)
                {
                    Saint1 = Choosing;
                    PlayerPrefs.SetInt("Saint1", Choosing);
                }
                break;
            case 2:
                if (Choosing != Saint1)
                {
                    Saint2 = Choosing;
                    PlayerPrefs.SetInt("Saint2", Choosing);
                }
                break;
        }
        PlayerPrefs.Save();
    }
    public void RunStart()
    {
        if (Saint1 != 0)
        {
            FadeOut.SetActive(true);
            IsVolumeFade = true;
            SE.PlayOneShot(OkSE);
            Invoke("SceneMove", 2f);
        }
    }
    void SceneMove()
    {
        SceneManager.LoadScene("Arena");
    }
}
