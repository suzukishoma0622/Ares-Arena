using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaintSelectController : MonoBehaviour
{
    public TMP_Text SaintName;
    public TMP_Text SaintTrait;
    public TMP_Text SaintExplain;
    public TMP_Text SaintHP;
    public Image SaintBar;
    int[] SaintTraitNum = {1, 1, 1, 2, 2, 2, 3, 3, 3};
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Select(int i)
    {
        switch(i)
        {
            case 1:
                SaintName.text = "The Sear";
                SaintExplain.text = "A frenzied warrior wielding a molten sword.\n" +
                    "Continues to burn himself, striving to become one with the flames.";
                SaintHP.text = "HP: 300";
                break;
            case 2:
                SaintName.text = "The Sentry";
                SaintExplain.text = "A summoner possessed by the ghosts of war.\n" +
                    "Thoughts are controlled by the ear ringing in spirit's";
                SaintHP.text = "HP: 300";
                break;
            case 3:
                SaintName.text = "The Codex";
                SaintExplain.text = "A frenzied warrior wielding a molten sword.\n" +
                    "\nContinues to burn himself, striving to become one with the flames.";
                SaintHP.text = "HP: 250";
                break;
            case 4:
                SaintName.text = "The Golem";
                SaintExplain.text = "A self-aware defense droid.\n" +
                    "Uses stone body as a shield to protect comrades.";
                SaintHP.text = "HP: 400";
                break;
            case 5:
                SaintName.text = "The Earthwind";
                SaintExplain.text = "A blind knight who fights by relying on the flow of the wind.\n" +
                    "Reads the winds of victory and sees through everything.";
                SaintHP.text = "HP: 300";
                break;
            case 6:
                SaintName.text = "The Professor";
                SaintExplain.text = "A scholar who achieved immortality through physical modification.\n" +
                    "With infinite regenerative power, rises again and again.";
                SaintHP.text = "HP: 350";
                break;
            case 7:
                SaintName.text = "The Valkyrie";
                SaintExplain.text = "The Holy Knight awakened from slumbering prayer.\n" +
                    "Ceaseless communication with the heavens moved the heart of God.";
                SaintHP.text = "HP: 300";
                break;
            case 8:
                SaintName.text = "The Watcher";
                SaintExplain.text = "The last surviving knight of the surveillance family.\n" +
                    "Fulfills own mission, clutching a watch that served as a memento.";
                SaintHP.text = "HP: 250";
                break;
            case 9:
                SaintName.text = "The Transfer";
                SaintExplain.text = "A wandering warrior cursed by the mist.\n" +
                    "Even after losing physical form, continues to wield blade.";
                SaintHP.text = "HP: 250";
                break;
        }
        switch(SaintTraitNum[i - 1])
        {
            case 1:
                SaintTrait.text = "Assault";
                SaintTrait.color = new Color(1f, 0f, 0f, 1f);
                SaintBar.color = new Color(1f, 0f, 0f, 1f);
                break;
            case 2:
                SaintTrait.text = "Guardian";
                SaintTrait.color = new Color(0.5f, 0f, 1f, 1f);
                SaintBar.color = new Color(0.5f, 0f, 1f, 1f);
                break;
            case 3:
                SaintTrait.text = "Mystic";
                SaintTrait.color = new Color(0f, 1f, 0f, 1f);
                SaintBar.color = new Color(0f, 1f, 0f, 1f);
                break;
        }
    }
}
