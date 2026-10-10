using TMPro;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    SaveData data;
    public GameObject Dobj;
    int[] BlessUnlock = new int[200];
    public GameObject[] BlessObj;
    public GameObject[] GemObj;
    public TMP_Text[] StarterText;
    void Start()
    {
        data = Dobj.GetComponent<DataManager>().Dscript;
        for (int i = 0; i < BlessObj.Length; i++)
        {
            BlessUnlock[i + 1] = data.BlessUnlock[i + 1];
            if (BlessUnlock[i + 1] == 1)
            {
                BlessObj[i].SetActive(true);
            }
        }
        for (int i = 0; i < GemObj.Length; i++)
        {
            if (data.GemUnlock[i + 1] == 1)
            {
                GemObj[i].SetActive(true);
            }
        }
        if (BlessUnlock[1] == 0 && BlessUnlock[2] == 0 && BlessUnlock[3] == 0 && BlessUnlock[4] == 0 && BlessUnlock[5] == 0 && BlessUnlock[6] == 0 && BlessUnlock[19] == 0 && BlessUnlock[20] == 0 && BlessUnlock[65] == 0 && BlessUnlock[66] == 0)
        {
            StarterText[0].text = "???";
            StarterText[0].GetComponent<Localization>().enabled = false;
        }
        if (BlessUnlock[7] == 0 && BlessUnlock[8] == 0 && BlessUnlock[9] == 0 && BlessUnlock[10] == 0 && BlessUnlock[11] == 0 && BlessUnlock[12] == 0 && BlessUnlock[23] == 0 && BlessUnlock[24] == 0 && BlessUnlock[67] == 0 && BlessUnlock[68] == 0)
        {
            StarterText[1].text = "???";
            StarterText[1].GetComponent<Localization>().enabled = false;
        }
        if (BlessUnlock[13] == 0 && BlessUnlock[14] == 0 && BlessUnlock[15] == 0 && BlessUnlock[16] == 0 && BlessUnlock[17] == 0 && BlessUnlock[18] == 0 && BlessUnlock[21] == 0 && BlessUnlock[22] == 0 && BlessUnlock[69] == 0 && BlessUnlock[70] == 0)
        {
            StarterText[2].text = "???";
            StarterText[2].GetComponent<Localization>().enabled = false;
        }
    }
}
