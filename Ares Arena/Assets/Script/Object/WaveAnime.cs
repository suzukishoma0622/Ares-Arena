using UnityEngine;

public class WaveAnime : MonoBehaviour
{
    public float MaxScale;
    public float MinScale;
    float speed = 1f;
    float num;
    void Start()
    {
        speed *= Random.Range(0.9f, 1.1f);
    }
    void Update()
    {
        num += Time.deltaTime * speed;
        this.transform.localScale = new Vector3(MinScale + Mathf.Sin(num) * (MaxScale - MinScale), MinScale + Mathf.Sin(num) * (MaxScale - MinScale), 0f);
    }
}
