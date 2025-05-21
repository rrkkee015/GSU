using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("이동 속도")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // 오로지 방향키 입력만 허용
        movement.x = 0f;
        movement.y = 0f;
        if (Input.GetKey(KeyCode.UpArrow)) movement.y = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) movement.y = -1f;
        if (Input.GetKey(KeyCode.LeftArrow)) movement.x = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) movement.x = 1f;
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }
}
