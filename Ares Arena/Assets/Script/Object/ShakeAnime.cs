using UnityEngine;

public class ShakeAnime : MonoBehaviour
{
    float speed = 1f;
    float num;
    float Currenty;
    void Start()
    {
        speed *= Random.Range(0.9f, 1.1f);
        Currenty = this.transform.localPosition.y;
    }
    void Update()
    {
        num += Time.deltaTime * speed;
        this.transform.localPosition = new Vector3(0f, Mathf.Sin(num) * 0.1f + Currenty, 0f);
    }
}
