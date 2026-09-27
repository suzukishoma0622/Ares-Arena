using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject[] Effect;
    public InfoDisplay Iscript;
    public BattleManager Bscript;
    public PuzzleManager Pscript;
    public GameObject Counter;
    public AudioClip HitSE;
    public AudioClip GuardSE;
    public AudioClip GuardBreakSE;
    public AudioClip ShieldSE;
    public AudioClip PoizonSE;
    public AudioClip HealSE;
    public AudioClip RevengeSE;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.tag == "AttackEffect" || collision.gameObject.tag == "PoizonEffect") && !Bscript.IsDefeat)
        {
            int d = collision.gameObject.GetComponent<EffectScript>().EffectNum;
            if (collision.gameObject.tag == "PoizonEffect")
            {
                Iscript.PlayerHP -= d;
                Iscript.SE.PlayOneShot(PoizonSE);
            }
            else
            {
                if(Iscript.PlayerHP >= Iscript.PlayerMaxHP * 0.5f && Iscript.PlayerHP + Bscript.PlayerShield <= d && Bscript.Iscript.Bless[56] == 1)
                {
                    d = Iscript.PlayerHP + Bscript.PlayerShield - 1;
                }
                if (Bscript.PlayerShield > 0)
                {
                    if (Bscript.PlayerShield >= d)
                    {
                        Bscript.PlayerShield -= d;
                        Iscript.SE.PlayOneShot(GuardSE);
                        d = 0;
                        GameObject g2 = Instantiate(Effect[2]);
                        g2.transform.position = this.transform.position;
                        g2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        g2.SetActive(true);
                        if(Bscript.Iscript.Bless[46] == 1)
                        {
                            Iscript.PlayerHP += Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.04f);
                            if(Iscript.PlayerHP > Iscript.PlayerMaxHP)
                            {
                                Iscript.PlayerHP = Iscript.PlayerMaxHP;
                            }
                            GameObject g3 = Instantiate(Pscript.HealEffect);
                            g3.transform.position = Pscript.gameObject.transform.position;
                            g3.GetComponent<EffectScript>().EffectNum = Mathf.FloorToInt(Iscript.PlayerMaxHP * 0.04f);
                            g3.GetComponent<BlockTrail>().GoPlayer = true;
                            g3.SetActive(true);
                        }
                    }
                    else
                    {
                        d -= Bscript.PlayerShield;
                        Bscript.PlayerShield = 0;
                        if (Bscript.Iscript.Bless[60] == 1 && Iscript.PlayerHP == Iscript.PlayerMaxHP)
                        {
                            Iscript.Revenge = Mathf.FloorToInt(100 * Iscript.PlayerHPRate);
                        }
                        Iscript.PlayerHP -= d;
                        Iscript.SE.PlayOneShot(GuardBreakSE);
                        Iscript.SE.PlayOneShot(HitSE);
                        Iscript.SE.PlayOneShot(RevengeSE);
                        GameObject g3 = Instantiate(Effect[3]);
                        g3.transform.position = this.transform.position;
                        g3.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        g3.SetActive(true);
                        if (collision.gameObject.GetComponent<EffectScript>().Attack_Execution)
                        {
                            Iscript.PlayerHP = 0;
                        }
                    }
                }
                else
                {
                    if (Bscript.Iscript.Bless[60] == 1 && Iscript.PlayerHP == Iscript.PlayerMaxHP)
                    {
                        Iscript.Revenge = Mathf.FloorToInt(100 * Iscript.PlayerHPRate);
                    }
                    Iscript.PlayerHP -= d;
                    Iscript.SE.PlayOneShot(HitSE);
                    Iscript.SE.PlayOneShot(RevengeSE);
                    if (collision.gameObject.GetComponent<EffectScript>().Attack_Execution)
                    {
                        Iscript.PlayerHP = 0;
                        Bscript.DeadEffect();
                    }
                }
            }
            if (Iscript.PlayerHP <= 0)
            {
                Iscript.PlayerHP = 0;
                Bscript.DeadEffect();
            }
            GameObject g = Instantiate(Counter);
            g.transform.position = new Vector3(this.transform.position.x + Random.Range(-1f, 1f), this.transform.position.y + Random.Range(-1f, 1f), 0);
            if (d > 0)
            {
                g.GetComponent<InfoDisplay_Counter>().Thisnum = d.ToString();
                Iscript.Revenge += d;
                if (Bscript.Iscript.Bless[26] == 1)
                {
                    Iscript.Revenge += Mathf.FloorToInt(100 * Iscript.PlayerHPRate * 0.25f);
                }
                if (Iscript.Revenge > Mathf.FloorToInt(100 * Iscript.PlayerHPRate))
                {
                    Iscript.Revenge = Mathf.FloorToInt(100 * Iscript.PlayerHPRate);
                }
                if (Bscript.Iscript.Bless[31] == 1)
                {
                    Bscript.Pscript.Bless31 = true;
                }
                if (Bscript.Iscript.Bless[43] == 1)
                {
                    Iscript.PlayerMaxHP += 10;
                    Iscript.PlayerHPRate *= (Iscript.PlayerMaxHP + 10) / Iscript.PlayerMaxHP;
                }
                Bscript.IsG = true;
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
        }
        if (collision.gameObject.tag == "ShieldEffect")
        {
            int d = collision.gameObject.GetComponent<EffectScript>().EffectNum;
            if(Iscript.Saint == 9 && Iscript.Crown >= 4 && d > 0)
            {
                d -= 1;
            }
            if (Bscript.Pscript.Gem136 != 2)
            {
                Bscript.PlayerShield += d;
            }
            GameObject g = Instantiate(Effect[1]);
            g.transform.position = this.transform.position;
            g.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            g.SetActive(true);
            if (Bscript.Iscript.Bless[39] == 1 && Bscript.Pscript.Gem136 != 2)
            {
                Bscript.PlayerShield += 1;
            }
            Iscript.SE.PlayOneShot(ShieldSE);
        }
        if (collision.gameObject.tag == "HealEffect")
        {
            int d = collision.gameObject.GetComponent<EffectScript>().EffectNum;
            GameObject g = Instantiate(Counter);
            g.transform.position = this.transform.position;
            g.GetComponent<InfoDisplay_Counter>().Thisnum = d.ToString();
            g.GetComponent<InfoDisplay_Counter>().Coloring_R = 0;
            g.GetComponent<InfoDisplay_Counter>().Coloring_G = 1;
            g.GetComponent<InfoDisplay_Counter>().Coloring_B = 0;
            g.SetActive(true);
            if (Bscript.Iscript.Bless[49] == 1)
            {
                d = Mathf.FloorToInt(d * 1.25f);
            }
            Iscript.PlayerHP += d;
            if(Iscript.PlayerHP > Iscript.PlayerMaxHP)
            {
                Iscript.PlayerHP = Iscript.PlayerMaxHP;
            }
            Iscript.SE.PlayOneShot(HealSE);
        }
        if (collision.gameObject.tag == "RevengeEffect")
        {
            int d = collision.gameObject.GetComponent<EffectScript>().EffectNum;
            Iscript.Revenge += d;
            if (Iscript.Revenge > Mathf.FloorToInt(100 * Iscript.PlayerHPRate))
            {
                Iscript.Revenge = Mathf.FloorToInt(100 * Iscript.PlayerHPRate);
            }
            Bscript.IsG = true;
            Iscript.SE.PlayOneShot(RevengeSE);
        }
    }
}
