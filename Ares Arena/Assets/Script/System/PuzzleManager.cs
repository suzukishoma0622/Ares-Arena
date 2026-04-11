using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PuzzleManager : MonoBehaviour
{
    public Transform[] JewelPos = new Transform[49];
    public int[] JewelNum = new int[49];
    public GameObject[] JewelObj;
    public GameObject[] JewelFlash;
    public GameObject JewelAttackEffect;
    public GameObject JewelDefenseEffect;
    GameObject[] JewelDisplay = new GameObject[49];

    public float TimeLimit;
    public int AttackScore;
    public int DefenseScore;
    public int Chain = -1;
    public float ChainTime;
    float AttackDisplay;
    float DefenseDisplay;
    public TMP_Text TimeText;
    public TMP_Text AttackText;
    public TMP_Text DefenseText;
    public TMP_Text ChainText;

    public Transform Pointer;
    public int PointerNum = -1;
    public int CaptureNum = -1;
    int[] ChangeNum = {-1, -1};
    bool[] Vanish = new bool[49];

    public bool PlayerRound;
    [SerializeField] GameObject TimeUpObj;
    [SerializeField] GameObject NoMoreMoveObj;
    [SerializeField] GameObject ParentCanvas;
    [SerializeField] CanvasGroup PuzzleCover;
    void Start()
    {
        RoundStart();
        Shuffle();
        PlayerRound = true;
    }
    void Update()
    {
        if(TimeLimit > 0f)
        {
            TimeLimit -= Time.deltaTime;
        }
        else if(PlayerRound)
        {
            GameObject g = Instantiate(TimeUpObj);
            g.transform.position = new Vector3(960f, 540f, 0f);
            g.transform.SetParent(ParentCanvas.transform);
            g.SetActive(true);
            PlayerRound = false;
            Scanning();
        }
        TimeText.text = Mathf.CeilToInt(TimeLimit).ToString();
        AttackText.text = AttackDisplay.ToString("0");
        DefenseText.text = DefenseDisplay.ToString("0");
        if(AttackDisplay < AttackScore)
        {
            AttackDisplay += Time.deltaTime * (10f + AttackScore - AttackDisplay);
        }
        else
        {
            AttackDisplay -= Time.deltaTime * (10f + AttackDisplay - AttackScore);
        }
        if (DefenseDisplay < DefenseScore)
        {
            DefenseDisplay += Time.deltaTime * (10f + DefenseScore - DefenseDisplay);
        }
        else
        {
            DefenseDisplay -= Time.deltaTime * (10f + DefenseDisplay - DefenseScore);
        }
        if (Chain <= 0)
        {
            ChainText.text = "0";
        }
        else
        {
            ChainText.text = Chain.ToString();
        }
        for(int i = 0; i < JewelPos.Length; i++)
        {
            if (CaptureNum == i)
            {
                JewelDisplay[i].transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
            }
            else if (JewelDisplay[i] != null)
            {
                JewelDisplay[i].transform.position = Vector3.MoveTowards(JewelDisplay[i].transform.position, JewelPos[i].position, Time.deltaTime * (5f +
                    (Mathf.Sqrt(Mathf.Pow((JewelDisplay[i].transform.position.x - JewelPos[i].position.x) * 5f, 2) + Mathf.Pow((JewelDisplay[i].transform.position.y - JewelPos[i].position.y) * 5f, 2)))));
            }
        }
        Pointer.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(PointerNum >= 0)
        {
            if (CaptureNum < 0)
            {
                if (Input.GetMouseButtonDown(0) && TimeLimit > 0f)
                {
                    for (int i = 0; i < 49; i++)
                    {
                        Vanish[i] = false;
                    }
                    CaptureNum = PointerNum;
                    PointerNum = -1;
                }
            }
            else
            {
                if ((PointerNum == CaptureNum + 1 || PointerNum == CaptureNum - 1 ||
               PointerNum == CaptureNum + 7 || PointerNum == CaptureNum - 7) && CaptureNum >= 0)
                {
                    ChangeNum[0] = CaptureNum;
                    ChangeNum[1] = PointerNum;
                    CaptureNum = -1;
                    PointerNum = -1;
                    int a = JewelNum[ChangeNum[0]];
                    GameObject g = JewelDisplay[ChangeNum[0]];
                    JewelNum[ChangeNum[0]] = JewelNum[ChangeNum[1]];
                    JewelNum[ChangeNum[1]] = a;
                    JewelDisplay[ChangeNum[0]] = JewelDisplay[ChangeNum[1]];
                    JewelDisplay[ChangeNum[1]] = g;
                    Invoke("BoardCheck", 0.2f);
                }
                else
                {
                    CaptureNum = -1;
                }
            }
        }
        if(Chain >= 1)
        {
            ChainText.gameObject.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 5f;
        }
        else if(ChainText.gameObject.GetComponent<CanvasGroup>().alpha > 0f)
        {
            ChainText.gameObject.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 2f;
        }
        if(ChainTime > 0)
        {
            ChainTime -= Time.deltaTime;
        }
        else
        {
            Chain = -1;
        }
        if(!PlayerRound)
        {
            PuzzleCover.alpha += Time.deltaTime * 2f;
        }
        else
        {
            PuzzleCover.alpha -= Time.deltaTime * 2f;
        }
    }
    public void RoundStart()
    {
        TimeLimit = 30f;
        AttackScore = 0;
        DefenseScore = 0;
    }
    public void NoMoreMove()
    {

    }
    public void Shuffle()
    {
        int s = 1;
        for (; s > 0;)
        {
            s = 0;
            for (int i = 0; i < 49; i++)
            {
                JewelNum[i] = Random.Range(0, 6);
            }
            for(int i = 0; i < 7; i++)
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
        }
        for (int i = 0; i < 49; i++)
        {
            GameObject g = Instantiate(JewelObj[JewelNum[i]]);
            g.transform.position = new Vector3(JewelPos[i].position.x, 4f, 0f);
            JewelDisplay[i] = g;
        }
    }
    public void BoardCheck()
    {
        int s = 0;
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (JewelNum[i * 7 + j] == JewelNum[i * 7 + j + 1] && JewelNum[i * 7 + j + 1] == JewelNum[i * 7 + j + 2])
                {
                    s++;
                    Vanish[i * 7 + j] = true;
                    Vanish[i * 7 + j + 1] = true;
                    Vanish[i * 7 + j + 2] = true;
                    switch (JewelNum[i * 7 + j])
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            AttackScore += 4 + Chain;
                            break;
                        case 4:
                        case 5:
                            DefenseScore += 4 + Chain;
                            break;
                    }
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
                    Vanish[j * 7 + i] = true;
                    Vanish[(j + 1) * 7 + i] = true;
                    Vanish[(j + 2) * 7 + i] = true;
                    switch(JewelNum[j * 7 + i])
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            AttackScore += 3 + Chain;
                            break;
                        case 4:
                        case 5:
                            DefenseScore += 3 + Chain;
                            break;
                    }
                }
            }
        }
        if (s == 0)
        {
            Reverse(ChangeNum[0], ChangeNum[1]);
        }
        else
        {
            Chain += 1;
            ChainTime = 1f;
            for (int i = 0; i < 49; i++)
            {
                if (Vanish[i])
                {
                    switch(JewelNum[i])
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            Instantiate(JewelAttackEffect, JewelPos[i].position, Quaternion.identity);
                            break;
                        case 4:
                        case 5:
                            Instantiate(JewelDefenseEffect, JewelPos[i].position, Quaternion.identity);
                            break;
                    }
                    Instantiate(JewelFlash[JewelNum[i]], JewelPos[i].position, Quaternion.identity);
                    JewelNum[i] = -1;
                    Destroy(JewelDisplay[i]);
                    JewelDisplay[i] = null;
                }
                Vanish[i] = false;
            }
            ChangeNum[0] = -1;
            ChangeNum[1] = -1;
            Invoke("JewelFall", 0.6f);
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
                JewelNum[i] = Random.Range(0, 6);
                GameObject g = Instantiate(JewelObj[JewelNum[i]]);
                g.transform.position = new Vector3(JewelPos[i].position.x, 4f, 0f);
                JewelDisplay[i] = g;
            }
        }
        Invoke("BoardCheck", 0.2f);
    }
    public void Reverse(int c1, int c2)
    {
        if(c1 == -1 || c2 == -1)
        {
            return;
        }
        int a = JewelNum[c1];
        GameObject g = JewelDisplay[c1];
        JewelNum[c1] = JewelNum[c2];
        JewelNum[c2] = a;
        JewelDisplay[c1] = JewelDisplay[c2];
        JewelDisplay[c2] = g;
        ChangeNum[0] = -1;
        ChangeNum[1] = -1;
    }
    public void Scanning()
    {
        int[] e = {-1, -1, -1};
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                for (int l = 0; l < 2; l++)
                {
                    if (JewelNum[i + l + j * 7] == JewelNum[i + (j + 1) * 7] && JewelNum[i + (j + 1) * 7] == JewelNum[i + (j + 2) * 7])
                    {
                        e[0] = i + l + j * 7;
                        e[1] = i + (j + 1) * 7;
                        e[2] = i + (j + 2) * 7;
                    }
                    if (JewelNum[i + l + j * 7] == JewelNum[i + 1 + (j + 1) * 7] && JewelNum[i + 1 + (j + 1) * 7] == JewelNum[i + (j + 2) * 7])
                    {
                        e[0] = i + l + j * 7;
                        e[1] = i + 1 + (j + 1) * 7;
                        e[2] = i + (j + 2) * 7;
                    }
                    if (JewelNum[i + l + j * 7] == JewelNum[i + (j + 1) * 7] && JewelNum[i + (j + 1) * 7] == JewelNum[i + 1 + (j + 2) * 7])
                    {
                        e[0] = i + l + j * 7;
                        e[1] = i + (j + 1) * 7;
                        e[2] = i + 1 + (j + 2) * 7;
                    }
                    if (JewelNum[i + l + j * 7] == JewelNum[i + 1 + (j + 1) * 7] && JewelNum[i + 1 + (j + 1) * 7] == JewelNum[i + 1 + (j + 2) * 7])
                    {
                        e[0] = i + l + j * 7;
                        e[1] = i + 1 + (j + 1) * 7;
                        e[2] = i + 1 + (j + 2) * 7;
                    }
                }
            }
            for (int k = 0; k < 3; k++)
            {
                if (e[k] != -1)
                {
                    GameObject g = Instantiate(JewelFlash[JewelNum[e[k]]]);
                    g.transform.position = JewelPos[e[k]].position;
                    g.GetComponent<Fadein>().num = 1f;
                }
                e[k] = -1;
            }
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                for (int l = 0; l < 2; l++)
                {
                    if (JewelNum[i + (l + j) * 7] == JewelNum[i + 1 + j * 7] && JewelNum[i + 1 + j * 7] == JewelNum[i + 2 + j * 7])
                    {
                        e[0] = i + (l + j) * 7;
                        e[1] = i + 1 + j * 7;
                        e[2] = i + 2 + j * 7;
                    }
                    if (JewelNum[i + (l + j) * 7] == JewelNum[i + 1 + (j + 1) * 7] && JewelNum[i + 1 + (j + 1) * 7] == JewelNum[i + 2 + j * 7])
                    {
                        e[0] = i + (l + j) * 7;
                        e[1] = i + 1 + (j + 1) * 7;
                        e[2] = i + 2 + j * 7;
                    }
                    if (JewelNum[i + (l + j) * 7] == JewelNum[i + 1 + j * 7] && JewelNum[i + 1 + j * 7] == JewelNum[i + 2 + (j + 1) * 7])
                    {
                        e[0] = i + (l + j) * 7;
                        e[1] = i + 1 + j * 7;
                        e[2] = i + 2 + (j + 1) * 7;
                    }
                    if (JewelNum[i + (l + j) * 7] == JewelNum[i + 1 + (j + 1) * 7] && JewelNum[i + 1 + (j + 1) * 7] == JewelNum[i + 2 + (j + 1) * 7])
                    {
                        e[0] = i + (l + j) * 7;
                        e[1] = i + 1 + (j + 1) * 7;
                        e[2] = i + 2 + (j + 1) * 7;
                    }
                }
                for (int k = 0; k < 3; k++)
                {
                    if (e[k] != -1)
                    {
                        GameObject g = Instantiate(JewelFlash[JewelNum[e[k]]]);
                        g.transform.position = JewelPos[e[k]].position;
                        g.GetComponent<Fadein>().num = 1f;
                    }
                    e[k] = -1;
                }
            }
        }
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (JewelNum[i * 7 + j] == JewelNum[i * 7 + j + 3] && JewelNum[i * 7 + j] == JewelNum[i * 7 + j + 1])
                {
                    e[0] = i * 7 + j;
                    e[1] = i * 7 + j + 3;
                    e[2] = i * 7 + j + 1;
                }
                if (JewelNum[i * 7 + j] == JewelNum[i * 7 + j + 3] && JewelNum[i * 7 + j] == JewelNum[i * 7 + j + 2])
                {
                    e[0] = i * 7 + j;
                    e[1] = i * 7 + j + 3;
                    e[2] = i * 7 + j + 2;
                }
                for (int k = 0; k < 3; k++)
                {
                    if (e[k] != -1)
                    {
                        GameObject g = Instantiate(JewelFlash[JewelNum[e[k]]]);
                        g.transform.position = JewelPos[e[k]].position;
                        g.GetComponent<Fadein>().num = 1f;
                    }
                    e[k] = -1;
                }
            }
        }
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (JewelNum[j * 7 + 1] == JewelNum[(j + 3) * 7 + i] && JewelNum[j * 7 + i] == JewelNum[(j + 1) * 7 + i])
                {
                    e[0] = j * 7 + i;
                    e[1] = (j + 3) * 7 + i;
                    e[2] = (j + 1) * 7 + i;
                }
                if (JewelNum[j * 7 + i] == JewelNum[(j + 3) * 7 + i] && JewelNum[j * 7 + i] == JewelNum[(j + 2) * 7 + i])
                {
                    e[0] = j * 7 + i;
                    e[1] = (j + 3) * 7 + i;
                    e[2] = (j + 2) * 7 + i;
                }
                for (int k = 0; k < 3; k++)
                {
                    if (e[k] != -1)
                    {
                        GameObject g = Instantiate(JewelFlash[JewelNum[e[k]]]);
                        g.transform.position = JewelPos[e[k]].position;
                        g.GetComponent<Fadein>().num = 1f;
                    }
                    e[k] = -1;
                }
            }
        }
    }
}
