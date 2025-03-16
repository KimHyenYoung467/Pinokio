using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Sprite.UGUI.UIscript.Manager
{
    public class ConfigManager : MonoBehaviour
    {
        [Header("Script")]
        [SerializeField] private MainConfig config;
        [SerializeField] private Animator animator;
    
        [Header("GameObject")] 
        public GameObject ConfigPanel { get; set; }             //Todo 메인 설정창 
        public GameObject SelectBar { get; set;  }              //Todo 설정창 / 아이템 선택바 
        public Button CloseBtn { get; set; }                   //Todo 닫기 / 삭제 버튼 
        public Slider MainSlider { get; set; }                 //Todo 사운드, 그래픽 조절 Slider 
        public Dropdown GraphicDropOption { get; set; }        //Todo 그래픽 메뉴 옵션 선택 바 
        public bool isClick { get; set; }

        //Todo 생성자
        protected ConfigManager()
        {
            config = GetComponent<MainConfig>();  
            animator = GetComponent<Animator>();
        } 

        protected ConfigManager(GameObject configObj, GameObject selObj, Button closebtn)  
        {
            if (configObj == null && closebtn == null && selObj == null) return;

        }

       
    
    }
}
