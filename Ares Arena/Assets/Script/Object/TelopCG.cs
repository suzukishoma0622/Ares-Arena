using UnityEngine;

public class TelopCG : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float display;
    bool IsSwitch;
    void Start()
    {
        Invoke("D", display);
    }
    void Update()
    {
        if(IsSwitch)
        {
            GetComponent<CanvasGroup>().alpha -= speed;
        }
        else
        {
            GetComponent<CanvasGroup>().alpha += speed;
        }
    }
    void D()
    {
        IsSwitch = true;
    }
}
