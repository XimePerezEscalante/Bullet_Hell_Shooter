using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] GameObject[] GameOverText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer objectRendererGame = GameOverText[0].GetComponent<Renderer>();
        Renderer objectRendererOver = GameOverText[1].GetComponent<Renderer>();
    }

    public void MakeVisible()
    {
         // Reproducir SFX "Game Over"
        GameOverText[0].SetActive(true);
        GameOverText[1].SetActive(true);
    }
}
