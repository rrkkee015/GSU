using UnityEngine;

public class DefaultEnemy : MonoBehaviour, IEnemy
{
    [Header("Enemy Settings")]
    public float moveSpeed = 3f;
    private Transform target;

    public void Initialize(Transform target)
    {
        this.target = target;
    }

    public void OnSpawned()
    {
        // 스폰 시 추가 동작 필요시 구현
    }

    void Update()
    {
        if (target == null) return;
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
} 