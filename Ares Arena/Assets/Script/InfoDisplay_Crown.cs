using UnityEngine;
using TMPro;

public class InfoDisplay_Crown : MonoBehaviour
{
    public InfoDisplay Iscript;
    public GameObject DisplayObj;
    public int Saint;
    public int Crown;
    public TMP_Text CrownName;
    public TMP_Text CrownDesc;
    int Language;
    private void Start()
    {
        Language = PlayerPrefs.GetInt("Language", 2);
        Saint = PlayerPrefs.GetInt("Saint1", 1);
        Crown = PlayerPrefs.GetInt("Crown", 0);
        Invoke("CrownDisplay", 0.1f);
    }
    void CrownDisplay()
    {
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
                switch (Saint)
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
                switch (Saint)
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
                        break;
                    case 6:
                        switch (Language)
                        {
                            case 1:
                                CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                    "スキルの効果が5減少する。\n" +
                                    "最大HPが10%減少する。\n";
                                break;
                            case 2:
                                CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                    "The skill's effect is reduced by 5.\n" +
                                    "Maximum HP is reduced by 10%.";
                                break;
                        }
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
                switch (Saint)
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
                        break;
                    case 6:
                        switch (Language)
                        {
                            case 1:
                                CrownDesc.text = "敵の耐久力が上昇し、攻撃が激化する。\n" +
                                    "スキルの効果が5減少する。\n" +
                                    "最大HPが10%減少する。\n" +
                                    "2体のエリートと戦闘する。\n";
                                break;
                            case 2:
                                CrownDesc.text = "Enemy durability increases, and attacks intensify.\n" +
                                    "The skill's effect is reduced by 5.\n" +
                                    "Maximum HP is reduced by 10%.\n" +
                                    "Fight 2 elites.";
                                break;
                        }
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
                switch (Saint)
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
