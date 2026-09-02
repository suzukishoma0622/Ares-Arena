using UnityEngine;

public class Gem_Cell : MonoBehaviour
{
    public int Growth = 1;
    public int Num = 1;
    public Animator Cellanim;
    public Animator Gemanim;
    private void Update()
    {
        Cellanim.Play($"Cell{Growth}");
        Gemanim.Play($"Gem{Num}");
        Gemanim.transform.localScale = new Vector3(0.05f + 0.15f * Growth, 0.05f + 0.15f * Growth, 1f);
    }
}
