using UnityEngine;
using TMPro;

public class BulletCountUI : MonoBehaviour
{
    public TextMeshProUGUI mermaidBulletCountText;
    public TextMeshProUGUI gorgonBulletCountText;

    private void OnEnable()
    {
        BulletManager.OnChangedMermaidBulletCount += UpdateMermaidBulletCount;
        BulletManager.OnChangedGorgonBulletCount += UpdateGorgonBulletCount;
    }

    private void UpdateMermaidBulletCount()
    {
        mermaidBulletCountText.text = $"{BulletManager.mermaidBulletCount}";
    }

    private void UpdateGorgonBulletCount()
    {
        gorgonBulletCountText.text = $"{BulletManager.gorgonBulletCount}";
    }
}
