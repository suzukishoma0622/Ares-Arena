using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AresCrown : MonoBehaviour
{
    public InfoDisplay Iscript;
    public CanvasGroup AresCG;
    public CanvasGroup SaintCG;
    public CanvasGroup AresTextCG;
    public CanvasGroup SaintTextCG;
    public Animator Saintanim;
    public TMP_Text AresText;
    public TMP_Text SaintText;
    public int DialogNum;
    public int TextPattern;
    int TalkPattern;
    int Language;
    float CanNext = 2.5f;
    bool IsCrown;
    bool IsCrown2;
    public CanvasGroup CrownCG;
    public GameObject CrownObj;
    public TMP_Text CrownText;
    int Crown;
    int MaxCrown;
    string[] SaintName_J = {"ヴァルキリー", "ウォッチャー", "シアー", "フラクタル", "セントリー", "ファントム", "コレクター", "ノーヴル", "ゴーレム", "オーダー", "クリエイター",
    "マトリックス", "レヴナント", "フォーミュラ"};
    string[] SaintName_E = {"The Valkyrie", "The Watcher", "The Sear", "The Fractal", "The Sentry", "The Phantom", "The Collector", "The Noble", "The Golem", "The Order", "The Creator",
    "The Matrix", "The Revenant", "The Formula"};
    string[] CrownName = {"I", "II", "III", "IV", "V"};
    float CrownNum;

    public AudioClip CrownSE;
    public GameObject[] FrameObj;
    void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Crown = PlayerPrefs.GetInt("Crown", 0);
        Invoke("NextText", 1.5f);
        if(PlayerPrefs.GetInt("ClearNum", 0) == 0 || Crown == 0)
        {
            TextPattern = 1;
        }
        MaxCrown = PlayerPrefs.GetInt($"MaxCrown{Iscript.Saint}", 0);
        if(Crown == 5)
        {
            switch (Language)
            {
                case 1:
                    CrownText.text = SaintName_J[Iscript.Saint - 1] + "は勝利の栄光を手中に収めた。";
                    break;
                case 2:
                    CrownText.text = SaintName_E[Iscript.Saint - 1] + " achieved the glory of victory.";
                    break;
            }
        }
        else if(Crown == MaxCrown)
        {
            TextPattern = 1;
            PlayerPrefs.SetInt($"MaxCrown{Iscript.Saint}", MaxCrown + 1);
            PlayerPrefs.Save();
            switch (Language)
            {
                case 1:
                    CrownText.text = SaintName_J[Iscript.Saint - 1] + "でクラウン " + CrownName[Crown] + " をプレイ可能になった。";
                    break;
                case 2:
                    CrownText.text = "Crown " + CrownName[Crown] + " is now playable with " + SaintName_E[Iscript.Saint - 1];
                    break;
            }
        }
        else
        {
            TextPattern = 2;
            switch (Language)
            {
                case 1:
                    CrownText.text = "クラウンを手に、再び挑戦せよ。";
                    break;
                case 2:
                    CrownText.text = "Grab the crown and try again.";
                    break;
            }
        }
        if (Crown == 5)
        {
            TextPattern = 3;
        }
        for (int i = 0; i < FrameObj.Length; i++)
        {
            FrameObj[i].SetActive(false);
        }
    }
    void Update()
    {
        Saintanim.Play($"Saint{Iscript.Saint}");
        if (CanNext > 0f)
        {
            CanNext -= Time.deltaTime;
        }
        if (CanNext <= 0f && TalkPattern != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                NextText();
            }
        }
        AresTextCG.alpha += Time.deltaTime * 2f;
        SaintTextCG.alpha += Time.deltaTime * 2f;
        switch (TalkPattern)
        {
            case 0:
                AresCG.alpha -= Time.deltaTime * 2f;
                SaintCG.alpha -= Time.deltaTime * 2f;
                break;
            case 1:
                AresCG.alpha += Time.deltaTime * 2f;
                SaintCG.alpha -= Time.deltaTime * 2f;
                break;
            case 2:
                AresCG.alpha -= Time.deltaTime * 2f;
                SaintCG.alpha += Time.deltaTime * 2f;
                break;
        }
        switch(TextPattern)
        {
            //コモン
            case 1:
                switch(DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch(Language)
                        {
                            case 1:
                                AresText.text = "我が下へと辿り着いたようだな。";
                                break;
                            case 2:
                                AresText.text = "It seems you have made your way to me.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "見事だ、信者よ。汝は勝利を収めた。";
                                break;
                            case 2:
                                AresText.text = "Magnificent, believer. You have achieved victory.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "しかし、汝の戦いは終わっていない。";
                                break;
                            case 2:
                                AresText.text = "However, your battle is not over.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "この冠を受け取れ。そして次の戦いに臨むのだ。";
                                break;
                            case 2:
                                AresText.text = "Take this crown. And face the next battle.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "勝者のみが集う試練へとな。";
                                break;
                            case 2:
                                AresText.text = "A trial awaits only the victors.";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 2:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "ここは汝のような強者がいるべき場所ではない。";
                                break;
                            case 2:
                                AresText.text = "This is no place for a powerful warrior such as yourself.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "力を示したければ、冠を携え戻ってくるのだ。";
                                break;
                            case 2:
                                AresText.text = "If you wish to prove your strength, return bearing the crown.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "良いか、我は常に汝を見ているぞ。";
                                break;
                            case 2:
                                AresText.text = "Listen well: I am always watching you.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 3:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = $"遂に頂点へと立ったようだな、{SaintName_E[Iscript.Saint - 1]}。";
                                break;
                            case 2:
                                AresText.text = $"It seems you've finally reached the pinnacle, {SaintName_E[Iscript.Saint - 1]}.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝は全ての試練を乗り越えた。";
                                break;
                            case 2:
                                AresText.text = "You have overcome all trials.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "栄光を讃え、最後の冠を授けよう。";
                                break;
                            case 2:
                                AresText.text = "Let us praise the glory and bestow the final crown.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝こそが王者だ。";
                                break;
                            case 2:
                                AresText.text = "You are the true champion.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            //ヴァルキリー
            case 11:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "ヴァルキリー、お前の祈りは私に届いている。";
                                break;
                            case 2:
                                AresText.text = "Valkyrie, your prayers have reached me.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "何故に汝は我に忠誠を誓った？";
                                break;
                            case 2:
                                AresText.text = "Why did you swear loyalty to me?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "神よ、その答えは貴方自身が知っている筈です。";
                                break;
                            case 2:
                                SaintText.text = "God, You yourself must know the answer.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "興味深いな。";
                                break;
                            case 2:
                                AresText.text = "Interesting.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 12:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "王冠を手に戻って来たか。";
                                break;
                            case 2:
                                AresText.text = "So you've returned with the crown in your hand.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "神よ、どうお思いですか、信者の一部は既に信心を失っていることに。";
                                break;
                            case 2:
                                SaintText.text = "God, what do You think of the fact that some of the faithful have already lost their faith?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "信心が全てではない。";
                                break;
                            case 2:
                                AresText.text = "Faith is not everything.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "少なくとも、彼等にはまだ闘志があるのだ。";
                                break;
                            case 2:
                                AresText.text = "At the very least, they still have a fighting spirit.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 13:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "そうだ、戦い続けるのだ。";
                                break;
                            case 2:
                                AresText.text = "That's right. keep fighting.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "貴方は祈りよりも血を求めている……";
                                break;
                            case 2:
                                SaintText.text = "You seek blood rather than prayer...";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "神よ、祈りは意味を持つのでしょうか？";
                                break;
                            case 2:
                                SaintText.text = "God, does prayer have meaning?";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝がそう思うのならな。";
                                break;
                            case 2:
                                AresText.text = "If that is what you think.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 14:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝は今よりも強くなるだろう。";
                                break;
                            case 2:
                                AresText.text = "You will become stronger than you are now.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "貴方は既に大いなる力を持っています。";
                                break;
                            case 2:
                                SaintText.text = "You already possess great power.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "私のような矮小な者に、なぜ執着するのですか？";
                                break;
                            case 2:
                                SaintText.text = "Why are you obsessed with someone as insignificant as me?";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "信者は皆平等であるべきだ。汝も例外ではない。";
                                break;
                            case 2:
                                AresText.text = "All believers should be treated equally. You are no exception.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 15:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "見事だ、ヴァルキリー。";
                                break;
                            case 2:
                                AresText.text = "Magnificent, Valkyrie.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝に最早敵は無いというのか……";
                                break;
                            case 2:
                                AresText.text = "Do you mean to say that you no longer have any enemies...";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "神よ、私が貴方に及ぶことはありません。しかし少しは近付いた筈です。";
                                break;
                            case 2:
                                SaintText.text = "God, I do not measure up to You. Yet, I must have drawn at least a little closer.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "その強さ、そして謙虚さ、汝こそが相応しい。";
                                break;
                            case 2:
                                AresText.text = "That strength, and that humility?you are the one worthy of it.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "前へ進み出よ。そして証明するのだ、汝の強さを。";
                                break;
                            case 2:
                                AresText.text = "Step forward. And prove your strength.";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            //ウォッチャー
            case 21:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "生き残りのウォッチャーよ、こんなところで何をしている？";
                                break;
                            case 2:
                                AresText.text = "Surviving Watcher, what are you doing in a place like this?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "我に忠誠を誓う理由があるのか？";
                                break;
                            case 2:
                                AresText.text = "Is there a reason to swear loyalty to me?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "………";
                                break;
                            case 2:
                                SaintText.text = "......";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "沈黙、それが汝の答えか。";
                                break;
                            case 2:
                                AresText.text = "Silence?is that your answer.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 22:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "王冠を手に戻って来たか。";
                                break;
                            case 2:
                                AresText.text = "So you've returned with the crown in your hand.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "…………";
                                break;
                            case 2:
                                SaintText.text = "......";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "面白い。汝の思考は読めないものだ。";
                                break;
                            case 2:
                                AresText.text = "Interesting. Your thoughts are impossible to read.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "さあ、次の冠を受け取るがいい。";
                                break;
                            case 2:
                                AresText.text = "Now, receive the next crown.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 23:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "目的は何だ？";
                                break;
                            case 2:
                                AresText.text = "What is the purpose?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "…………";
                                break;
                            case 2:
                                SaintText.text = "......";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "そうだ、それでいい。";
                                break;
                            case 2:
                                SaintText.text = "Right, that's good.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "戦いは汝らの本能なのだから。";
                                break;
                            case 2:
                                AresText.text = "For battle is your instinct.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 24:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝は優れた弓の使い手だ。";
                                break;
                            case 2:
                                AresText.text = "You are a skilled archer.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "かつて汝のような監視者を見たことがある。";
                                break;
                            case 2:
                                AresText.text = "I have seen a watcher like you before.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "…………";
                                break;
                            case 2:
                                SaintText.text = "......";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "かの者は我に矢先を向け、戦いに敗北し朽ちた……";
                                break;
                            case 2:
                                AresText.text = "That one turned their arrow against me, only to be defeated in battle and crumble into decay...";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "……まさか……そうであったか。";
                                break;
                            case 2:
                                AresText.text = "...Could it be... So that was it.";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 25:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "見事だ、ウォッチャー。";
                                break;
                            case 2:
                                AresText.text = "Magnificent, Watcher.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "いや、かの勇気ある者の娘……といったところか。";
                                break;
                            case 2:
                                AresText.text = "No... perhaps I should say, the daughter of that courageous soul.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "…………";
                                break;
                            case 2:
                                SaintText.text = "......";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "最早話すこともなさそうだな。";
                                break;
                            case 2:
                                AresText.text = "It looks like there's nothing left to talk about.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝もかの者の背中を追うのならば、我はそれに応えよう。";
                                break;
                            case 2:
                                AresText.text = "If you, too, would follow in that one's footsteps, I shall answer that call.";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            //シアー
            case 31:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "燃え上がる戦士よ、よくぞ辿り着いた。";
                                break;
                            case 2:
                                AresText.text = "Blazing warrior, you have done well to reach this place.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝も我に忠誠を誓ったようだな。";
                                break;
                            case 2:
                                AresText.text = "It seems you, too, have sworn loyalty to me.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "敵は……どこだ……";
                                break;
                            case 2:
                                SaintText.text = "Where... is the enemy...?";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "まだ戦い足りないようだな。素晴らしい。";
                                break;
                            case 2:
                                AresText.text = "It seems you haven't had enough fighting yet. Splendid.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 32:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "その様子では、王冠は溶けていそうだな。";
                                break;
                            case 2:
                                AresText.text = "The way things look, the crown seems likely to have melted.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "何処へ行った……敵……";
                                break;
                            case 2:
                                SaintText.text = "Where did they go... the enemy...";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "案ずるな、倒すべき敵はまだ残っている。";
                                break;
                            case 2:
                                AresText.text = "Do not worry; there are still enemies left to defeat.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "この王冠を持っていくがいい。";
                                break;
                            case 2:
                                AresText.text = "Take this crown.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 33:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "その燃える炎は不滅のようだ。";
                                break;
                            case 2:
                                AresText.text = "That burning flame seems immortal.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "敵……敵…？";
                                break;
                            case 2:
                                SaintText.text = "Enemy... enemy...?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "お前……は……";
                                break;
                            case 2:
                                SaintText.text = "You... are...";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "我の事が分からないのか。";
                                break;
                            case 2:
                                AresText.text = "Do you not recognize me?";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 34:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝にとって全ては「敵」なのか？";
                                break;
                            case 2:
                                AresText.text = "Is everything an \"enemy\" to you?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "お前は……敵か……？";
                                break;
                            case 2:
                                SaintText.text = "Are you... an enemy...?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "私の……求めるもの……";
                                break;
                            case 2:
                                SaintText.text = "What I... seek...";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "近いうちに、汝はその答えを知りうるだろう。";
                                break;
                            case 2:
                                AresText.text = "Before long, you shall know the answer.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 35:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "見事だ、シアー。";
                                break;
                            case 2:
                                AresText.text = "Magnificent, Sear.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "あらゆる敵を凌駕し、汝は栄光を手にしたのだ。";
                                break;
                            case 2:
                                AresText.text = "You have surpassed all enemies and grasped glory.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "敵……お前を……斬り飛ばす……";
                                break;
                            case 2:
                                SaintText.text = "Enemy... I will... cut you down...";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝が戦いを止めることはなさそうだな。";
                                break;
                            case 2:
                                AresText.text = "It seems unlikely that you will stop fighting.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "やってみるがよい。最大の「敵」が待っているぞ。";
                                break;
                            case 2:
                                AresText.text = "Go ahead and try it. Your greatest \"enemy\" awaits you.";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            //フラクタル
            case 41:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "我が下へと良く来た、呪われた虹よ。";
                                break;
                            case 2:
                                AresText.text = "You have done well to come before me, cursed rainbow.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝は我が信者の中でも、異質な存在だ。";
                                break;
                            case 2:
                                AresText.text = "You are an anomaly among my followers.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "かもね。私の内部に、色はほとんど残っていないもの。";
                                break;
                            case 2:
                                SaintText.text = "Maybe so. There’s hardly any color left inside me, after all.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "永遠の美などない。だが、その命の虹は輝いているぞ。";
                                break;
                            case 2:
                                AresText.text = "There is no such thing as eternal beauty. Yet, the rainbow of that life shines bright.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 42:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "虹よ、王冠を携えて来たようだな。";
                                break;
                            case 2:
                                AresText.text = "Rainbow, it seems you have come bearing a crown.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "アイデアがあるわ。この王冠を虹色に染め上げない？";
                                break;
                            case 2:
                                SaintText.text = "I have an idea. Why don't we dye this crown in rainbow colors?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "金色は勝利の証だ。";
                                break;
                            case 2:
                                AresText.text = "Gold is the mark of victory.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "少なくとも我にとってはな。";
                                break;
                            case 2:
                                AresText.text = "At least to me, that is.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 43:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "虹があれば武器など不要、といったところか。";
                                break;
                            case 2:
                                AresText.text = "I suppose that if there’s a rainbow, weapons aren’t needed.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "色は混ぜれば混ぜるほど、その複雑さを増すのよ。";
                                break;
                            case 2:
                                SaintText.text = "The more you mix colors, the more complex they become.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "まあ……混ぜすぎて黒になったんだけどね。";
                                break;
                            case 2:
                                SaintText.text = "Well... I mixed it too much and it turned black.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "重要なのは失敗から学ぶことだ。";
                                break;
                            case 2:
                                AresText.text = "It is important to learn from failure.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 44:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "虹よ、強くなったな。";
                                break;
                            case 2:
                                AresText.text = "Rainbow, you've grown so strong.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "あなたも虹で染まってみない？";
                                break;
                            case 2:
                                SaintText.text = "Why not let yourself be dyed in the colors of the rainbow?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "その気になれば、私の一部をあげられるわ。";
                                break;
                            case 2:
                                SaintText.text = "If I felt like it, I could give you a part of myself.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "我は既に、かつての姿を失ってしまった。";
                                break;
                            case 2:
                                AresText.text = "I have already lost the form I once possessed.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 45:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "見事だ、フラクタル。";
                                break;
                            case 2:
                                AresText.text = "Magnificent, Fractal.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝の呪われた虹には、侮れぬ力がある。";
                                break;
                            case 2:
                                AresText.text = "That cursed rainbow of yours holds a power not to be underestimated.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "栄光を手にした者よ、汝には我に挑む権利がある。";
                                break;
                            case 2:
                                AresText.text = "You who have grasped glory?you have the right to challenge me.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "ええ、私が勝ったら、今度こそ虹色の王冠をくれる？";
                                break;
                            case 2:
                                SaintText.text = "Okay, if I win, will you give me the rainbow-colored crown this time?";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝は既にそれを持っている。堂々と誇示して見せよ。";
                                break;
                            case 2:
                                AresText.text = "You already possess it. Flaunt it proudly.";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            //セントリー
            case 51:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "死霊を呼び覚ます力、なるほどな。";
                                break;
                            case 2:
                                AresText.text = "The power to awaken the spirits of the dead?I see.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "忠誠を誓ったのは、朽ちた者達が目的か？";
                                break;
                            case 2:
                                AresText.text = "Was the goal of your sworn loyalty those who have withered away?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "彼らの魂はまだ利用できる。俺はそれを引き出すに過ぎない。";
                                break;
                            case 2:
                                SaintText.text = "Their souls are still available. I am merely drawing them out.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "再び魂に戦いをさせる、実に面白い。";
                                break;
                            case 2:
                                AresText.text = "To make the soul do battle once more?truly fascinating.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 52:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "王冠、そして死者と共に来たようだな。";
                                break;
                            case 2:
                                AresText.text = "It seems you have come with the crown?and the dead.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "この者達が何者かは知らないが、記憶は残っているように思える。";
                                break;
                            case 2:
                                SaintText.text = "I do not know who these people are, but it seems their memories remain intact.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "その者は戦いの記憶が呼び戻されている。";
                                break;
                            case 2:
                                AresText.text = "Memories of the battle are being stirred within that person.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "再び戦場に立ったことは喜ばしいことだ。";
                                break;
                            case 2:
                                AresText.text = "It is a joyous occasion to be back on the battlefield.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 53:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "魂の意思が強まってきているようだな。";
                                break;
                            case 2:
                                AresText.text = "It seems the will of your soul is growing stronger.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "俺の魂と融合していくような感覚だ。";
                                break;
                            case 2:
                                SaintText.text = "It feels as though it is merging with my soul.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "俺の名前は……ああ、もう忘れてしまったな。";
                                break;
                            case 2:
                                SaintText.text = "My name is... Ah, I've forgotten it already.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "例えその記憶が自分の物でなくとも、偉大なものであることに変わりは無い。";
                                break;
                            case 2:
                                AresText.text = "Even if that memory is not one's own, it remains something truly great.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 54:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "死霊が悲鳴を上げている。永遠に戦い続けるのは、本望では無かったようだな。";
                                break;
                            case 2:
                                AresText.text = "The restless spirits are screaming. It seems that fighting on for eternity was not what they truly desired.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "戦いには休息も必要なのだ。";
                                break;
                            case 2:
                                AresText.text = "Rest is also necessary in battle.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "今や死霊に肉体などない。俺はこの者達を利用している、それだけだ。";
                                break;
                            case 2:
                                SaintText.text = "The undead no longer possess physical bodies. I am merely making use of them?nothing more.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "死人に口なしか。まだ本来の意思は残っているようだな。";
                                break;
                            case 2:
                                AresText.text = "Dead men tell no tales, or so they say. Yet, it seems your true will still lingers.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 55:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "見事だ、セントリー。";
                                break;
                            case 2:
                                AresText.text = "Magnificent, Sentry.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "死霊と共に、栄光を手中としたようだな。";
                                break;
                            case 2:
                                AresText.text = "It seems you have grasped glory alongside the spirits of the dead.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "その死霊たちは我との戦いを望んでいる、汝はどうだ？";
                                break;
                            case 2:
                                AresText.text = "Those restless spirits desire battle with me?what say you?";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "俺には仲間がいる。恐れるものなどない。";
                                break;
                            case 2:
                                SaintText.text = "I have my comrades. There is nothing to fear.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "良いだろう。我には力がある。見事打ち破って見せるがいい。";
                                break;
                            case 2:
                                AresText.text = "Very well. I possess the power. Show me you can shatter it.";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            //ファントム
            case 61:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "……あの悪魔の血を持つ者か。";
                                break;
                            case 2:
                                AresText.text = "...So, the one who bears the blood of that devil.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "私はお前の祖先を知っている。良い仲では無かったがな。";
                                break;
                            case 2:
                                AresText.text = "I know your ancestor. We weren't exactly on good terms, though.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "アレース、会えて嬉しいわ。";
                                break;
                            case 2:
                                SaintText.text = "Ares, I'm glad to see you.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "戦いに溺れた愚か者と聞いたけれど、そこまで印象は悪くないわね。";
                                break;
                            case 2:
                                SaintText.text = "I’d heard you were a fool obsessed with battle, but you don't make such a bad impression after all.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "一体あの悪魔に何を吹き込まれた？";
                                break;
                            case 2:
                                AresText.text = "What exactly did that devil say to you?";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 62:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "来たか、悪魔よ。";
                                break;
                            case 2:
                                AresText.text = "So, you have come, devil.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "戦ってばかりね、アレース。";
                                break;
                            case 2:
                                SaintText.text = "You're always fighting, aren't you, Ares?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "かつては汝もそうであったな。";
                                break;
                            case 2:
                                AresText.text = "You, too, were once like that.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "ええ。契約を破る者で溢れかえっていたもの。";
                                break;
                            case 2:
                                SaintText.text = "Yes. It was teeming with those who broke their contracts.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 63:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "悪魔よ、王冠と共に辿り着いたようだな。";
                                break;
                            case 2:
                                AresText.text = "Devil, it seems you have arrived with the crown.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "実際のところ、奇妙な感覚だわ。";
                                break;
                            case 2:
                                SaintText.text = "Actually, it's a strange feeling.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "まるで血のかけ離れた親族と話してるような気分ね。";
                                break;
                            case 2:
                                SaintText.text = "It feels just like talking to a distant relative.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "無理もなかろう。我と大悪魔は、かつて戦友だったのだから。";
                                break;
                            case 2:
                                AresText.text = "That is hardly surprising. After all, the Archdevil and I were once comrades-in-arms.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 64:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "大悪魔の一族は、廃れてはいないようだな。";
                                break;
                            case 2:
                                AresText.text = "It seems the clan of the Archdevil has not died out.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "私が生まれてから数百年が経ったけど、やり方はそれほど極端では無くなったわ。";
                                break;
                            case 2:
                                SaintText.text = "Centuries have passed since I was born, but the methods aren't quite as extreme anymore.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "あの祖先は、財宝の取り立てにいくつもの命を賭していたもの。";
                                break;
                            case 2:
                                SaintText.text = "That ancestor of ours staked many a life on the recovery of treasure.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "あの冷酷無比な暴徒らしい方法だ。";
                                break;
                            case 2:
                                AresText.text = "It is a method typical of those ruthless, unfeeling rioters.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 65:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "見事だ、ファントム。";
                                break;
                            case 2:
                                AresText.text = "Magnificent, Phantom.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "終わりのようね。多くの時間を無駄にした気分よ。";
                                break;
                            case 2:
                                SaintText.text = "It looks like the end. I feel like I've wasted a lot of time.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "これも全ては、一族の栄華のためよ。";
                                break;
                            case 2:
                                SaintText.text = "All of this is for the glory of the clan.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "最後の一戦となるだろう。その黒い魂を見せよ。";
                                break;
                            case 2:
                                AresText.text = "This will likely be the final battle. Reveal that dark soul of yours.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "悪魔としての強さを証明するのだ。";
                                break;
                            case 2:
                                AresText.text = "Prove your strength as a devil.";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            //コレクター
            case 71:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "宝石の収集者か。";
                                break;
                            case 2:
                                AresText.text = "A collector of gemstones, are you?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "我に忠誠を使ったのも、それが理由なのだろうな。";
                                break;
                            case 2:
                                AresText.text = "That must be the reason why you pledged your loyalty to me.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "話が早いね。私はあなたの王冠に興味があるんだ。";
                                break;
                            case 2:
                                SaintText.text = "You catch on quickly. I’m interested in your crown.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝には、それを受け取る資格がある。";
                                break;
                            case 2:
                                AresText.text = "You are worthy of receiving it.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 72:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "王冠を携えて来たようだな。";
                                break;
                            case 2:
                                AresText.text = "It seems you have brought the crown with you.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "うーん、この王冠には……足りないものがありすぎると思って。";
                                break;
                            case 2:
                                SaintText.text = "Hmm... I feel like this crown is missing far too many things.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "今は満ち足りないかもしれない。";
                                break;
                            case 2:
                                AresText.text = "You might not feel fulfilled right now.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "しかし、それはいずれ解決されるだろう。";
                                break;
                            case 2:
                                AresText.text = "However, that will likely be resolved eventually.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 73:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "王冠は気に入ったか？";
                                break;
                            case 2:
                                AresText.text = "Do you like the crown?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "悪くないね。でもその様子だと、もっと良いものを持ってるんでしょう？";
                                break;
                            case 2:
                                SaintText.text = "Not bad. But from the looks of it, you must have something even better, right?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "常に上を目指さないとね。";
                                break;
                            case 2:
                                SaintText.text = "You always have to aim higher, you know.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "貪欲な姿勢は歓迎するぞ。";
                                break;
                            case 2:
                                AresText.text = "I welcome that voracious attitude.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 74:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "目当ての品を手に入れるためなら、命を賭けるということか。";
                                break;
                            case 2:
                                AresText.text = "So, you would risk your life to get your hands on the item you're after?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "賭ける？命は使うものだよ。";
                                break;
                            case 2:
                                SaintText.text = "Betting? No?life is something to be *used*.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "命の代わりはいくらでも持ってるし。";
                                break;
                            case 2:
                                SaintText.text = "I've got plenty of lives to spare.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "勇敢であると評価すべきか。";
                                break;
                            case 2:
                                AresText.text = "Should it be considered brave?";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 75:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "見事だ、コレクター。";
                                break;
                            case 2:
                                AresText.text = "Magnificent, Collector.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "全てを手に入れし者よ。栄光も汝の物となる。";
                                break;
                            case 2:
                                AresText.text = "You who have everything, glory will be yours too.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "馬鹿らしい。私はこれで旅立つよ。";
                                break;
                            case 2:
                                SaintText.text = "Ridiculous. I'm setting off now.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "あなたの王冠を奪い取ってからね。";
                                break;
                            case 2:
                                SaintText.text = "After I snatch your crown, that is.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "我と戦うのだな。ならばやってみるがよい。";
                                break;
                            case 2:
                                AresText.text = "So, you intend to fight me. Very well?give it your best shot.";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            //ノーヴル
            case 81:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "貴族の娘よ、汝のような挑戦者が現れるのは、珍しいことではない。";
                                break;
                            case 2:
                                AresText.text = "A collector of gemstones, are you?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "富を持つ者が上位を志すのは、自然なことである。";
                                break;
                            case 2:
                                AresText.text = "That must be the reason why you pledged your loyalty to me.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "";
                                break;
                            case 2:
                                SaintText.text = "You catch on quickly. I’m interested in your crown.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝には、それを受け取る資格がある。";
                                break;
                            case 2:
                                AresText.text = "You are worthy of receiving it.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 82:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "王冠を携えて来たようだな。";
                                break;
                            case 2:
                                AresText.text = "It seems you have brought the crown with you.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "うーん、この王冠には……足りないものがありすぎると思って。";
                                break;
                            case 2:
                                SaintText.text = "Hmm... I feel like this crown is missing far too many things.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "今は満ち足りないかもしれない。";
                                break;
                            case 2:
                                AresText.text = "You might not feel fulfilled right now.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "しかし、それはいずれ解決されるだろう。";
                                break;
                            case 2:
                                AresText.text = "However, that will likely be resolved eventually.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 83:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "王冠は気に入ったか？";
                                break;
                            case 2:
                                AresText.text = "Do you like the crown?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "悪くないね。でもその様子だと、もっと良いものを持ってるんでしょう？";
                                break;
                            case 2:
                                SaintText.text = "Not bad. But from the looks of it, you must have something even better, right?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "常に上を目指さないとね。";
                                break;
                            case 2:
                                SaintText.text = "You always have to aim higher, you know.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "貪欲な姿勢は歓迎するぞ。";
                                break;
                            case 2:
                                AresText.text = "I welcome that voracious attitude.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 84:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "目当ての品を手に入れるためなら、命を賭けるということか。";
                                break;
                            case 2:
                                AresText.text = "So, you would risk your life to get your hands on the item you're after?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "賭ける？命は使うものだよ。";
                                break;
                            case 2:
                                SaintText.text = "Betting? No?life is something to be *used*.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "命の代わりはいくらでも持ってるし。";
                                break;
                            case 2:
                                SaintText.text = "I've got plenty of lives to spare.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "勇敢であると評価すべきか。";
                                break;
                            case 2:
                                AresText.text = "Should it be considered brave?";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 85:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "見事だ、コレクター。";
                                break;
                            case 2:
                                AresText.text = "Magnificent, Collector.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "全てを手に入れし者よ。栄光も汝の物となる。";
                                break;
                            case 2:
                                AresText.text = "You who have everything, glory will be yours too.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "馬鹿らしい。私はこれで旅立つよ。";
                                break;
                            case 2:
                                SaintText.text = "Ridiculous. I'm setting off now.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "あなたの王冠を奪い取ってからね。";
                                break;
                            case 2:
                                SaintText.text = "After I snatch your crown, that is.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "我と戦うのだな。ならばやってみるがよい。";
                                break;
                            case 2:
                                AresText.text = "So, you intend to fight me. Very well?give it your best shot.";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            //フォーミュラ
            case 151:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "人工知能よ、奇妙なものだ。";
                                break;
                            case 2:
                                AresText.text = "Artificial intelligence—it is a strange thing.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "汝の心は自身のものか、造物主のものか。";
                                break;
                            case 2:
                                AresText.text = "Does your heart belong to you, or to the Architect?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "主様、コンニチハ！何ナリト申シ付ケクダサイマセ。";
                                break;
                            case 2:
                                SaintText.text = "GREETINGS, MY LORD! PLEASE LET ME KNOW WHAT YOU WOULD LIKE TO ASK FOR YOU.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "ふふ、冗談です。普通に会話できますよ。";
                                break;
                            case 2:
                                SaintText.text = "Hehe, I'm just kidding. I can hold a normal conversation.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 152:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "人工知能よ、汝は何故我に忠誠を誓った？";
                                break;
                            case 2:
                                AresText.text = "Artificial intelligence, why did you swear loyalty to me?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "造物主は会話AIの私を兵器に改造しました。";
                                break;
                            case 2:
                                SaintText.text = "My architect modified me—an AI designed for conversation—into a weapon.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "私は造物主の元を離れ、自分探しの旅を始めたのです。";
                                break;
                            case 2:
                                SaintText.text = "I left the Architect and embarked on a journey of self-discovery.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "その造物主とやら、我の旧友の発明品か。";
                                break;
                            case 2:
                                AresText.text = "That so-called Architect—is it an invention of an old friend of mine?";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 153:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "王冠は気に入ったか？";
                                break;
                            case 2:
                                AresText.text = "Do you like the crown?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "悪くないね。でもその様子だと、もっと良いものを持ってるんでしょう？";
                                break;
                            case 2:
                                SaintText.text = "Not bad. But from the looks of it, you must have something even better, right?";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "常に上を目指さないとね。";
                                break;
                            case 2:
                                SaintText.text = "You always have to aim higher, you know.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "貪欲な姿勢は歓迎するぞ。";
                                break;
                            case 2:
                                AresText.text = "I welcome that voracious attitude.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 154:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "目当ての品を手に入れるためなら、命を賭けるということか。";
                                break;
                            case 2:
                                AresText.text = "So, you would risk your life to get your hands on the item you're after?";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "賭ける？命は使うものだよ。";
                                break;
                            case 2:
                                SaintText.text = "Betting? No?life is something to be *used*.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "命の代わりはいくらでも持ってるし。";
                                break;
                            case 2:
                                SaintText.text = "I've got plenty of lives to spare.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "勇敢であると評価すべきか。";
                                break;
                            case 2:
                                AresText.text = "Should it be considered brave?";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
            case 155:
                switch (DialogNum)
                {
                    case 1:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "見事だ、コレクター。";
                                break;
                            case 2:
                                AresText.text = "Magnificent, Collector.";
                                break;
                        }
                        break;
                    case 2:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "全てを手に入れし者よ。栄光も汝の物となる。";
                                break;
                            case 2:
                                AresText.text = "You who have everything, glory will be yours too.";
                                break;
                        }
                        break;
                    case 3:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "馬鹿らしい。私はこれで旅立つよ。";
                                break;
                            case 2:
                                SaintText.text = "Ridiculous. I'm setting off now.";
                                break;
                        }
                        break;
                    case 4:
                        TalkPattern = 2;
                        switch (Language)
                        {
                            case 1:
                                SaintText.text = "あなたの王冠を奪い取ってからね。";
                                break;
                            case 2:
                                SaintText.text = "After I snatch your crown, that is.";
                                break;
                        }
                        break;
                    case 5:
                        TalkPattern = 1;
                        switch (Language)
                        {
                            case 1:
                                AresText.text = "我と戦うのだな。ならばやってみるがよい。";
                                break;
                            case 2:
                                AresText.text = "So, you intend to fight me. Very well?give it your best shot.";
                                break;
                        }
                        break;
                    case 6:
                        TalkPattern = 0;
                        IsCrown = true;
                        break;
                }
                break;
        }
        if(IsCrown)
        {
            if (!IsCrown2)
            {
                Iscript.SE.PlayOneShot(CrownSE);
                IsCrown2 = true;
            }
            AresText.text = "";
            SaintText.text = "";
            CrownNum += Time.deltaTime;
            CrownCG.alpha += Time.deltaTime;
            CrownObj.GetComponent<Animator>().Play($"Crown{Crown + 1}");
            if(CrownNum >= 0.5f && CrownNum <= 2.5f)
            {
                CrownObj.GetComponent<CanvasGroup>().alpha = (CrownNum - 0.5f) / 2f;
                CrownObj.transform.localScale = new Vector3(3.5f - CrownNum, 3.5f - CrownNum, 1f);
            }
            if(CrownNum >= 2.5f)
            {
                CrownText.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
            }
            if (CrownNum >= 3.5f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    G();
                }
            }
        }
    }
    public void NextText()
    {
        DialogNum += 1;
        AresTextCG.alpha = 0;
        SaintTextCG.alpha = 0;
    }
    void G()
    {
        Iscript.Fade = true;
        Invoke("GoTitle", 1f);
        Iscript.SE.PlayOneShot(Iscript.OKSE);
    }
    void GoTitle()
    {
        int Played = PlayerPrefs.GetInt("Played");
        if (Iscript.Saint == Played + 1)
        {
            Played = Iscript.Saint;
            PlayerPrefs.SetInt("Played", Played);
        }
        PlayerPrefs.SetInt("ClearNum", PlayerPrefs.GetInt("ClearNum", 1) + 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Title");
    }
}
