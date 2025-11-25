using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static int mermaidBulletCount;
    public static int gorgonBulletCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Mermaid Bullet Count" + mermaidBulletCount);
    }
}
