using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10f; // 飛彈速度
    public float rotationSpeed = 2f; // 旋轉速度
    public Transform targetPosition; // 追蹤的目標
    public GameObject explosionEffect; // 爆炸特效
    public AudioClip explosionSound; // 爆炸音效

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 使用生成時的方向進行初始飛行
        rb.velocity = transform.forward * speed;
    }

    private void FixedUpdate()
    {
        if (targetPosition != null)
        {
            // 計算指向目標的方向
            Vector3 directionToTarget = (targetPosition.position - transform.position).normalized;

            // 計算目標旋轉
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // 平滑旋轉到目標方向
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

            // 更新飛彈速度，使其保持朝向當前旋轉方向
            rb.velocity = transform.forward * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    private void Explode()
    {
        if (explosionEffect != null)
        {
            // 指定旋轉角度
            Quaternion customRotation = Quaternion.Euler(-90, 0, 0); // 例如 Z 軸旋轉 45 度
            GameObject effect = Instantiate(explosionEffect, transform.position, customRotation);
            Destroy(effect, 2f);
        }

        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }

        Destroy(gameObject);
    }

}
