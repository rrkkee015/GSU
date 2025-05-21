using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DashController : MonoBehaviour
{
    [Header("대시 이동 거리")]
    [SerializeField] private float dashDistance = 5f;
    [Header("대시 속도")]
    [SerializeField] private float dashSpeed = 15f;
    [Header("대시 쿨타임 (초)")]
    [SerializeField] private float dashCooldown = 1f;

    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashTime = 0f;
    private float dashDuration = 0.2f;
    private float lastDashTime = -Mathf.Infinity;
    private Vector2 dashDirection;

    public bool IsDashing => isDashing;
    public bool CanDash => !isDashing && Time.time >= lastDashTime + dashCooldown;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void RequestDash(Vector2 direction)
    {
        if (CanDash && direction != Vector2.zero)
        {
            isDashing = true;
            dashTime = 0f;
            dashDuration = dashDistance / dashSpeed;
            dashDirection = direction.normalized;
            lastDashTime = Time.time;
        }
    }

    public void DashMove(Vector2 inputDirection)
    {
        if (isDashing)
        {
            if (inputDirection != Vector2.zero)
                dashDirection = inputDirection.normalized;
            rb.linearVelocity = dashDirection * dashSpeed;
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            dashTime += Time.fixedDeltaTime;
            if (dashTime >= dashDuration)
            {
                isDashing = false;
            }
        }
    }
}
