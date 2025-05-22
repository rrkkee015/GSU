using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 3;
    public int currentHP = 3;
    public System.Action<int, int> onHPChanged;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP = Mathf.Max(0, currentHP - amount);
        onHPChanged?.Invoke(currentHP, maxHP);
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
} 