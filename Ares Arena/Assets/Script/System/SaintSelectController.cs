using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaintSelectController : MonoBehaviour
{
    SaveData data;
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
    int Casual;
    public TMP_Text CrownName;
    public TMP_Text CrownDesc;
    public Animator Crownanim;
    public GameObject CrownArrow_Up;
    public GameObject CrownArrow_Down;
    int MaxCrown;
    int SaintCrown;
    public GameObject CrownObj;
    public GameObject TutorialObj4;
    public GameObject TutorialObj5;

    void Start()
    {
        data = GetComponent<DataManager>().Dscript;
        Language = PlayerPrefs.GetInt("Language", 2);
        Played = data.SaintUnlock;
        Select(1);
        for(int i = 0; i < SaintCrownanim.Length; i++)
        {
            if (data.MaxCrown[i + 1] == 0)
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

        if (PlayerPrefs.GetInt("Tutorial4", 0) == 1)
        {
            TutorialObj4.SetActive(true);
            PlayerPrefs.SetInt("Tutorial4", 2);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt("Tutorial5", 0) == 1)
        {
            TutorialObj5.SetActive(true);
            PlayerPrefs.SetInt("Tutorial5", 2);
            PlayerPrefs.Save();
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
        if (Casual == 1)
        {
            Crownanim.Play("Casual");
            switch (Language)
            {
                case 1:
                    CrownName.text = "カジュアル";
                    break;
                case 2:
                    CrownName.text = "Casual";
                    break;
            }
            switch (Language)
            {
                case 1:
                    CrownDesc.text = "ターン開始時、ハンド数5。\n" +
                        "最大HPが25%増加する。";
                    break;
                case 2:
                    CrownDesc.text = "At the start of turn, Hand +5.\n" +
                        "Maximum HP increases 25%.";
                    break;
            }
        }
        else
        {
            Crownanim.Play($"Crown{Crown}");
            switch (Crown)
            {
                case 0:
                    switch (Language)
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
                    PlayerPrefs.SetInt("EnemyHPLevel", 0);
                    PlayerPrefs.SetInt("EnemyAttackLevel", 0);
                    PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                    break;
                case 1:
                    switch (Language)
                    {
                        case 1:
                            CrownName.text = "クラウン I";
                            CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。";
                            break;
                        case 2:
                            CrownName.text = "Crown I";
                            CrownDesc.text = "Enemy durability increases, and attacks intensify.";
                            break;
                    }
                    PlayerPrefs.SetInt("EnemyHPLevel", 1);
                    PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                    PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                    break;
                case 2:
                    switch (Language)
                    {
                        case 1:
                            CrownName.text = "クラウン II";
                            break;
                        case 2:
                            CrownName.text = "Crown II";
                            break;
                    }
                    switch (Saint1)
                    {
                        case 1:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "最大HPが10%減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "Maximum HP is reduced by 10%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 2:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が3減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 3.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 3:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジに必要なダメージが20%増加する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The damage required for Revenge increases by 20%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 4:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が1減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 1.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 5:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "全ての敵の耐久力が更に上昇する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The durability of all enemies increases further.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 2);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 6:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が5減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 5.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 7:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が1減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 1.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 8:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "ショップの商品が値上がりする。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The prices of items in the shop are going up.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 9:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "全ての敵の攻撃がさらに激化する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "All enemy attacks intensify further.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 2);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 10:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジの効果が2減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The effect of Revenge is reduced by 2.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 11:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジに必要なダメージが20%増加する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The damage required for Revenge increases by 20%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 12:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルを使用後のみターンを終了できる。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "You can end your turn only after using a skill.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 13:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "ポーションスロットの数が1減少。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The number of potion slots is reduced by 1.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 14:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "同じ種類のドロイドを3体までしか出せなくなる。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "You can generate no more than 3 droids of the same type.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                    }
                    break;
                case 3:
                    switch (Language)
                    {
                        case 1:
                            CrownName.text = "クラウン III";
                            break;
                        case 2:
                            CrownName.text = "Crown III";
                            break;
                    }
                    switch (Saint1)
                    {
                        case 1:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "最大HPが10%減少する。\n" +
                                        "HP75%でランを開始する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "Maximum HP is reduced by 10%.\n" +
                                        "Start the run at 75% HP.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 2:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が3減少する。\n" +
                                        "ターン開始時、ハンド数-1。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 3.\n" +
                                        "At the start of the turn, Hand -1.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 3:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "休憩時に回復できるHPが失った分の75%に減少。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "The HP recovered by resting is reduced to 75% of the amount lost.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 4:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が1減少する。\n" +
                                        "リベンジの効果が2減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 1.\n" +
                                        "The revenge's effect is reduced by 2.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 5:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "全ての敵の耐久力が更に上昇する。\n" +
                                        "最大HPが10%減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The durability of all enemies increases further.\n" +
                                        "Maximum HP is reduced by 10%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 2);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 6:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が5減少する。\n" +
                                        "最大HPが10%減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                       "The skill's effect is reduced by 5.\n" +
                                       "Maximum HP is reduced by 10%.\n";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 7:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が1減少する。\n" +
                                        "スロットの各宝石の所持上限が3までになる。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 1.\n" +
                                        "The maximum number of each type of gem held in the slots becomes 3.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 8:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "ショップの商品が値上がりする。\n" +
                                        "スキルの効果が1減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The prices of items in the shop are going up.\n" +
                                        "The skill's effect is reduced by 1.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 9:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "全ての敵の攻撃がさらに激化する。\n" +
                                        "スキル発動時、シールドの40%を失う。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "All enemy attacks intensify further.\n" +
                                        "Upon skill activation, lose 40% of the shield.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 2);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 10:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジの効果が2減少する。\n" +
                                        "スキルに失敗すると、即座にターンを終了する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The revenge's effect is reduced by 2.\n" +
                                        "If the skill fails, the turn ends immediately.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 11:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "セルをハンドした時、追加でハンドを1失う。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The damage required for Revenge increases by 20%.\n" +
                                        "When you hand Cell, you lose an additional 1 hand.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 12:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルを使用後のみターンを終了できる。\n" +
                                        "リベンジの効果が1減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "You can end your turn only after using a skill.\n" +
                                        "The revenge's effect is reduced by 1.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 13:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "ポーションスロットの数が1減少。\n" +
                                        "リベンジに必要なダメージが20%増加する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The number of potion slots is reduced by 1.\n" +
                                        "The damage required for revenge increases by 20%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 14:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "同じ種類のドロイドを3体までしか出せなくなる。\n" +
                                        "リベンジに必要なダメージが20%増加する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "You can generate no more than 3 droids of the same type.\n" +
                                        "The damage required for revenge increases by 20%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                    }
                    break;
                case 4:
                    switch (Language)
                    {
                        case 1:
                            CrownName.text = "クラウン IV";
                            break;
                        case 2:
                            CrownName.text = "Crown IV";
                            break;
                    }
                    switch (Saint1)
                    {
                        case 1:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "最大HPが10%減少する。\n" +
                                        "HP75%でランを開始する。\n" +
                                        "リベンジの効果が2減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "Maximum HP is reduced by 10%.\n" +
                                        "Start the run at 75% HP.\n" +
                                        "The revenge's effect is reduced by 2.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 2:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が3減少する。\n" +
                                        "ターン開始時、ハンド数-1。\n" +
                                        "スキルの効果がさらに3減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 3.\n" +
                                        "At the start of the turn, Hand -1.\n" +
                                        "The skill's effect is reduced by an additional 3.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 3:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "休憩時に回復できるHPが失った分の75%に減少。\n" +
                                        "HP75%でランを開始する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "The HP recovered by resting is reduced to 75% of the amount lost.\n" +
                                        "Start the run at 75% HP.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 4:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が1減少する。\n" +
                                        "リベンジの効果が2減少する。\n" +
                                        "全ての敵の特殊能力が強化される。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 1.\n" +
                                        "The revenge's effect is reduced by 2.\n" +
                                        "All enemies' special abilities are enhanced.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 1);
                            break;
                        case 5:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "全ての敵の耐久力が更に上昇する。\n" +
                                        "最大HPが10%減少する。\n" +
                                        "リベンジに必要なダメージが20%増加する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The durability of all enemies increases further.\n" +
                                        "Maximum HP is reduced by 10%.\n" +
                                        "The damage required for revenge increases by 20%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 2);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 6:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が5減少する。\n" +
                                        "最大HPが10%減少する。\n" +
                                        "2体のエリートと戦闘する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                       "The skill's effect is reduced by 5.\n" +
                                       "Maximum HP is reduced by 10%.\n" +
                                       "Fight 2 elites.\n";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 7:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が1減少する。\n" +
                                        "スロットの各宝石の所持上限が3までになる。\n" +
                                        "全ての敵の特殊能力が強化される。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 1.\n" +
                                        "The maximum number of each type of gem held in the slots becomes 3.\n" +
                                        "All enemies' special abilities are enhanced.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 1);
                            break;
                        case 8:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "ショップの商品が値上がりする。\n" +
                                        "スキルの効果が1減少する。\n" +
                                        "リベンジに必要なダメージが20%増加する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The prices of items in the shop are going up.\n" +
                                        "The skill's effect is reduced by 1.\n" +
                                        "The damage required for revenge increases by 20%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 9:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "全ての敵の攻撃がさらに激化する。\n" +
                                        "スキル発動時、シールドの40%を失う。\n" +
                                        "シールドを得た時、その値が1減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "All enemy attacks intensify further.\n" +
                                        "Upon skill activation, lose 40% of the shield.\n" +
                                        "When you gain shield, its value decreases by 1.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 2);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 10:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジの効果が2減少する。\n" +
                                        "スキルに失敗すると、即座にターンを終了する。\n" +
                                        "リベンジに必要なダメージが20%増加する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The revenge's effect is reduced by 2.\n" +
                                        "If the skill fails, the turn ends immediately.\n" +
                                        "The damage required for revenge increases by 20%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 11:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "セルをハンドした時、追加でハンドを1失う。\n" +
                                        "鍛えた時のHP増加効果が15%に減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "When you hand Cell, you lose an additional 1 hand.\n" +
                                        "The HP increase effect when trained is reduced to 15%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 12:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルを使用後のみターンを終了できる。\n" +
                                        "リベンジの効果が1減少する。\n" +
                                        "ターン開始時、ハンド数-1。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "You can end your turn only after using a skill.\n" +
                                        "The revenge's effect is reduced by 1.\n" +
                                        "At the start of the turn, Hand -1.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 13:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "ポーションスロットの数が1減少。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "全ての敵の攻撃がさらに激化する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The number of potion slots is reduced by 1.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "All enemy attacks intensify further.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 2);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 14:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "同じ種類のドロイドを3体までしか出せなくなる。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "全ての敵の特殊能力が強化される。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "You can generate no more than 3 droids of the same type.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "All enemies' special abilities are enhanced.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 1);
                            break;
                    }
                    break;
                case 5:
                    switch (Language)
                    {
                        case 1:
                            CrownName.text = "クラウン V";
                            break;
                        case 2:
                            CrownName.text = "Crown V";
                            break;
                    }
                    switch (Saint1)
                    {
                        case 1:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "最大HPが10%減少する。\n" +
                                        "HP75%でランを開始する。\n" +
                                        "リベンジの効果が2減少する。\n" +
                                        "ボスのHPが25%増加する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "Maximum HP is reduced by 10%.\n" +
                                        "Start the run at 75% HP.\n" +
                                        "The revenge's effect is reduced by 2.\n" +
                                        "The boss's HP increases by 25%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 2:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が3減少する。\n" +
                                        "ターン開始時、ハンド数-1。\n" +
                                        "スキルの効果がさらに3減少する。\n" +
                                        "全ての敵の特殊能力が強化される。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 3.\n" +
                                        "At the start of the turn, Hand -1.\n" +
                                        "The skill's effect is reduced by an additional 3.\n" +
                                        "All enemies' special abilities are enhanced.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 1);
                            break;
                        case 3:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "休憩時に回復できるHPが失った分の75%に減少。\n" +
                                        "HP75%でランを開始する。\n" +
                                        "2体のエリートと戦闘する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "The HP recovered by resting is reduced to 75% of the amount lost.\n" +
                                        "Start the run at 75% HP.\n" +
                                        "Fight 2 elites.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 4:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が1減少する。\n" +
                                        "リベンジの効果が2減少する。\n" +
                                        "全ての敵の特殊能力が強化される。\n" +
                                        "プリズムを消去する毎に、最大HPを1失う。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 1.\n" +
                                        "The revenge's effect is reduced by 2.\n" +
                                        "All enemies' special abilities are enhanced.\n" +
                                        "Lose 1 Max HP each time you cast Prism.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 1);
                            break;
                        case 5:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "全ての敵の耐久力が更に上昇する。\n" +
                                        "最大HPが10%減少する。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "リベンジの永続強化効果が20減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The durability of all enemies increases further.\n" +
                                        "Maximum HP is reduced by 10%.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "The permanent buff effect of revenge is reduced by 20.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 2);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 6:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が5減少する。\n" +
                                        "最大HPが10%減少する。\n" +
                                        "2体のエリートと戦闘する。\n" +
                                        "全ての敵の特殊能力が強化される。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 5.\n" +
                                        "Maximum HP is reduced by 10%.\n" +
                                        "Fight 2 elites.\n" +
                                        "All enemies' special abilities are enhanced.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 1);
                            break;
                        case 7:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルの効果が1減少する。\n" +
                                        "スロットの各宝石の所持上限が3までになる。\n" +
                                        "全ての敵の特殊能力が強化される。\n" +
                                        "リベンジの効果が1減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The skill's effect is reduced by 1.\n" +
                                        "The maximum number of each type of gem held in the slots becomes 3.\n" +
                                        "All enemies' special abilities are enhanced.\n" +
                                        "The revenge's effect is reduced by 1.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 1);
                            break;
                        case 8:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "ショップの商品が値上がりする。\n" +
                                        "スキルの効果が1減少する。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "ボスのHPが25%増加する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The prices of items in the shop are going up.\n" +
                                        "The skill's effect is reduced by 1.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "The boss's HP increases by 25%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 9:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "全ての敵の攻撃がさらに激化する。\n" +
                                        "スキル発動時、シールドの40%を失う。\n" +
                                        "シールドを得た時、その値が1減少する。\n" +
                                        "最大HPが10%減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "All enemy attacks intensify further.\n" +
                                        "Upon skill activation, lose 40% of the shield.\n" +
                                        "When you gain shield, its value decreases by 1.\n" +
                                        "Maximum HP is reduced by 10%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 2);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 10:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジの効果が2減少する。\n" +
                                        "スキルに失敗すると、即座にターンを終了する。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "2体のエリートと戦闘する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The revenge's effect is reduced by 2.\n" +
                                        "If the skill fails, the turn ends immediately.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "Fight 2 elites.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 11:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "セルをハンドした時、追加でハンドを1失う。\n" +
                                        "鍛えた時のHP増加効果が15%に減少する。\n" +
                                        "セルは3段階目までしか成長しない。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "When you hand Cell, you lose an additional 1 hand.\n" +
                                        "The HP increase effect when trained is reduced to 15%.\n" +
                                        "Cell only grows up to the 3rd stage.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 12:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "スキルを使用後のみターンを終了できる。\n" +
                                        "リベンジの効果が1減少する。\n" +
                                        "ターン開始時、ハンド数-1。\n" +
                                        "全ての敵の特殊能力が強化される。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "You can end your turn only after using a skill.\n" +
                                        "The revenge's effect is reduced by 1.\n" +
                                        "At the start of the turn, Hand -1.\n" +
                                        "All enemies' special abilities are enhanced.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 1);
                            break;
                        case 13:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "ポーションスロットの数が1減少。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "全ての敵の攻撃がさらに激化する。\n" +
                                        "最大HPが10%減少する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "The number of potion slots is reduced by 1.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "All enemy attacks intensify further.\n" +
                                        "Maximum HP is reduced by 10%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 2);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 0);
                            break;
                        case 14:
                            switch (Language)
                            {
                                case 1:
                                    CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                        "同じ種類のドロイドを3体までしか出せなくなる。\n" +
                                        "リベンジに必要なダメージが20%増加する。\n" +
                                        "全ての敵の特殊能力が強化される。\n" +
                                        "ボスのHPが25%増加する。";
                                    break;
                                case 2:
                                    CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                        "You can generate no more than 3 droids of the same type.\n" +
                                        "The damage required for revenge increases by 20%.\n" +
                                        "All enemies' special abilities are enhanced.\n" +
                                        "The boss's HP increases by 25%.";
                                    break;
                            }
                            PlayerPrefs.SetInt("EnemyHPLevel", 1);
                            PlayerPrefs.SetInt("EnemyAttackLevel", 1);
                            PlayerPrefs.SetInt("EnemyAbilityLevel", 1);
                            break;
                    }
                    break;
            }
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
                        case 14:
                            SaintName.text = "フォーミュラ";
                            SaintExplain.text = "兵器に改造された自律思考AI。\n" +
                                "戦いの場では、ドロイドと共に行動する。";
                            SkillName.text = "センチネル";
                            SkillDesc.text = "選択したドロイドを1つ生成する。同時に生成出来るのは5つまで。";
                            RevengeName.text = "機械学習";
                            RevengeDesc.text = "選択したドロイドを永続的に1段階アップグレードする。";
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
                        case 14:
                            SaintName.text = "The Formula";
                            SaintExplain.text = "An autonomous AI modified into a weapon.\n" +
                                "It operates alongside its droids on the battlefield.";
                            SkillName.text = "Sentinel";
                            SkillDesc.text = "Generate a selected droid. You can generate up to five at a time.";
                            RevengeName.text = "Machine Learning";
                            RevengeDesc.text = "Permanently upgrades a selected droid by 1 Lv.";
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
                case 14:
                    SaintHP.text = "HP: 380";
                    break;
            }
            Choosing = i;
            Saint1 = Choosing;
            SaintChoose(1);
            Saintanim.Play($"Saint{i}");
            MaxCrown = data.MaxCrown[i];
            SaintCrown = data.SaintCrown[i];
            Crown = SaintCrown;
            Casual = 0;
            CrownArrow_Down.SetActive(true);
            if(Crown < MaxCrown)
            {
                CrownArrow_Up.SetActive(true);
            }
            else
            {
                CrownArrow_Up.SetActive(false);
            }
            PlayerPrefs.SetInt("Crown", SaintCrown);
            PlayerPrefs.Save();
            CrownObj.SetActive(true);
            CrownDisplay();
            SE.PlayOneShot(OkSE);
        }
    }
    public void CrownUp()
    {
        if(Casual == 1)
        {
            Casual = 0;
            CrownDisplay();
        }
        else if(Crown < MaxCrown)
        {
            Crown += 1;
            data.SaintCrown[Saint1] = Crown;
            PlayerPrefs.SetInt("Crown", Crown);
            PlayerPrefs.Save();
            CrownDisplay();
            
        }
        CrownArrow_Down.SetActive(true);
        if (Crown == MaxCrown)
        {
            CrownArrow_Up.SetActive(false);
        }
    }
    public void CrownDown()
    {
        if (Crown > 0)
        {
            Crown -= 1;
            data.SaintCrown[Saint1] = Crown;
            PlayerPrefs.SetInt("Crown", Crown);
            PlayerPrefs.Save();
            CrownDisplay();
        }
        else if(Casual == 0)
        {
            Casual = 1;
            CrownDisplay();
        }
        CrownArrow_Up.SetActive(true);
        if (Casual == 1)
        {
            CrownArrow_Down.SetActive(false);
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
            PlayerPrefs.SetInt("Casual", Casual);
            PlayerPrefs.Save();
            Invoke("SceneMove", 2f);
        }
    }
    public void BackTitle()
    {
        FadeOut.SetActive(true);
        IsVolumeFade = true;
        SE.PlayOneShot(OkSE);
        Invoke("TitleMove", 2f);
    }
    void SceneMove()
    {
        SceneManager.LoadScene("Arena");
    }
    void TitleMove()
    {
        SceneManager.LoadScene("Title");
    }
}
