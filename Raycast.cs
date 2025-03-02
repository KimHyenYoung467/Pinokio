using System.Net;
using UnityEngine;
using Color = UnityEngine.Color;

public interface IInteractable
{
    void Interact();
}


  public class Raycast2DHandler : MonoBehaviour
{
    private Camera mainCamera;
    private RaycastHit2D hitInfo;
    private Vector2 hitPoint;
    [SerializeField] private bool hitDetected = false;
    [SerializeField] private GameObject target; 
    
    public float maxDistance = 5f;
    public LayerMask layerMask;
    public Color rayColor = Color.red; 

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera == null) return; // 카메라가 없다면 리턴

        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭 위치를 월드 좌표로 변환
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var direction = (mousePosition - (Vector2)transform.position).normalized;

            // Raycast2D 실행
            hitInfo = Physics2D.Raycast(transform.position, direction, maxDistance, layerMask);

            if (hitInfo.collider != null)
            {
                hitDetected = true;
                hitPoint = hitInfo.point;
                InteractWithRay();
            }
            else
            {
                hitDetected = false;
            }
        }
    }

    private void InteractWithRay()
    {
        Debug.Log("Hit Object: " + hitInfo.collider.gameObject.name);
        
        var interactable = hitInfo.collider.GetComponent<IInteractable>();
        interactable?.Interact();

        var renderer = hitInfo.collider.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            renderer.color = Random.ColorHSV();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        if (hitDetected)
        {
            Gizmos.DrawLine(transform.position, hitPoint);
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 100));
        if (hitDetected)
        {
            GUILayout.Label("Hit: " + hitInfo.collider.gameObject.name);
            GUILayout.Label("Distance: " + hitInfo.distance.ToString("F2"));
            GUILayout.Label("Position: " + hitInfo.point.ToString("F2"));
        }
        else
        {
            GUILayout.Label("No Hit");
        }
    }
} 


