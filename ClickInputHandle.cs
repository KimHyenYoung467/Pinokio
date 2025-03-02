using UnityEditor.Searcher;
using UnityEngine;

public class ClickInputHandle : MonoBehaviour
{
    [SerializeField] private MoveToClick2D characterMover;
    [SerializeField] private Camera mainCamera;
   
    private void Awake()
    {
        mainCamera = Camera.main;
        if (characterMover == null)
        {
            characterMover = gameObject.GetComponent<MoveToClick2D>();
        }
        else return; 
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 감지
        {
            Vector3 targetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;
            characterMover.SetTargetPosition( gameObject.transform.position);
        }
        else return; 
    }

}
