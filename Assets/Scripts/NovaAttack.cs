using UnityEngine;
using System.Collections;

public class NovaAttack : MonoBehaviour
{
    [Header("노바 공격 범위(반지름)")]
    public float radius = 3f;
    [Header("노바 공격력")]
    public int damage = 9999;
    [Header("노바 공격 주기(초)")]
    public float attackInterval = 2f;
    [Header("노바 이펙트 프리팹 (선택)")]
    public GameObject effectPrefab;
    [Header("이펙트 지속 시간(초)")]
    public float effectDuration = 0.5f;
    [Header("적 레이어 마스크")]
    public LayerMask enemyLayer;

    private float timer = 0f;
    private Coroutine novaCoroutine;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackInterval)
        {
            timer = 0f;
            if (novaCoroutine != null)
                StopCoroutine(novaCoroutine);
            novaCoroutine = StartCoroutine(NovaRoutine());
        }
    }

    IEnumerator NovaRoutine()
    {
        GameObject effect = null;
        if (effectPrefab != null)
        {
            effect = Instantiate(effectPrefab, transform.position, Quaternion.identity, transform); // 플레이어의 자식으로 생성
            // SpriteRenderer의 월드 크기를 감지하여 스케일 보정
            var sr = effect.GetComponentInChildren<SpriteRenderer>();
            float spriteWorldSize = 1f;
            if (sr != null)
            {
                spriteWorldSize = Mathf.Max(sr.bounds.size.x, sr.bounds.size.y);
                if (spriteWorldSize > 0.01f)
                {
                    float targetDiameter = radius * 2f;
                    float scale = targetDiameter / spriteWorldSize;
                    effect.transform.localScale = Vector3.one * scale;
                }
                else
                {
                    effect.transform.localScale = Vector3.one * radius * 2f;
                }
            }
            else
            {
                effect.transform.localScale = Vector3.one * radius * 2f;
            }
            Destroy(effect, effectDuration);
        }

        float elapsed = 0f;
        while (elapsed < effectDuration)
        {
            // 항상 플레이어(이 스크립트가 붙은 오브젝트) 위치 기준으로 판정
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayer);
            foreach (var hit in hits)
            {
                var enemyHealth = hit.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    // 에디터에서 범위 시각화
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
} 