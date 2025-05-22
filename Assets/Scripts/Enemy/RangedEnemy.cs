using UnityEngine;

public class RangedEnemy : MonoBehaviour, IEnemy
{
    [Header("Enemy Settings")]
    public float moveSpeed = 2f;
    public float shootingRange = 5f;
    public float attackCooldown = 2f;
    public GameObject projectilePrefab;
    
    private Transform target;
    private float lastAttackTime = -999f;
    
    void Awake()
    {
        // Ensure this enemy has a Collider2D for collision detection
        if (GetComponent<Collider2D>() == null)
        {
            CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D>();
            collider.radius = 0.5f;
            collider.isTrigger = true;
        }
        // Ensure this enemy has an EnemyHealth component
        if (GetComponent<EnemyHealth>() == null)
        {
            gameObject.AddComponent<EnemyHealth>();
        }
        // Ensure this enemy has a DamageDealer component
        if (GetComponent<DamageDealer>() == null)
        {
            DamageDealer dealer = gameObject.AddComponent<DamageDealer>();
            dealer.damageAmount = 1;
            dealer.isProjectile = false;
        }
    }
    
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
        
        // Calculate distance to player
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        
        // If within shooting range, try to attack
        if (distanceToPlayer < shootingRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                ShootAtPlayer();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            // Otherwise move toward player
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
    
    void ShootAtPlayer()
    {
        if (projectilePrefab == null)
        {
            Debug.LogWarning("Projectile prefab is missing!");
            return;
        }
        
        // Calculate direction to player
        Vector2 direction = (target.position - transform.position).normalized;
        
        // Instantiate projectile
        GameObject projectileObj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        ProjectileBase projectile = projectileObj.GetComponent<ProjectileBase>();
        
        if (projectile != null)
        {
            projectile.Initialize(direction);
        }
        else
        {
            // If prefab doesn't have ProjectileBase component, add it
            projectile = projectileObj.AddComponent<ProjectileBase>();
            projectile.Initialize(direction);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어와 충돌 시 데미지 처리
        PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();
        DamageDealer dealer = GetComponent<DamageDealer>();
        if (playerHealth != null && dealer != null)
        {
            playerHealth.TakeDamage(dealer.damageAmount);
            // 적도 사라지게
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            if (enemyHealth != null)
                enemyHealth.TakeDamage(enemyHealth.currentHP); // 즉시 사망
        }
    }
}