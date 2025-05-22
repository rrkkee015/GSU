using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float speed = 5f;
    public float lifetime = 5f;
    public Vector2 direction = Vector2.zero;

    private DamageDealer damageDealer;
    
    void Awake()
    {
        // Ensure this projectile has a DamageDealer component
        damageDealer = GetComponent<DamageDealer>();
        if (damageDealer == null)
        {
            damageDealer = gameObject.AddComponent<DamageDealer>();
            damageDealer.damageAmount = 1;
            damageDealer.isProjectile = true;
        }
        
        // Ensure this projectile has a Collider2D for collision detection
        if (GetComponent<Collider2D>() == null)
        {
            CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D>();
            collider.radius = 0.3f;
            collider.isTrigger = true;
        }
        
        // Ensure this projectile has a Rigidbody2D
        if (GetComponent<Rigidbody2D>() == null)
        {
            Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
        
        // Destroy after lifetime
        Destroy(gameObject, lifetime);
    }
    
    public void Initialize(Vector2 direction)
    {
        this.direction = direction.normalized;
    }
    
    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어에게 데미지
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        DamageDealer dealer = GetComponent<DamageDealer>();
        if (playerHealth != null && dealer != null)
        {
            playerHealth.TakeDamage(dealer.damageAmount);
            Destroy(gameObject); // 투사체는 충돌 후 파괴
            return;
        }
        // 적에게 데미지 (확장성)
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null && dealer != null)
        {
            enemyHealth.TakeDamage(dealer.damageAmount);
            Destroy(gameObject);
        }
    }
}