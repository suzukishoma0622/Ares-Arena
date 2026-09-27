using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject[] Effect;
    public InfoDisplay Iscript;
    public BattleManager Bscript;
    public GameObject Counter;
    public bool Gaze;
    public AudioClip HitSE;
    public AudioClip GuardSE;
    public AudioClip GuardBreakSE;
    public AudioClip ShieldSE;
    public AudioClip HealSE;

    public bool IsCaptainScissors;
    public Enemy_CaptainScissors Cscript;
    public bool IsStaticBeast;
    public Enemy_StaticBeast Sscript;
    public int Evasion;
    void Start()
    {
        Invoke("Bless_CleverScheme", 0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "AttackEffect" && !collision.gameObject.GetComponent<BlockTrail>().GoPlayer)
        {
            int d = collision.gameObject.GetComponent<EffectScript>().EffectNum;
            if (Bscript.Iscript.Bless[16] == 1)
            {
                d += 1 + Iscript.Bless[54];
            }
            if(Gaze)
            {
                d *= 2 + Bscript.Pscript.Bless22;
                d += Iscript.Bless[54];
            }
            d += Bscript.Pscript.Gem135;
            if (Evasion > 0 && d > Evasion)
            {
                d = Evasion;
            }
            Bscript.Pscript.DamageSum += d;
            if (Bscript.EnemyShield > 0)
            {
                if (Bscript.Iscript.Bless[17] == 1)
                {
                    d *= 2;
                }
                if (Bscript.EnemyShield >= d)
                {
                    Bscript.EnemyShield -= d;
                    Iscript.SE.PlayOneShot(GuardSE);
                    d = 0;
                    GameObject g2 = Instantiate(Effect[2]);
                    g2.transform.position = this.transform.position;
                    g2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    g2.SetActive(true);
                }
                else
                {
                    d -= Bscript.EnemyShield;
                    Bscript.EnemyShield = 0;
                    Bscript.EnemyHP -= d;
                    if (IsStaticBeast)
                    {
                        Sscript.AttackRate += 0.01f;
                    }
                    Iscript.SE.PlayOneShot(GuardBreakSE);
                    Iscript.SE.PlayOneShot(HitSE);
                    GameObject g3 = Instantiate(Effect[3]);
                    g3.transform.position = this.transform.position;
                    g3.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    g3.SetActive(true);
                }
            }
            else
            {
                Bscript.EnemyHP -= d;
                Iscript.SE.PlayOneShot(HitSE);
                if (IsStaticBeast)
                {
                    Sscript.AttackRate += 0.01f;
                }
            }
            if (Bscript.EnemyHP <= 0)
            {
                Bscript.EnemyHP = 0;
                if (!Bscript.IsDefeat)
                {
                    if (collision.gameObject.GetComponent<EffectScript>().Gem76)
                    {
                        Bscript.RewardMedal += 1;
                    }
                    Bscript.DefeatEffect();
                }
            }
            GameObject g = Instantiate(Counter);
            g.transform.position = new Vector3(this.transform.position.x + Random.Range(-1f, 1f), this.transform.position.y + Random.Range(-1f, 1f), 0);
            if (d > 0)
            {
                g.GetComponent<InfoDisplay_Counter>().Thisnum = d.ToString();
            }
            else
            {
                g.GetComponent<InfoDisplay_Counter>().Thisnum = "0";
            }
            g.GetComponent<InfoDisplay_Counter>().Coloring_R = 1;
            g.GetComponent<InfoDisplay_Counter>().Coloring_G = 0;
            g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
            g.SetActive(true);
            for(int i = 0; i < 2;i++)
            {
                GameObject g2 = Instantiate(Effect[0]);
                g2.transform.position = this.transform.position;
                g2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-180f, 180f));
                g2.SetActive(true);
            }
            if(IsCaptainScissors)
            {
                if(Cscript.Refrect > 0)
                {
                    GameObject g2 = Instantiate(Cscript.AttackObj[0]);
                    g2.transform.position = this.transform.position;
                    g2.GetComponent<BlockTrail>().GoPlayer = true;
                    g2.GetComponent<EffectScript>().EffectNum = Cscript.Refrect;
                }
            }
        }
        if (collision.gameObject.tag == "ShieldEffect")
        {
            int d = collision.gameObject.GetComponent<EffectScript>().EffectNum;
            Bscript.EnemyShield += d;
            Iscript.SE.PlayOneShot(ShieldSE);
            GameObject g = Instantiate(Effect[1]);
            g.transform.position = this.transform.position;
            g.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            g.SetActive(true);
        }
        if (collision.gameObject.tag == "HealEffect")
        {
            int d = collision.gameObject.GetComponent<EffectScript>().EffectNum;
            GameObject g = Instantiate(Counter);
            Iscript.SE.PlayOneShot(HealSE);
            g.transform.position = this.transform.position;
            g.GetComponent<InfoDisplay_Counter>().Thisnum = d.ToString();
            g.GetComponent<InfoDisplay_Counter>().Coloring_R = 0;
            g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
            g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
            g.SetActive(true);
            Bscript.EnemyHP += d;
            if (Bscript.EnemyHP > Bscript.EnemyMaxHP)
            {
                Bscript.EnemyHP = Bscript.EnemyMaxHP;
            }
        }
    }
    private void Bless_CleverScheme()
    {
        if (Iscript.Bless[50] == 1 && Iscript.CurrentRound <= 5)
        {
            Bscript.EnemyHP = Mathf.FloorToInt(Bscript.EnemyMaxHP * 0.5f);
            Iscript.Bless[50] = 2;
        }
    }
}
