using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    public GameObject[] BlessObj;
    public GameObject[] GemObj;
    void Start()
    {
        for(int i = 0; i < BlessObj.Length; i++)
        {
            if(PlayerPrefs.GetInt($"BlessUnlock{i + 1}", 0) == 1)
            {
                BlessObj[i].SetActive(true);
            }
        }
        for (int i = 0; i < GemObj.Length; i++)
        {
            if (PlayerPrefs.GetInt($"GemUnlock{i + 1}", 0) == 1)
            {
                GemObj[i].SetActive(true);
            }
        }
    }
}
