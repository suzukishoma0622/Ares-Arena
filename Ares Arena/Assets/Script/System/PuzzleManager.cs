using UnityEngine;
using TMPro;
using UnityEngine.UI;
#if !UNITY_WEBGL

using Steamworks;
#endif
using System.Collections;

public class PuzzleManager : MonoBehaviour
{
    public InfoDisplay Iscript;
    public EnemyHealth Escript;
    public Transform[] JewelPos = new Transform[49];
    public GameObject[] SelectObj;
    public int SelectNum;
    public int[] JewelNum = new int[49];
    int Language;
    public GameObject[] JewelObj;
    public GameObject[] JewelFlash;
    public GameObject[] JewelFlash2;
    public int[] EquipJewel;
    public int[] AdditionalJewel;
    public GameObject JewelAttackEffect;
    public GameObject JewelDefenseEffect;
    public GameObject[] JewelDisplay = new GameObject[49];

    public int CurrentHand;
    public int Chain = 0;
    float ChainTime;
    int C;
    int C3;
    int[] ChainNum = new int[49];
    public TMP_Text HandText;
    public TMP_Text ChainText;
    public TMP_Text ChainBonusText;
    public TMP_Text DamageText;
    public int DamageSum;

    public bool PlayerRound;
    [SerializeField] GameObject TimeUpObj;
    [SerializeField] GameObject NoMoreMoveObj;
    [SerializeField] CanvasGroup PuzzleCover;

    [SerializeField] public GameObject AttackEffect;
    [SerializeField] public GameObject ShieldEffect;
    [SerializeField] public GameObject HealEffect;
    [SerializeField] GameObject RevengeEffect;

    int Saint;
    public int ActiveSkill;
    public TMP_Text SkillNameText;
    public TMP_Text SkillDescText;
    public TMP_Text SkillUseText;
    [SerializeField] GameObject[] SaintSkillEffect;
    [SerializeField] Transform[] SkillEffectPos;
    [SerializeField] GameObject[] SaintRevengeEffect;
    [SerializeField] Transform[] RevengeEffectPos;
    public TMP_Text RevengeNameText;
    public BattleManager Bscript;

    int CurrentTurnHand;
    int Chained;
    public float[] GemProb;
    public TMP_Text[] GemProbText;
    int[] P = {100, 100, 100, 100, 100};

    public int Debuff_Lightning;
    public int Debuff_Weak;
    public int Debuff_Void;
    public int Debuff_Exhaustion;
    float WeakNum;

    public bool IsAgate;
    public bool IsCitrine;
    public bool IsTimemachine;
    public Enemy_TimeMachine Tscript;
    public bool IsCyberResistance;
    public Enemy_CyberResistance Cscript;
    public bool IsJewelryFish;
    public Enemy_JewelryFish Jscript;
    public bool IsAetherRizer;
    public Enemy_AetherRizer Ascript;
    public bool IsFrozenHound;
    public bool IsFilamentMilitar;
    public Enemy_FilamentMilitar Fscript;
    public bool IsGemSlasher;
    public Enemy_GemSlasher Gscript;
    public bool IsBlackSniper;
    public Enemy_BlackSniper Bscript2;
    
    public int DayBreak;
    public int Blackstar;
    public int Gem54 = 32;
    int Gem55 = 1;
    int Gem78 = 0;
    int Gem112 = 5;
    int Gem118;
    int Gem119;
    int Gem128;
    int Gem130;
    int Gem131;
    public int Gem133;
    public int Gem135;
    public int Gem136;
    bool BurningHand;
    bool Gaze;
    bool Revenged;

    public InfoDisplay_Skill Sscript;

    public float Bless3;
    public int Bless22 = 1;
    public bool Bless31;
    int j30;
    public int Watcher_Sniper;
    public int Watcher_Quiver = 10;
    public CanvasGroup WatcherCG;
    public int Fractal_Prism;
    public CanvasGroup FractalCG;
    int[] CatalystNum = new int[49];
    GameObject[] CatalystDisplay = new GameObject[49];
    public GameObject CatalystObj;
    bool CatalystPut;
    public Animator[] CollectorSlot;
    public int[] CollectorGem;
    public TMP_Text[] CollectorGemText;
    int Collector_Skill;
    public CanvasGroup CollectorCG;
    public CanvasGroup[] CollectorPutCG;
    public int CollectorPut = -1;
    public GameObject Collector_SlotObj;
    int[] OrderNum = new int[49];
    GameObject[] OrderDisplay = new GameObject[49];
    public GameObject OrderObj;
    bool OrderRev;
    public int Creator_Cell;
    public CanvasGroup CreatorCG;
    int Creator_i;
    int Creator_j;
    public CanvasGroup MatrixCG;
    public CanvasGroup MatrixCG2;
    public int[] MatrixGem;
    public Animator[] Matrixanim;
    public Animator[] Matrixanim2;
    public int MatrixMemory;
    public GameObject[] MatrixCount;
    int MatrixSkill;
    int MatrixAlter;
    public GameObject Revenant_Slot;
    public GameObject Revenant_Slot4;
    int[] RevenantPotion = new int[4];
    public InfoDisplay_Potion[] RevenantDisplay;
    public GameObject[] Formula_Slot;
    public InfoDisplay_Droid[] FormulaDisplay;
    public GameObject[] FormulaDroid = new GameObject[3];
    public int[] FormulaNum = new int[5];
    public int FormulaSelect;
    public GameObject[] FormulaSelectObj;
    public Transform[] FormulaDroidPos;
    public Transform[] FormulaDroidObj;
    public GameObject[] FormulaEffect;

    public AudioClip CastSE1;
    public AudioClip CastSE2;
    public AudioClip SkillSE;
    public AudioClip RevengeSE;
    public AudioClip SentrySE;
    public AudioClip GolemSE;
    public AudioClip RevenantSE;
    public AudioClip GamblerSE;

    int A16;
    int A22;
    int A23;
    
    void Start()
    {
        Saint = PlayerPrefs.GetInt("Saint1", 1);
        Gem133 = PlayerPrefs.GetInt("Gem133", 10);
        if (Saint == 7)
        {
            Collector_SlotObj.SetActive(true);
        }
        if(Saint == 12)
        {
            MatrixCG.alpha = 1;
            MatrixCG.interactable = true;
            MatrixCG.blocksRaycasts = true;
        }
        if (Saint == 13)
        {
            Revenant_Slot.SetActive(true);
            if(Iscript.Crown >= 2)
            {
                Revenant_Slot4.SetActive(false);
            }
            for(int i = 0; i < 4; i++)
            {
                RevenantPotion[i] = PlayerPrefs.GetInt($"Potion{i}", 0);
                RevenantDisplay[i].PotionNum = RevenantPotion[i];
            }
        }
        if (Saint == 14)
        {
            Formula_Slot[0].SetActive(true);
            Formula_Slot[1].SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                FormulaDisplay[i].DroidLevel = PlayerPrefs.GetInt($"Droid{i}", 0);
            }
        }
        Chain = 0;
        for (int i = 0; i < 5; i++)
        {
            EquipJewel[i] = Iscript.JewelNum[i];
            CollectorSlot[i].Play($"Gem{EquipJewel[i]}");
        }
        Probcalc();
        Shuffle();
        for(int i = 0; i < ChainNum.Length; i++)
        {
            ChainNum[i] = -1;
        }
        Language = PlayerPrefs.GetInt("Language", 2);
        SkillDisplay();
        if (Bscript.Iscript.Bless[21] == 1)
        {
            Bless22 = 2;
            Sscript.Bless22 = 2;
            if (Iscript.Bless[54] == 1)
            {
                Bless22 = 3;
                Sscript.Bless22 = 3;
            }
            Sscript.Start();
        }
        if (Bscript.Iscript.Bless[55] == 1 && Iscript.CurrentRound == 7)
        {
            GameObject g = Instantiate(HealEffect);
            g.transform.position = this.transform.position;
            g.GetComponent<EffectScript>().EffectNum = Iscript.PlayerMaxHP - Iscript.PlayerHP;
            g.GetComponent<BlockTrail>().GoPlayer = true;
            g.SetActive(true);
            if (Iscript.Bless[3] == 1)
            {
                Bless3 += Iscript.PlayerMaxHP * (Iscript.PlayerMaxHP - Iscript.PlayerHP) * 0.1f;
                if (Bless3 >= 1f)
                {
                    Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                    Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                    Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                }
            }
        }
        if (Iscript.Crown >= 4)
        {
            Watcher_Quiver = 4;
        }
        else if (Iscript.Crown >= 2)
        {
            Watcher_Quiver = 7;
        }
        A16 = PlayerPrefs.GetInt("A16", 0);
        A22 = PlayerPrefs.GetInt("A22", 0);
        A23 = PlayerPrefs.GetInt("A23", 0);
    }
    void Update()
    {
        if(CurrentHand < 0)
        {
            CurrentHand = 0;
        }
        #if !UNITY_WEBGL

        if(CurrentHand >= 20 && A16 == 0)
        {
            if (SteamManager.Initialized)
            {
                SteamUserStats.GetAchievement("Achieve16", out bool isUnlocked);
                if (!isUnlocked)
                {
                    SteamUserStats.SetAchievement("Achieve16");
                }
                SteamUserStats.StoreStats();
                A16 = 1;
                PlayerPrefs.SetInt("A16", 1);
                PlayerPrefs.Save();
            }
        }
        if (Bscript.PlayerShield >= 1000 && A22 == 0)
        {
            if (SteamManager.Initialized)
            {
                SteamUserStats.GetAchievement("Achieve22", out bool isUnlocked);
                if (!isUnlocked)
                {
                    SteamUserStats.SetAchievement("Achieve22");
                }
                SteamUserStats.StoreStats();
                A22 = 1;
                PlayerPrefs.SetInt("A22", 1);
                PlayerPrefs.Save();
            }
        }
#endif
        HandText.text = CurrentHand.ToString();
        DamageText.text = DamageSum.ToString();
        if (Chain <= 0)
        {
            ChainText.text = Chained.ToString();
            Chain = 0;
        }
        else
        {
            ChainText.text = Chain.ToString();
        }
        if(Chain >= 1)
        {
            ChainText.gameObject.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 5f;
            DamageText.gameObject.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 5f;
        }
        if(ChainTime > 0f)
        {
            ChainTime -= Time.deltaTime;
            if(ChainTime <= 0f)
            {
                Chained = Chain;
                Chain = 0;
                for (int i = 0; i < ChainNum.Length; i++)
                {
                    ChainNum[i] = -1;
                }
                JewelFall();
                IsAgate = false;
                for (int i = 0; i < JewelPos.Length; i++)
                {
                    JewelPos[i].GetComponent<Button>().interactable = true;
                }
                if(IsJewelryFish)
                {
                    for (int i = 0; i < Jscript.StaticElectricity; i++)
                    {
                        int Judge = Random.Range(0, 49);
                        if (Jscript.Staticnum[Judge] == 0)
                        {
                            Jscript.Staticnum[Judge] = 1;
                            GameObject g2 = Instantiate(Jscript.StaticEffect1);
                            g2.transform.position = JewelPos[Judge].transform.position;
                            g2.transform.SetParent(Bscript.gameObject.transform, true);
                            g2.SetActive(true);
                            Jscript.StaticDisplay[Judge] = g2;
                        }
                    }
                }
                if (IsAetherRizer)
                {
                    if (Ascript.Wind > 0)
                    {
                        for (int j = 0; j < 13; j++)
                        {
                            GameObject g2 = Instantiate(Ascript.WindEffect2);
                            g2.transform.position = JewelPos[Ascript.WindDict[j]].transform.position;
                            g2.transform.SetParent(Bscript.gameObject.transform, true);
                            g2.SetActive(true);
                            Destroy(Ascript.WindDisplay[j]);
                        }
                        int Judge1 = Random.Range(0, 7);
                        int Judge2 = Random.Range(0, 7);
                        int m = 0;
                        for (int i = 0; i < 7; i++)
                        {
                            Ascript.Windnum[Judge1 * 7 + i] = 1;
                            GameObject g2 = Instantiate(Ascript.WindEffect1);
                            g2.transform.position = JewelPos[Judge1 * 7 + i].transform.position;
                            g2.transform.SetParent(Bscript.gameObject.transform, true);
                            g2.SetActive(true);
                            Ascript.WindDict[i] = Judge1 * 7 + i;
                            Ascript.WindDisplay[i] = g2;
                        }
                        for (int k = 0; k < 7; k++)
                        {
                            if (k != Judge1)
                            {
                                Ascript.Windnum[k * 7 + Judge2] = 1;
                                GameObject g2 = Instantiate(Ascript.WindEffect1);
                                g2.transform.position = JewelPos[k * 7 + Judge2].transform.position;
                                g2.transform.SetParent(Bscript.gameObject.transform, true);
                                g2.SetActive(true);
                                Ascript.WindDict[m + 7] = k * 7 + Judge2;
                                Ascript.WindDisplay[m + 7] = g2;
                                m += 1;
                            }
                        }
                    }
                }
            }
        }
        else if(ChainText.gameObject.GetComponent<CanvasGroup>().alpha > 0f)
        {
            ChainText.gameObject.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 0.5f;
            DamageText.gameObject.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 0.6f;
        }
        if(!PlayerRound)
        {
            PuzzleCover.alpha += Time.deltaTime * 2f;
        }
        else
        {
            PuzzleCover.alpha -= Time.deltaTime * 2f;
        }
        for (int i = 0; i < JewelDisplay.Length; i++)
        {
            if (JewelDisplay[i] != null)
            {
                JewelDisplay[i].transform.position = Vector3.MoveTowards(JewelDisplay[i].transform.position, JewelPos[i].transform.position,
                    10f * Time.deltaTime);
            }
        }
        if(Debuff_Weak > 0)
        {
            WeakNum = 0.5f;
        }
        else
        {
            WeakNum = 1f;
        }
        if(Watcher_Sniper > 0 && !Bscript.IsDefeat && !Bscript.IsDead && Saint == 2)
        {
            WatcherCG.alpha += Time.deltaTime * 2f;
            WatcherCG.gameObject.GetComponent<TextMeshProUGUI>().text = Watcher_Sniper.ToString();
        }
        else
        {
            WatcherCG.alpha -= Time.deltaTime * 2f;
        }
        if (Fractal_Prism > 0 && !Bscript.IsDefeat && !Bscript.IsDead && Saint == 4)
        {
            FractalCG.alpha += Time.deltaTime * 2f;
            FractalCG.gameObject.GetComponent<TextMeshProUGUI>().text = Fractal_Prism.ToString();
        }
        else
        {
            FractalCG.alpha -= Time.deltaTime * 2f;
        }
        if (Collector_Skill > 0 && !Bscript.IsDefeat && !Bscript.IsDead && Saint == 7)
        {
            CollectorCG.alpha += Time.deltaTime * 2f;
            CollectorCG.gameObject.GetComponent<TextMeshProUGUI>().text = Collector_Skill.ToString();
        }
        else
        {
            CollectorCG.alpha -= Time.deltaTime * 2f;
        }
        if (Creator_Cell > 0 && !Bscript.IsDefeat && !Bscript.IsDead && Saint == 11)
        {
            CreatorCG.alpha += Time.deltaTime * 2f;
            CreatorCG.gameObject.GetComponent<TextMeshProUGUI>().text = Creator_Cell.ToString();
        }
        else
        {
            CreatorCG.alpha -= Time.deltaTime * 2f;
        }
        if (MatrixSkill > 0 && !Bscript.IsDefeat && !Bscript.IsDead && Saint == 12)
        {
            MatrixCG2.alpha += Time.deltaTime * 2f;
            MatrixCG2.gameObject.GetComponent<TextMeshProUGUI>().text = MatrixSkill.ToString();
        }
        else
        {
            MatrixCG2.alpha -= Time.deltaTime * 2f;
        }
        if (Saint == 7)
        {
            for (int i = 0; i < 5; i++)
            {
                CollectorGemText[i].text = CollectorGem[i].ToString();
                if (CollectorPutCG[5 + i].alpha > 0)
                {
                    CollectorPutCG[5 + i].alpha -= Time.deltaTime * 3f;
                }
                if (Iscript.Crown >= 3)
                {
                    if (CollectorGem[i] > 3)
                    {
                        CollectorGem[i] = 3;
                    }
                }
            }
        }
        if(Saint == 12)
        {
            for(int i = 0; i < 10; i++)
            {
                if(MatrixMemory >= i + 1)
                {
                    MatrixCount[i].SetActive(true);
                }
                else
                {
                    MatrixCount[i].SetActive(false);
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (MatrixGem[i] >= 0)
                {
                    Matrixanim[i].gameObject.SetActive(true);
                    Matrixanim[i].Play($"Gem{MatrixGem[i]}");
                }
                else
                {
                    Matrixanim[i].gameObject.SetActive(false);
                }
            }
        }
        if(Saint == 13)
        {
            for(int i = 0; i < 4; i++)
            {
                if (RevenantPotion[i] == 0)
                {
                    RevenantDisplay[i].gameObject.SetActive(false);
                }
                else
                {
                    RevenantDisplay[i].gameObject.SetActive(true);
                }
            }
        }
        if(Saint == 14)
        {
            for(int i = 0; i < 5; i++)
            {
                if (FormulaDroidObj[i] != null)
                {
                    FormulaDroidObj[i].position = Vector3.MoveTowards(FormulaDroidObj[i].position, FormulaDroidPos[i].position, Time.deltaTime * 4f);
                }
            }
        }
    }
    public void RoundStart()
    {
        if (Iscript.Bless[40] == 1)
        {
            if(CurrentHand > 5)
            {
                CurrentHand = 5;
            }
            CurrentHand += 10;
        }
        else
        {
            CurrentHand = 10;
        }
        CurrentHand -= Debuff_Lightning;
        CurrentTurnHand = 0;
        if (Iscript.Bless[34] == 1 && ActiveSkill == 1)
        {
            CurrentHand += 4;
        }
        if(Iscript.Bless70)
        {
            CurrentHand += 2 * Iscript.Bless[54] + 2;
        }
        ActiveSkill = 1;
        if (Bscript.CurrentRound >= 2)
        {
            Gem112 += 2;
        }
        Revenged = false;
        Gem118 = 0;
        Gem128 = 0;
        Gem135 = 0;
        Gem136 = 0;
        if(Gem130 > 0)
        {
            GameObject g130 = Instantiate(ShieldEffect);
            g130.transform.position = this.transform.position;
            g130.GetComponent<EffectScript>().EffectNum = Gem130;
            g130.GetComponent<BlockTrail>().GoPlayer = true;
            g130.SetActive(true);
            Gem130 = 0;
        }
        SkillDisplay();
        Probcalc();
        int j3 = Random.Range(0, 5);
        for (; Iscript.JewelNum[j3] == 110;)
        {
            j3 = Random.Range(0, 5);
        }
        for (int i = 0; i < 49; i++)
        {
            if (OrderDisplay[i] != null)
            {
                OrderDisplay[i].GetComponent<OrderCount>().text.gameObject.SetActive(true);
            }
            if (JewelNum[i] == 201)
            {
                if ((Iscript.Crown <= 4 && JewelDisplay[i].GetComponent<Gem_Cell>().Growth < 4) || (Iscript.Crown >= 5 && JewelDisplay[i].GetComponent<Gem_Cell>().Growth < 3))
                {
                    JewelDisplay[i].GetComponent<Gem_Cell>().Growth += 1;
                    GameObject g2 = Instantiate(JewelFlash[201]);
                    g2.transform.position = JewelPos[i].position;
                    g2.SetActive(true);
                }
            }
            if (JewelNum[i] == 110)
            {
                JewelNum[i] = Iscript.JewelNum[j3];
                GameObject g5 = Instantiate(JewelObj[Iscript.JewelNum[j3]]);
                g5.transform.position = JewelDisplay[i].transform.position;
                g5.transform.SetParent(gameObject.transform, true);
                Destroy(JewelDisplay[i]);
                JewelDisplay[i] = g5;
                GameObject g5_2 = Instantiate(SaintRevengeEffect[2]);
                g5_2.transform.position = JewelDisplay[i].transform.position;
            }
            if (JewelNum[i] == 122)
            {
                int Judge = Random.Range(0, 10);
                if (Judge <= 2)
                {
                    JewelNum[i] = 200;
                    GameObject g4 = Instantiate(JewelObj[200]);
                    g4.transform.position = JewelDisplay[i].transform.position;
                    g4.transform.SetParent(gameObject.transform, true);
                    Destroy(JewelDisplay[i]);
                    JewelDisplay[i] = g4;
                    GameObject g4_2 = Instantiate(SaintRevengeEffect[2]);
                    g4_2.transform.position = JewelDisplay[i].transform.position;
                }
            }
        }
        if (OrderRev)
        {
            for (int j = 0; j < 49; j++)
            {
                if (OrderNum[j] > 0)
                {
                    GameObject g6 = Instantiate(SaintSkillEffect[17]);
                    g6.transform.position = JewelPos[j].position;
                    g6.SetActive(true);
                }
                OrderNum[j] = 0;
                Destroy(OrderDisplay[j]);
            }
            OrderRev = false;
        }
        if(Saint == 12)
        {
            if (Bless22 >= 1)
            {
                MatrixMemory = Bless22;
                Bless22 = 0;
            }
            if(MatrixMemory == 0)
            {
                MatrixMemory = 1;
            }
        }
        if (Bscript.CurrentRound == 1 && Bscript.Iscript.Bless[2] == 1)
        {
            Bscript.PlayerShield += Mathf.FloorToInt(Bscript.Iscript.PlayerMaxHP * 0.3f * (1 + Iscript.Bless[54]));
        }
        if (Bscript.Iscript.Bless[6] == 1)
        {
            CurrentHand += 1 + Iscript.Bless[54];
        }
        if (Bscript.Iscript.Bless[22] == 1 && Bscript.CurrentRound == 1)
        {
            Iscript.Revenge += Mathf.FloorToInt(100 * Iscript.PlayerHPRate * 0.3f * (1 + Iscript.Bless[54]));
            if (Iscript.Revenge > Mathf.FloorToInt(100 * Iscript.PlayerHPRate))
            {
                Iscript.Revenge = Mathf.FloorToInt(100 * Iscript.PlayerHPRate);
            }
        }
        if (Bscript.Iscript.Bless[28] == 1 && (Iscript.PlayerHP <= Iscript.PlayerMaxHP / 2 || Iscript.Bless[42] == 1))
        {
            CurrentHand += 2;
        }
        if (Bless31)
        {
            Bscript.PlayerShield += Mathf.FloorToInt(Bscript.Iscript.PlayerMaxHP * 0.1f);
            Bless31 = false;
        }
        if (IsFrozenHound)
        {
            for(int i = 0; i < 49; i++)
            {
                if (JewelNum[i] == 306)
                {
                    float Judge = Random.Range(0f, 100f);
                    int j = 0;
                    float j2 = 0;
                    for (int k = 0; k < P.Length; k++)
                    {
                        j2 += GemProb[k];
                        if (Judge < j2)
                        {
                            j = k;
                            break;
                        }
                    }
                    JewelNum[i] = EquipJewel[j];
                    GameObject g4 = Instantiate(JewelObj[EquipJewel[j]]);
                    g4.transform.position = JewelDisplay[i].transform.position;
                    g4.transform.SetParent(gameObject.transform, true);
                    Destroy(JewelDisplay[i]);
                    JewelDisplay[i] = g4;
                    GameObject g4_2 = Instantiate(JewelFlash[306]);
                    g4_2.transform.position = JewelDisplay[i].transform.position;
                }
            }
        }
        if (Bscript.Iscript.Bless[35] == 1)
        {
            GameObject g = Instantiate(HealEffect);
            g.transform.position = this.transform.position;
            g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.03f);
            g.GetComponent<BlockTrail>().GoPlayer = true;
            g.SetActive(true);
            if (Iscript.Bless[3] == 1)
            {
                Bless3 += Iscript.PlayerMaxHP * 0.03f * 0.1f;
                if (Bless3 >= 1f)
                {
                    Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                    Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                    Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                }
            }
        }
        if (Bscript.Iscript.Bless[52] == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                int Judge = Random.Range(0, 49);
                for (int i4 = 0; i4 < 100 && JewelNum[Judge] == 200; i4++)
                {
                    Judge = Random.Range(0, 49);
                }
                JewelNum[Judge] = 200;
                GameObject g4 = Instantiate(JewelObj[200]);
                g4.transform.position = JewelDisplay[Judge].transform.position;
                g4.transform.SetParent(gameObject.transform, true);
                Destroy(JewelDisplay[Judge]);
                JewelDisplay[Judge] = g4;
                GameObject g4_2 = Instantiate(SaintRevengeEffect[2]);
                g4_2.transform.position = JewelDisplay[Judge].transform.position;
            }
        }
        if (Bscript.Iscript.Bless[53] == 1 && Bscript.CurrentRound == 1)
        {
            for (int i = 0; i < 6; i++)
            {
                int Judge = Random.Range(0, 49);
                for (int i4 = 0; i4 < 100 && JewelNum[Judge] == 200; i4++)
                {
                    Judge = Random.Range(0, 49);
                }
                JewelNum[Judge] = 200;
                GameObject g4 = Instantiate(JewelObj[200]);
                g4.transform.position = JewelDisplay[Judge].transform.position;
                g4.transform.SetParent(gameObject.transform, true);
                Destroy(JewelDisplay[Judge]);
                JewelDisplay[Judge] = g4;
                GameObject g4_2 = Instantiate(SaintRevengeEffect[2]);
                g4_2.transform.position = JewelDisplay[Judge].transform.position;
            }
        }
        if (Bscript.Iscript.Bless[59] == 1 && Bscript.CurrentRound == 1)
        {
            GameObject g = Instantiate(AttackEffect);
            g.transform.position = this.transform.position;
            g.GetComponent<EffectScript>().EffectNum = 200;
            g.GetComponent<BlockTrail>().GoPlayer = false;
            g.SetActive(true);
        }
        if (Bscript.Iscript.Bless[61] == 1 && Bscript.CurrentRound == 1)
        {
            CurrentHand += 2;
        }
        if (Bscript.Iscript.Bless[62] == 1)
        {
            Iscript.Revenge += Mathf.FloorToInt(100 * Iscript.PlayerHPRate * 0.1f);
            if (Iscript.Revenge > Mathf.FloorToInt(100 * Iscript.PlayerHPRate))
            {
                Iscript.Revenge = Mathf.FloorToInt(100 * Iscript.PlayerHPRate);
            }
        }
        if((Iscript.Saint == 2 && Iscript.Crown >= 3) || (Iscript.Saint == 12 && Iscript.Crown >= 4))
        {
            CurrentHand -= 1;
        }
        if(Iscript.Casual == 1)
        {
            CurrentHand += 5;
        }
    }
    public void Shuffle()
    {
        int s = 1;
        s = 0;
        for (int i = 0; i < 49; i++)
        {
            float Judge = Random.Range(0f, 100f);
            int j = 0;
            float j2 = 0;
            for (int k = 0; k < P.Length; k++)
            {
                j2 += GemProb[k];
                if (Judge < j2)
                {
                    j = k;
                    break;
                }
            }
            if (j >= 5)
            {
                JewelNum[i] = AdditionalJewel[j - 5];
            }
            else
            {
                JewelNum[i] = EquipJewel[j];
            }
            if (JewelNum[i] == 22)
            {
                float Judge2 = Random.Range(0f, 100f);
                if (Judge2 < 30f)
                {
                    JewelNum[i] = 200;
                    for (int k = 0; k < 3; k++)
                    {
                        GameObject g22 = Instantiate(JewelFlash2[2]);
                        g22.transform.position = JewelPos[i % 7].position;
                        g22.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                        g22.SetActive(true);
                    }
                }
            }
            if (JewelNum[i] == 67)
            {
                float Judge2 = Random.Range(0f, 100f);
                if (Judge2 < 40f)
                {
                    JewelNum[i] = 200;
                    for (int k = 0; k < 3; k++)
                    {
                        GameObject g22 = Instantiate(JewelFlash2[2]);
                        g22.transform.position = JewelPos[i % 7].position;
                        g22.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                        g22.SetActive(true);
                    }
                }
            }
        }
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (JewelNum[i * 7 + j] == JewelNum[i * 7 + j + 1] && JewelNum[i * 7 + j + 1] == JewelNum[i * 7 + j + 2])
                {
                    s++;
                }
            }
        }
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (JewelNum[j * 7 + i] == JewelNum[(j + 1) * 7 + i] && JewelNum[(j + 1) * 7 + i] == JewelNum[(j + 2) * 7 + i])
                {
                    s++;
                }
            }
        }
        for (int i = 0; i < 49; i++)
        {
            GameObject g = Instantiate(JewelObj[JewelNum[i]]);
            g.transform.position = new Vector3(JewelPos[i].position.x, 4f, 0f);
            JewelDisplay[i] = g;
            g.transform.SetParent(this.transform, true);
        }
    }
    public void Probcalc()
    {
        for (int i = 0; i < P.Length; i++)
        {
            P[i] = 100;
            switch (EquipJewel[i])
            {
                case 19:
                    P[i] = 50;
                    break;
                case 20:
                    P[i] = 20;
                    break;
                case 26:
                    P[i] = 200;
                    break;
                case 37:
                    P[i] = 100 / Mathf.Max(Bscript.CurrentRound, 1);
                    break;
                case 49:
                    P[i] = 100 * Mathf.Max(Bscript.CurrentRound, 1);
                    break;
                case 54:
                    P[i] = 100 * Gem55;
                    break;
                case 56:
                    P[i] = 10;
                    break;
                case 79:
                    if (Bscript.CurrentRound <= 1)
                    {
                        P[i] = 300;
                    }
                    break;
                case 137:
                    if(Bscript.CurrentRound >= 4)
                    {
                        P[i] = 0;
                    }
                    break;
            }
            if (Bscript.Iscript.Bless[63] == 1 && EquipJewel[i] <= 4)
            {
                P[i] = Mathf.FloorToInt(P[i] * 0.5f);
            }
        }
        if (Bscript.Iscript.Bless[37] == 1)
        {
            P[0] = P[0] / 2;
        }
        if (Bscript.Iscript.Bless[38] == 1)
        {
            P[4] = P[4] * 2;
        }
        for (int i = 0; i < P.Length; i++)
        {
            if (EquipJewel[i] == 100 && i < 4)
            {
                P[i + 1] *= 2;
            }
            if (EquipJewel[i] == 101 && i > 0)
            {
                P[i - 1] = P[i - 1] / 2;
            }
        }
        if (Iscript.Bless[67] == 1 && Bscript.CurrentRound == 1)
        {
            int m = Random.Range(0, 5);
            P[m] = 0;
            if (Iscript.Bless[54] == 1)
            {
                int n = Random.Range(0, 5);
                for(;m == n ; )
                {
                    n = Random.Range(0, 5);
                }
                P[n] = 0;
            }
        }
        for (int j = 0; j < 5; j++)
        {
            if (EquipJewel[j] == 88)
            {
                P[j] = (P[0] + P[1] + P[2] + P[3] + P[4]) / 5;
            }
        }
        int P2 = P[0] + P[1] + P[2] + P[3] + P[4];
        for (int j = 0; j < 5; j++)
        {
            GemProb[j] = 100 * P[j] / P2;
            GemProbText[j].text = GemProb[j].ToString("0") + "%";
            #if !UNITY_WEBGL

            if (GemProb[j] >= 90 && A23 == 0)
            {
                if (SteamManager.Initialized)
                {
                    SteamUserStats.GetAchievement("Achieve23", out bool isUnlocked);
                    if (!isUnlocked)
                    {
                        SteamUserStats.SetAchievement("Achieve23");
                    }
                    SteamUserStats.StoreStats();
                    A23 = 1;
                    PlayerPrefs.SetInt("A23", 1);
                    PlayerPrefs.Save();
                }
            }
#endif
        }
    }
    public void JewelFall()
    {
        for (int i = 41; i >= 0; i--)
        {
            if (JewelNum[i + 7] == -1)
            {
                if (i < 35 && JewelNum[i + 14] == -1)
                {
                    if (i < 28 && JewelNum[i + 21] == -1)
                    {
                        if (i < 21 && JewelNum[i + 28] == -1)
                        {
                            if (i < 14 && JewelNum[i + 35] == -1)
                            {
                                if (i < 7 && JewelNum[i + 42] == -1)
                                {
                                    JewelDisplay[i + 42] = JewelDisplay[i];
                                    JewelDisplay[i] = null;
                                    JewelNum[i + 42] = JewelNum[i];
                                    JewelNum[i] = -1;
                                }
                                else
                                {
                                    JewelDisplay[i + 35] = JewelDisplay[i];
                                    JewelDisplay[i] = null;
                                    JewelNum[i + 35] = JewelNum[i];
                                    JewelNum[i] = -1;
                                }
                            }
                            else
                            {
                                JewelDisplay[i + 28] = JewelDisplay[i];
                                JewelDisplay[i] = null;
                                JewelNum[i + 28] = JewelNum[i];
                                JewelNum[i] = -1;
                            }
                        }
                        else
                        {
                            JewelDisplay[i + 21] = JewelDisplay[i];
                            JewelDisplay[i] = null;
                            JewelNum[i + 21] = JewelNum[i];
                            JewelNum[i] = -1;
                        }
                    }
                    else
                    {
                        JewelDisplay[i + 14] = JewelDisplay[i];
                        JewelDisplay[i] = null;
                        JewelNum[i + 14] = JewelNum[i];
                        JewelNum[i] = -1;
                    }
                }
                else
                {
                    JewelDisplay[i + 7] = JewelDisplay[i];
                    JewelDisplay[i] = null;
                    JewelNum[i + 7] = JewelNum[i];
                    JewelNum[i] = -1;
                }
            }
        }
        for (int i = 0; i < 49; i++)
        {
            if (JewelNum[i] == -1)
            {
                float Judge = Random.Range(0f, 100f);
                int j = 0;
                float j2 = 0;
                for (int k = 0; k < P.Length; k++)
                {
                    j2 += GemProb[k];
                    if (Judge < j2)
                    {
                        j = k;
                        break;
                    }
                }
                if (j >= 5)
                {
                    JewelNum[i] = AdditionalJewel[j - 5];
                }
                else
                {
                    JewelNum[i] = EquipJewel[j];
                }
                if(Gem128 == 1)
                {
                    Gem128 = 2;
                }
                if (Gem136 == 1)
                {
                    Gem136 = 2;
                }
                if (DayBreak > 0)
                {
                    float Judge2 = Random.Range(0f, 100f);
                    if(Judge2 < DayBreak)
                    {
                        JewelNum[i] = 303;
                    }
                }
                if (Blackstar > 0)
                {
                    float Judge2 = Random.Range(0f, 100f);
                    if (Judge2 < Blackstar)
                    {
                        JewelNum[i] = 310;
                    }
                }
                if (IsFrozenHound)
                {
                    JewelNum[i] = 306;
                }
                if(IsGemSlasher)
                {
                    if(Gscript.StolenGem == j)
                    {
                        JewelNum[i] = 309;
                    }
                }
                if (JewelNum[i] == 22)
                {
                    float Judge2 = Random.Range(0f, 100f);
                    if(Judge2 < 30f)
                    {
                        JewelNum[i] = 200;
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g22 = Instantiate(JewelFlash2[2]);
                            g22.transform.position = JewelPos[i % 7].position;
                            g22.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g22.SetActive(true);
                        }
                    }
                }
                if (JewelNum[i] == 67)
                {
                    float Judge2 = Random.Range(0f, 100f);
                    if (Judge2 < 40f)
                    {
                        JewelNum[i] = 200;
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g22 = Instantiate(JewelFlash2[2]);
                            g22.transform.position = JewelPos[i % 7].position;
                            g22.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g22.SetActive(true);
                        }
                    }
                }
                if (IsCitrine)
                {
                    JewelNum[i] = 40;
                }
                if (IsAgate)
                {
                    JewelNum[i] = 301;
                }
                GameObject g = Instantiate(JewelObj[JewelNum[i]]);
                g.transform.position = new Vector3(JewelPos[i].position.x, 4f, 0f);
                JewelDisplay[i] = g;
                g.transform.SetParent(this.transform, true);
            }
        }
        if (BurningHand)
        {
            BurningHand = false;
        }
        if (Gaze)
        {
            Gaze = false;
            Escript.Gaze = false;
        }
        if (Gem118 == 1)
        {
            Gem118 = 2;
        }
        if (Gem119 == 1)
        {
            Gem119 = 2;
        }
        if(Gem128 == 1)
        {
            Gem128 = 2;
        }
    }
    public void JewelSelect(int i)
    {
        if (PlayerRound && CurrentHand > 0 && !Bscript.IsDead && !Bscript.IsDefeat)
        {
            SelectNum = i;
            SelectObj[i].SetActive(true);
        }
    }
    public void JewelOutSelect(int i)
    {
        SelectObj[i].SetActive(false);
    }
    public void JewelHand(int i)
    {
        if (JewelNum[i] != 56 && !Bscript.IsDefeat)
        {
            if (Watcher_Sniper > 0)
            {
                JewelVanish(i);
                GameObject g2 = Instantiate(SaintSkillEffect[2]);
                g2.transform.position = JewelPos[i].position;
                g2.SetActive(true);
                for (int j = 0; j < JewelPos.Length; j++)
                {
                    JewelPos[j].GetComponent<Button>().interactable = false;
                }
            }
            else if (Fractal_Prism > 0)
            {
                JewelNum[i] = 200;
                GameObject g = Instantiate(JewelObj[200]);
                g.transform.position = JewelDisplay[i].transform.position;
                g.transform.SetParent(this.gameObject.transform, true);
                Destroy(JewelDisplay[i]);
                JewelDisplay[i] = g;

                GameObject g2 = Instantiate(SaintSkillEffect[4]);
                g2.transform.position = JewelPos[i].position;
                g2.SetActive(true);
            }
            else if (Collector_Skill > 0)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (JewelNum[i] == EquipJewel[j])
                    {
                        CollectorGem[j] += 1;
                        break;
                    }
                }
                JewelVanish(i);
                GameObject g2 = Instantiate(SaintSkillEffect[8]);
                g2.transform.position = JewelPos[i].position;
                g2.SetActive(true);
                for (int j = 0; j < JewelPos.Length; j++)
                {
                    JewelPos[j].GetComponent<Button>().interactable = false;
                }
            }
            else if (CollectorPut >= 0)
            {
                JewelNum[i] = EquipJewel[CollectorPut];
                GameObject g = Instantiate(JewelObj[EquipJewel[CollectorPut]]);
                g.transform.position = JewelDisplay[i].transform.position;
                g.transform.SetParent(this.gameObject.transform, true);
                Destroy(JewelDisplay[i]);
                JewelDisplay[i] = g;

                GameObject g2 = Instantiate(SaintSkillEffect[8]);
                g2.transform.position = JewelPos[i].position;
                g2.SetActive(true);
                CollectorGem[CollectorPut] -= 1;
                if (CollectorGem[CollectorPut] == 0)
                {
                    Invoke("CollectorReset", 0.05f);
                }
            }
            else if (CatalystPut)
            {
                if (CatalystNum[i] == 0)
                {
                    GameObject g6 = Instantiate(SaintSkillEffect[10]);
                    g6.transform.position = JewelPos[i].position;
                    g6.SetActive(true);
                    GameObject g6_2 = Instantiate(CatalystObj);
                    g6_2.transform.position = JewelPos[i].position;
                    g6_2.SetActive(true);
                    g6_2.GetComponent<CatalystCount>().Num = 20;
                    g6_2.transform.SetParent(this.transform, true);
                    if (Iscript.Crown >= 2)
                    {
                        CatalystNum[i] = 15;
                    }
                    else
                    {
                        CatalystNum[i] = 20;
                    }
                    CatalystDisplay[i] = g6_2;
                    for (int k = 0; k < 2; k++)
                    {
                        GameObject g6_3 = Instantiate(SaintSkillEffect[11]);
                        g6_3.transform.position = JewelPos[i].position;
                        g6_3.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                        g6_3.SetActive(true);
                    }
                    Invoke("C1", 0.05f);
                }
            }
            else if (Creator_Cell > 0)
            {
                if (JewelNum[i] < 200)
                {
                    GameObject g = Instantiate(JewelObj[201]);
                    g.transform.position = JewelDisplay[i].transform.position;
                    g.transform.SetParent(this.gameObject.transform, true);
                    Destroy(JewelDisplay[i]);
                    JewelDisplay[i] = g;
                    g.GetComponent<Gem_Cell>().Growth = 1;
                    g.GetComponent<Gem_Cell>().Num = JewelNum[i];
                    JewelNum[i] = 201;

                    GameObject g2 = Instantiate(SaintSkillEffect[18]);
                    g2.transform.position = JewelPos[i].position;
                    g2.SetActive(true);
                }
            }
            else if(MatrixSkill > 0)
            {
                MatrixGem[4] = JewelNum[i];
                if(i % 7 >= 1)
                {
                    MatrixGem[3] = JewelNum[i - 1];
                }
                else
                {
                    MatrixGem[3] = -1;
                }
                if (i % 7 <= 5)
                {
                    MatrixGem[5] = JewelNum[i + 1];
                }
                else
                {
                    MatrixGem[5] = -1;
                }
                if (i / 7 >= 1)
                {
                    MatrixGem[1] = JewelNum[i - 7];
                    if (i % 7 >= 1)
                    {
                        MatrixGem[0] = JewelNum[i - 8];
                    }
                    else
                    {
                        MatrixGem[0] = -1;
                    }
                    if (i % 7 <= 5)
                    {
                        MatrixGem[2] = JewelNum[i - 6];
                    }
                    else
                    {
                        MatrixGem[2] = -1;
                    }
                }
                else
                {
                    MatrixGem[0] = -1;
                    MatrixGem[1] = -1;
                    MatrixGem[2] = -1;
                }
                if (i / 7 <= 5)
                {
                    MatrixGem[7] = JewelNum[i + 7];
                    if (i % 7 >= 1)
                    {
                        MatrixGem[6] = JewelNum[i + 6];
                    }
                    else
                    {
                        MatrixGem[6] = -1;
                    }
                    if (i % 7 <= 5)
                    {
                        MatrixGem[8] = JewelNum[i + 8];
                    }
                    else
                    {
                        MatrixGem[8] = -1;
                    }
                }
                else
                {
                    MatrixGem[6] = -1;
                    MatrixGem[7] = -1;
                    MatrixGem[8] = -1;
                }
                for (int j = 0; j < 9; j++)
                {
                    if (MatrixGem[j] >= 200)
                    {
                        MatrixGem[j] = -1;
                        Matrixanim[j].gameObject.SetActive(false);
                    }
                }

                GameObject g2 = Instantiate(SaintSkillEffect[21]);
                g2.transform.position = JewelPos[i].position;
                g2.SetActive(true);
            }
            else if(MatrixAlter > 0)
            {
                MatrixChange(i, 4);
                if (i % 7 >= 1)
                {
                    MatrixChange(i - 1, 3);
                }
                if (i % 7 <= 5)
                {
                    MatrixChange(i + 1, 5);
                }
                if (i / 7 >= 1)
                {
                    MatrixChange(i - 7, 1);
                    if (i % 7 >= 1)
                    {
                        MatrixChange(i - 8, 0);
                    }
                    if (i % 7 <= 5)
                    {
                        MatrixChange(i - 6, 2);
                    }
                }
                if (i / 7 <= 5)
                {
                    MatrixChange(i + 7, 7);
                    if (i % 7 >= 1)
                    {
                        MatrixChange(i + 6, 6);
                    }
                    if (i % 7 <= 5)
                    {
                        MatrixChange(i + 8, 8);
                    }
                }

                GameObject g2 = Instantiate(SaintSkillEffect[21]);
                g2.transform.position = JewelPos[i].position;
                g2.SetActive(true);
            }
            else if (JewelNum[i] == 201)
            {
                if (JewelDisplay[i].GetComponent<Gem_Cell>().Growth >= 1)
                {
                    CreatorTransform2(i, JewelDisplay[i].GetComponent<Gem_Cell>().Num);
                }
                if (JewelDisplay[i].GetComponent<Gem_Cell>().Growth >= 2)
                {
                    CreatorTransform3(i, JewelDisplay[i].GetComponent<Gem_Cell>().Num);
                }
                if (JewelDisplay[i].GetComponent<Gem_Cell>().Growth >= 3)
                {
                    CreatorTransform4(i, JewelDisplay[i].GetComponent<Gem_Cell>().Num);
                }
                if (JewelDisplay[i].GetComponent<Gem_Cell>().Growth >= 4)
                {
                    CreatorTransform5(i, JewelDisplay[i].GetComponent<Gem_Cell>().Num);
                }
                CreatorTransform(i, JewelDisplay[i].GetComponent<Gem_Cell>().Num);
            }
            else
            {
                if (CurrentHand > 0 || ChainTime > 0f)
                {
                    C = i;
                    if ((JewelNum[C] == 60 || JewelNum[C] == 305) && Chain == 0)
                    {
                        CurrentHand -= 1;
                    }
                    if ((JewelNum[C] == 121) && Chain == 0)
                    {
                        CurrentHand -= 4;
                    }
                    C3 = JewelNum[C];
                    if (JewelNum[C] == 301)
                    {
                        IsAgate = true;
                    }
                    if (JewelNum[C] == 131 && Chain == 0)
                    {
                        for (int i3 = 0; i3 < Gem131; i3++)
                        {
                            int Judge = Random.Range(0, 49);
                            for (int i4 = 0; i4 < 100 && (JewelNum[Judge] == 200 || JewelNum[Judge] == 131); i4++)
                            {
                                Judge = Random.Range(0, 49);
                            }
                            JewelNum[Judge] = 200;
                            GameObject g4 = Instantiate(JewelObj[200]);
                            g4.transform.position = JewelDisplay[Judge].transform.position;
                            g4.transform.SetParent(gameObject.transform, true);
                            Destroy(JewelDisplay[Judge]);
                            JewelDisplay[Judge] = g4;
                            GameObject g4_2 = Instantiate(SaintRevengeEffect[2]);
                            g4_2.transform.position = JewelDisplay[Judge].transform.position;
                        }
                    }
                    if (JewelNum[C] == 135 && Chain == 0)
                    {
                        Gem135 += 2;
                    }
                    if (JewelNum[C] == 200 && Iscript.Saint == 4 && Iscript.Crown >= 5)
                    {
                        if (Iscript.PlayerMaxHP > 1)
                        {
                            Iscript.PlayerMaxHP -= 1;
                        }
                        if (Iscript.PlayerHP > Iscript.PlayerMaxHP)
                        {
                            Iscript.PlayerHP = Iscript.PlayerMaxHP;
                        }
                    }
                    if (JewelNum[C] == 201 && Iscript.Saint == 11 && Iscript.Crown >= 3)
                    {
                        CurrentHand -= 1;
                    }
                    GameObject g = Instantiate(JewelFlash[JewelNum[i]]);
                    g.transform.position = JewelPos[C].position;
                    g.SetActive(true);
                    for (int j = 0; j < 2; j++)
                    {
                        GameObject g2 = Instantiate(JewelFlash2[0]);
                        g2.transform.position = JewelPos[C].position;
                        g2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                        g2.SetActive(true);
                        if (Chain >= 8)
                        {
                            GameObject g3 = Instantiate(JewelFlash2[1]);
                            g3.transform.position = JewelPos[C].position;
                            g3.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g3.SetActive(true);
                        }
                    }
                    int C67 = 0;
                    if (Bscript.Iscript.Bless[57] == 1 && Chained <= 2 && Chained > 0 && Chain == 0)
                    {
                        C67 = 3;
                    }
                    if (JewelNum[i] == 102 && Chain == 0)
                    {
                        Chain += 3;
                    }
                    if (Bscript.Iscript.Bless[41] == 1 && Chain == 0)
                    {
                        Chain += 1;
                    }
                    Chain += 1 + C67;
                    if (JewelNum[C] != 78)
                    {
                        Chain += Gem78;
                        Gem78 = 0;
                    }
                    if (JewelNum[C] == 119)
                    {
                        if (Gem119 == 0)
                        {
                            Gem119 += 1;
                        }
                    }
                    else
                    {
                        Gem119 = 0;
                    }
                    JewelEffect(JewelNum[C], C);
                    if (BurningHand)
                    {
                        Iscript.Revenge += Mathf.FloorToInt(4f * Iscript.PlayerHPRate * Bless22);
                        GameObject g3 = Instantiate(SaintSkillEffect[5]);
                        g3.transform.position = JewelPos[C].position;
                        g3.SetActive(true);
                        Bscript.IsG = true;
                    }
                    if (Gaze)
                    {
                        GameObject g3 = Instantiate(SaintSkillEffect[9]);
                        g3.transform.position = JewelPos[C].position;
                        g3.SetActive(true);
                    }
                    if (OrderRev)
                    {
                        if (OrderNum[C] > 0)
                        {
                            GameObject g10 = Instantiate(AttackEffect);
                            g10.transform.position = JewelPos[i].position;
                            g10.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(70 + (Chain - 1) * 7f);
                            g10.GetComponent<BlockTrail>().GoPlayer = false;
                            g10.SetActive(true);
                            OrderNum[C] = 0;
                            Destroy(OrderDisplay[C]);
                        }
                    }
                    else
                    {
                        switch (OrderNum[C])
                        {
                            case 1:
                                GameObject g10 = Instantiate(AttackEffect);
                                g10.transform.position = JewelPos[i].position;
                                g10.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(70 + (Chain - 1) * 7f);
                                g10.GetComponent<BlockTrail>().GoPlayer = false;
                                g10.SetActive(true);
                                for (int j = 0; j < 49; j++)
                                {
                                    if (OrderNum[j] > 0)
                                    {
                                        OrderNum[j] -= 1;
                                        OrderDisplay[j].GetComponent<OrderCount>().Num -= 1;
                                        if (OrderNum[j] == 0)
                                        {
                                            GameObject g6 = Instantiate(SaintSkillEffect[15]);
                                            g6.transform.position = JewelPos[j].position;
                                            g6.SetActive(true);
                                            Destroy(OrderDisplay[j]);
                                        }
                                    }
                                }
                                break;
                            case > 1:
                                for (int j = 0; j < 49; j++)
                                {
                                    if (OrderNum[j] > 0)
                                    {
                                        GameObject g6 = Instantiate(SaintSkillEffect[17]);
                                        g6.transform.position = JewelPos[j].position;
                                        g6.SetActive(true);
                                    }
                                    OrderNum[j] = 0;
                                    Destroy(OrderDisplay[j]);
                                }
                                if(Iscript.Crown >= 3)
                                {
                                    Bscript.RoundEnd();
                                }
                                break;
                        }
                    }
                    if (Bscript.Iscript.Bless[36] == 1 && (Chain == 6 || Chain == 7))
                    {
                        Chain += 2;
                    }
                    if (Bscript.Iscript.Bless[48] == 1 && Chain % 5 == 0)
                    {
                        GameObject g4 = Instantiate(ShieldEffect);
                        g4.transform.position = this.transform.position;
                        g4.GetComponent<EffectScript>().EffectNum = 4;
                        g4.GetComponent<BlockTrail>().GoPlayer = true;
                        g4.SetActive(true);
                    }
                    JewelNum[i] = -1;
                    Destroy(JewelDisplay[C]);
                    ChainTime = 0.3f;
                    if (Chain >= 2)
                    {
                        ChainBonusText.text = ((Chain - 1) * 10).ToString() + "% Bonus";
                    }
                    else
                    {
                        ChainBonusText.text = "";
                    }
                    #if !UNITY_WEBGL

                    if(Chain >= 49)
                    {
                        if (SteamManager.Initialized)
                        {
                            SteamUserStats.GetAchievement("Achieve12", out bool isUnlocked);
                            if (!isUnlocked)
                            {
                                SteamUserStats.SetAchievement("Achieve12");
                            }
                            SteamUserStats.StoreStats();
                        }
                    }
#endif
                    Invoke("ChainHand", 0.1f);
                    for (int i2 = 0; i2 < JewelPos.Length; i2++)
                    {
                        JewelPos[i2].GetComponent<Button>().interactable = false;
                    }
                    if (IsCyberResistance)
                    {
                        Cscript.DisNoise(i);
                    }
                    if (IsBlackSniper)
                    {
                        Bscript2.TrackDetect(i);
                    }
                    if (IsJewelryFish)
                    {
                        Jscript.DisNoise(i);
                    }
                    if (IsAetherRizer)
                    {
                        Ascript.DisWind(i);
                    }
                }
            }
            Iscript.SE.PlayOneShot(CastSE1);
        }
    }
    public void JewelVanish(int i)
    {
        if (JewelNum[i] != 56)
        {
            Iscript.SE.PlayOneShot(CastSE1);
            C = i;
            C3 = JewelNum[C];
            if (JewelNum[C] == 301)
            {
                IsAgate = true;
            }
            GameObject g = Instantiate(JewelFlash[JewelNum[i]]);
            g.transform.position = JewelPos[C].position;
            g.SetActive(true);
            for (int j = 0; j < 2; j++)
            {
                GameObject g2 = Instantiate(JewelFlash2[0]);
                g2.transform.position = JewelPos[C].position;
                g2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                g2.SetActive(true);
                if (Chain >= 8)
                {
                    GameObject g3 = Instantiate(JewelFlash2[1]);
                    g3.transform.position = JewelPos[C].position;
                    g3.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                    g3.SetActive(true);
                }
            }
            Destroy(JewelDisplay[C]);
            Chain = 1;
            JewelEffect(JewelNum[C], C);
            JewelNum[i] = -1;
            ChainTime = 0.3f;
        }
    }
    void ChainHand()
    {
        for (int j = 0; j < ChainNum.Length; j++)
        {
            if (ChainNum[j] == -1)
            {
                ChainNum[j] = C;
                break;
            }
        }
        for (int i = 0; i < ChainNum.Length; i++)
        {
            int C2 = ChainNum[i];
            if (C2 == -1)
            {
                break;
            }
            else
            {
                if (C2 >= 7)
                {
                    if ((JewelNum[C2 - 7] == C3 || JewelNum[C2 - 7] == 200 || (C3 == 4 && JewelNum[C2 - 7] == 138) || (C3 == 138 && JewelNum[C2 - 7] == 4)
                         || (C3 == 2 && JewelNum[C2 - 7] == 139) || (C3 == 139 && JewelNum[C2 - 7] == 2)) && JewelNum[C2 - 7] != -1 && C3 != -1)
                    {
                        JewelNum[C2 - 7] = C3;
                        JewelHand(C2 - 7);
                        break;
                    }
                }
                if (C2 <= 41)
                {
                    if ((JewelNum[C2 + 7] == C3 || JewelNum[C2 + 7] == 200 || (C3 == 4 && JewelNum[C2 + 7] == 138) || (C3 == 138 && JewelNum[C2 + 7] == 4)
                         || (C3 == 2 && JewelNum[C2 + 7] == 139) || (C3 == 139 && JewelNum[C2 + 7] == 2)) && JewelNum[C2 + 7] != -1 && C3 != -1)
                    {
                        JewelNum[C2 + 7] = C3;
                        JewelHand(C2 + 7);
                        break;
                    }
                }
                if (C2 % 7 >= 1)
                {
                    if ((JewelNum[C2 - 1] == C3 || JewelNum[C2 - 1] == 200 || (C3 == 4 && JewelNum[C2 - 1] == 138) || (C3 == 138 && JewelNum[C2 - 1] == 4)
                         || (C3 == 2 && JewelNum[C2 - 1] == 139) || (C3 == 139 && JewelNum[C2 - 1] == 2)) && JewelNum[C2 - 1] != -1 && C3 != -1)
                    {
                        JewelNum[C2 - 1] = C3;
                        JewelHand(C2 - 1);
                        break;
                    }
                }
                if (C2 % 7 <= 5)
                {
                    if ((JewelNum[C2 + 1] == C3 || JewelNum[C2 + 1] == 200 || (C3 == 4 && JewelNum[C2 + 1] == 138) || (C3 == 138 && JewelNum[C2 + 1] == 4)
                         || (C3 == 2 && JewelNum[C2 + 1] == 139) || (C3 == 139 && JewelNum[C2 + 1] == 2)) && JewelNum[C2 + 1] != -1 && C3 != -1)
                    {
                        JewelNum[C2 + 1] = C3;
                        JewelHand(C2 + 1);
                        break;
                    }
                }
            }
        }
    }
    void JewelEffect(int i, int j)
    {
        if (Debuff_Void <= 0)
        {
            switch (i)
            {
                case 0:
                    GameObject g0 = Instantiate(AttackEffect);
                    g0.transform.position = JewelPos[j].position;
                    g0.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10 + Iscript.Bless[8] * (1 + Iscript.Bless[54]) + (Chain - 1)) * WeakNum);
                    for (int k = 0; k < 5; k++)
                    {
                        if (EquipJewel[k] == 94)
                        {
                            g0.GetComponent<EffectScript>().EffectNum += 2;
                            break;
                        }
                    }
                    g0.GetComponent<BlockTrail>().GoPlayer = false;
                    g0.SetActive(true);
                    break;
                case 2:
                    GameObject g1 = Instantiate(AttackEffect);
                    g1.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[29] == 1)
                    {
                        g1.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((15 + Iscript.Bless[8] * (1 + Iscript.Bless[54]) * 1.5f + (Chain - 1) * 2f) * WeakNum);
                    }
                    else
                    {
                        g1.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10 + Iscript.Bless[8] * (1 + Iscript.Bless[54]) + (Chain - 1)) * WeakNum);
                    }
                    for (int k = 0; k < 5; k++)
                    {
                        if (EquipJewel[k] == 94)
                        {
                            g1.GetComponent<EffectScript>().EffectNum += 2 + Bscript.Iscript.Bless[29];
                            break;
                        }
                    }
                    g1.GetComponent<BlockTrail>().GoPlayer = false;
                    g1.SetActive(true);
                    break;
                case 1:
                    GameObject g2 = Instantiate(AttackEffect);
                    g2.transform.position = JewelPos[j].position;
                    g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10 + Iscript.Bless[8] * (1 + Iscript.Bless[54]) + (Chain - 1)) * WeakNum);
                    for (int k = 0; k < 5; k++)
                    {
                        if (EquipJewel[k] == 94)
                        {
                            g2.GetComponent<EffectScript>().EffectNum += 2 + Bscript.Iscript.Bless[29];
                            break;
                        }
                    }
                    g2.GetComponent<BlockTrail>().GoPlayer = false;
                    g2.SetActive(true);
                    break;
                case 3:
                    GameObject g3 = Instantiate(ShieldEffect);
                    g3.transform.position = JewelPos[j].position;
                    g3.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((5 + Iscript.Bless[8] * (1 + Iscript.Bless[54]) + (Chain - 1) * 0.5f) * WeakNum);
                    for (int k = 0; k < 5; k++)
                    {
                        if (EquipJewel[k] == 94)
                        {
                            g3.GetComponent<EffectScript>().EffectNum += 2 + Bscript.Iscript.Bless[29];
                            break;
                        }
                    }
                    g3.GetComponent<BlockTrail>().GoPlayer = true;
                    g3.SetActive(true);
                    break;
                case 4:
                    GameObject g4 = Instantiate(ShieldEffect);
                    g4.transform.position = JewelPos[j].position;
                    g4.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((5 + Iscript.Bless[8] * (1 + Iscript.Bless[54]) + (Chain - 1) * 0.5f) * WeakNum);
                    for (int k = 0; k < 5; k++)
                    {
                        if (EquipJewel[k] == 94)
                        {
                            g4.GetComponent<EffectScript>().EffectNum += 2 + Bscript.Iscript.Bless[29];
                            break;
                        }
                    }
                    g4.GetComponent<BlockTrail>().GoPlayer = true;
                    g4.SetActive(true);
                    break;
                case 5:
                    GameObject g5 = Instantiate(AttackEffect);
                    g5.transform.position = JewelPos[j].position;
                    g5.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum * (1 + Iscript.Bless[54]));
                    g5.GetComponent<BlockTrail>().GoPlayer = false;
                    g5.SetActive(true);
                    break;
                case 6:
                    GameObject g7 = Instantiate(ShieldEffect);
                    g7.transform.position = JewelPos[j].position;
                    g7.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((8 + (Chain - 1) * 0.8f) * WeakNum * (1 + Iscript.Bless[54]));
                    g7.GetComponent<BlockTrail>().GoPlayer = true;
                    g7.SetActive(true);
                    break;
                case 7:
                    GameObject g6_1 = Instantiate(AttackEffect);
                    g6_1.transform.position = JewelPos[j].position;
                    g6_1.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((12 + (Chain - 1) * 1.2f) * WeakNum * (1 + Iscript.Bless[54]));
                    g6_1.GetComponent<BlockTrail>().GoPlayer = false;
                    g6_1.SetActive(true);
                    GameObject g6_2 = Instantiate(ShieldEffect);
                    g6_2.transform.position = JewelPos[j].position;
                    g6_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((2 + (Chain - 1) * 0.2f) * WeakNum * (1 + Iscript.Bless[54]));
                    g6_2.GetComponent<BlockTrail>().GoPlayer = true;
                    g6_2.SetActive(true);
                    break;
                case 8:
                    GameObject g8 = Instantiate(AttackEffect);
                    g8.transform.position = JewelPos[j].position;
                    g8.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((20 + (Chain - 1) * 2.0f) * WeakNum);
                    g8.GetComponent<BlockTrail>().GoPlayer = false;
                    g8.SetActive(true);
                    break;
                case 9:
                    GameObject g9 = Instantiate(ShieldEffect);
                    g9.transform.position = JewelPos[j].position;
                    g9.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10 + (Chain - 1.0f)) * WeakNum);
                    g9.GetComponent<BlockTrail>().GoPlayer = true;
                    g9.SetActive(true);
                    break;
                case 10:
                    GameObject g10 = Instantiate(AttackEffect);
                    g10.transform.position = JewelPos[j].position;
                    if (Chain == 1)
                    {
                        g10.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(45 * WeakNum);
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g10_2 = Instantiate(JewelFlash2[2]);
                            g10_2.transform.position = JewelPos[C].position;
                            g10_2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g10_2.SetActive(true);
                        }
                    }
                    else
                    {
                        g10.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((15 + (Chain - 1) * 1.5f) * WeakNum);
                    }
                    g10.GetComponent<BlockTrail>().GoPlayer = false;
                    g10.SetActive(true);
                    break;
                case 11:
                    if (Chain > 2)
                    {
                        GameObject g11 = Instantiate(ShieldEffect);
                        g11.transform.position = JewelPos[j].position;
                        g11.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((13 + (Chain - 1) * 1.3f) * WeakNum);
                        g11.GetComponent<BlockTrail>().GoPlayer = true;
                        g11.SetActive(true);
                    }
                    break;
                case 12:
                    GameObject g12 = Instantiate(HealEffect);
                    g12.transform.position = JewelPos[j].position;
                    g12.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((5 + (Chain - 1) * 0.5f) * WeakNum);
                    g12.GetComponent<BlockTrail>().GoPlayer = true;
                    g12.SetActive(true);
                    if (Iscript.Bless[3] == 1)
                    {
                        Bless3 += (5 + (Chain - 1) * 0.5f) * WeakNum * 0.1f;
                        if (Bless3 >= 1f)
                        {
                            Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                        }
                    }
                    break;
                case 13:
                    GameObject g13 = Instantiate(ShieldEffect);
                    g13.transform.position = JewelPos[j].position;
                    g13.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    g13.GetComponent<BlockTrail>().GoPlayer = true;
                    g13.SetActive(true);
                    GameObject g13_2 = Instantiate(RevengeEffect);
                    g13_2.transform.position = JewelPos[j].position;
                    g13_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((3 + (Chain - 1) * 0.3f) * WeakNum);
                    g13_2.GetComponent<BlockTrail>().GoPlayer = true;
                    g13_2.SetActive(true);
                    break;
                case 14:
                    GameObject g14 = Instantiate(ShieldEffect);
                    g14.transform.position = JewelPos[j].position;
                    g14.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((6 + (Chain - 1) * 0.6f) * WeakNum);
                    g14.GetComponent<BlockTrail>().GoPlayer = true;
                    g14.SetActive(true);
                    break;
                case 15:
                    GameObject g15 = Instantiate(AttackEffect);
                    g15.transform.position = JewelPos[j].position;
                    g15.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10 + (Chain - 1) * 3f) * WeakNum);
                    g15.GetComponent<BlockTrail>().GoPlayer = false;
                    g15.SetActive(true);
                    break;
                case 16:
                    GameObject g16 = Instantiate(AttackEffect);
                    g16.transform.position = JewelPos[j].position;
                    g16.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((12 + (Chain - 1) * 1.2f) * WeakNum);
                    g16.GetComponent<BlockTrail>().GoPlayer = false;
                    g16.SetActive(true);
                    if (Chain == 7)
                    {
                        CurrentHand += 1;
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g16_2 = Instantiate(JewelFlash2[2]);
                            g16_2.transform.position = JewelPos[C].position;
                            g16_2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g16_2.SetActive(true);
                        }
                    }
                    break;
                case 17:
                    GameObject g17 = Instantiate(AttackEffect);
                    g17.transform.position = JewelPos[j].position;
                    g17.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(8 + (2 * CurrentTurnHand) + (Chain - 1) * (0.8f + 0.2f * CurrentTurnHand));
                    g17.GetComponent<BlockTrail>().GoPlayer = false;
                    g17.SetActive(true);
                    break;
                case 18:
                    GameObject g18 = Instantiate(AttackEffect);
                    g18.transform.position = JewelPos[j].position;
                    g18.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(28 * WeakNum);
                    g18.GetComponent<BlockTrail>().GoPlayer = false;
                    g18.SetActive(true);
                    break;
                case 19:
                    GameObject g19 = Instantiate(ShieldEffect);
                    g19.transform.position = JewelPos[j].position;
                    g19.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((17 + (Chain - 1) * 1.7f) * WeakNum);
                    g19.GetComponent<BlockTrail>().GoPlayer = true;
                    g19.SetActive(true);
                    break;
                case 20:
                    GameObject g20 = Instantiate(ShieldEffect);
                    g20.transform.position = JewelPos[j].position;
                    g20.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((5 + (Chain - 1) * 0.5f) * WeakNum);
                    g20.GetComponent<BlockTrail>().GoPlayer = true;
                    g20.SetActive(true);
                    break;
                case 21:
                    if (Chain <= 5)
                    {
                        GameObject g21 = Instantiate(ShieldEffect);
                        g21.transform.position = JewelPos[j].position;
                        g21.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                        g21.GetComponent<BlockTrail>().GoPlayer = true;
                        g21.SetActive(true);
                    }
                    break;
                case 22:
                    GameObject g22 = Instantiate(AttackEffect);
                    g22.transform.position = JewelPos[j].position;
                    g22.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                    g22.GetComponent<BlockTrail>().GoPlayer = false;
                    g22.SetActive(true);
                    break;
                case 23:
                    GameObject g23 = Instantiate(AttackEffect);
                    g23.transform.position = JewelPos[j].position;
                    g23.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((4 * Chained) + (Chain - 1) * 0.4f * Chained);
                    g23.GetComponent<BlockTrail>().GoPlayer = false;
                    g23.SetActive(true);
                    break;
                case 24:
                    GameObject g24_1 = Instantiate(AttackEffect);
                    g24_1.transform.position = JewelPos[j].position;
                    g24_1.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10 + (Chain - 1) * 1f) * WeakNum);
                    g24_1.GetComponent<BlockTrail>().GoPlayer = false;
                    g24_1.SetActive(true);
                    GameObject g24_2 = Instantiate(ShieldEffect);
                    g24_2.transform.position = JewelPos[j].position;
                    g24_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((5 + (Chain - 1) * 0.5f) * WeakNum);
                    g24_2.GetComponent<BlockTrail>().GoPlayer = true;
                    g24_2.SetActive(true);
                    break;
                case 25:
                    int j25 = 0;
                    for (int i25 = 0; i25 < 49; i25++)
                    {
                        if (JewelNum[i25] == 25)
                        {
                            j25 += 1;
                        }
                    }
                    GameObject g25 = Instantiate(ShieldEffect);
                    g25.transform.position = JewelPos[j].position;
                    g25.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((j25 + (Chain - 1) * j25 * 0.1f) * WeakNum);
                    g25.GetComponent<BlockTrail>().GoPlayer = true;
                    g25.SetActive(true);
                    break;
                case 26:
                    GameObject g26 = Instantiate(AttackEffect);
                    g26.transform.position = JewelPos[j].position;
                    g26.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(14 + (Chain - 1) * 1.4f);
                    g26.GetComponent<BlockTrail>().GoPlayer = false;
                    g26.SetActive(true);
                    break;
                case 27:
                    GameObject g27_1 = Instantiate(ShieldEffect);
                    g27_1.transform.position = JewelPos[j].position;
                    g27_1.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((6 + (Chain - 1) * 0.6f) * WeakNum);
                    g27_1.GetComponent<BlockTrail>().GoPlayer = true;
                    g27_1.SetActive(true);
                    GameObject g27_2 = Instantiate(HealEffect);
                    g27_2.transform.position = JewelPos[j].position;
                    g27_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((2 + (Chain - 1) * 0.2f) * WeakNum);
                    g27_2.GetComponent<BlockTrail>().GoPlayer = true;
                    g27_2.SetActive(true);
                    if (Iscript.Bless[3] == 1)
                    {
                        Bless3 += (2 + (Chain - 1) * 0.2f) * WeakNum * 0.1f;
                        if (Bless3 >= 1f)
                        {
                            Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                        }
                    }
                    break;
                case 28:
                    GameObject g28_1 = Instantiate(AttackEffect);
                    g28_1.transform.position = JewelPos[j].position;
                    g28_1.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(26 + (Chain - 1) * 2.6f);
                    g28_1.GetComponent<BlockTrail>().GoPlayer = false;
                    g28_1.SetActive(true);
                    if (Iscript.PlayerHP > 2)
                    {
                        Iscript.PlayerHP -= 2;
                    }
                    break;
                case 29:
                    GameObject g29 = Instantiate(AttackEffect);
                    g29.transform.position = JewelPos[j].position;
                    g29.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((Bscript.PlayerShield / 10f) + (Chain - 1) * (Bscript.PlayerShield / 100f));
                    g29.GetComponent<BlockTrail>().GoPlayer = false;
                    g29.SetActive(true);
                    break;
                case 30:
                    GameObject g30 = Instantiate(AttackEffect);
                    g30.transform.position = JewelPos[j].position;
                    if (j30 % 2 == 1)
                    {
                        g30.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(28 + (Chain - 1) * 2.8f);
                    }
                    else
                    {
                        g30.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(14 + (Chain - 1) * 1.4f);
                    }
                    g30.GetComponent<BlockTrail>().GoPlayer = false;
                    g30.SetActive(true);
                    break;
                case 31:
                    GameObject g31 = Instantiate(ShieldEffect);
                    g31.transform.position = JewelPos[j].position;
                    if (j30 % 2 == 0)
                    {
                        g31.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(14 + (Chain - 1) * 1.4f);
                    }
                    else
                    {
                        g31.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(7 + (Chain - 1) * 0.7f);
                    }
                    g31.GetComponent<BlockTrail>().GoPlayer = true;
                    g31.SetActive(true);
                    break;
                case 32:
                    int j32 = Random.Range(5, 41);
                    GameObject g32 = Instantiate(AttackEffect);
                    g32.transform.position = JewelPos[j].position;
                    g32.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(j32 + (Chain - 1) * (j32 / 10f));
                    g32.GetComponent<BlockTrail>().GoPlayer = false;
                    g32.SetActive(true);
                    break;
                case 33:
                    GameObject g33 = Instantiate(ShieldEffect);
                    g33.transform.position = JewelPos[j].position;
                    g33.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((12 + (Chain - 1) * 1.2f) * WeakNum);
                    g33.GetComponent<BlockTrail>().GoPlayer = true;
                    g33.SetActive(true);
                    if (Iscript.PlayerHP > 1)
                    {
                        Iscript.PlayerHP -= 1;
                    }
                    break;
                case 34:
                    GameObject g34 = Instantiate(AttackEffect);
                    g34.transform.position = JewelPos[j].position;
                    g34.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((28 + (Chain - 1) * 2.8f) * WeakNum);
                    g34.GetComponent<BlockTrail>().GoPlayer = false;
                    g34.SetActive(true);
                    if (Chain == 7)
                    {
                        CurrentHand -= 2;
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g34_2 = Instantiate(JewelFlash2[2]);
                            g34_2.transform.position = JewelPos[C].position;
                            g34_2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g34_2.SetActive(true);
                        }
                    }
                    break;
                case 35:
                    GameObject g35 = Instantiate(RevengeEffect);
                    g35.transform.position = JewelPos[j].position;
                    g35.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((11 + (Chain - 1) * 1.1f) * WeakNum);
                    g35.GetComponent<BlockTrail>().GoPlayer = true;
                    g35.SetActive(true);
                    break;
                case 36:
                    GameObject g36 = Instantiate(HealEffect);
                    g36.transform.position = JewelPos[j].position;
                    g36.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((3 + (Chain - 1) * 0.3f) * WeakNum);
                    g36.GetComponent<BlockTrail>().GoPlayer = true;
                    g36.SetActive(true);
                    if (Iscript.Bless[3] == 1)
                    {
                        Bless3 += (3 + (Chain - 1) * 0.3f) * WeakNum * 0.1f;
                        if (Bless3 >= 1f)
                        {
                            Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                        }
                    }
                    GameObject g36_2 = Instantiate(RevengeEffect);
                    g36_2.transform.position = JewelPos[j].position;
                    g36_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((4 + (Chain - 1) * 0.4f) * WeakNum);
                    g36_2.GetComponent<BlockTrail>().GoPlayer = true;
                    g36_2.SetActive(true);
                    break;
                case 37:
                    GameObject g37 = Instantiate(AttackEffect);
                    g37.transform.position = JewelPos[j].position;
                    g37.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                    g37.GetComponent<BlockTrail>().GoPlayer = false;
                    g37.SetActive(true);
                    break;
                case 38:
                    GameObject g38 = Instantiate(AttackEffect);
                    g38.transform.position = JewelPos[j].position;
                    g38.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((14 + (Chain - 1) * 1.4f) * WeakNum);
                    g38.GetComponent<BlockTrail>().GoPlayer = false;
                    g38.SetActive(true);
                    if (Chain == 16)
                    {
                        ActiveSkill = 1;
                        SkillDisplay();
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g38_2 = Instantiate(JewelFlash2[2]);
                            g38_2.transform.position = JewelPos[C].position;
                            g38_2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g38_2.SetActive(true);
                        }
                    }
                    break;
                case 39:
                    GameObject g39 = Instantiate(AttackEffect);
                    g39.transform.position = JewelPos[j].position;
                    g39.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((30 + (Chain - 1) * 3.0f) * WeakNum);
                    g39.GetComponent<BlockTrail>().GoPlayer = false;
                    g39.SetActive(true);
                    if (Iscript.PlayerMaxHP > 2)
                    {
                        Iscript.PlayerMaxHP -= 2;
                    }
                    else if(Iscript.PlayerMaxHP > 1)
                    {
                        Iscript.PlayerMaxHP -= 1;
                    }
                    if (Iscript.PlayerHP > Iscript.PlayerMaxHP)
                    {
                        Iscript.PlayerHP = Iscript.PlayerMaxHP;
                    }
                    break;
                case 40:
                    GameObject g40 = Instantiate(AttackEffect);
                    g40.transform.position = JewelPos[j].position;
                    g40.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                    g40.GetComponent<BlockTrail>().GoPlayer = false;
                    g40.SetActive(true);
                    if (Chain >= 6)
                    {
                        IsCitrine = false;
                    }
                    else
                    {
                        IsCitrine = true;
                    }
                    break;
                case 41:
                    Iscript.PlayerMaxHP += 2;
                    break;
                case 42:
                    GameObject g42 = Instantiate(ShieldEffect);
                    g42.transform.position = JewelPos[j].position;
                    g42.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((13 + (Chain - 1) * 1.3f) * WeakNum);
                    g42.GetComponent<BlockTrail>().GoPlayer = true;
                    g42.SetActive(true);
                    Iscript.Revenge -= 2;
                    if (Iscript.Revenge < 0)
                    {
                        Iscript.Revenge = 0;
                    }
                    break;
                case 43:
                    GameObject g43 = Instantiate(AttackEffect);
                    g43.transform.position = JewelPos[j].position;
                    if (Iscript.PlayerHP == Iscript.PlayerMaxHP)
                    {
                        g43.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(32 + (Chain - 1) * 3.2f);
                    }
                    else
                    {
                        g43.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(16 + (Chain - 1) * 1.6f);
                    }
                    g43.GetComponent<BlockTrail>().GoPlayer = false;
                    g43.SetActive(true);
                    break;
                case 44:
                    GameObject g44 = Instantiate(ShieldEffect);
                    g44.transform.position = JewelPos[j].position;
                    if (Iscript.PlayerHP <= Iscript.PlayerMaxHP * 0.25f || Iscript.Bless[42] == 1)
                    {
                        g44.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(16 + (Chain - 1) * 1.6f);
                    }
                    else
                    {
                        g44.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(8 + (Chain - 1) * 0.8f);
                    }
                    g44.GetComponent<BlockTrail>().GoPlayer = true;
                    g44.SetActive(true);
                    break;
                case 45:
                    GameObject g45 = Instantiate(ShieldEffect);
                    g45.transform.position = JewelPos[j].position;
                    g45.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    g45.GetComponent<BlockTrail>().GoPlayer = true;
                    g45.SetActive(true);
                    Chain += 1;
                    break;
                case 46:
                    GameObject g46 = Instantiate(AttackEffect);
                    g46.transform.position = JewelPos[j].position;
                    g46.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((17 + (Chain - 1) * 1.7f) * WeakNum);
                    g46.GetComponent<BlockTrail>().GoPlayer = false;
                    g46.SetActive(true);
                    if (Debuff_Weak > 0)
                    {
                        if (Bscript.Iscript.Bless[25] == 1)
                        {
                            Debuff_Weak -= 8;
                        }
                        else
                        {
                            Debuff_Weak -= 4;
                        }
                        if (Debuff_Weak < 0)
                        {
                            Debuff_Weak = 0;
                        }
                    }
                    break;
                case 47:
                    GameObject g47 = Instantiate(ShieldEffect);
                    g47.transform.position = JewelPos[j].position;
                    g47.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((5 + (Chain - 1) * 0.5f) * WeakNum);
                    g47.GetComponent<BlockTrail>().GoPlayer = true;
                    g47.SetActive(true);
                    if (Chain == 9)
                    {
                        CurrentHand += 2;
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g47_2 = Instantiate(JewelFlash2[2]);
                            g47_2.transform.position = JewelPos[C].position;
                            g47_2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g47_2.SetActive(true);
                        }
                    }
                    break;
                case 48:
                    GameObject g48 = Instantiate(AttackEffect);
                    g48.transform.position = JewelPos[j].position;
                    g48.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(((6 * Bscript.CurrentRound) + (Chain - 1) * (0.6f * Bscript.CurrentRound)) * WeakNum);
                    g48.GetComponent<BlockTrail>().GoPlayer = false;
                    g48.SetActive(true);
                    break;
                case 49:
                    GameObject g49 = Instantiate(ShieldEffect);
                    g49.transform.position = JewelPos[j].position;
                    g49.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    g49.GetComponent<BlockTrail>().GoPlayer = true;
                    g49.SetActive(true);
                    break;
                case 50:
                    GameObject g50 = Instantiate(AttackEffect);
                    g50.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[29] == 1)
                    {
                        g50.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((19.5f + (Chain - 1) * 1.95f) * WeakNum);
                    }
                    else
                    {
                        g50.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((13 + (Chain - 1) * 1.3f) * WeakNum);
                    }
                    g50.GetComponent<BlockTrail>().GoPlayer = false;
                    g50.SetActive(true);
                    GameObject g50_2 = Instantiate(RevengeEffect);
                    g50_2.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[29] == 1)
                    {
                        g50_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((6 + (Chain - 1) * 0.6f) * WeakNum);
                    }
                    else
                    {
                        g50_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((4 + (Chain - 1) * 0.4f) * WeakNum);
                    }
                    g50_2.GetComponent<BlockTrail>().GoPlayer = true;
                    g50_2.SetActive(true);
                    break;
                case 51:
                    GameObject g51 = Instantiate(ShieldEffect);
                    g51.transform.position = JewelPos[j].position;
                    g51.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((14 + (Chain - 1) * 1.4f) * WeakNum);
                    g51.GetComponent<BlockTrail>().GoPlayer = true;
                    g51.SetActive(true);
                    GameObject g51_2 = Instantiate(ShieldEffect);
                    g51_2.transform.position = JewelPos[j].position;
                    g51_2.GetComponent<EffectScript>().EffectNum = 14;
                    g51_2.GetComponent<BlockTrail>().GoPlayer = false;
                    g51_2.SetActive(true);
                    break;
                case 52:
                    GameObject g52 = Instantiate(ShieldEffect);
                    g52.transform.position = JewelPos[j].position;
                    g52.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((PlayerPrefs.GetInt("Gem53", 5) + (Chain - 1) * PlayerPrefs.GetInt("Gem53", 5) * 0.1f) * WeakNum);
                    g52.GetComponent<BlockTrail>().GoPlayer = true;
                    g52.SetActive(true);
                    if (Chain == 12)
                    {
                        PlayerPrefs.SetInt("Gem53", PlayerPrefs.GetInt("Gem53", 5) + 1);
                        PlayerPrefs.Save();
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g52_2 = Instantiate(JewelFlash2[2]);
                            g52_2.transform.position = JewelPos[C].position;
                            g52_2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g52_2.SetActive(true);
                        }
                    }
                    break;
                case 53:
                    GameObject g53 = Instantiate(AttackEffect);
                    g53.transform.position = JewelPos[j].position;
                    g53.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((Gem54 + (Chain - 1) * Gem54 * 0.1f) * WeakNum);
                    g53.GetComponent<BlockTrail>().GoPlayer = false;
                    g53.SetActive(true);
                    Gem54 -= 1;
                    PlayerPrefs.SetInt("Gem54", Gem54);
                    PlayerPrefs.Save();
                    break;
                case 54:
                    GameObject g54 = Instantiate(AttackEffect);
                    g54.transform.position = JewelPos[j].position;
                    g54.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((15 + (Chain - 1) * 1.5f) * WeakNum);
                    g54.GetComponent<BlockTrail>().GoPlayer = false;
                    g54.SetActive(true);
                    if (Chain == 17)
                    {
                        Gem55 *= 2;
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g = Instantiate(JewelFlash2[2]);
                            g.transform.position = JewelPos[C].position;
                            g.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g.SetActive(true);
                        }
                    }
                    break;
                case 55:
                    GameObject g55 = Instantiate(AttackEffect);
                    g55.transform.position = JewelPos[j].position;
                    g55.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((PlayerPrefs.GetInt("HPLose", 0) + (Chain - 1) * (PlayerPrefs.GetInt("HPLose", 0) * 0.1f)) * WeakNum);
                    g55.GetComponent<BlockTrail>().GoPlayer = false;
                    g55.SetActive(true);
                    break;
                case 56:
                    break;
                case 57:
                    if (Bscript.Iscript.PlayerHP < Bscript.Iscript.PlayerMaxHP / 2 || Iscript.Bless[42] == 1)
                    {
                        GameObject g57 = Instantiate(ShieldEffect);
                        g57.transform.position = JewelPos[j].position;
                        g57.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((19 + (Chain - 1) * 1.9f) * WeakNum);
                        g57.GetComponent<BlockTrail>().GoPlayer = true;
                        g57.SetActive(true);
                    }
                    break;
                case 58:
                    if (Chain > 4)
                    {
                        GameObject g58 = Instantiate(AttackEffect);
                        g58.transform.position = JewelPos[j].position;
                        g58.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((29 + (Chain - 1) * 2.9f) * WeakNum);
                        g58.GetComponent<BlockTrail>().GoPlayer = false;
                        g58.SetActive(true);
                    }
                    break;
                case 59:
                    GameObject g59 = Instantiate(RevengeEffect);
                    g59.transform.position = JewelPos[j].position;
                    g59.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 0.16f) * WeakNum);
                    g59.GetComponent<BlockTrail>().GoPlayer = true;
                    g59.SetActive(true);
                    if (Iscript.PlayerHP > 3)
                    {
                        Iscript.PlayerHP -= 3;
                    }
                    break;
                case 60:
                    GameObject g60 = Instantiate(ShieldEffect);
                    g60.transform.position = JewelPos[j].position;
                    g60.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((18 + (Chain - 1) * 1.8f) * WeakNum);
                    g60.GetComponent<BlockTrail>().GoPlayer = true;
                    g60.SetActive(true);
                    break;
                case 61:
                    GameObject g61 = Instantiate(AttackEffect);
                    g61.transform.position = JewelPos[j].position;
                    if (CurrentHand >= 5)
                    {
                        g61.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((28 + (Chain - 1) * 2.8f) * WeakNum);
                    }
                    else
                    {
                        g61.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((14 + (Chain - 1) * 1.4f) * WeakNum);
                    }
                    g61.GetComponent<BlockTrail>().GoPlayer = false;
                    g61.SetActive(true);
                    break;
                case 62:
                    GameObject g62 = Instantiate(ShieldEffect);
                    g62.transform.position = JewelPos[j].position;
                    if (CurrentHand <= 4)
                    {
                        g62.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((14 + (Chain - 1) * 1.4f) * WeakNum);
                    }
                    else
                    {
                        g62.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    }
                    g62.GetComponent<BlockTrail>().GoPlayer = true;
                    g62.SetActive(true);
                    break;
                case 63:
                    GameObject g63 = Instantiate(AttackEffect);
                    g63.transform.position = JewelPos[j].position;
                    if ((Iscript.JewelNum[0] == 63 && GemProb[0] <= 15f) || (Iscript.JewelNum[1] == 63 && GemProb[1] <= 15f) || (Iscript.JewelNum[2] == 63 && GemProb[2] <= 15f) ||
                        (Iscript.JewelNum[3] == 63 && GemProb[3] <= 15f) || (Iscript.JewelNum[4] == 63 && GemProb[4] <= 15f))
                    {
                        g63.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((34 + (Chain - 1) * 3.6f) * WeakNum);
                    }
                    else
                    {
                        g63.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((17 + (Chain - 1) * 1.8f) * WeakNum);
                    }
                    g63.GetComponent<BlockTrail>().GoPlayer = false;
                    g63.SetActive(true);
                    break;
                case 64:
                    GameObject g64 = Instantiate(ShieldEffect);
                    g64.transform.position = JewelPos[j].position;
                    if ((Iscript.JewelNum[0] == 64 && GemProb[0] >= 30f) || (Iscript.JewelNum[1] == 64 && GemProb[1] >= 30f) || (Iscript.JewelNum[2] == 64 && GemProb[2] >= 30f) ||
                        (Iscript.JewelNum[3] == 64 && GemProb[3] >= 30f) || (Iscript.JewelNum[4] == 64 && GemProb[4] >= 30f))
                    {
                        g64.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                    }
                    else
                    {
                        g64.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((8 + (Chain - 1) * 0.8f) * WeakNum);
                    }
                    g64.GetComponent<BlockTrail>().GoPlayer = true;
                    g64.SetActive(true);
                    break;
                case 65:
                    if (Chain % 4 == 0)
                    {
                        CurrentHand += 1;
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g = Instantiate(JewelFlash2[2]);
                            g.transform.position = JewelPos[C].position;
                            g.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g.SetActive(true);
                        }
                    }
                    break;
                case 66:
                    GameObject g66 = Instantiate(AttackEffect);
                    g66.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[42] == 1)
                    {
                        g66.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((40 + (Chain - 1) * 4f) * WeakNum);
                    }
                    else
                    {
                        g66.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((5 + 35 * (Iscript.PlayerMaxHP - Iscript.PlayerHP) / Iscript.PlayerMaxHP +
                        (Chain - 1) * 0.1f * (5 + 35 * (Iscript.PlayerMaxHP - Iscript.PlayerHP) / Iscript.PlayerMaxHP)) * WeakNum);
                    }
                    g66.GetComponent<BlockTrail>().GoPlayer = false;
                    g66.SetActive(true);
                    break;
                case 67:
                    GameObject g67 = Instantiate(ShieldEffect);
                    g67.transform.position = JewelPos[j].position;
                    g67.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((5 + (Chain - 1) * 0.5f) * WeakNum);
                    g67.GetComponent<BlockTrail>().GoPlayer = true;
                    g67.SetActive(true);
                    break;
                case 68:
                    GameObject g68 = Instantiate(AttackEffect);
                    g68.transform.position = JewelPos[j].position;
                    if (Bscript.CurrentRound >= 3)
                    {
                        g68.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((26 + (Chain - 1) * 2.6f) * WeakNum);
                    }
                    else
                    {
                        g68.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((13 + (Chain - 1) * 1.3f) * WeakNum);
                    }
                    g68.GetComponent<BlockTrail>().GoPlayer = false;
                    g68.SetActive(true);
                    break;
                case 69:
                    GameObject g69 = Instantiate(ShieldEffect);
                    g69.transform.position = JewelPos[j].position;
                    if (Bscript.CurrentRound <= 2)
                    {
                        g69.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                    }
                    else
                    {
                        g69.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((8 + (Chain - 1) * 0.8f) * WeakNum);
                    }
                    g69.GetComponent<BlockTrail>().GoPlayer = true;
                    g69.SetActive(true);
                    break;
                case 70:
                    GameObject g70 = Instantiate(AttackEffect);
                    g70.transform.position = JewelPos[j].position;
                    g70.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((PlayerPrefs.GetInt("Gem70", 50) + (Chain - 1) * 0.1f * PlayerPrefs.GetInt("Gem70", 50)) * WeakNum);
                    g70.GetComponent<BlockTrail>().GoPlayer = false;
                    g70.SetActive(true);
                    PlayerPrefs.SetInt("Gem70", Mathf.Max(PlayerPrefs.GetInt("Gem70", 50) - 1, 0));
                    PlayerPrefs.Save();
                    break;
                case 71:
                    GameObject g71 = Instantiate(ShieldEffect);
                    g71.transform.position = JewelPos[j].position;
                    g71.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((4 + 12 * Iscript.PlayerHP / Iscript.PlayerMaxHP + (Chain - 1) * 0.1f *
                        (4 + 12 * Iscript.PlayerHP / Iscript.PlayerMaxHP)) * WeakNum);
                    g71.GetComponent<BlockTrail>().GoPlayer = true;
                    g71.SetActive(true);
                    break;
                case 72:
                    int i72 = 16;
                    for (int j72 = 0; j72 < 5; j72++)
                    {
                        if (EquipJewel[j72] == 19 || EquipJewel[j72] == 63 || EquipJewel[j72] == 76 || EquipJewel[j72] == 82 ||
                            EquipJewel[j72] == 87 || EquipJewel[j72] == 88 || EquipJewel[j72] == 93)
                        {
                            i72 += 8;
                        }
                    }
                    GameObject g72 = Instantiate(AttackEffect);
                    g72.transform.position = JewelPos[j].position;
                    g72.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((i72 + (Chain - 1) * 0.1f * i72) * WeakNum);
                    g72.GetComponent<BlockTrail>().GoPlayer = false;
                    g72.SetActive(true);
                    break;
                case 73:
                    GameObject g73 = Instantiate(AttackEffect);
                    g73.transform.position = JewelPos[j].position;
                    if (Chain == 10)
                    {
                        g73.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((130 + (Chain - 1) * 13f) * WeakNum);
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g10_2 = Instantiate(JewelFlash2[2]);
                            g10_2.transform.position = JewelPos[C].position;
                            g10_2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g10_2.SetActive(true);
                        }
                    }
                    else
                    {
                        g73.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((13 + (Chain - 1) * 1.3f) * WeakNum);
                    }
                    g73.GetComponent<BlockTrail>().GoPlayer = false;
                    g73.SetActive(true);
                    break;
                case 74:
                    GameObject g74_1 = Instantiate(AttackEffect);
                    g74_1.transform.position = JewelPos[j].position;
                    g74_1.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((15 + (Chain - 1) * 1.5f) * WeakNum);
                    g74_1.GetComponent<BlockTrail>().GoPlayer = false;
                    g74_1.SetActive(true);
                    GameObject g74_2 = Instantiate(ShieldEffect);
                    g74_2.transform.position = JewelPos[j].position;
                    g74_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((8 + (Chain - 1) * 0.8f) * WeakNum);
                    g74_2.GetComponent<BlockTrail>().GoPlayer = true;
                    g74_2.SetActive(true);
                    if (Iscript.PlayerHP > 2)
                    {
                        Iscript.PlayerHP -= 2;
                    }
                    break;
                case 75:
                    GameObject g75 = Instantiate(HealEffect);
                    g75.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[29] == 1)
                    {
                        g75.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10.5f + (Chain - 1) * 1.05f) * WeakNum);
                    }
                    else
                    {
                        g75.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    }
                    g75.GetComponent<BlockTrail>().GoPlayer = true;
                    g75.SetActive(true);
                    if (Iscript.Bless[3] == 1)
                    {
                        Bless3 += (7 + (Chain - 1) * 0.7f) * WeakNum * 0.1f;
                        if (Bless3 >= 1f)
                        {
                            Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                        }
                    }
                    Bscript.PlayerShield -= 4;
                    if (Bscript.PlayerShield < 0)
                    {
                        Bscript.PlayerShield = 0;
                    }
                    break;
                case 76:
                    GameObject g76 = Instantiate(AttackEffect);
                    g76.transform.position = JewelPos[j].position;
                    g76.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((17 + (Chain - 1) * 1.7f) * WeakNum);
                    g76.GetComponent<BlockTrail>().GoPlayer = false;
                    g76.SetActive(true);
                    g76.GetComponent<EffectScript>().Gem76 = true;
                    break;
                case 77:
                    GameObject g77 = Instantiate(AttackEffect);
                    g77.transform.position = JewelPos[j].position;
                    if (Bscript.EnemyShield > 0)
                    {
                        g77.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((34 + (Chain - 1) * 3.4f) * WeakNum);
                    }
                    else
                    {
                        g77.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((17 + (Chain - 1) * 1.7f) * WeakNum);
                    }
                    g77.GetComponent<BlockTrail>().GoPlayer = false;
                    g77.SetActive(true);
                    break;
                case 78:
                    GameObject g78 = Instantiate(ShieldEffect);
                    g78.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[29] == 1)
                    {
                        g78.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10.5f + (Chain - 1) * 1.05f) * WeakNum);
                    }
                    else
                    {
                        g78.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    }
                    g78.GetComponent<BlockTrail>().GoPlayer = true;
                    g78.SetActive(true);
                    Gem78 += 1;
                    break;
                case 79:
                    GameObject g79 = Instantiate(ShieldEffect);
                    g79.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[29] == 1)
                    {
                        g79.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((13.5f + (Chain - 1) * 1.35f) * WeakNum);
                    }
                    else
                    {
                        g79.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((9 + (Chain - 1) * 0.9f) * WeakNum);
                    }
                    g79.GetComponent<BlockTrail>().GoPlayer = true;
                    g79.SetActive(true);
                    break;
                case 80:
                    int i80 = 12;
                    for (int j80 = 0; j80 < 5; j80++)
                    {
                        if (EquipJewel[j80] <= 4)
                        {
                            i80 += 6;
                        }
                    }
                    GameObject g80 = Instantiate(AttackEffect);
                    g80.transform.position = JewelPos[j].position;
                    g80.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((i80 + (Chain - 1) * 0.1f * i80) * WeakNum);
                    g80.GetComponent<BlockTrail>().GoPlayer = false;
                    g80.SetActive(true);
                    break;
                case 81:
                    GameObject g81 = Instantiate(AttackEffect);
                    g81.transform.position = JewelPos[j].position;
                    g81.GetComponent<EffectScript>().EffectNum = 1;
                    g81.GetComponent<BlockTrail>().GoPlayer = true;
                    g81.SetActive(true);
                    break;
                case 82:
                    GameObject g82 = Instantiate(AttackEffect);
                    g82.transform.position = JewelPos[j].position;
                    if (Iscript.CurrentRound == 7)
                    {
                        g82.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((30 + (Chain - 1) * 3f) * WeakNum);
                    }
                    else
                    {
                        g82.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((15 + (Chain - 1) * 1.5f) * WeakNum);
                    }
                    g82.GetComponent<BlockTrail>().GoPlayer = false;
                    g82.SetActive(true);
                    break;
                case 83:
                    GameObject g83 = Instantiate(ShieldEffect);
                    g83.transform.position = JewelPos[j].position;
                    if (Chain >= 7)
                    {
                        g83.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                    }
                    else
                    {
                        g83.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((8 + (Chain - 1) * 0.8f) * WeakNum);
                    }
                    g83.GetComponent<BlockTrail>().GoPlayer = true;
                    g83.SetActive(true);
                    break;
                case 84:
                    if (EquipJewel[0] > 5 || EquipJewel[1] > 5 || EquipJewel[2] > 5 || EquipJewel[3] > 5 || EquipJewel[4] > 5)
                    {
                        GameObject g84 = Instantiate(ShieldEffect);
                        g84.transform.position = JewelPos[j].position;
                        g84.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((14 + (Chain - 1) * 1.4f) * WeakNum);
                        g84.GetComponent<BlockTrail>().GoPlayer = true;
                        g84.SetActive(true);
                    }
                    break;
                case 85:
                    GameObject g85 = Instantiate(HealEffect);
                    g85.transform.position = JewelPos[j].position;
                    g85.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    g85.GetComponent<BlockTrail>().GoPlayer = true;
                    g85.SetActive(true);
                    if (Iscript.Bless[3] == 1)
                    {
                        Bless3 += (7 + (Chain - 1) * 0.7f) * WeakNum * 0.1f;
                        if (Bless3 >= 1f)
                        {
                            Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                        }
                    }
                    if (Iscript.PlayerMaxHP > 1)
                    {
                        Iscript.PlayerMaxHP -= 1;
                    }
                    if (Iscript.PlayerHP > Iscript.PlayerMaxHP)
                    {
                        Iscript.PlayerHP = Iscript.PlayerMaxHP;
                    }
                    break;
                case 86:
                    GameObject g86 = Instantiate(AttackEffect);
                    g86.transform.position = JewelPos[j].position;
                    g86.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((25 + (Chain - 1) * 2.5f) * WeakNum);
                    g86.GetComponent<BlockTrail>().GoPlayer = false;
                    g86.SetActive(true);
                    Iscript.Revenge -= 2;
                    if (Iscript.Revenge < 0)
                    {
                        Iscript.Revenge = 0;
                    }
                    break;
                case 87:
                    if (Chain <= 1)
                    {
                        GameObject g87 = Instantiate(ShieldEffect);
                        g87.transform.position = JewelPos[j].position;
                        g87.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((30 + (Chain - 1) * 3f) * WeakNum);
                        g87.GetComponent<BlockTrail>().GoPlayer = true;
                        g87.SetActive(true);
                    }
                    break;
                case 88:
                    GameObject g88 = Instantiate(AttackEffect);
                    g88.transform.position = JewelPos[j].position;
                    g88.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((25 + (Chain - 1) * 2.5f) * WeakNum);
                    g88.GetComponent<BlockTrail>().GoPlayer = false;
                    g88.SetActive(true);
                    break;
                case 89:
                    GameObject g89 = Instantiate(ShieldEffect);
                    g89.transform.position = JewelPos[j].position;
                    g89.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((15 + (Chain - 1) * 1.5f) * WeakNum);
                    g89.GetComponent<BlockTrail>().GoPlayer = true;
                    g89.SetActive(true);
                    break;
                case 90:
                    if (ActiveSkill == 0)
                    {
                        GameObject g90 = Instantiate(ShieldEffect);
                        g90.transform.position = JewelPos[j].position;
                        g90.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((13 + (Chain - 1) * 1.3f) * WeakNum);
                        g90.GetComponent<BlockTrail>().GoPlayer = true;
                        g90.SetActive(true);
                    }
                    break;
                case 91:
                    if (Chained >= 7)
                    {
                        GameObject g91 = Instantiate(AttackEffect);
                        g91.transform.position = JewelPos[j].position;
                        g91.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((42 + (Chain - 1) * 4.2f) * WeakNum);
                        g91.GetComponent<BlockTrail>().GoPlayer = false;
                        g91.SetActive(true);
                    }
                    break;
                case 92:
                    GameObject g92_1 = Instantiate(AttackEffect);
                    g92_1.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[29] == 1)
                    {
                        g92_1.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((13.5f + (Chain - 1) * 1.35f) * WeakNum);
                    }
                    else
                    {
                        g92_1.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((9 + (Chain - 1) * 0.9f) * WeakNum);
                    }
                    g92_1.GetComponent<BlockTrail>().GoPlayer = false;
                    g92_1.SetActive(true);
                    GameObject g92_2 = Instantiate(HealEffect);
                    g92_2.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[29] == 1)
                    {
                        g92_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((4.5f + (Chain - 1) * 0.45f) * WeakNum);
                    }
                    else
                    {
                        g92_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((3 + (Chain - 1) * 0.3f) * WeakNum);
                    }
                    g92_2.GetComponent<BlockTrail>().GoPlayer = true;
                    g92_2.SetActive(true);
                    if (Iscript.Bless[3] == 1)
                    {
                        Bless3 += (3 + (Chain - 1) * 0.3f) * WeakNum * 0.1f;
                        if (Bless3 >= 1f)
                        {
                            Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                        }
                    }
                    break;
                case 93:
                    GameObject g93 = Instantiate(HealEffect);
                    g93.transform.position = JewelPos[j].position;
                    g93.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    g93.GetComponent<BlockTrail>().GoPlayer = true;
                    g93.SetActive(true);
                    if (Iscript.Bless[3] == 1)
                    {
                        Bless3 += (7 + (Chain - 1) * 0.7f) * WeakNum * 0.1f;
                        if (Bless3 >= 1f)
                        {
                            Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                        }
                    }
                    Iscript.Revenge -= 4;
                    if (Iscript.Revenge < 0)
                    {
                        Iscript.Revenge = 0;
                    }
                    break;
                case 94:
                    GameObject g94 = Instantiate(AttackEffect);
                    g94.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[29] == 1)
                    {
                        g94.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((24 + (Chain - 1) * 2.4f) * WeakNum);
                    }
                    else
                    {
                        g94.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                    }
                    g94.GetComponent<BlockTrail>().GoPlayer = false;
                    g94.SetActive(true);
                    break;
                case 95:
                    GameObject g95 = Instantiate(ShieldEffect);
                    g95.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.PlayerHP % 10 == 5)
                    {
                        g95.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((24 + (Chain - 1) * 2.4f) * WeakNum);
                    }
                    else
                    {
                        g95.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((8 + (Chain - 1) * 0.8f) * WeakNum);
                    }
                    g95.GetComponent<BlockTrail>().GoPlayer = true;
                    g95.SetActive(true);
                    break;
                case 96:
                    GameObject g96 = Instantiate(AttackEffect);
                    g96.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.PlayerHP % 100 == 0)
                    {
                        g96.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((90 + (Chain - 1) * 9f) * WeakNum);
                    }
                    else
                    {
                        g96.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((18 + (Chain - 1) * 1.8f) * WeakNum);
                    }
                    g96.GetComponent<BlockTrail>().GoPlayer = false;
                    g96.SetActive(true);
                    break;
                case 97:
                    GameObject g97 = Instantiate(AttackEffect);
                    g97.transform.position = JewelPos[j].position;
                    g97.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                    for (int k = 0; k < 5; k++)
                    {
                        if (EquipJewel[k] == 98)
                        {
                            g97.GetComponent<EffectScript>().EffectNum += Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                            break;
                        }
                    }
                    g97.GetComponent<BlockTrail>().GoPlayer = false;
                    g97.SetActive(true);
                    break;
                case 98:
                    GameObject g98 = Instantiate(ShieldEffect);
                    g98.transform.position = JewelPos[j].position;
                    g98.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((8 + (Chain - 1) * 0.8f) * WeakNum);
                    for (int k = 0; k < 5; k++)
                    {
                        if (EquipJewel[k] == 97)
                        {
                            g98.GetComponent<EffectScript>().EffectNum += Mathf.FloorToInt((8 + (Chain - 1) * 0.8f) * WeakNum);
                            break;
                        }
                    }
                    g98.GetComponent<BlockTrail>().GoPlayer = true;
                    g98.SetActive(true);
                    break;
                case 99:
                    if (ActiveSkill == 1)
                    {
                        GameObject g99 = Instantiate(AttackEffect);
                        g99.transform.position = JewelPos[j].position;
                        g99.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((30 + (Chain - 1) * 3f) * WeakNum);
                        g99.GetComponent<BlockTrail>().GoPlayer = false;
                        g99.SetActive(true);
                    }
                    break;
                case 100:
                    GameObject g100 = Instantiate(AttackEffect);
                    g100.transform.position = JewelPos[j].position;
                    g100.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10 + (Chain - 1) * 1f) * WeakNum);
                    g100.GetComponent<BlockTrail>().GoPlayer = false;
                    g100.SetActive(true);
                    break;
                case 101:
                    GameObject g101 = Instantiate(ShieldEffect);
                    g101.transform.position = JewelPos[j].position;
                    g101.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((5 + (Chain - 1) * 0.5f) * WeakNum);
                    g101.GetComponent<BlockTrail>().GoPlayer = true;
                    g101.SetActive(true);
                    break;
                case 102:
                    GameObject g102 = Instantiate(AttackEffect);
                    g102.transform.position = JewelPos[j].position;
                    g102.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                    g102.GetComponent<BlockTrail>().GoPlayer = false;
                    g102.SetActive(true);
                    break;
                case 103:
                    GameObject g103 = Instantiate(ShieldEffect);
                    g103.transform.position = JewelPos[j].position;
                    g103.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(((2 * Chained) + (Chain - 1) * (2 * Chained) * 0.1f) * WeakNum);
                    g103.GetComponent<BlockTrail>().GoPlayer = true;
                    g103.SetActive(true);
                    break;
                case 104:
                    GameObject g104 = Instantiate(ShieldEffect);
                    g104.transform.position = JewelPos[j].position;
                    if (Chained >= 10)
                    {
                        g104.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((14 + (Chain - 1) * 1.4f) * WeakNum);
                    }
                    else
                    {
                        g104.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    }
                    g104.GetComponent<BlockTrail>().GoPlayer = true;
                    g104.SetActive(true);
                    break;
                case 105:
                    GameObject g105 = Instantiate(AttackEffect);
                    g105.transform.position = JewelPos[j].position;
                    if(Bscript.EnemyHP >= Bscript.EnemyMaxHP / 2)
                    {
                        g105.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((28 + (Chain - 1) * 2.8f) * WeakNum);
                    }
                    else
                    {
                        g105.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((14 + (Chain - 1) * 1.4f) * WeakNum);
                    }
                    g105.GetComponent<BlockTrail>().GoPlayer = false;
                    g105.SetActive(true);
                    break;
                case 106:
                    GameObject g106 = Instantiate(AttackEffect);
                    g106.transform.position = JewelPos[j].position;
                    g106.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((23 + (Chain - 1) * 2.3f) * WeakNum);
                    g106.GetComponent<BlockTrail>().GoPlayer = false;
                    g106.SetActive(true);
                    break;
                case 107:
                    GameObject g107 = Instantiate(HealEffect);
                    g107.transform.position = JewelPos[j].position;
                    g107.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((4 + (Chain - 1) * 0.4f) * WeakNum);
                    g107.GetComponent<BlockTrail>().GoPlayer = true;
                    g107.SetActive(true);
                    if(Bscript.PlayerHP == Iscript.PlayerMaxHP)
                    {
                        GameObject g107_2 = Instantiate(ShieldEffect);
                        g107_2.transform.position = JewelPos[j].position;
                        g107_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                        g107_2.GetComponent<BlockTrail>().GoPlayer = true;
                        g107_2.SetActive(true);
                    }
                    if (Iscript.Bless[3] == 1)
                    {
                        Bless3 += (4 + (Chain - 1) * 0.4f) * WeakNum * 0.1f;
                        if (Bless3 >= 1f)
                        {
                            Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                        }
                    }
                    break;
                case 108:
                    if(Bscript.PlayerHP >= Iscript.PlayerMaxHP / 2)
                    {
                        GameObject g108 = Instantiate(AttackEffect);
                        g108.transform.position = JewelPos[j].position;
                        g108.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((21 + (Chain - 1) * 2.1f) * WeakNum);
                        g108.GetComponent<BlockTrail>().GoPlayer = false;
                        g108.SetActive(true);
                    }
                    else
                    {
                        GameObject g108_2 = Instantiate(ShieldEffect);
                        g108_2.transform.position = JewelPos[j].position;
                        g108_2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((11 + (Chain - 1) * 1.1f) * WeakNum);
                        g108_2.GetComponent<BlockTrail>().GoPlayer = true;
                        g108_2.SetActive(true);
                    }
                    break;
                case 109:
                    int m = 0;
                    for(int n = 0; n < 12; n++)
                    {
                        if (Iscript.BlessList[n] > 0)
                        {
                            m += 1;
                        }
                    }
                    GameObject g109 = Instantiate(AttackEffect);
                    g109.transform.position = JewelPos[j].position;
                    g109.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(((4 * m) + (Chain - 1) * (4 * m) * 0.1f) * WeakNum);
                    g109.GetComponent<BlockTrail>().GoPlayer = false;
                    g109.SetActive(true);
                    break;
                case 110:
                    GameObject g110 = Instantiate(ShieldEffect);
                    g110.transform.position = JewelPos[j].position;
                    g110.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    g110.GetComponent<BlockTrail>().GoPlayer = true;
                    g110.SetActive(true);
                    break;
                case 111:
                    Chain = 10;
                    GameObject g111 = Instantiate(AttackEffect);
                    g111.transform.position = JewelPos[j].position;
                    g111.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((13 + (Chain - 1) * 1.3f) * WeakNum);
                    g111.GetComponent<BlockTrail>().GoPlayer = false;
                    g111.SetActive(true);
                    break;
                case 112:
                    GameObject g112 = Instantiate(ShieldEffect);
                    g112.transform.position = JewelPos[j].position;
                    g112.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((Gem112 + (Chain - 1) * Gem112 * 0.1f) * WeakNum);
                    g112.GetComponent<BlockTrail>().GoPlayer = true;
                    g112.SetActive(true);
                    break;
                case 113:
                    GameObject g113 = Instantiate(HealEffect);
                    g113.transform.position = JewelPos[j].position;
                    g113.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    g113.GetComponent<BlockTrail>().GoPlayer = true;
                    g113.SetActive(true);
                    GameObject g113_2 = Instantiate(HealEffect);
                    g113_2.transform.position = JewelPos[j].position;
                    g113_2.GetComponent<EffectScript>().EffectNum = 7;
                    g113_2.GetComponent<BlockTrail>().GoPlayer = false;
                    g113_2.SetActive(true);
                    if (Iscript.Bless[3] == 1)
                    {
                        Bless3 += (7 + (Chain - 1) * 0.7f) * WeakNum * 0.1f;
                        if (Bless3 >= 1f)
                        {
                            Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                        }
                    }
                    break;
                case 114:
                    if(Bscript.PlayerShield <= 250)
                    {
                        GameObject g114 = Instantiate(ShieldEffect);
                        g114.transform.position = JewelPos[j].position;
                        g114.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((13 + (Chain - 1) * 1.3f) * WeakNum);
                        g114.GetComponent<BlockTrail>().GoPlayer = true;
                        g114.SetActive(true);
                    }
                    break;
                case 115:
                    if (!Revenged)
                    {
                        GameObject g115 = Instantiate(RevengeEffect);
                        g115.transform.position = JewelPos[j].position;
                        g115.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((14 + (Chain - 1) * 1.4f) * WeakNum);
                        g115.GetComponent<BlockTrail>().GoPlayer = true;
                        g115.SetActive(true);
                    }
                    break;
                case 116:
                    GameObject g116 = Instantiate(AttackEffect);
                    g116.transform.position = JewelPos[j].position;
                    g116.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((3 * CurrentHand + (Chain - 1) * 0.3f * CurrentHand) * WeakNum);
                    g116.GetComponent<BlockTrail>().GoPlayer = false;
                    g116.SetActive(true);
                    break;
                case 117:
                    GameObject g117 = Instantiate(RevengeEffect);
                    g117.transform.position = JewelPos[j].position;
                    g117.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((6 + (Chain - 1) * 0.6f) * WeakNum);
                    g117.GetComponent<BlockTrail>().GoPlayer = true;
                    g117.SetActive(true);
                    break;
                case 118:
                    GameObject g118 = Instantiate(AttackEffect);
                    g118.transform.position = JewelPos[j].position;
                    if(Gem118 < 2)
                    {
                        g118.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((30 + (Chain - 1) * 3f) * WeakNum);
                        Gem118 = 1;
                    }
                    else
                    {
                        g118.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((15 + (Chain - 1) * 1.5f) * WeakNum);
                    }
                    g118.GetComponent<BlockTrail>().GoPlayer = false;
                    g118.SetActive(true);
                    break;
                case 119:
                    GameObject g119 = Instantiate(ShieldEffect);
                    g119.transform.position = JewelPos[j].position;
                    if (Gem119 == 2)
                    {
                        g119.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((14 + (Chain - 1) * 1.4f) * WeakNum);
                    }
                    else
                    {
                        g119.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    }
                    g119.GetComponent<BlockTrail>().GoPlayer = true;
                    g119.SetActive(true);
                    break;
                case 120:
                    int j2 = Random.Range(0, 20);
                    GameObject g120 = Instantiate(AttackEffect);
                    g120.transform.position = JewelPos[j].position;
                    if (j2 == 0)
                    {
                        g120.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((150 + (Chain - 1) * 15f) * WeakNum);
                        for (int k = 0; k < 3; k++)
                        {
                            GameObject g10_2 = Instantiate(JewelFlash2[2]);
                            g10_2.transform.position = JewelPos[C].position;
                            g10_2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g10_2.SetActive(true);
                        }
                    }
                    else
                    {
                        g120.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((15 + (Chain - 1) * 1.5f) * WeakNum);
                    }
                    g120.GetComponent<BlockTrail>().GoPlayer = false;
                    g120.SetActive(true);
                    break;
                case 121:
                    GameObject g121 = Instantiate(AttackEffect);
                    g121.transform.position = JewelPos[j].position;
                    g121.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((45 + (Chain - 1) * 4.5f) * WeakNum);
                    g121.GetComponent<BlockTrail>().GoPlayer = false;
                    g121.SetActive(true);
                    break;
                case 122:
                    GameObject g122 = Instantiate(ShieldEffect);
                    g122.transform.position = JewelPos[j].position;
                    g122.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    g122.GetComponent<BlockTrail>().GoPlayer = true;
                    g122.SetActive(true);
                    break;
                case 123:
                    int m2 = 0;
                    for(int j3 = 0; j3 < 49; j3++)
                    {
                        if (JewelNum[j3] == 123)
                        {
                            m2 += 1;
                        }
                    }
                    GameObject g123 = Instantiate(AttackEffect);
                    g123.transform.position = JewelPos[j].position;
                    g123.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((2 * m2 + (Chain - 1) * 0.2f * m2) * WeakNum);
                    g123.GetComponent<BlockTrail>().GoPlayer = false;
                    g123.SetActive(true);
                    break;
                case 124:
                    GameObject g124 = Instantiate(AttackEffect);
                    g124.transform.position = JewelPos[j].position;
                    g124.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((25 + (Chain - 1) * 2.5f) * WeakNum);
                    g124.GetComponent<BlockTrail>().GoPlayer = false;
                    g124.SetActive(true);
                    Bscript.PlayerShield -= 3;
                    break;
                case 125:
                    GameObject g125 = Instantiate(AttackEffect);
                    g125.transform.position = JewelPos[j].position;
                    g125.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((14 + (Chain - 1) * 1.4f) * WeakNum);
                    g125.GetComponent<BlockTrail>().GoPlayer = false;
                    g125.SetActive(true);
                    if(Chain >= 9)
                    {
                        for(int i8 = 0; i8 < 49; i8++)
                        {
                            if (JewelNum[i8] == 125)
                            {
                                Chain = 0;
                                JewelVanish(i8);
                            }
                        }
                    }
                    break;
                case 126:
                    GameObject g126 = Instantiate(AttackEffect);
                    g126.transform.position = JewelPos[j].position;
                    if (j < 7)
                    {
                        g126.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((32 + (Chain - 1) * 3f) * WeakNum);
                    }
                    else
                    {
                        g126.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.5f) * WeakNum);
                    }
                    g126.GetComponent<BlockTrail>().GoPlayer = false;
                    g126.SetActive(true);
                    break;
                case 127:
                    GameObject g127 = Instantiate(HealEffect);
                    g127.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[42] == 1)
                    {
                        g127.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10 + (Chain - 1) * 1f) * WeakNum);
                        if (Iscript.Bless[3] == 1)
                        {
                            Bless3 += (10 + (Chain - 1) * 1f) * WeakNum * 0.1f;
                            if (Bless3 >= 1f)
                            {
                                Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                                Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                                Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            }
                        }
                    }
                    else
                    {
                        g127.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((2 + 8 * (Iscript.PlayerMaxHP - Iscript.PlayerHP) / Iscript.PlayerMaxHP +
                        (Chain - 1) * 0.1f * (2 + 8 * (Iscript.PlayerMaxHP - Iscript.PlayerHP) / Iscript.PlayerMaxHP)) * WeakNum);
                        if (Iscript.Bless[3] == 1)
                        {
                            Bless3 += (2 + 8 * (Iscript.PlayerMaxHP - Iscript.PlayerHP) / Iscript.PlayerMaxHP +
                        (Chain - 1) * 0.1f * (2 + 8 * (Iscript.PlayerMaxHP - Iscript.PlayerHP) / Iscript.PlayerMaxHP)) * WeakNum * 0.1f;
                            if (Bless3 >= 1f)
                            {
                                Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                                Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                                Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                            }
                        }
                    }
                    g127.GetComponent<BlockTrail>().GoPlayer = true;
                    g127.SetActive(true);
                    break;
                case 128:
                    GameObject g128 = Instantiate(ShieldEffect);
                    g128.transform.position = JewelPos[j].position;
                    g128.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((7 + (Chain - 1) * 0.7f) * WeakNum);
                    g128.GetComponent<BlockTrail>().GoPlayer = true;
                    g128.SetActive(true);
                    if(Gem128 == 0)
                    {
                        Gem128 = 1;
                    }
                    break;
                case 129:
                    Gem130 += Mathf.FloorToInt((12 + (Chain - 1) * 1.2f) * WeakNum);
                    break;
                case 130:
                    if (Iscript.CurrentRound < 7)
                    {
                        GameObject g130 = Instantiate(AttackEffect);
                        g130.transform.position = JewelPos[j].position;
                        g130.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((25 + (Chain - 1) * 2.5f) * WeakNum);
                        g130.GetComponent<BlockTrail>().GoPlayer = false;
                        g130.SetActive(true);
                    }
                    break;
                case 131:
                    Gem131 = 2;
                    GameObject g131 = Instantiate(ShieldEffect);
                    g131.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[29] == 1)
                    {
                        Gem131 = 3;
                        g131.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((9 + (Chain - 1) * 0.9f) * WeakNum);
                    }
                    else
                    {
                        g131.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((6 + (Chain - 1) * 0.6f) * WeakNum);
                    }
                    g131.GetComponent<BlockTrail>().GoPlayer = true;
                    g131.SetActive(true);
                    break;
                case 132:
                    GameObject g132 = Instantiate(ShieldEffect);
                    g132.transform.position = JewelPos[j].position;
                    if (j >= 42)
                    {
                        g132.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
                    }
                    else
                    {
                        g132.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((8 + (Chain - 1) * 0.8f) * WeakNum);
                    }
                    g132.GetComponent<BlockTrail>().GoPlayer = true;
                    g132.SetActive(true);
                    break;
                case 133:
                    GameObject g133 = Instantiate(AttackEffect);
                    g133.transform.position = JewelPos[j].position;
                    g133.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10 + Gem133 + (Chain - 1) * (10f + Gem133) * 0.1f) * WeakNum);
                    g133.GetComponent<BlockTrail>().GoPlayer = false;
                    g133.SetActive(true);
                    break;
                case 134:
                    GameObject g134 = Instantiate(AttackEffect);
                    g134.transform.position = JewelPos[j].position;
                    g134.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((40 + (Chain - 1) * 4f) * WeakNum);
                    g134.GetComponent<BlockTrail>().GoPlayer = false;
                    g134.SetActive(true);
                    break;
                case 135:
                    GameObject g135 = Instantiate(AttackEffect);
                    g135.transform.position = JewelPos[j].position;
                    g135.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((14 + (Chain - 1) * 1.4f) * WeakNum);
                    g135.GetComponent<BlockTrail>().GoPlayer = false;
                    g135.SetActive(true);
                    break;
                case 136:
                    GameObject g136 = Instantiate(ShieldEffect);
                    g136.transform.position = JewelPos[j].position;
                    g136.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((24 + (Chain - 1) * 2.4f) * WeakNum);
                    g136.GetComponent<BlockTrail>().GoPlayer = true;
                    g136.SetActive(true);
                    Gem136 = 1;
                    break;
                case 137:
                    GameObject g137 = Instantiate(AttackEffect);
                    g137.transform.position = JewelPos[j].position;
                    g137.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((15 + (Chain - 1) * 1.5f) * WeakNum);
                    g137.GetComponent<BlockTrail>().GoPlayer = false;
                    g137.SetActive(true);
                    break;
                case 138:
                    GameObject g138 = Instantiate(ShieldEffect);
                    g138.transform.position = JewelPos[j].position;
                    g138.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((5 + (Chain - 1) * 0.5f) * WeakNum);
                    g138.GetComponent<BlockTrail>().GoPlayer = true;
                    g138.SetActive(true);
                    break;
                case 139:
                    GameObject g139 = Instantiate(AttackEffect);
                    g139.transform.position = JewelPos[j].position;
                    if (Bscript.Iscript.Bless[29] == 1)
                    {
                        g139.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((15 + (Chain - 1) * 1.5f) * WeakNum);
                    }
                    else
                    {
                        g139.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10 + (Chain - 1) * 1f) * WeakNum);
                    }
                    g139.GetComponent<BlockTrail>().GoPlayer = false;
                    g139.SetActive(true);
                    break;

                case 304:
                    Debuff_Weak += 6;
                    break;
                case 308:
                    GameObject g308 = Instantiate(AttackEffect);
                    g308.transform.position = JewelPos[j].position;
                    g308.GetComponent<EffectScript>().EffectNum = 20;
                    g308.GetComponent<BlockTrail>().GoPlayer = true;
                    g308.SetActive(true);
                    break;
                case 310:
                    GameObject g310 = Instantiate(AttackEffect);
                    g310.transform.position = JewelPos[j].position;
                    g310.GetComponent<EffectScript>().EffectNum = 10;
                    g310.GetComponent<BlockTrail>().GoPlayer = true;
                    g310.SetActive(true);
                    break;
            }
            if (Debuff_Weak > 0)
            {
                if (Bscript.Iscript.Bless[25] == 1)
                {
                    Debuff_Weak -= 2;
                }
                else
                {
                    Debuff_Weak -= 1;
                }
                if (Debuff_Weak < 0)
                {
                    Debuff_Weak = 0;
                }
            }
            if (i != 40)
            {
                IsCitrine = false;
            }
            if (Iscript.Bless[30] == 1 && (i == 4 || i == 74 || i == 83 || i == 84 || i == 90 || i == 95 || i == 132 || i == 138))
            {
                GameObject g0 = Instantiate(HealEffect);
                g0.transform.position = JewelPos[j].position;
                g0.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((3 + (Chain - 1) * 0.3f) * WeakNum);
                g0.GetComponent<BlockTrail>().GoPlayer = true;
                g0.SetActive(true);
                if (Iscript.Bless[3] == 1)
                {
                    Bless3 += (3 + (Chain - 1) * 0.3f) * WeakNum * 0.1f;
                    if (Bless3 >= 1f)
                    {
                        Iscript.PlayerMaxHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                        Iscript.PlayerHP += Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                        Bless3 -= Mathf.FloorToInt(Bless3 * (1 + Iscript.Bless[54]));
                    }
                }
            }
        }
        else
        {
            Debuff_Void -= 1;
        }
    }
    public void ClickHand()
    {
        DamageSum = 0;
        if (!Bscript.IsDefeat)
        {
            if (Watcher_Sniper > 0)
            {
                Watcher_Sniper -= 1;
            }
            else if (Fractal_Prism > 0)
            {
                Fractal_Prism -= 1;
            }
            else if (Collector_Skill > 0)
            {
                Collector_Skill -= 1;
            }
            else if (CollectorPut >= 0)
            {

            }
            else if (CatalystPut)
            {

            }
            else if (Creator_Cell > 0)
            {
                Creator_Cell -= 1;
            }
            else if (MatrixSkill > 0)
            {
                MatrixSkill -= 1;
            }
            else if (MatrixAlter > 0)
            {
                MatrixAlter -= 1;
                for (int i = 0; i < 9; i++)
                {
                    Matrixanim2[i].Play("Matrix1");
                }
            }
            else if (CurrentHand > 0 && JewelNum[C] != 65)
            {
                j30 = CurrentHand;
                CurrentHand -= 1;
                CurrentTurnHand += 1;
                if (Iscript.Bless[10] == 1)
                {
                    Iscript.PlayerHP += 2 * (1 + Iscript.Bless[54]);
                    if (Iscript.PlayerHP > Iscript.PlayerMaxHP)
                    {
                        Iscript.PlayerHP = Iscript.PlayerMaxHP;
                    }
                }
                if (IsTimemachine)
                {
                    Tscript.MomentHand();
                }
                if (Iscript.Saint == 6)
                {
                    for (int i2 = 0; i2 < JewelNum.Length; i2++)
                    {
                        if (CatalystNum[i2] > 0)
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                GameObject g6_3 = Instantiate(SaintSkillEffect[11]);
                                g6_3.transform.position = JewelPos[i2].position;
                                g6_3.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                                g6_3.SetActive(true);
                            }
                            CatalystVanish(i2);
                            CatalystNum[i2] -= 1;
                            CatalystDisplay[i2].GetComponent<CatalystCount>().Num -= 1;
                            if (CatalystNum[i2] == 0)
                            {
                                GameObject g6 = Instantiate(SaintSkillEffect[10]);
                                g6.transform.position = JewelPos[i2].position;
                                g6.SetActive(true);
                                Destroy(CatalystDisplay[i2]);
                            }
                        }
                    }
                }
            }
        }
    }
    public void SaintSkill()
    {
        if (ActiveSkill > 0 && PlayerRound && !Bscript.IsDefeat)
        {
            Iscript.SE.PlayOneShot(SkillSE);
            switch (Saint)
            {
                case 1:
                    int Judge = Random.Range(0, 5);
                    int Judge2 = Random.Range(0, 5);
                    for(;Judge == Judge2 ; )
                    {
                        Judge2 = Random.Range(0, 5);
                    }
                    int Judge3 = Random.Range(0, 5);
                    for (; Judge == Judge3 || Judge2 == Judge3;)
                    {
                        Judge3 = Random.Range(0, 5);
                    }
                    for (int i = 0; i < 49; i++)
                    {
                        if (JewelNum[i] == EquipJewel[Judge])
                        {
                            JewelVanish(i);
                            GameObject g1 = Instantiate(SaintSkillEffect[0]);
                            g1.transform.position = JewelPos[i].position;
                            g1.SetActive(true);
                        }
                        if(Bless22 >= 2)
                        {
                            if (JewelNum[i] == EquipJewel[Judge2])
                            {
                                JewelVanish(i);
                                GameObject g1 = Instantiate(SaintSkillEffect[0]);
                                g1.transform.position = JewelPos[i].position;
                                g1.SetActive(true);
                            }
                        }
                        if (Bless22 >= 3)
                        {
                            if (JewelNum[i] == EquipJewel[Judge3])
                            {
                                JewelVanish(i);
                                GameObject g1 = Instantiate(SaintSkillEffect[0]);
                                g1.transform.position = JewelPos[i].position;
                                g1.SetActive(true);
                            }
                        }
                    }
                    break;
                case 2:
                    GameObject g2 = Instantiate(SaintSkillEffect[1]);
                    g2.transform.position = SkillEffectPos[0].position;
                    g2.SetActive(true);
                    Watcher_Sniper = Watcher_Quiver * Bless22;
                    break;
                case 3:
                    GameObject g3 = Instantiate(SaintSkillEffect[6]);
                    g3.transform.position = SkillEffectPos[1].position;
                    g3.SetActive(true);
                    BurningHand = true;
                    break;
                case 4:
                    GameObject g4 = Instantiate(SaintSkillEffect[3]);
                    g4.transform.position = SkillEffectPos[1].position;
                    g4.SetActive(true);
                    if (Iscript.Crown >= 2)
                    {
                        Fractal_Prism = 3 * Bless22;
                    }
                    else
                    {
                        Fractal_Prism = 4 * Bless22;
                    }
                    break;
                case 5:
                    GameObject g5 = Instantiate(SaintRevengeEffect[5]);
                    g5.transform.position = SkillEffectPos[1].position;
                    g5.SetActive(true);
                    Gaze = true;
                    Escript.Gaze = true;
                    break;
                case 6:
                    GameObject g6 = Instantiate(SaintSkillEffect[12]);
                    g6.transform.position = SkillEffectPos[1].position;
                    g6.SetActive(true);
                    CatalystPut = true;
                    break;
                case 7:
                    GameObject g7 = Instantiate(SaintSkillEffect[7]);
                    g7.transform.position = SkillEffectPos[1].position;
                    g7.SetActive(true);
                    if (Iscript.Crown >= 2)
                    {
                        Collector_Skill = 2 * Bless22;
                    }
                    else
                    {
                        Collector_Skill = 3 * Bless22;
                    }
                    break;
                case 8:
                    if (Iscript.Crown >= 3)
                    {
                        CurrentHand += 3 * Bless22;
                    }
                    else
                    {
                        CurrentHand += 4 * Bless22;
                    }
                    for (int i = 0; i < 20; i++)
                    {
                        int Judge8 = Random.Range(0, 49);
                        for (int i4 = 0; i4 < 100 && JewelNum[Judge8] == 307; i4++)
                        {
                            Judge8 = Random.Range(0, 49);
                        }
                        JewelNum[Judge8] = 307;
                        GameObject g8 = Instantiate(JewelObj[307]);
                        g8.transform.position = JewelDisplay[Judge8].transform.position;
                        g8.transform.SetParent(gameObject.transform, true);
                        Destroy(JewelDisplay[Judge8]);
                        JewelDisplay[Judge8] = g8;
                        GameObject g8_2 = Instantiate(SaintSkillEffect[13]);
                        g8_2.transform.position = JewelDisplay[Judge8].transform.position;
                    }
                    break;
                case 9:
                    GameObject g = Instantiate(SaintSkillEffect[14]);
                    g.transform.position = SkillEffectPos[0].position;
                    g.SetActive(true);
                    GameObject g9 = Instantiate(AttackEffect);
                    g9.transform.position = SkillEffectPos[0].position;
                    g9.GetComponent<EffectScript>().EffectNum = Bscript.PlayerShield * Bless22;
                    g9.GetComponent<BlockTrail>().GoPlayer = false;
                    g9.SetActive(true);
                    if (Iscript.Crown >= 3)
                    {
                        Bscript.PlayerShield = Mathf.FloorToInt(Bscript.PlayerShield * 0.6f);
                    }
                    else
                    {
                        Bscript.PlayerShield = Mathf.FloorToInt(Bscript.PlayerShield * 0.7f);
                    }
                    Iscript.SE.PlayOneShot(GolemSE);
                    break;
                case 10:
                    for (int l = 0; l < 4 * Bless22; l++)
                    {
                        int j = Random.Range(0, 49);
                        for (; OrderNum[j] > 0;)
                        {
                            j = Random.Range(0, 49);
                        }
                        GameObject g10 = Instantiate(SaintSkillEffect[15]);
                        g10.transform.position = JewelPos[j].position;
                        g10.SetActive(true);
                        for(int l2 = 0; l2 < 49; l2++)
                        {
                            if (OrderNum[l2] > 0 && j != l2)
                            {
                                OrderNum[j] += 1;
                            }
                        }
                        OrderNum[j] += 1;
                        GameObject g10_2 = Instantiate(OrderObj);
                        g10_2.transform.position = JewelPos[j].position;
                        g10_2.SetActive(true);
                        g10_2.GetComponent<OrderCount>().Num = OrderNum[j];
                        if(OrderRev)
                        {
                           g10_2.GetComponent<OrderCount>().text.gameObject.SetActive(false);
                        }
                        OrderDisplay[j] = g10_2;
                        g10_2.transform.SetParent(this.transform, true);
                        GameObject g10_3 = Instantiate(SaintSkillEffect[16]);
                        g10_3.transform.position = JewelPos[j].position;
                        g10_3.SetActive(true);
                    }
                    break;
                case 11:
                    GameObject g11 = Instantiate(SaintSkillEffect[19]);
                    g11.transform.position = SkillEffectPos[1].position;
                    g11.SetActive(true);
                    Creator_Cell = Bless22;
                    break;
                case 12:
                    GameObject g12 = Instantiate(SaintSkillEffect[20]);
                    g12.transform.position = SkillEffectPos[0].position;
                    g12.SetActive(true);
                    MatrixSkill = 1;
                    break;
                case 13:
                    int n = 4;
                    if (Iscript.Crown >= 2)
                    {
                        n = 3;
                    }
                    for (int k = 0; k < Bless22; k++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (RevenantPotion[j] == 0)
                            {
                                RevenantPotion[j] = Random.Range(1, 5);
                                RevenantDisplay[j].PotionNum = RevenantPotion[j];
                                PlayerPrefs.SetInt($"Potion{j}", RevenantPotion[j]);
                                PlayerPrefs.Save();
                                GameObject g13 = Instantiate(SaintSkillEffect[22]);
                                g13.transform.position = RevenantDisplay[j].transform.position;
                                g13.SetActive(true);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    break;
                case 14:
                    int[] k3 = {0, 0, 0, 0};
                    for(int k2 = 0; k2 < 5; k2++)
                    {
                        k3[FormulaNum[k2]] += 1;
                    }
                    for(int k2 = 0; k2 < 3; k2++)
                    {
                        if (k3[k2] >= 3)
                        {
                            k3[3] = 1;
                        }
                    }
                    if(Iscript.Crown <= 1 || (Iscript.Crown >= 2 || k3[3] == 0))
                    {
                        for (int k = 0; k < Bless22; k++)
                        {
                            if (FormulaNum[4] == -1)
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    if (FormulaNum[i] == -1)
                                    {
                                        FormulaNum[i] = FormulaSelect;
                                        GameObject g14 = Instantiate(FormulaDroid[FormulaSelect]);
                                        g14.transform.position = FormulaDroidPos[i].position;
                                        FormulaDroidObj[i] = g14.transform;
                                        g14.transform.SetParent(Bscript.gameObject.transform, true);
                                        GameObject g14_2 = Instantiate(SaintSkillEffect[23]);
                                        g14_2.transform.position = FormulaDroidObj[i].transform.position;
                                        g14_2.SetActive(true);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Destroy(FormulaDroidObj[0].gameObject);
                                for (int i = 0; i < 4; i++)
                                {
                                    FormulaDroidObj[i] = FormulaDroidObj[i + 1];
                                    FormulaNum[i] = FormulaNum[i + 1];
                                }
                                FormulaNum[4] = FormulaSelect;
                                GameObject g14_3 = Instantiate(FormulaDroid[FormulaSelect]);
                                g14_3.transform.position = FormulaDroidPos[4].position;
                                FormulaDroidObj[4] = g14_3.transform;
                                g14_3.transform.SetParent(Bscript.gameObject.transform, true);
                                GameObject g14_2 = Instantiate(SaintSkillEffect[23]);
                                g14_2.transform.position = FormulaDroidObj[4].transform.position;
                                g14_2.SetActive(true);
                            }
                        }
                    }
                    break;
            }
            if(Bless22 >= 2)
            {
                Bless22 = 1;
                Sscript.Bless22 = 1;
                Sscript.Start();
            }
            ActiveSkill -= 1;
            if (Iscript.Bless[68] == 1)
            {
                int j = Random.Range(0, 100);
                if(j <= 10 * Iscript.Bless[54] + 10)
                {
                    ActiveSkill = 1;
                    Iscript.SE.PlayOneShot(GamblerSE);
                }
            }
            SkillDisplay();
            PlayerPrefs.SetInt("Skilled", 1);
        }
    }
    public void RevengeSkill()
    {
        if(Bscript.RevengeSlider.value == Bscript.RevengeSlider.maxValue && PlayerRound && !Bscript.IsDefeat)
        {
            Iscript.SE.PlayOneShot(RevengeSE);
            Revenged = true;
            switch (Saint)
            {
                case 1:
                    if (Iscript.Crown >= 4)
                    {
                        CurrentHand += 3;
                    }
                    else
                    {
                        CurrentHand += 5;
                    }
                    GameObject g1 = Instantiate(SaintRevengeEffect[0]);
                    g1.transform.position = RevengeEffectPos[0].transform.position;
                    g1.SetActive(true);
                    break;
                case 2:
                    Watcher_Quiver += 3;
                    switch(Language)
                    {
                        case 1:
                            SkillDescText.text = "任意の宝石" + Watcher_Quiver * Bless22 + "つを消去する。";
                            break;
                        case 2:
                            SkillDescText.text = "Cast any " + Watcher_Quiver * Bless22 + " gems.";
                            break;
                    }
                    GameObject g2 = Instantiate(SaintRevengeEffect[1]);
                    g2.transform.position = RevengeEffectPos[1].transform.position;
                    g2.SetActive(true);
                    break;
                case 3:
                    for (int m = 0; m < 5; m++)
                    {
                        for (int i = 28; i < 49; i++)
                        {
                            if (JewelNum[i] == EquipJewel[m])
                            {
                                JewelVanish(i);
                                GameObject g3 = Instantiate(SaintSkillEffect[5]);
                                g3.transform.position = JewelPos[i].position;
                                g3.SetActive(true);
                            }
                        }
                    }
                    break;
                case 4:
                    if (Iscript.Crown >= 3)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            int Judge = Random.Range(0, 49);
                            for (int i4 = 0; i4 < 100 && JewelNum[Judge] == 200; i4++)
                            {
                                Judge = Random.Range(0, 49);
                            }
                            JewelNum[Judge] = 200;
                            GameObject g4 = Instantiate(JewelObj[200]);
                            g4.transform.position = JewelDisplay[Judge].transform.position;
                            g4.transform.SetParent(gameObject.transform, true);
                            Destroy(JewelDisplay[Judge]);
                            JewelDisplay[Judge] = g4;
                            GameObject g4_2 = Instantiate(SaintRevengeEffect[2]);
                            g4_2.transform.position = JewelDisplay[Judge].transform.position;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            int Judge = Random.Range(0, 49);
                            for (int i4 = 0; i4 < 100 && JewelNum[Judge] == 200; i4++)
                            {
                                Judge = Random.Range(0, 49);
                            }
                            JewelNum[Judge] = 200;
                            GameObject g4 = Instantiate(JewelObj[200]);
                            g4.transform.position = JewelDisplay[Judge].transform.position;
                            g4.transform.SetParent(gameObject.transform, true);
                            Destroy(JewelDisplay[Judge]);
                            JewelDisplay[Judge] = g4;
                            GameObject g4_2 = Instantiate(SaintRevengeEffect[2]);
                            g4_2.transform.position = JewelDisplay[Judge].transform.position;
                        }
                    }
                    break;
                case 5:
                    Gaze = false;
                    Escript.Gaze = false;
                    GameObject g = Instantiate(SaintRevengeEffect[5]);
                    g.transform.position = SkillEffectPos[0].position;
                    g.SetActive(true);
                    GameObject g0 = Instantiate(AttackEffect);
                    g0.transform.position = SkillEffectPos[0].position;
                    g0.GetComponent<EffectScript>().EffectNum = 300 + PlayerPrefs.GetInt("SentryRevenge", 0);
                    g0.GetComponent<BlockTrail>().GoPlayer = false;
                    g0.SetActive(true);
                    if (Iscript.Crown >= 5)
                    {
                        PlayerPrefs.SetInt("SentryRevenge", PlayerPrefs.GetInt("SentryRevenge", 0) + 40);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("SentryRevenge", PlayerPrefs.GetInt("SentryRevenge", 0) + 60);
                    }
                    PlayerPrefs.Save();
                    Iscript.SE.PlayOneShot(SentrySE);
                    break;
                case 6:
                    for (int l = 0; l < 6; l++)
                    {
                        int j = Random.Range(0, 49);
                        for (; CatalystNum[j] > 0;)
                        {
                            j = Random.Range(0, 49);
                        }
                        GameObject g6 = Instantiate(SaintSkillEffect[10]);
                        g6.transform.position = JewelPos[j].position;
                        g6.SetActive(true);
                        GameObject g6_2 = Instantiate(CatalystObj);
                        g6_2.transform.position = JewelPos[j].position;
                        g6_2.SetActive(true);
                        g6_2.GetComponent<CatalystCount>().Num = 5;
                        CatalystNum[j] = 5;
                        CatalystDisplay[j] = g6_2;
                        g6_2.transform.SetParent(this.transform, true);
                        for (int k = 0; k < 2; k++)
                        {
                            GameObject g6_3 = Instantiate(SaintSkillEffect[11]);
                            g6_3.transform.position = JewelPos[j].position;
                            g6_3.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                            g6_3.SetActive(true);
                        }
                    }
                    break;
                case 7:
                    if (Iscript.Crown >= 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            CollectorGem[i] += 1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            CollectorGem[i] += 2;
                        }
                    }
                    GameObject g7 = Instantiate(SaintRevengeEffect[4]);
                    g7.transform.position = this.transform.position;
                    g7.SetActive(true);
                    break;
                case 8:
                    Bscript.RewardMedal += 1;
                    GameObject g8 = Instantiate(SaintRevengeEffect[6]);
                    g8.transform.position = RevengeEffectPos[2].transform.position;
                    g8.SetActive(true);
                    break;
                case 9:
                    GameObject g9_2 = Instantiate(SaintSkillEffect[14]);
                    g9_2.transform.position = SkillEffectPos[1].position;
                    g9_2.SetActive(true);
                    GameObject g9 = Instantiate(ShieldEffect);
                    g9.transform.position = SkillEffectPos[1].position;
                    g9.GetComponent<EffectScript>().EffectNum = 200;
                    g9.GetComponent<BlockTrail>().GoPlayer = true;
                    g9.SetActive(true);
                    break;
                case 10:
                    int n = 6;
                    if (Iscript.Crown >= 2)
                    {
                        n = 4;
                    }
                    else
                    {
                        n = 6;
                    }
                    for (int l = 0; l < n; l++)
                    {
                        int j = Random.Range(0, 49);
                        for (; OrderNum[j] > 0;)
                        {
                            j = Random.Range(0, 49);
                        }
                        GameObject g10_2 = Instantiate(OrderObj);
                        g10_2.transform.position = JewelPos[j].position;
                        g10_2.SetActive(true);
                        g10_2.GetComponent<OrderCount>().Num = OrderNum[j];
                        OrderDisplay[j] = g10_2;
                        g10_2.transform.SetParent(this.transform, true);
                        GameObject g10 = Instantiate(SaintSkillEffect[15]);
                        g10.transform.position = JewelPos[j].position;
                        g10.SetActive(true);
                        for (int l2 = 0; l2 < 49; l2++)
                        {
                            if (OrderNum[l2] > 0 && j != l2)
                            {
                                OrderNum[j] += 1;
                            }
                        }
                        OrderNum[j] += 1;
                        GameObject g10_3 = Instantiate(SaintSkillEffect[16]);
                        g10_3.transform.position = JewelPos[j].position;
                        g10_3.SetActive(true);
                        OrderRev = true;
                    }
                    for (int i = 0; i < 49; i++)
                    {
                        if (OrderDisplay[i] != null)
                        {
                            OrderDisplay[i].GetComponent<OrderCount>().text.gameObject.SetActive(false);
                        }
                    }
                    break;
                case 11:
                    CreatorGrowth();
                    break;
                case 12:
                    if (Iscript.Crown >= 3)
                    {
                        MatrixMemory += 1;
                    }
                    else
                    {
                        MatrixMemory += 2;
                    }
                    GameObject g12_2 = Instantiate(SaintRevengeEffect[2]);
                    g12_2.transform.position = RevengeEffectPos[2].transform.position;
                    break;
                case 13:
                    int n2 = 4;
                    if (Iscript.Crown >= 2)
                    {
                        n2 = 3;
                    }
                    for (int j = 0; j < n2; j++)
                    {
                        if (RevenantPotion[j] == 0)
                        {
                            RevenantPotion[j] = Random.Range(1, 5);
                            RevenantDisplay[j].PotionNum = RevenantPotion[j];
                            PlayerPrefs.SetInt($"Potion{j}", RevenantPotion[j]);
                            PlayerPrefs.Save();
                            GameObject g13 = Instantiate(SaintSkillEffect[22]);
                            g13.transform.position = RevenantDisplay[j].transform.position;
                            g13.SetActive(true);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    break;
                case 14:
                    FormulaDisplay[FormulaSelect].DroidLevel += 1;
                    PlayerPrefs.SetInt($"Droid{FormulaSelect}", FormulaDisplay[FormulaSelect].DroidLevel);
                    PlayerPrefs.Save();
                    GameObject g14 = Instantiate(SaintSkillEffect[24]);
                    g14.transform.position = RevengeEffectPos[1].transform.position;
                    g14.SetActive(true);
                    break;
            }
            Bscript.Iscript.Revenge = 0;
            if (Bscript.Iscript.Bless[64] == 1)
            {
                GameObject g = Instantiate(ShieldEffect);
                g.transform.position = this.transform.position;
                g.GetComponent<EffectScript>().EffectNum = 50;
                g.GetComponent<BlockTrail>().GoPlayer = true;
                g.SetActive(true);
            }
            if (Iscript.Bless[76] == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    int Judge = Random.Range(0, 49);
                    for (int i4 = 0; i4 < 100 && JewelNum[Judge] == 200; i4++)
                    {
                        Judge = Random.Range(0, 49);
                    }
                    JewelNum[Judge] = 200;
                    GameObject g4 = Instantiate(JewelObj[200]);
                    g4.transform.position = JewelDisplay[Judge].transform.position;
                    g4.transform.SetParent(gameObject.transform, true);
                    Destroy(JewelDisplay[Judge]);
                    JewelDisplay[Judge] = g4;
                    GameObject g4_2 = Instantiate(SaintRevengeEffect[2]);
                    g4_2.transform.position = JewelDisplay[Judge].transform.position;
                }
            }
            for(int i = 0; i < 49; i++)
            {
                if (JewelNum[i] == 117)
                {
                    JewelVanish(i);
                }
            }
        }
        
    }
    void SkillDisplay()
    {
        SkillUseText.text = ActiveSkill.ToString();
        switch(Saint)
        {
            case 1:
                switch(Language)
                {
                    case 1:
                        SkillNameText.text = "覚醒";
                        RevengeNameText.text = "プライムハンド";
                        break;
                    case 2:
                        SkillNameText.text = "Awakening";
                        RevengeNameText.text = "Prime Hand";
                        break;
                }
                break;
            case 2:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "狙撃";
                        RevengeNameText.text = "矢筒拡張";
                        break;
                    case 2:
                        SkillNameText.text = "Sniper";
                        RevengeNameText.text = "Quiver expansion";
                        break;
                }
                break;
            case 3:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "バーニングハンド";
                        RevengeNameText.text = "噴火";
                        break;
                    case 2:
                        SkillNameText.text = "Burning Hand";
                        RevengeNameText.text = "Eruption";
                        break;
                }
                break;
            case 4:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "万華鏡";
                        RevengeNameText.text = "乱反射";
                        break;
                    case 2:
                        SkillNameText.text = "Kaleidoscope";
                        RevengeNameText.text = "Diffuse Reflection";
                        break;
                }
                break;
            case 5:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "凝視";
                        RevengeNameText.text = "一斉射撃";
                        break;
                    case 2:
                        SkillNameText.text = "Gaze";
                        RevengeNameText.text = "Broadside";
                        break;
                }
                break;
            case 6:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "侵蝕";
                        RevengeNameText.text = "支配";
                        break;
                    case 2:
                        SkillNameText.text = "Erosion";
                        RevengeNameText.text = "Domination";
                        break;
                }
                break;
            case 7:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "収集";
                        RevengeNameText.text = "展覧会";
                        break;
                    case 2:
                        SkillNameText.text = "Collection";
                        RevengeNameText.text = "Exhibition";
                        break;
                }
                break;
            case 8:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "ミダスの手";
                        RevengeNameText.text = "黄金の血";
                        break;
                    case 2:
                        SkillNameText.text = "Midas Touch";
                        RevengeNameText.text = "Golden Blood";
                        break;
                }
                break;
            case 9:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "シールドバッシュ";
                        RevengeNameText.text = "金属体";
                        break;
                    case 2:
                        SkillNameText.text = "Shield Bash";
                        RevengeNameText.text = "Metal Body";
                        break;
                }
                break;
            case 10:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "弱点探知";
                        RevengeNameText.text = "剣の舞";
                        break;
                    case 2:
                        SkillNameText.text = "Weak Detection";
                        RevengeNameText.text = "Sword Dance";
                        break;
                }
                break;
            case 11:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "創始";
                        RevengeNameText.text = "増殖";
                        break;
                    case 2:
                        SkillNameText.text = "Creation";
                        RevengeNameText.text = "Prosperity";
                        break;
                }
                break;
            case 12:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "念写";
                        RevengeNameText.text = "記憶改竄";
                        break;
                    case 2:
                        SkillNameText.text = "Spirit Graphy";
                        RevengeNameText.text = "Alteration";
                        break;
                }
                break;
            case 13:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "大釜";
                        RevengeNameText.text = "禁断の醸造";
                        break;
                    case 2:
                        SkillNameText.text = "Cauldron";
                        RevengeNameText.text = "Forbidden Brewing";
                        break;
                }
                break;
            case 14:
                switch (Language)
                {
                    case 1:
                        SkillNameText.text = "センチネル";
                        RevengeNameText.text = "機械学習";
                        break;
                    case 2:
                        SkillNameText.text = "Sentinel";
                        RevengeNameText.text = "Machine Learning";
                        break;
                }
                break;
        }
    }
    void CatalystVanish(int i)
    {
        if (JewelNum[i] != 56)
        {
            GameObject g = Instantiate(JewelFlash[JewelNum[i]]);
            g.transform.position = JewelPos[i].position;
            g.SetActive(true);
            GameObject g2 = Instantiate(JewelFlash2[0]);
            g2.transform.position = JewelPos[i].position;
            g2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
            g2.SetActive(true);
            Destroy(JewelDisplay[i]);
            JewelEffect(JewelNum[i], i);
            JewelNum[i] = -1;
            ChainTime = 0.3f;
        }
    }
    public void CollectorSlotSelect(int i)
    {
        for(int j = 0; j < 5; j++)
        {
            CollectorPutCG[j].alpha = 0;
        }
        if (CollectorPut == i)
        {
            CollectorPut = -1;
            CollectorPutCG[i + 5].alpha = 1;
        }
        else if(CollectorGem[i] > 0)
        {
            CollectorPut = i;
            CollectorPutCG[i].alpha = 1;
            CollectorPutCG[i + 5].alpha = 1;
        }
    }
    void CollectorReset()
    {
        CollectorPutCG[CollectorPut].alpha = 0;
        CollectorPutCG[CollectorPut + 5].alpha = 1;
        CollectorPut = -1;
    }
    void CreatorGrowth()
    {
        for (int i = 0; i < 49; i++)
        {
            if (JewelNum[i] == 201)
            {
                if (JewelDisplay[i].GetComponent<Gem_Cell>().Growth < 4)
                {
                    JewelDisplay[i].GetComponent<Gem_Cell>().Growth += 1;
                    GameObject g11 = Instantiate(JewelFlash[201]);
                    g11.transform.position = JewelPos[i].position;
                    g11.SetActive(true);
                }
            }
        }
    }
    void CreatorTransform(int i, int j)
    {
        JewelNum[i] = j;
        GameObject g = Instantiate(JewelObj[j]);
        g.transform.position = JewelDisplay[i].transform.position;
        g.transform.SetParent(this.gameObject.transform, true);
        Destroy(JewelDisplay[i]);
        JewelDisplay[i] = g;

        GameObject g2 = Instantiate(JewelFlash[j]);
        g2.transform.position = JewelPos[i].position;
        g2.SetActive(true);
    }
    void CreatorTransform2(int i, int j)
    {
        if(i / 7 >= 1)
        {
            CreatorTransform(i - 7, j);
        }
        if (i / 7 <= 5)
        {
            CreatorTransform(i + 7, j);
        }
        if (i % 7 <= 5)
        {
            CreatorTransform(i + 1, j);
        }
        if (i % 7 >= 1)
        {
            CreatorTransform(i - 1, j);
        }
    }
    void CreatorTransform3(int i, int j)
    {
        if (i / 7 >= 2)
        {
            CreatorTransform(i - 14, j);
        }
        if (i / 7 <= 4)
        {
            CreatorTransform(i + 14, j);
        }
        if (i % 7 <= 4)
        {
            CreatorTransform(i + 2, j);
        }
        if (i % 7 >= 2)
        {
            CreatorTransform(i - 2, j);
        }
        if (i / 7 >= 1 && i % 7 >= 1)
        {
            CreatorTransform(i - 8, j);
        }
        if (i / 7 <= 5 && i % 7 >= 1)
        {
            CreatorTransform(i + 6, j);
        }
        if (i / 7 >= 1 && i % 7 <= 5)
        {
            CreatorTransform(i - 6, j);
        }
        if (i / 7 <= 5 && i % 7 <= 5)
        {
            CreatorTransform(i + 8, j);
        }
    }
    void CreatorTransform4(int i, int j)
    {
        if (i / 7 >= 3)
        {
            CreatorTransform(i - 21, j);
        }
        if (i / 7 <= 3)
        {
            CreatorTransform(i + 21, j);
        }
        if (i % 7 <= 3)
        {
            CreatorTransform(i + 3, j);
        }
        if (i % 7 >= 3)
        {
            CreatorTransform(i - 3, j);
        }
        if (i / 7 >= 2 && i % 7 >= 1)
        {
            CreatorTransform(i - 15, j);
        }
        if (i / 7 <= 4 && i % 7 >= 1)
        {
            CreatorTransform(i + 13, j);
        }
        if (i / 7 >= 2 && i % 7 <= 5)
        {
            CreatorTransform(i - 13, j);
        }
        if (i / 7 <= 4 && i % 7 <= 5)
        {
            CreatorTransform(i + 15, j);
        }
        if (i / 7 >= 1 && i % 7 >= 2)
        {
            CreatorTransform(i - 9, j);
        }
        if (i / 7 <= 5 && i % 7 >= 2)
        {
            CreatorTransform(i + 5, j);
        }
        if (i / 7 >= 1 && i % 7 <= 4)
        {
            CreatorTransform(i - 5, j);
        }
        if (i / 7 <= 5 && i % 7 <= 4)
        {
            CreatorTransform(i + 9, j);
        }
    }
    void CreatorTransform5(int i, int j)
    {
        if (i / 7 >= 4)
        {
            CreatorTransform(i - 28, j);
        }
        if (i / 7 <= 2)
        {
            CreatorTransform(i + 28, j);
        }
        if (i % 7 <= 2)
        {
            CreatorTransform(i + 4, j);
        }
        if (i % 7 >= 4)
        {
            CreatorTransform(i - 4, j);
        }
        if (i / 7 >= 3 && i % 7 >= 1)
        {
            CreatorTransform(i - 22, j);
        }
        if (i / 7 <= 3 && i % 7 >= 1)
        {
            CreatorTransform(i + 20, j);
        }
        if (i / 7 >= 3 && i % 7 <= 5)
        {
            CreatorTransform(i - 20, j);
        }
        if (i / 7 <= 3 && i % 7 <= 5)
        {
            CreatorTransform(i + 22, j);
        }
        if (i / 7 >= 1 && i % 7 >= 3)
        {
            CreatorTransform(i - 10, j);
        }
        if (i / 7 <= 5 && i % 7 >= 3)
        {
            CreatorTransform(i + 4, j);
        }
        if (i / 7 >= 1 && i % 7 <= 3)
        {
            CreatorTransform(i - 4, j);
        }
        if (i / 7 <= 5 && i % 7 <= 3)
        {
            CreatorTransform(i + 10, j);
        }
        if (i / 7 >= 2 && i % 7 >= 2)
        {
            CreatorTransform(i - 16, j);
        }
        if (i / 7 <= 4 && i % 7 >= 2)
        {
            CreatorTransform(i + 14, j);
        }
        if (i / 7 >= 2 && i % 7 <= 4)
        {
            CreatorTransform(i - 14, j);
        }
        if (i / 7 <= 4 && i % 7 <= 4)
        {
            CreatorTransform(i + 16, j);
        }
    }
    void C1()
    {
        CatalystPut = false;
    }
    public void MatrixRemember()
    {
        if(MatrixMemory > 0 && MatrixAlter == 0)
        {
            MatrixMemory -= 1;
            MatrixAlter += 1;
            for (int i = 0; i < 9; i++)
            {
                Matrixanim2[i].Play("Matrix2");
            }
        }
    }
    public void MatrixChange(int i, int j)
    {
        if (MatrixGem[j] >= 0)
        {
            JewelNum[i] = MatrixGem[j];
            GameObject g = Instantiate(JewelObj[MatrixGem[j]]);
            g.transform.position = JewelDisplay[i].transform.position;
            g.transform.SetParent(this.gameObject.transform, true);
            Destroy(JewelDisplay[i]);
            JewelDisplay[i] = g;
        }
    }
    public void UsePotion(int i)
    {
        if (PlayerRound && !Bscript.IsDefeat)
        {
            switch (RevenantPotion[i])
            {
                case 1:
                    GameObject g1 = Instantiate(HealEffect);
                    g1.transform.position = this.transform.position;
                    g1.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.1f);
                    g1.GetComponent<BlockTrail>().GoPlayer = true;
                    g1.SetActive(true);
                    break;
                case 2:
                    GameObject g2 = Instantiate(ShieldEffect);
                    g2.transform.position = this.transform.position;
                    g2.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.2f);
                    g2.GetComponent<BlockTrail>().GoPlayer = true;
                    g2.SetActive(true);
                    break;
                case 3:
                    CurrentHand += 2;
                    break;
                case 4:
                    GameObject g4 = Instantiate(AttackEffect);
                    g4.transform.position = this.transform.position;
                    g4.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.4f);
                    g4.GetComponent<BlockTrail>().GoPlayer = false;
                    g4.SetActive(true);
                    break;
            }
            RevenantPotion[i] = 0;
            RevenantDisplay[i].PotionNum = 0;
            PlayerPrefs.SetInt($"Potion{i}", 0);
            PlayerPrefs.Save();
            GameObject g = Instantiate(SaintSkillEffect[22]);
            g.transform.position = RevenantDisplay[i].transform.position;
            g.SetActive(true);
            Iscript.SE.PlayOneShot(RevenantSE);
        }
    }
    public void SelectDroid(int i)
    {
        for(int j = 0; j < 3; j++)
        {
            FormulaSelectObj[j].SetActive(false);
        }
        FormulaSelectObj[i].SetActive(true);
        FormulaSelect = i;
    }
    public void DroidActivate()
    {
        for (int i = 0; i < 5; i++)
        {
            if (FormulaNum[i] > -1)
            {
                StartCoroutine(DroidEffect(FormulaNum[i], i));
            }
        }
    }
    public IEnumerator DroidEffect(int i, int j)
    {
        yield return new WaitForSeconds(j * 0.1f);
        switch (i)
        {
            case 0:
                GameObject g = Instantiate(AttackEffect);
                g.transform.position = FormulaDroidObj[j].position;
                g.GetComponent<EffectScript>().EffectNum = 15 + 15 * FormulaDisplay[0].DroidLevel;
                g.GetComponent<BlockTrail>().GoPlayer = false;
                g.SetActive(true);
                GameObject h = Instantiate(FormulaEffect[0]);
                h.transform.position = FormulaDroidObj[j].position;
                h.GetComponent<BlockTrail>().GoPlayer = false;
                h.SetActive(true);
                break;
            case 1:
                GameObject g2 = Instantiate(ShieldEffect);
                g2.transform.position = FormulaDroidObj[j].position;
                g2.GetComponent<EffectScript>().EffectNum = 8 + 7 * FormulaDisplay[1].DroidLevel;
                g2.GetComponent<BlockTrail>().GoPlayer = true;
                g2.SetActive(true);
                GameObject h2 = Instantiate(FormulaEffect[1]);
                h2.transform.position = FormulaDroidObj[j].position;
                h2.SetActive(true);
                break;
            case 2:
                int[] k = new int[49];
                for (int m = 0; m < 2 + FormulaDisplay[2].DroidLevel; m++)
                {
                    int Judge = Random.Range(0, 49);
                    for (int i4 = 0; i4 < 100 && k[Judge] == 1; i4++)
                    {
                        Judge = Random.Range(0, 49);
                    }
                    k[Judge] = 1;
                    if (JewelNum[Judge] < 200)
                    {
                        JewelVanish(Judge);
                    }
                    GameObject h3 = Instantiate(FormulaEffect[2]);
                    h3.transform.position = JewelPos[Judge].position;
                    h3.SetActive(true);
                }
                break;
        }
    }
}
