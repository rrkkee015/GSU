using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // 따라갈 대상(플레이어)
    [SerializeField] private float smoothSpeed = 5f; // 부드럽게 따라가는 정도
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10); // 카메라 오프셋
    [SerializeField] private Vector2 minBounds; // 카메라 최소 경계
    [SerializeField] private Vector2 maxBounds; // 카메라 최대 경계
    [SerializeField] private bool useBounds = false; // 경계 사용 여부

    void LateUpdate()
    {
        if (target == null) return;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        if (useBounds)
        {
            float clampX = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
            float clampY = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);
            transform.position = new Vector3(clampX, clampY, offset.z);
        }
        else
        {
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, offset.z);
        }
    }
} 