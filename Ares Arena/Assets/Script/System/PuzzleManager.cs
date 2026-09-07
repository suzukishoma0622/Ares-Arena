using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;

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
    
    public int DayBreak;
    public int Gem54 = 32;
    int Gem55 = 1;
    int Gem78 = 0;
    bool BurningHand;
    bool Gaze;

    float Bless3;
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
    int[] RevenantPotion = new int[4];
    public InfoDisplay_Potion[] RevenantDisplay;

    public AudioClip CastSE1;
    public AudioClip CastSE2;
    public AudioClip SkillSE;
    public AudioClip RevengeSE;
    public AudioClip SentrySE;
    public AudioClip GolemSE;
    public AudioClip RevenantSE;
    void Start()
    {
        Saint = PlayerPrefs.GetInt("Saint1", 1);
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
            for(int i = 0; i < 4; i++)
            {
                RevenantPotion[i] = PlayerPrefs.GetInt($"Potion{i}", 0);
                RevenantDisplay[i].PotionNum = RevenantPotion[i];
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
    }
    void Update()
    {
        if(CurrentHand < 0)
        {
            CurrentHand = 0;
        }
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
    }
    public void RoundStart()
    {
        if (Bscript.Iscript.Bless[40] == 1)
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
        if (Bscript.Iscript.Bless[34] == 1 && ActiveSkill == 1)
        {
            CurrentHand += 4;
        }
        ActiveSkill = 1;
        SkillDisplay();
        Probcalc();
        for (int i = 0; i < 49; i++)
        {
            if (OrderDisplay[i] != null)
            {
                OrderDisplay[i].GetComponent<OrderCount>().text.gameObject.SetActive(true);
            }
            if (JewelNum[i] == 201)
            {
                if (JewelDisplay[i].GetComponent<Gem_Cell>().Growth < 4)
                {
                    JewelDisplay[i].GetComponent<Gem_Cell>().Growth += 1;
                    GameObject g2 = Instantiate(JewelFlash[201]);
                    g2.transform.position = JewelPos[i].position;
                    g2.SetActive(true);
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
        if (Bscript.Iscript.Bless[28] == 1 && (Iscript.PlayerHP <= Iscript.PlayerMaxHP / 2 || Iscript.Bless[42] == 1))
        {
            CurrentHand += 2;
        }
        if (Bless31)
        {
            Bscript.PlayerShield += Mathf.FloorToInt(Bscript.Iscript.PlayerMaxHP * 0.2f);
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
            g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.02f);
            g.GetComponent<BlockTrail>().GoPlayer = true;
            g.SetActive(true);
            if (Iscript.Bless[3] == 1)
            {
                Bless3 += Iscript.PlayerMaxHP * 0.02f * 0.1f;
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
        if (Bscript.Iscript.Bless[50] == 1 && Bscript.CurrentRound == 1)
        {
            GameObject g = Instantiate(AttackEffect);
            g.transform.position = this.transform.position;
            g.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(Bscript.EnemyMaxHP * 0.5f);
            g.GetComponent<BlockTrail>().GoPlayer = false;
            g.SetActive(true);
            Bscript.Iscript.Bless[50] = 2;
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
        for(int j = 0; j < 5; j++)
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
                if(DayBreak > 0)
                {
                    float Judge2 = Random.Range(0f, 100f);
                    if(Judge2 < DayBreak)
                    {
                        JewelNum[i] = 303;
                    }
                }
                if(IsFrozenHound)
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
                    CatalystNum[i] = 20;
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
                    int C67 = 0;
                    if (Bscript.Iscript.Bless[57] == 1 && Chained <= 2 && Chained > 0 && Chain == 0)
                    {
                        C67 = 3;
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
                    JewelEffect(JewelNum[C], C);
                    if (BurningHand)
                    {
                        Iscript.Revenge += Mathf.FloorToInt(4f * Iscript.PlayerHPRate);
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
                    Invoke("ChainHand", 0.1f);
                    for (int i2 = 0; i2 < JewelPos.Length; i2++)
                    {
                        JewelPos[i2].GetComponent<Button>().interactable = false;
                    }
                    if (IsCyberResistance)
                    {
                        Cscript.DisNoise(i);
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
                    if ((JewelNum[C2 - 7] == C3 || JewelNum[C2 - 7] == 200) && JewelNum[C2 - 7] != -1 && C3 != -1)
                    {
                        JewelNum[C2 - 7] = C3;
                        JewelHand(C2 - 7);
                        break;
                    }
                }
                if (C2 <= 41)
                {
                    if ((JewelNum[C2 + 7] == C3 || JewelNum[C2 + 7] == 200) && JewelNum[C2 + 7] != -1 && C3 != -1)
                    {
                        JewelNum[C2 + 7] = C3;
                        JewelHand(C2 + 7);
                        break;
                    }
                }
                if (C2 % 7 >= 1)
                {
                    if ((JewelNum[C2 - 1] == C3 || JewelNum[C2 - 1] == 200) && JewelNum[C2 - 1] != -1 && C3 != -1)
                    {
                        JewelNum[C2 - 1] = C3;
                        JewelHand(C2 - 1);
                        break;
                    }
                }
                if (C2 % 7 <= 5)
                {
                    if ((JewelNum[C2 + 1] == C3 || JewelNum[C2 + 1] == 200) && JewelNum[C2 + 1] != -1 && C3 != -1)
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
                    g8.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((20 + (Chain - 1) * 2f) * WeakNum);
                    g8.GetComponent<BlockTrail>().GoPlayer = false;
                    g8.SetActive(true);
                    break;
                case 9:
                    GameObject g9 = Instantiate(ShieldEffect);
                    g9.transform.position = JewelPos[j].position;
                    g9.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((10 + (Chain - 1)) * WeakNum);
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
                    g14.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((5 + (Chain - 1) * 0.5f) * WeakNum);
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
                    g17.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(7 + (2 * CurrentTurnHand) + (Chain - 1) * (0.7f + 0.2f * CurrentTurnHand));
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
                    g19.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((18 + (Chain - 1) * 1.8f) * WeakNum);
                    g19.GetComponent<BlockTrail>().GoPlayer = true;
                    g19.SetActive(true);
                    break;
                case 20:
                    GameObject g20 = Instantiate(ShieldEffect);
                    g20.transform.position = JewelPos[j].position;
                    g20.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((6 + (Chain - 1) * 0.6f) * WeakNum);
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
                    g28_1.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(27 + (Chain - 1) * 2.7f);
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
                    g33.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((13 + (Chain - 1) * 1.3f) * WeakNum);
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
                    g34.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((30 + (Chain - 1) * 3f) * WeakNum);
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
                    g38.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((12 + (Chain - 1) * 1.2f) * WeakNum);
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
                    g39.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((32 + (Chain - 1) * 3.2f) * WeakNum);
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
                    g40.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((15 + (Chain - 1) * 1.5f) * WeakNum);
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
                    g46.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((18 + (Chain - 1) * 1.8f) * WeakNum);
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
                    g54.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((17 + (Chain - 1) * 1.7f) * WeakNum);
                    g54.GetComponent<BlockTrail>().GoPlayer = false;
                    g54.SetActive(true);
                    if (Chain == 15)
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
                        g63.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((36 + (Chain - 1) * 3.6f) * WeakNum);
                    }
                    else
                    {
                        g63.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((18 + (Chain - 1) * 1.8f) * WeakNum);
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
                    if (Chain % 5 == 0)
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
                        g77.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((32 + (Chain - 1) * 3.2f) * WeakNum);
                    }
                    else
                    {
                        g77.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((16 + (Chain - 1) * 1.6f) * WeakNum);
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
                    g85.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((8 + (Chain - 1) * 0.8f) * WeakNum);
                    g85.GetComponent<BlockTrail>().GoPlayer = true;
                    g85.SetActive(true);
                    if (Iscript.Bless[3] == 1)
                    {
                        Bless3 += (8 + (Chain - 1) * 0.8f) * WeakNum * 0.1f;
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
                    Iscript.Revenge -= 3;
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
                        GameObject g90 = Instantiate(AttackEffect);
                        g90.transform.position = JewelPos[j].position;
                        g90.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt((30 + (Chain - 1) * 3f) * WeakNum);
                        g90.GetComponent<BlockTrail>().GoPlayer = false;
                        g90.SetActive(true);
                    }
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
            if (Iscript.Bless[30] == 1 && (i == 4 || i == 74 || i == 83 || i == 84 || i == 90 || i == 95))
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
                    for (int i = 0; i < 49; i++)
                    {
                        if (JewelNum[i] == EquipJewel[Judge])
                        {
                            JewelVanish(i);
                            GameObject g1 = Instantiate(SaintSkillEffect[0]);
                            g1.transform.position = JewelPos[i].position;
                            g1.SetActive(true);
                        }
                    }
                    break;
                case 2:
                    GameObject g2 = Instantiate(SaintSkillEffect[1]);
                    g2.transform.position = SkillEffectPos[0].position;
                    g2.SetActive(true);
                    Watcher_Sniper = Watcher_Quiver;
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
                    Fractal_Prism = 4;
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
                    Collector_Skill = 3;
                    break;
                case 8:
                    CurrentHand += 4;
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
                    g9.GetComponent<EffectScript>().EffectNum = Bscript.PlayerShield;
                    g9.GetComponent<BlockTrail>().GoPlayer = false;
                    g9.SetActive(true);
                    Bscript.PlayerShield = Mathf.FloorToInt(Bscript.PlayerShield * 0.7f);
                    Iscript.SE.PlayOneShot(GolemSE);
                    break;
                case 10:
                    for (int l = 0; l < 4; l++)
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
                    Creator_Cell = 1;
                    break;
                case 12:
                    GameObject g12 = Instantiate(SaintSkillEffect[20]);
                    g12.transform.position = SkillEffectPos[0].position;
                    g12.SetActive(true);
                    MatrixSkill = 1;
                    break;
                case 13:
                    for(int j = 0; j < 4; j++)
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
                    break;
            }
            ActiveSkill -= 1;
            SkillDisplay();
        }
    }
    public void RevengeSkill()
    {
        if(Bscript.RevengeSlider.value == Bscript.RevengeSlider.maxValue && PlayerRound && !Bscript.IsDefeat)
        {
            Iscript.SE.PlayOneShot(RevengeSE);
            switch (Saint)
            {
                case 1:
                    CurrentHand += 5;
                    GameObject g1 = Instantiate(SaintRevengeEffect[0]);
                    g1.transform.position = RevengeEffectPos[0].transform.position;
                    g1.SetActive(true);
                    break;
                case 2:
                    Watcher_Quiver += 3;
                    switch(Language)
                    {
                        case 1:
                            SkillDescText.text = "任意の宝石" + Watcher_Quiver + "つを消去する。";
                            break;
                        case 2:
                            SkillDescText.text = "Cast any " + Watcher_Quiver + " gems.";
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
                    PlayerPrefs.SetInt("SentryRevenge", PlayerPrefs.GetInt("SentryRevenge", 0) + 60);
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
                    for(int i = 0;i < 5;i++)
                    {
                        CollectorGem[i] += 2;
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
                    for (int l = 0; l < 6; l++)
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
                    MatrixMemory += 2;
                    GameObject g12_2 = Instantiate(SaintRevengeEffect[2]);
                    g12_2.transform.position = RevengeEffectPos[2].transform.position;
                    break;
                case 13:
                    for (int j = 0; j < 4; j++)
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
}
