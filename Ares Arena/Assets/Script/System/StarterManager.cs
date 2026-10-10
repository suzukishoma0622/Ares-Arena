using TMPro;
using UnityEngine;

public class StarterManager : MonoBehaviour
{
    public InfoDisplay Iscript;
    [SerializeField] int StarterNum;
    [SerializeField] int[] AppearBless;
    int Language;
    public TMP_Text Messagetext;
    int FirstContact;

    public TMP_Text[] NameText;
    public TMP_Text[] DescriptionText;
    [SerializeField] Animator[] Blessanim;
    int[] BlessJudge = new int[3];

    bool IsChoose;
    [SerializeField] GameObject NextCG;
    [SerializeField] GameObject ChooseCG;
    [SerializeField] GameObject[] Flash;

    public GameObject[] BattleObj;
    int Crown;
    public GameObject[] StarterObj;
    public AudioClip StarterSE1;

    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Crown = PlayerPrefs.GetInt("Crown", 0);
        int Judge = Random.Range(1, 16);
        FirstContact = PlayerPrefs.GetInt($"FirstContact{StarterNum}", 0);
        if (FirstContact == 0)
        {
            Judge = 0;
            PlayerPrefs.SetInt($"FirstContact{StarterNum}", 1);
            PlayerPrefs.Save();
        }
        switch(StarterNum)
        {
            case 1:
                switch(Language)
                {
                    case 1:
                        switch(Judge)
                        {
                            case 0:
                                Messagetext.text = "挑戦者…か……\n" +
                                    "私の名は……アビス…、祝福を…授けよう……";
                                break;
                            case 1:
                                Messagetext.text = "勇敢…なる…者よ……、行くのだ……\n" +
                                    "アレースの元へ……";
                                break;
                            case 2:
                                Messagetext.text = "アレース……奴の…思い通りに……\n" +
                                    "させては…ならない……";
                                break;
                            case 3:
                                Messagetext.text = "奴に……忠誠を……誓った……お前は…";
                                break;
                            case 4:
                                Messagetext.text = "未だ……滅びる…運命に……あらず……";
                                break;
                            case 5:
                                Messagetext.text = "祝福を…持っていけ……\n" +
                                    "お前を…守って…くれる……";
                                break;
                            case 6:
                                Messagetext.text = "アレース……奴の…目的……";
                                break;
                            case 7:
                                Messagetext.text = "奴らに……気をつけろ……\n" +
                                    "奴らも…忠誠を……誓った……";
                                break;
                            case 8:
                                Messagetext.text = "また……お前か……立ち上がれ…再び……";
                                break;
                            case 9:
                                Messagetext.text = "いつか…奴を……滅ぼす…者が……";
                                break;
                            case 10:
                                Messagetext.text = "受け取れ……祝福を……\n" +
                                    "お前は…選ばれた……";
                                break;
                            case 11:
                                Messagetext.text = "諦めぬ心を……持つ限り……\n" +
                                    "私は……お前を見守ろう……";
                                break;
                            case 12:
                                Messagetext.text = "目覚めの……時は……来た……";
                                break;
                            case 13:
                                Messagetext.text = "栄光が……お前を待つ……\n" +
                                    "決して……見失うな……";
                                break;
                            case 14:
                                Messagetext.text = "死は……終わりではない……";
                                break;
                            case 15:
                                Messagetext.text = "お前は……繰り返しているのだ……\n" +
                                    "死に……学び……そして死ぬ……";
                                break;
                        }
                        break;
                    case 2:
                        switch (Judge)
                        {
                            case 0:
                                Messagetext.text = "A challenger... huh... My name is... Abyss...\n" +
                                    "I shall bestow... a blessing upon you...";
                                break;
                            case 1:
                                Messagetext.text = "Brave one... go... to meet Ares...";
                                break;
                            case 2:
                                Messagetext.text = "Ares... we must not let him... have his way...";
                                break;
                            case 3:
                                Messagetext.text = "You... swore allegiance... to him...";
                                break;
                            case 4:
                                Messagetext.text = "Not yet... destined... to perish...";
                                break;
                            case 5:
                                Messagetext.text = "Take the blessing... with you...\n" +
                                    "It will protect you...";
                                break;
                            case 6:
                                Messagetext.text = "Ares... his... purpose...";
                                break;
                            case 7:
                                Messagetext.text = "Be careful of them...\n" +
                                    "They too... have sworn allegiance...";
                                break;
                            case 8:
                                Messagetext.text = "It's you again... Get up... once more...";
                                break;
                            case 9:
                                Messagetext.text = "Someday... someone will... destroy him...";
                                break;
                            case 10:
                                Messagetext.text = "Receive it...the blessing...\n" +
                                    "you have been chosen...";
                                break;
                            case 11:
                                Messagetext.text = "As long as you hold onto... an unyielding heart...\n" +
                                    "I will... watch over you...";
                                break;
                            case 12:
                                Messagetext.text = "The time... for awakening... has come...";
                                break;
                            case 13:
                                Messagetext.text = "Glory... awaits you...\n" +
                                    "Never... lose sight of it...";
                                break;
                            case 14:
                                Messagetext.text = "Death is... not the end...";
                                break;
                            case 15:
                                Messagetext.text = "You are... repeating it...\n" +
                                    "dying... learning... and dying...";
                                break;
                        }
                        break;
                }
                break;
            case 2:
                switch (Language)
                {
                    case 1:
                        switch (Judge)
                        {
                            case 0:
                                Messagetext.text = "あら、挑戦者ね？怖がらないで、あなたの味方よ。\n" +
                                    "私はエキソディウム。祝福でもいかが？";
                                break;
                            case 1:
                                Messagetext.text = "祝福を持っていきなさい。あなたは可能性を秘めているわ。";
                                break;
                            case 2:
                                Messagetext.text = "彼に忠誠を誓ったのね？\n" +
                                    "あなたはもう逃れられないわよ。";
                                break;
                            case 3:
                                Messagetext.text = "そんな顔をしないで。目と目を合わせてお話しましょう？";
                                break;
                            case 4:
                                Messagetext.text = "何か飲んでいく？殺気が湧いてくるやつをね。";
                                break;
                            case 5:
                                Messagetext.text = "アレース？彼の正体？\n" +
                                    "さあね、何なんでしょう。";
                                break;
                            case 6:
                                Messagetext.text = "殺しによって忠誠は示される……\n" +
                                    "分かりやすいやり方ね。";
                                break;
                            case 7:
                                Messagetext.text = "また行くのね。\n" +
                                    "今度は……上手くいくといいけど。";
                                break;
                            case 8:
                                Messagetext.text = "へえ、綺麗な宝石を持ってるじゃない。";
                                break;
                            case 9:
                                Messagetext.text = "忠誠心？そんなの関係ないわ。\n" +
                                    "私たちはもう、彼のものなのよ。";
                                break;
                            case 10:
                                Messagetext.text = "戦い続けなさい、永遠に。\n" +
                                    "あなたが運命を変えるつもりが無いのならね。";
                                break;
                            case 11:
                                Messagetext.text = "アレースがいる限り、栄光を目指す限り、\n" +
                                    "あなたは殺戮し続けるのでしょう？";
                                break;
                            case 12:
                                Messagetext.text = "慈悲を捨てなさい、挑戦者。\n" +
                                    "有象無象があなたにそうするように。";
                                break;
                            case 13:
                                Messagetext.text = "死を恐れる必要はないわ。\n" +
                                    "既にあなたは、それを体験し、知っているはずよ。";
                                break;
                            case 14:
                                Messagetext.text = "勝つことが全てではない。\n" +
                                    "勝者にも、敗者にも、未来はあるものよ。";
                                break;
                            case 15:
                                Messagetext.text = "目を覚まして。まだあなたには、\n" +
                                    "やるべきことが沢山ある。";
                                break;
                        }
                        break;
                    case 2:
                        switch (Judge)
                        {
                            case 0:
                                Messagetext.text = "Oh, a challenger, are you? Don't be afraid?I'm on your side. \n" +
                                    "I am Exodium. Care for a bless?";
                                break;
                            case 1:
                                Messagetext.text = "Take this blessing with you. You hold great potential.";
                                break;
                            case 2:
                                Messagetext.text = "So, you've sworn loyalty to him?\n" +
                                    "You can't escape now.";
                                break;
                            case 3:
                                Messagetext.text = "Don't make a face like that. Let's look each other in the eye and talk, shall we?";
                                break;
                            case 4:
                                Messagetext.text = "Care for a drink? The kind that stirs up a murderous intent.";
                                break;
                            case 5:
                                Messagetext.text = "Ares? His true identity?\n" +
                                    "Well, who knows?what could it be?";
                                break;
                            case 6:
                                Messagetext.text = "Loyalty is proven through killing...\n" +
                                    "A straightforward way of doing things.";
                                break;
                            case 7:
                                Messagetext.text = "So, you're going again.\n" +
                                    "This time... I hope it goes well.";
                                break;
                            case 8:
                                Messagetext.text = "Oh, you've got a beautiful gem there.";
                                break;
                            case 9:
                                Messagetext.text = "Loyalty? That doesn't matter.\n" +
                                    "We belong to him now.";
                                break;
                            case 10:
                                Messagetext.text = "Keep fighting?forever.\n" +
                                    "That is, unless you have no intention of changing your fate.";
                                break;
                            case 11:
                                Messagetext.text = "As long as Ares is with you, and as long as you strive for glory," +
                                    "you will go on slaughtering, won't you?";
                                break;
                            case 12:
                                Messagetext.text = "Abandon mercy, challenger.\n" +
                                    "Just as the motley crew do to you.";
                                break;
                            case 13:
                                Messagetext.text = "There is no need to fear death. You have already\n" +
                                    "experienced it—you should know it well.";
                                break;
                            case 14:
                                Messagetext.text = "Winning isn't everything.\n" +
                                    "Both winners and losers have a future.";
                                break;
                            case 15:
                                Messagetext.text = "Wake up. You still have so much left to do.";
                                break;
                        }
                        break;
                }
                break;
            case 3:
                switch (Language)
                {
                    case 1:
                        switch (Judge)
                        {
                            case 0:
                                Messagetext.text = "挑戦者か？\n" +
                                    "俺の名はファフニル。お前に、祝福をやろう！";
                                break;
                            case 1:
                                Messagetext.text = "奴らを殺そうぜ！";
                                break;
                            case 2:
                                Messagetext.text = "そんなものが武器だって？";
                                break;
                            case 3:
                                Messagetext.text = "アレース？奴は分かってないな……";
                                break;
                            case 4:
                                Messagetext.text = "力！暴力！殺しの限りを尽くせ！！";
                                break;
                            case 5:
                                Messagetext.text = "アレースだって殺してみせるぞ！";
                                break;
                            case 6:
                                Messagetext.text = "奴らはどこにいる？";
                                break;
                            case 7:
                                Messagetext.text = "殺意が足りない！";
                                break;
                            case 8:
                                Messagetext.text = "武器を取るのだ、殺せ！";
                                break;
                            case 9:
                                Messagetext.text = "その武器、お前に似合ってるぞ？";
                                break;
                            case 10:
                                Messagetext.text = "始めようではないか！";
                                break;
                            case 11:
                                Messagetext.text = "終わりなき殺戮を讃えよ！";
                                break;
                            case 12:
                                Messagetext.text = "邪魔する者は叩き潰せ！";
                                break;
                            case 13:
                                Messagetext.text = "死は新しい始まりだ！";
                                break;
                            case 14:
                                Messagetext.text = "血が滾る……戦いたいなあ！";
                                break;
                            case 15:
                                Messagetext.text = "俺の力を使いこなすとはな、気に入ったぞ！";
                                break;
                        }
                        break;
                    case 2:
                        switch (Judge)
                        {
                            case 0:
                                Messagetext.text = "A challenger? My name is Fafnir.\n" +
                                    "I shall grant you a blessing!";
                                break;
                            case 1:
                                Messagetext.text = "Let's kill 'em!";
                                break;
                            case 2:
                                Messagetext.text = "You call that a weapon?";
                                break;
                            case 3:
                                Messagetext.text = "Ares? He just doesn't get it...";
                                break;
                            case 4:
                                Messagetext.text = "Might! Violence! Unleash every form of slaughter!!";
                                break;
                            case 5:
                                Messagetext.text = "I'll kill even Ares!";
                                break;
                            case 6:
                                Messagetext.text = "Not enough murderous intent!";
                                break;
                            case 7:
                                Messagetext.text = "Where are they?";
                                break;
                            case 8:
                                Messagetext.text = "Take up arms?kill!";
                                break;
                            case 9:
                                Messagetext.text = "That weapon suits you.";
                                break;
                            case 10:
                                Messagetext.text = "Let us begin!";
                                break;
                            case 11:
                                Messagetext.text = "Praise the endless slaughter!";
                                break;
                            case 12:
                                Messagetext.text = "Crush anyone who stands in your way!";
                                break;
                            case 13:
                                Messagetext.text = "Death is a new beginning!";
                                break;
                            case 14:
                                Messagetext.text = "My blood is boiling... I want to fight!";
                                break;
                            case 15:
                                Messagetext.text = "To think you've mastered my power... I like you!";
                                break;
                        }
                        break;
                }
                break;
            case 4:
                switch (Language)
                {
                    case 1:
                        switch (Judge)
                        {
                            case 0:
                                Messagetext.text = "我が愛する信者よ、よくぞ来た。\n" +
                                    "恐れることはない、さあ、前へ進み出でよ。";
                                break;
                            case 1:
                                Messagetext.text = "祝福は万人に与えられなければならない。\n" +
                                    "戦士よ、汝が望むものを取り、その手中とするのだ。";
                                break;
                            case 2:
                                Messagetext.text = "力か？富か？栄光か？\n" +
                                    "我に忠誠を誓うのだ、さすれば全てが手に入るだろう。";
                                break;
                            case 3:
                                Messagetext.text = "勇敢なるものよ、汝の戦いと勇姿を\n" +
                                    "我は常に見守っているぞ。";
                                break;
                            case 4:
                                Messagetext.text = "汝にはまだ成長の余地がある。\n" +
                                    "私の下まで辿り着いてみるがいい。";
                                break;
                            case 5:
                                Messagetext.text = "アビス、エキソディウム、ファフニル……\n" +
                                    "あの者たちは息災であるか？";
                                break;
                            case 6:
                                Messagetext.text = "恐怖を克服せよ、壁を打ち破るのだ……\n" +
                                    "栄光を掴み取る権利は、皆平等にあるのだからな。";
                                break;
                            case 7:
                                Messagetext.text = "戦友が待っているぞ。\n" +
                                    "情けなどいらぬ、それが相手への敬意なのだ。";
                                break;
                            case 8:
                                Messagetext.text = "\n" +
                                    "";
                                break;
                            case 9:
                                Messagetext.text = "その武器、お前に似合ってるぞ？";
                                break;
                            case 10:
                                Messagetext.text = "始めようではないか！";
                                break;
                        }
                        break;
                    case 2:
                        switch (Judge)
                        {
                            case 0:
                                Messagetext.text = "A challenger? My name is Fafnir.\n" +
                                    "I shall grant you a blessing!";
                                break;
                            case 1:
                                Messagetext.text = "Let's kill 'em!";
                                break;
                            case 2:
                                Messagetext.text = "You call that a weapon?";
                                break;
                            case 3:
                                Messagetext.text = "Ares? He just doesn't get it...";
                                break;
                            case 4:
                                Messagetext.text = "Might! Violence! Unleash every form of slaughter!!";
                                break;
                            case 5:
                                Messagetext.text = "I'll kill even Ares!";
                                break;
                            case 6:
                                Messagetext.text = "Not enough murderous intent!";
                                break;
                            case 7:
                                Messagetext.text = "Where are they?";
                                break;
                            case 8:
                                Messagetext.text = "Take up arms?kill!";
                                break;
                            case 9:
                                Messagetext.text = "That weapon suits you.";
                                break;
                            case 10:
                                Messagetext.text = "Let us begin!";
                                break;
                        }
                        break;
                }
                break;
        }
        for (int i = 0; i < 3; i++)
        {
            BlessJudge[i] = AppearBless [Random.Range(0, AppearBless.Length)];
        }
        for(;BlessJudge[0] == BlessJudge[1];)
        {
            BlessJudge[1] = AppearBless[Random.Range(0, AppearBless.Length)];
        }
        for (; BlessJudge[0] == BlessJudge[2] || BlessJudge[1] == BlessJudge[2];)
        {
            BlessJudge[2] = AppearBless[Random.Range(0, AppearBless.Length)];
        }
        for (int i = 0; i < 3; i++)
        {
            Blessanim[i].Play($"Bless{BlessJudge[i]}");
            switch (BlessJudge[i])
            {
                case 1:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "守護者";
                            DescriptionText[i].text = "最大HPが15%増加する。";
                            break;
                        case 2:
                            NameText[i].text = "Guardian";
                            DescriptionText[i].text = "Maximum HP increases by 15%.";
                            break;
                    }
                    break;
                case 2:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "皮膚硬化";
                            DescriptionText[i].text = "戦闘開始時、最大HPの30%にあたるシールドを得る。";
                            break;
                        case 2:
                            NameText[i].text = "Skin Hardening";
                            DescriptionText[i].text = "At the start of battle, gain a shield equal to 30% of maximum HP.";
                            break;
                    }
                    break;
                case 3:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "超回復体";
                            DescriptionText[i].text = "HPを回復するたび、回復量の10%にあたる最大HP増加を得る。";
                            break;
                        case 2:
                            NameText[i].text = "Super Recovering";
                            DescriptionText[i].text = "Each time recover HP, gain a maximum HP increase equal to 10% of the amount recovered.";
                            break;
                    }
                    break;
                case 4:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "頑強なる肉体";
                            DescriptionText[i].text = "戦闘終了時、最大HPの12%を回復する。";
                            break;
                        case 2:
                            NameText[i].text = "Robust Body";
                            DescriptionText[i].text = "At the end of battle, restore 12% of your maximum HP.";
                            break;
                    }
                    break;
                case 5:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "深淵の石";
                            DescriptionText[i].text = "サファイアをセレスタイトと置き換える。";
                            break;
                        case 2:
                            NameText[i].text = "Abyssal Stone";
                            DescriptionText[i].text = "Replace Sapphire with Celestite";
                            break;
                    }
                    break;
                case 6:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "第六指";
                            DescriptionText[i].text = "ターン開始時、ハンド数+1。";
                            break;
                        case 2:
                            NameText[i].text = "Sixth finger";
                            DescriptionText[i].text = "At the start of your turn, gain 1 hand.";
                            break;
                    }
                    break;
                case 7:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "小さな宝石箱";
                            DescriptionText[i].text = "エメラルドをペリドットと置き換える。";
                            break;
                        case 2:
                            NameText[i].text = "Small Jewelry box";
                            DescriptionText[i].text = "Replace Emerald with Peridot.";
                            break;
                    }
                    break;
                case 8:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "研磨";
                            DescriptionText[i].text = "全てのスターター宝石の効果が1増加する。";
                            break;
                        case 2:
                            NameText[i].text = "Polishing";
                            DescriptionText[i].text = "The effect of all starter gems increases by 1.";
                            break;
                    }
                    break;
                case 9:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "恍惚";
                            DescriptionText[i].text = "3回目までの戦闘終了時、HPを18%回復する。";
                            break;
                        case 2:
                            NameText[i].text = "Ecstasy";
                            DescriptionText[i].text = "After the first 3 battles, recover 18% of your HP.";
                            break;
                    }
                    break;
                case 10:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "第三の眼";
                            DescriptionText[i].text = "ハンドする毎にHPを2回復する。";
                            break;
                        case 2:
                            NameText[i].text = "Third Eye";
                            DescriptionText[i].text = "Restores 2 HP each time handed.";
                            break;
                    }
                    break;
                case 11:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "啓示";
                            DescriptionText[i].text = "毎回ショップのランダムな商品1つに割引が発生する。";
                            break;
                        case 2:
                            NameText[i].text = "Revelation";
                            DescriptionText[i].text = "A discount is applied to 1 random item in the shop each time.";
                            break;
                    }
                    break;
                case 12:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "富豪";
                            DescriptionText[i].text = "メダルを2枚獲得する。";
                            break;
                        case 2:
                            NameText[i].text = "Rich";
                            DescriptionText[i].text = "Gain 2 Medals.";
                            break;
                    }
                    break;
                case 13:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "肉体制御";
                            DescriptionText[i].text = "HPが40%以下の状態で戦闘を終了した時、HPを40%まで回復する。";
                            break;
                        case 2:
                            NameText[i].text = "Body control";
                            DescriptionText[i].text = "When a battle ends with HP at 40% or less, HP is restored to 40%.";
                            break;
                    }
                    break;
                case 14:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "狂戦士";
                            DescriptionText[i].text = "最大HPが30%増加する。HPを50%失う。";
                            break;
                        case 2:
                            NameText[i].text = "Berserker";
                            DescriptionText[i].text = "Maximum HP increases by 30%. Lose 50% of HP.";
                            break;
                    }
                    break;
                case 15:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "暴虐の赤石";
                            DescriptionText[i].text = "ルビーをガーネットと置き換える。";
                            break;
                        case 2:
                            NameText[i].text = "Redstone of Tyranny";
                            DescriptionText[i].text = "Replace Ruby with Garnet.";
                            break;
                    }
                    break;
                case 16:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "怪力";
                            DescriptionText[i].text = "敵にダメージを与えた時、その値が1増加する。";
                            break;
                        case 2:
                            NameText[i].text = "Superhuman Strength";
                            DescriptionText[i].text = "When dealing damage to an enemy, that value increases by 1.";
                            break;
                    }
                    break;
                case 17:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "破砕";
                            DescriptionText[i].text = "シールドを持つ敵に与えるダメージが2倍になる。";
                            break;
                        case 2:
                            NameText[i].text = "Crushing";
                            DescriptionText[i].text = "Damage dealt to shielded enemies is doubled.";
                            break;
                    }
                    break;
                case 18:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "復讐の炎";
                            DescriptionText[i].text = "リベンジに必要なダメージが15%減少する。";
                            break;
                        case 2:
                            NameText[i].text = "Flames of Revenge";
                            DescriptionText[i].text = "The damage required for Revenge is reduced by 15%.";
                            break;
                    }
                    break;
                case 19:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "深淵の声";
                            DescriptionText[i].text = $"休憩する毎に最大HPが50増加する。";
                            break;
                        case 2:
                            NameText[i].text = "Voice of the Abyss";
                            DescriptionText[i].text = $"Maximum HP increases by 50 each time you rest.";
                            break;
                    }
                    break;
                case 20:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "不死";
                            DescriptionText[i].text = $"HPが0になると、一度のみHP20%で復活する。";
                            break;
                        case 2:
                            NameText[i].text = "Undead";
                            DescriptionText[i].text = $"When HP reaches 0, you revive once with HP equal to 20%.";
                            break;
                    }
                    break;
                case 21:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "巧妙";
                            DescriptionText[i].text = $"各戦闘で最初にスキルを使用したとき、その効果は2倍になる。";
                            break;
                        case 2:
                            NameText[i].text = "Ingenious";
                            DescriptionText[i].text = $"When a skill is used for the first time in each battle, its effect is multiplied by 2.";
                            break;
                    }
                    break;
                case 22:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "血塗れの契約";
                            DescriptionText[i].text = $"戦闘開始時、リベンジを30%チャージする。";
                            break;
                        case 2:
                            NameText[i].text = "Bloody contract";
                            DescriptionText[i].text = $"At the start of battle, charge Revenge by 30%.";
                            break;
                    }
                    break;
                case 23:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "交渉術";
                            DescriptionText[i].text = $"ショップに追加で1つの宝石と祝福が並ぶ。";
                            break;
                        case 2:
                            NameText[i].text = "Negotiation Techniques";
                            DescriptionText[i].text = $"An additional 1 gems and blessings will appear in the shop.";
                            break;
                    }
                    break;
                case 24:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "転禍";
                            DescriptionText[i].text = $"ショップの内容を2回までリロール出来るようになる。";
                            break;
                        case 2:
                            NameText[i].text = "Turning Misfortune";
                            DescriptionText[i].text = $"The shop contents can be rerolled up to 2 times.";
                            break;
                    }
                    break;
                case 65:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "アビスの恩寵";
                            DescriptionText[i].text = $"最初に受ける200以上のダメージを無効化する。";
                            break;
                        case 2:
                            NameText[i].text = "Grace of the Abyss";
                            DescriptionText[i].text = $"Negates the first damage taken equal to or greater than 200.";
                            break;
                    }
                    break;
                case 66:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "漆黒の護符";
                            DescriptionText[i].text = $"2回目までの戦闘において、敵のHPが25%減少する。";
                            break;
                        case 2:
                            NameText[i].text = "Jet-black Amulet";
                            DescriptionText[i].text = $"In battles up to the 2 one, the enemy's HP is reduced by 25%.";
                            break;
                    }
                    break;
                case 67:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "ほろ酔い";
                            DescriptionText[i].text = $"最初のターンにおいて、ランダムな宝石1種類の出現確率が0%になる。";
                            break;
                        case 2:
                            NameText[i].text = "Tipsy";
                            DescriptionText[i].text = $"On the first turn, the appearance probability of 1 random type of gem becomes 0%.";
                            break;
                    }
                    break;
                case 68:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "賭博師";
                            DescriptionText[i].text = $"スキル使用時、10%の確率で再度スキルが使用可能になる。";
                            break;
                        case 2:
                            NameText[i].text = "Gambler";
                            DescriptionText[i].text = $"When using a skill, there is a 10% chance that the skill becomes available for use again.";
                            break;
                    }
                    break;
                case 69:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "虐殺者";
                            DescriptionText[i].text = $"与えるダメージが25%増加する。ダメージを受ける毎に効果が5%ずつ減少する。";
                            break;
                        case 2:
                            NameText[i].text = "Slaughterer";
                            DescriptionText[i].text = $"Damage dealt increases by 25%. The effect decreases by 5% each time damage is taken.";
                            break;
                    }
                    break;
                case 70:
                    switch (Language)
                    {
                        case 1:
                            NameText[i].text = "一触即発";
                            DescriptionText[i].text = $"ダメージを受けた次のターン、ハンド数+2。";
                            break;
                        case 2:
                            NameText[i].text = "Critical Situation";
                            DescriptionText[i].text = $"The turn after taking damage, Hand +2.";
                            break;
                    }
                    break;
            }
        }
        Iscript.SE.PlayOneShot(StarterSE1);
    }
    void Update()
    {
        if(IsChoose)
        {
            NextCG.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 2f;
            ChooseCG.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 2f;
            if(ChooseCG.GetComponent<CanvasGroup>().alpha == 0f)
            {
                ChooseCG.SetActive(false);
            }
        }
    }
    public void BlessChoose(int i)
    {
        if (!IsChoose)
        {
            Flash[i].SetActive(true);
            IsChoose = true;
            NextCG.SetActive(true);
            Iscript.BlessAdd(BlessJudge[i]);
        }
    }
    public void EnterArena()
    {
        Iscript.Fade = true;
        Iscript.SE.PlayOneShot(Iscript.OKSE);
        Invoke("E", 1f);
    }
    void E()
    {
        Iscript.BattleBGM.Play();
        Iscript.SilentBGM.Play();
        int Judge = Random.Range(0, BattleObj.Length);
        if (FirstContact == 0)
        {
            Judge = 0;
        }
        Iscript.EnemyPool[Judge] = 1;
        GameObject g = Instantiate(BattleObj[Judge]);
        g.transform.position = BattleObj[Judge].transform.position;
        g.SetActive(true);
        Destroy(this.gameObject);
    }
}
