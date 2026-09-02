using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Localization : MonoBehaviour
{
    float count;
    public string Japanese;
    public string English;
    public bool ReloadOn;
    void Start()
    {
        Japanese = GetComponent<TMP_Text>().text;
        switch (PlayerPrefs.GetInt("Language", 2))
        {
            case 2:
                GetComponent<TMP_Text>().text = English;
                break;
        }
    }
    void Update()
    {
        if(ReloadOn)
        {
            count += Time.deltaTime;
            if(count > 1f)
            {
                count = 0f;
                switch (PlayerPrefs.GetInt("Language", 2))
                {
                    case 1:
                        GetComponent<TMP_Text>().text = Japanese;
                        break;
                    case 2:
                        GetComponent<TMP_Text>().text = English;
                        break;
                }
            }
        }
    }
}
