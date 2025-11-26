using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //bulletInstance.GetComponent<BulletController>().NormalAttackPlayer();
    }

    public void OnEnable()
    {
        Debug.Log("Enable");
        TimeManager.OnSecondChanged += TimeCheck;
    }

    public void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

    private void TimeCheck()
    {
        Debug.Log("Time check");
        if (!bullet.isAttacking && TimeManager.Second > 6 && TimeManager.Second % bullet.fireRate == 0)
        {
            SpawnBullet();
             // Aumentar contador de balas del jefe
            BulletManager.ChangeGorgonBulletCount(true);
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    private void SpawnBullet()
    {
        //transform.position = new Vector3(-0.95f, 3.3f, 1);
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = bullet.rotation;

        GameObject bulletInstance = Instantiate(bullet.bulletPrefab, spawnPosition, spawnRotation);
    }
}
