using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sprite.UGUI.UIscript.Manager
{
    public class Quest : MonoBehaviour 
    {
        private OnButtonClick _onButtonClick; 
        
        private static readonly int TriggerClick = Animator.StringToHash("triggerClick");
        private static readonly int ClickCount = Animator.StringToHash("ClickCount");
        private static int _speed = Animator.StringToHash("Speed");
        
        [SerializeField] private QuestManager qManager; 
        private QuestInfo _questinfo; 
        
        private List<QuestInfo> _questlist = new List<QuestInfo>();  //Todo 퀘스트 생성 정보 얻기 
        private List<Quest>  _qlist = new List<Quest>();             //Todo 정보 
        
        //Todo 퀘스트 생성 => 아이템 생성과 합치기 가능한가? 
        private int AddQuest(int id, string qname, string qstatustext)
        {
            if (_questinfo == null) return 0; 
            _questinfo.QId = id; 
            _questinfo.QName = qname;
            _questinfo.QStatus = qstatustext;

            _questlist.Add(_questinfo);
            
            return _questlist.Count;
        }
        
        //Todo 스테이터스 창 오픈 
        private void OpenStatus(GameObject Obj, int speed)
        {
            _speed = speed;
            Obj.gameObject.SetActive(true); //Todo 오브젝트 활성화 
            
            if (Input.GetMouseButtonDown(0) != Obj.gameObject) return;
            
            qManager.Animator.SetTrigger(TriggerClick);
            qManager.Animator.SetTrigger(_speed = -1); 
            qManager.Animator.Play("InPutAnim");
        }
        
        //Todo 삭제 버튼 클릭 시 삭제 
        private void DeleteBtn(Button delbtn)
        {
            if (Input.GetMouseButtonDown(0) != delbtn.gameObject) return;

            qManager.Animator.SetTrigger(ClickCount);
            qManager.Animation.DetectClick();
            
            if (ClickCount == 2)
            {
                qManager.Animation.Initialize(delbtn.gameObject, -1);
                qManager.Animator.Play("InPutAnim"); 
                Destroy(qManager.QStatus.gameObject);
            }
            
            qManager.Animation.ResetClick(); 
        }
    }
}
