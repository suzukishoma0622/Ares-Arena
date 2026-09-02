using UnityEngine;

public class TelopCG : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float display;
    bool IsSwitch;
    void Start()
    {
        Invoke("d", display);
    }
    void Update()
    {
        if(IsSwitch)
        {
            GetComponent<CanvasGroup>().alpha -= speed * Time.deltaTime;
        }
        else
        {
            GetComponent<CanvasGroup>().alpha += speed * Time.deltaTime;
        }
    }
    void d()
    {
        IsSwitch = true;
    }
}
