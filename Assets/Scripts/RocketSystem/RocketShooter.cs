using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShooter : MonoBehaviour
{
    public GameObject missilePrefab; // 飛彈預製件
    public Transform launchPoint;   // 發射台位置和方向
    public float fireRate = 2f;     // 發射頻率

    private float nextFireTime;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireMissile();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void FireMissile()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Transform targetTransform = player.transform;

            // 生成飛彈並初始化方向
            GameObject missile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

            // 設置飛彈的目標
            Rocket missileScript = missile.GetComponent<Rocket>();
            if (missileScript != null)
            {
                missileScript.targetPosition = targetTransform; // 傳遞目標 Transform
            }
        }
    }
}


