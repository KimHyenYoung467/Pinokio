using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sprite.UGUI.UIscript.Manager
{
    public abstract class QuestInfo
    {
      public int QId { get; set; }
      public string QName { get; set; }
      public string QStatus { get; set; }

      QuestInfo(int qId, string qName, string qStatus)
      {
          QId = qId;
          QName = qName;
          QStatus = qStatus; 
      }
      
    }
    public class QuestManager : MonoBehaviour
    {
        //Todo 퀘스트의 아이디와 Status 구성 요소 만들기 (Clear) 
        
        //Todo 퀘스트의 닫기 버튼 을 컨피그 와 연결 하기
        //Todo 닫기 버튼 클릭 시에 퀘스트 스테이터스 삭제 하기 (Dstroy, 혹은 옆으로 밀기) 
        //Todo 하지만 메인 퀘스트일 시 닫기 버튼 비활성화 시키기 
        //Todo 퀘스트 오브젝트 클릭 시 , 스테이터스 열기 

        [Header("script")]
        [SerializeField]
        public Quest quest;

        [SerializeField]
        public Animator Animator {
            get { return Animator = GetComponent<Animator>();}
            set { Animator = gameObject.GetComponent<Animator>(); }
        }

        [SerializeField] public Animation Animation {
            get { return Animation = GetComponent<Animation>();}
            set { Animation = gameObject.GetComponent<Animation>();}
        }
    
        [Header("Object")] 
        [SerializeField] public GameObject qUnit { get; set; } //Todo 퀘스트 제목 축소화된 퀘스트 창 
        public Image QStatus { get; set; }           //Todo 퀘스트 스테이터스 창 
        public TMP_Text QuestName { get; set; }      //Todo 퀘스트 이름 
        public TMP_Text QuestStatus { get; set; }    //Todo 퀘스트 스테이터스 설명창
        public Button QDeleteBtn { get; set; }
       
    }
}
