using UnityEngine;

public class PointerNumber : MonoBehaviour
{
    [SerializeField] int ThisNum;
    public PuzzleManager Pscript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Pointer")
        {
            Pscript.PointerNum = ThisNum;
        }
    }
}
