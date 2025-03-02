using System;
using UnityEngine;

public class MoveToClick2D : MonoBehaviour
{
    

    public event Action OnMoveComplete; // 이동 완료 시 이벤트 호출

    [SerializeField] [Range(5f, 10f)] private float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Awake()
    {
        targetPosition = transform.position; // 초기값 설정
    }

    private void Update()
    {
        HandleMouseClick();

        if (isMoving)
        {
            Move();
        }
    }

    private void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 감지
        {
            SetTargetPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        position.z = 0f; // 2D 이동을 위해 Z값을 0으로 고정
        targetPosition = position;
        isMoving = true;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
            OnMoveComplete?.Invoke(); // 이동 완료 이벤트 호출
        }
    }

   
}