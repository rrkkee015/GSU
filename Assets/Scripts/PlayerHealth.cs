using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
    }

    public void Heal(int amount)
    {
        currentHP = Mathf.Min(maxHP, currentHP + amount);
        onHPChanged?.Invoke(currentHP, maxHP);
    }

    public void SetMaxHP(int newMax)
    {
        maxHP = Mathf.Max(1, newMax);
        currentHP = Mathf.Min(currentHP, maxHP);
        onHPChanged?.Invoke(currentHP, maxHP);
    }
}