using System;
using UnityEngine;

namespace Cameras
{
    public class CameraMove // 캐릭터 카메라 화면 안나가게 하기 
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameObject target;
        [SerializeField] private Vector2 targetDirection;
        private Vector2 CameraMaxPosition; // 카메라 최대 좌표 == 경계 끝자락 
        private Vector2 CameraMinPosition; // 카메라 최소 좌표 == 경계 끝
       
        void Start()
        {
            mainCamera = Camera.main; 
        }

        private Camera SetCamera(Camera maincamera)
        {
            if (maincamera == null) return maincamera;
                
                target.transform.position = maincamera.transform.position;
                targetDirection = Camera.main.ScreenToWorldPoint(target.transform.position);
            var Ray = new Ray(target.transform.position,targetDirection);
            
           
        return maincamera; 
        }

    }
}