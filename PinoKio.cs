
using UnityEngine;

public class PinoKio : MonoBehaviour
{
    [SerializeField] private MoveToClick2D moveToClick;
    [SerializeField] private ClickInputHandle clickHandle;

   
    // 캐릭터의 생성 
  
    
    
    void Start() // 초기화 전용 
    {
      moveToClick = gameObject.GetComponent<MoveToClick2D>(); 
      clickHandle = gameObject.GetComponent<ClickInputHandle>(); 
        
        // [SerializeField]로 설정된 경우, 인스펙터에서 할당되지 않았을 때만 Find를 사용하여 할당
        if (moveToClick == null)
            moveToClick = GetComponent<MoveToClick2D>();
        
        if (clickHandle == null)
            clickHandle = GetComponent<ClickInputHandle>();

        // 현재 GameObject(PinoKio)를 타겟으로 설정
        if (moveToClick != null)
        {
           // moveToClick.TargetPosition(gameObject);
            moveToClick.SetTargetPosition(transform.position);
        }
        else
        {
            Debug.LogWarning("MoveToClick2D 컴포넌트가 없습니다.");
        }
    }
}
