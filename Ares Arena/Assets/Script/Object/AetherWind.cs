using UnityEngine;

public class AetherWind : MonoBehaviour
{
    public GameObject Trail1;
    public GameObject Trail2;
    float T = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(T > 0.5f)
        {
            T -= Time.deltaTime * 2f;
            Trail1.transform.localPosition = new Vector3(0, T, 0);
            Trail2.transform.localPosition = new Vector3(0, -T, 0);
        }
    }
}
