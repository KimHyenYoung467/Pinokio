using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

namespace Sprite.UGUI.UIscript.Manager
{
  public class MainConfig : ConfigManager
  {
      
    //Todo 메인 설정창의 선택바를 inventory 내에 있는 선택바 이동 함수를 사용할 수 없나? 
    //Todo X버튼 선택시 Config 창을 삭제 하기 
    //Todo 설정창의 변경 목록 선택 시 변경 창의 내용 변경 =>  그래픽 프리팹과 사운드 프리팹 등을 변환 할 수 있는 방법 
    //Todo 사운드 바 슬라이더 , 실제 해상도 변경 => mainsoundSlider , voiceSoundSlider, BackSoundSlider /// DropDown x 3 /// Button 1
   
    //Todo 전체 음량 => 전체 음량의 슬라이더 조절 시 더빙, 배경 의 슬라이더 동시 조절 
    //Todo 음량 조절 시 보이스, 더빙 사운드 조절할 수 있는 사운드 매니저 클래스 제작 필요 
    
    //Todo (First) x 버튼 누를 시 메인 설정 창 없애기 
    //Todo (Second) 선택바가 마우스 포지션 위치로 이동할 때 선택바의 색깔 약간 밝게 만들기 
    //Todo (Third) 인벤토리 cs 내부에 있는 선택바 이동 함수를 사용할 수는 없을까? 
    //Todo (Four) 슬라이더 조절 함수 
    
    //Todo 더빙, 배경의 현재 위치를 저장해서 전체 음량의 슬라이더 조절 시 함꼐 움직이도록 한다. 
    //Todo 해상도 변경 DropDown의 목록을 마우스로 클릭 시에 해상도를 변경 한다. => 해상도 변경 방법 탐색 필요. 
    //Todo 마우스 커서 모양 => 목록은 아직 부족하나, 목록의 스프라이트로 마우스 커서의 모양을 변경 필요
    
    //Todo 마우스 커서 모양은 목록 안에 있는 목록을 선택할 때 텍스트에 맞는 이미지가 마우스 커서의 모양이 되어야 한다. 
    [SerializeField] private ConfigManager manager;
    
    //Todo SetInit 

    void Start()
    {
        manager = GetComponent<ConfigManager>(); 
    }
    //Todo 따로 매니저로 옮길 수 있나? select Manager (선택, 확인 등)?
     private void MoveSelectbar(GameObject selectObj) //Todo 인벤토리의 선택바와 합칠 방법 찾기 
     {
         //Todo 선택바의 위치가 마우스 위치에 맞지 않거나, 이름이 Config가 아닐 때, 인벤토리가 아닐 때 isClick = false, 그리고, 
         //Todo 현재 마우스 위치 확인 및 마우스로 Inventable 클릭 신호가 들어왔는 지, 확인하기. 
         //Todo 현재 마우스가 클릭 한 것이 InvenTable Object 가 맞는 지 확인하고,  맞다면 선택바의 위치를 마우스가 선택한 
         //Todo 인벤 테이블 위치로 이동시킨다.
         
         if (selectObj.transform.position != Input.mousePosition
             || !selectObj.CompareTag("config")
             || !selectObj.CompareTag("InvenTable"))
         { 
             manager.isClick = false; 
             var mousePos = Input.mousePosition;
             Debug.Log("현재 마우스 위치 : " + mousePos); // 현재 마우스 위치 확인하기 
         }

         if (Input.GetMouseButtonDown(0)!= gameObject) return;
         
         manager.isClick = true;
         selectObj.transform.position = Input.mousePosition; // 선택바의 위치를 마우스 포인터의 위치로 이동한다. 
        
         //Todo 그리고 설정 정보 창을 출력 한다. 
         if (gameObject.CompareTag("Selected"))
         {
             //Todo 설정 정보 창 출력 함수 제작 필요 
         }
        
         if (Input.GetMouseButtonUp(0) == gameObject.CompareTag("Selected"))
         {
             manager.isClick = false;
             DeleteConfig(gameObject , manager.CloseBtn);
         }
         
         //선택바와 마우스 포인터로 클릭한 위치가 같을 때, 선택시 선택바의 크기 줄였다가 크게 하는 선택 표현 하기
         selectObj.transform.localScale -= Vector3.one; 
         selectObj.transform.localScale += Vector3.one; 
     }
     //Todo 설정의 창 출력 
     //Todo 설정 창의 이름 체크 필요. 
     
     private void DeleteConfig(GameObject conObj, Button closeBtn)       // x 버튼 클릭 시 삭제 
     {
         if (!Input.GetMouseButtonDown(0) || !closeBtn.gameObject) return;
         
         Destroy(conObj);
         Debug.Log("설정 창 삭제");
     }

     private void SliderBarSetting(Slider mainSlider, string sValueText)
     {
         if (mainSlider == null) return; 
         
         mainSlider.minValue = 0; 
         mainSlider.maxValue = 1;
         
         if (!(mainSlider.value <= mainSlider.minValue) || !(mainSlider.value >= mainSlider.maxValue)) return;

         var soundValueText = mainSlider.gameObject.GetComponent<TMP_Text>(); 
         soundValueText.text = sValueText;
         //Todo 사운드 매니저 제작 필요 
     }

     private void _DDMenuPush(TMP_Dropdown dropList, string firstOp, string secondOp, string thirdOp)
     {
         //Todo 드롭다운 목록 추가
         if (!dropList.CompareTag("config") && !dropList.CompareTag("DropDown")) return;
         
          dropList.options.Add(new TMP_Dropdown.OptionData() { text = firstOp });
          dropList.options.Add(new TMP_Dropdown.OptionData() { text = secondOp });
          dropList.options.Add(new TMP_Dropdown.OptionData() { text = thirdOp });
          
     }
  }
}
