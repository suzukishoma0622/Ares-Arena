using UnityEngine;

public class FadeCG : MonoBehaviour
{
    public bool fade = false;
    public CanvasGroup img;
    public float num = 0.01f;
    public float count;
    public bool IsCount;
    // Start is called before the first frame update
    void Start()
    {
        if (IsCount)
        {
            Invoke("Fadestart", count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            img.alpha += Time.deltaTime * num;
        }
        count -= Time.deltaTime;
        if (IsCount && count <= 0f)
        {
            fade = true;
        }
    }
    public void Fadestart()
    {
        fade = true;
    }
}
