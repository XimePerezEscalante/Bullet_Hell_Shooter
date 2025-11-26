using UnityEngine;
/// <summary>
/// This life manager class updates the corresponding heart depending on the player's health.
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class LifeManager : MonoBehaviour
{
    // Arreglo con los tres corazones
    public GameObject[] Life;
    // Animator para cambiar las animaciones
    private static Animator animator;
    // Objeto sirena para obtener su vida
    public Mermaid mermaid;

    /// <summary>
    /// This method is called once per frame
    /// </summary>
    void Update()
    {
        // El indice corresponde a la ubicacion visual del corazon
        if (mermaid.health == 2.5) {
            animator = Life[2].GetComponent<Animator>();
            animator.SetTrigger("Half");
        }
        else if (mermaid.health == 2) {
            Destroy(Life[2].gameObject);
        }
        else if (mermaid.health == 1.5)
        {
            animator = Life[1].GetComponent<Animator>();
            animator.SetTrigger("Half");
        }
        else if (mermaid.health == 1) {
            Destroy(Life[1].gameObject);
        }
        else if (mermaid.health == 0.5)
        {
            animator = Life[0].GetComponent<Animator>();
            animator.SetTrigger("Half");
        }
        else if (mermaid.health == 0)
        {
            Destroy(Life[0].gameObject);
        }
    }
}
