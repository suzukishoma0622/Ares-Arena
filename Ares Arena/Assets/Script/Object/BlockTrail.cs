using UnityEngine;

public class BlockTrail : MonoBehaviour
{
    public bool GoPlayer;
    public int TrailNum;
    GameObject[] TargetObj;
    float count;
    void Start()
    {
        if(GoPlayer)
        {
            TargetObj = GameObject.FindGameObjectsWithTag("Player");
        }
        else
        {
            TargetObj = GameObject.FindGameObjectsWithTag("Enemy");
        }
    }

    void Update()
    {
        if (count > 0)
        {
            count -= Time.deltaTime;
        }
        switch(TrailNum)
        {
            case 0:
                this.transform.position = Vector3.MoveTowards(this.transform.position, TargetObj[0].transform.position, 80f * Time.deltaTime);
                break;
        }
    }
}
