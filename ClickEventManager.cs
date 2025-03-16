using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ClickEventManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
   private IMouseEvent mouseEvent;
   private IDropHandler Drophandle; 
   
    public void OnPointerEnter(PointerEventData eventData)
    {
       Debug.Log("OnPointerEnter : 들어왔다."); //Todo 마우스 포인터가 오브젝트 안으로 들어왔을 때. 
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       Debug.Log("나갔다."); // Todo 마우스 포인터가 오브젝트에서 나왔을 떄
      
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       Debug.Log("클릭 했다."); //Todo 포인터를 누르고 떘을 때 
    }
}
