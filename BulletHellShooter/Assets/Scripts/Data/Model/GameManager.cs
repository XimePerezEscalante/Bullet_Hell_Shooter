using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] Mermaid mermaid;
    [SerializeField] GameOverController gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mermaid.IsAlive == false)
        {
            StartCoroutine(FinishGame());
        }
    }

    private IEnumerator FinishGame()
    {
        gameOver.MakeVisible();
        yield return new WaitForSeconds(2);
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
