using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Sprite.UGUI.UIscript.Manager;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

//Todo 아이템을 만들어서, 아이템을 정해진 ItemTable에 저장.


namespace Sprite.UGUI.UIscript.Item
{
    
    public class ItemUnitInfo
    {
        private TMP_Text _statustext;
        private Image _itemImg;
        
      public string ItemName { get; set; }
      public int ItemID { get; set; }

        public Image ItemImage
        {
            get => _itemImg;  
            set => ItemImage.sprite = value.sprite;
        }

        public ItemUnitInfo(int id, string itemname, string description, Image itemImg)
        {
            ItemID = id; 
            ItemName =itemname; 
            _statustext.text = description; 
            ItemImage.sprite = itemImg.sprite; 
        }
    }
    public class ItemUnit : MonoBehaviour
    {
        [SerializeField] private ItemController itemControl;
        [SerializeField] private TMP_Text itemname;
        [SerializeField] private GameObject itemprefab;

        [SerializeField] private QuestManager qManager; //Todo 실험용  나중에 확정 시 미삭제 
        
        private bool _isClick; 
    
            [Header("ObjList")]
            private List<ItemUnit> itemUnits = new List<ItemUnit>(); // 생성한 정보 담기 
            private List<ItemUnitInfo> _itemlist = new List<ItemUnitInfo>(); // 정보 

            void Start()
            {
                foreach (var unit in itemUnits)
                {
                    var obj = Instantiate(itemprefab, transform); //아이템 프리팹, transfom.
                    var itemUnit = obj.GetComponent<ItemUnit>();
                   // SetInit(unit);
                    itemUnits.Add(itemUnit);
                }
            }

           public void SetInit(ItemUnitInfo unitinfo)
            {
                 itemname.text = unitinfo.ItemName; 
            }
            
            //Todo 아이템 삭제 함수 만들기 
             public void AddItem(int id , string itemname, string description, Image itemImg)
             {
               
                _itemlist.Add(new ItemUnitInfo(id, itemname, description, itemImg));
                //Todo 아이템의 정보를 받아서 리스트에 추가 한다.  
                //Todo 아이템 아이디, 이름, 설명 을 받아서, 리스트에 한다 
                //Todo 리스트에 저장한 아이템을 아이템 테이블에 
             }

            private void RemoveItem(ItemUnitInfo item, Button delBtn, GameObject qUnit)
            {
                //Todo 삭제 버튼을 눌렀을 때 선택되어 있는 아이템을 삭제한다. 
                //Todo 삭제 버튼이 눌렸는 지 검사. 
                //Todo 삭제 버튼 눌렸을 때 삭제 , 눌리지 않으면 이어서 진행
                if (item != null && delBtn == null && Input.GetMouseButtonDown(0) != delBtn.gameObject) return;

                qUnit.gameObject.transform.position += new Vector3(-5f, 0f, 0f); // 클릭시 왼쪽으로 이동해 화면 밖으로 나가라 
                if (qUnit.transform.position.x == -5f)
                {
                    qUnit.IsDestroyed()
                }
                    
                if (!Input.GetMouseButtonDown(0))
                {
                    _isClick = false;
                    return; 
                }

                if (Input.GetMouseButtonDown(0) != delBtn.gameObject &&  !gameObject.CompareTag(item.ItemName)) return;
                
                _isClick = true;
                _itemlist.Remove(item);
            }
            
            
            
            

    }
}
