using Sprite.UGUI.UIscript.Item;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sprite.UGUI.UIscript.Manager
{
    public class InventoryManager : MonoBehaviour
    {
        
        [Header("Script")] 
        private InventoryManager _inventoryManager;
        private Animation _animation;
        [SerializeField] protected ItemUnitInfo ItemUnit;
        [SerializeField] private InvenSetInit _setinven;
        
        [Header("Object")] 

        [SerializeField] protected RectTransform selectBar;   // SelectBar 오브젝트 
        private GameObject _itemTable;                        // 아이템 테이블 오브젝트 
        private GameObject _itemStatus;                       // 아이템 스테이터스 오브젝트 
        protected TMP_Text StatusText;                        // Text_MeshPro 텍스트 상자 내용
          
        [Header("Sprite")]  
        [SerializeField]  
        protected Image itemthisImg;                          // 아이템 스테이터스 현재 이미지 
          
        [Header("Item")]  
        public RectTransform itemImgBack;                     // 아이템 이미지 백그라운드 
        public GameObject itemStatus;                         // 아이템 스테이터스 설명창 

        void Start()
        {
            _animation = gameObject.GetComponent<Animation>();
            ItemUnit = GetComponent<ItemUnitInfo>(); 
            _setinven = GetComponent<InvenSetInit>(); 
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
