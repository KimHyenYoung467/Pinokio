using System.Security.Cryptography.X509Certificates;
using Sprite.UGUI.UIscript.Item;
using Sprite.UGUI.UIscript.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;


// Todo (Clear) SelectBar 를 받아와서, SelectBar 의 현재 위치에서 마우스 포인터의 위치로 이동하여, (Clear) 

// Todo 클릭 시에 ImgBG(부분 Clear) 및 ItemStatus 에 설명창 띄우기 

// Todo Item의 Text 오브젝트 내의 내용을 아이템 아이디에 맞춰서 변경하고, 이미지 또한 변경이 필요하다.


//Todo Item의 셀렉트 바의 위치에 따라 선택된 설명 창의 이미지를 변경 하고, 설명 창의 설명 란 내용을 변경.

namespace Sprite.UGUI.UIscript
{
    public class Inventory : InventoryManager
    {
        private InventoryManager _invenManager;  
        
        void Start() // 초기화
        {
            _invenManager = GetComponent<InventoryManager>();
        }
        
        //Todo 설명창 설명 내용 바꾸기 
        private string ItemDscription(RectTransform obj, string itemDescription) //Todo 설명 텍스트 내용 바꾸기 
        { 
            if (obj.gameObject.CompareTag("Inventory") || obj.gameObject.CompareTag("Quest"))
                StatusText.text = itemDescription;
            return StatusText.text;
        }
        
        //Todo 선택바가 선택한 위치에 있는 아이템의 이미지를 아이템 status 이미지 부분에 출력 
        //Todo 선택바가 현재 위치에서 이동할 시, 이동된 위치에 있는 아이템이 비어있으면 냅두고,
        //Todo 아이템이 있을 때 변경된 위치에 있는 아이템의 이미지로 변경.
      
        //Todo 아이템 선택 이미지 변경 
        private void Imgprint(Image itemChangeImg, GameObject selectObj, ItemUnitInfo itemUnit)
        {
            var thisImg = itemthisImg;
                thisImg.sprite = ItemUnit.ItemImage.sprite;
                
                if (!selectObj.transform.position.Equals(Input.mousePosition)) return;
                
            //Todo 선택바 위치가 현재 아이템이 있는 테이블 위치에 동일 할 때  
            // 그리고, 선택바의 위치가 바뀌면서 아이템의 아이디가 변경된 게 확인 되었을 때,
            // 현재 아이템의 아이디와 바뀐 아이템의 아이디를 변경 되었을 시, 이미지를 바꾼다.
            
            if (selectObj.transform.position.Equals(Input.mousePosition)
                && Input.GetMouseButtonDown(0).Equals(gameObject.CompareTag("InvenTable")))
            {   
                thisImg.sprite = ItemUnit.ItemImage.sprite;
                Debug.Log($"{thisImg}"); // 현재 이미지 출력 
            }
            else if (selectObj.gameObject.transform.position.Equals(Input.mousePosition)
                     && itemUnit.ItemID.Equals(itemUnit.ItemID))
            {
                 // Todo 클릭한 아이템의 아이디가 동일하지 않을 때, 아이템의 아이디에 따른 이미지로 변경
                 thisImg.sprite = itemChangeImg.sprite;
                 Debug.Log("현재 이미지 변경 ");
            }

        }
        
    }
} 


