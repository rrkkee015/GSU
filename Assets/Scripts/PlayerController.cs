using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("이동 속도")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private DashController dashController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashController = GetComponent<DashController>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // 입력은 Update에서만 처리
        movement = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow)) movement.y += 1f;
        if (Input.GetKey(KeyCode.DownArrow)) movement.y -= 1f;
        if (Input.GetKey(KeyCode.LeftArrow)) movement.x -= 1f;
        if (Input.GetKey(KeyCode.RightArrow)) movement.x += 1f;
        movement = movement.normalized;

        // 대시 입력
        if (Input.GetKeyDown(KeyCode.Space) && dashController != null)
        {
            dashController.RequestDash(movement);
        }
    }

    void FixedUpdate()
    {
        // FixedUpdate에서만 velocity를 제어
        if (dashController != null && dashController.IsDashing)
        {
            dashController.DashMove(movement);
        }
        else
        {
            rb.linearVelocity = movement * moveSpeed;
        }
    }
}
