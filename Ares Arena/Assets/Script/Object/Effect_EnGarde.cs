using UnityEngine;
using UnityEngine.UI;

public class Effect_EnGarde : MonoBehaviour
{
    public CanvasGroup TextCG;
    public RectTransform BackGround;
    float count;
    public AudioClip StartSE;
    void Start()
    {
        Invoke("Sound", 0.6f);
    }
    void Update()
    {
        count += Time.deltaTime;
        if (count >= 2.3f)
        {
            Destroy(this.gameObject);
        }
        if (count >= 2.05f)
        {
            BackGround.localScale = new Vector3(1f, 0f, 1f);
        }
        else if (count >= 1.8f)
        {
            BackGround.localScale = new Vector3(1f, (2.05f - count) * 4f, 1f);
        }
        else if (count >= 0.85f)
        {
            
        }
        else if (count >= 0.6f)
        {
            BackGround.localScale = new Vector3(1f, (count - 0.6f) * 4f, 1f);
        }
        if(count <= 0.6f)
        {

        }
        else if(count <= 1.8f)
        {
            TextCG.alpha += Time.deltaTime * 2f;
        }
        else
        {
            TextCG.alpha -= Time.deltaTime * 2f;
        }
    }
    void Sound()
    {
        GetComponent<AudioSource>().PlayOneShot(StartSE);
    }
}
