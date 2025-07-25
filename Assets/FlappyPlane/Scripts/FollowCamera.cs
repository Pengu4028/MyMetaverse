using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinigameFlap
{ 
    public class FollowCamera : MonoBehaviour
    {

        public Transform target;

        float offsetX;


        // Start is called before the first frame update
        void Start()
        {
            if (target == null)
                return;

            //카메라와 플레이어 사이의 거리를 저장
            offsetX = transform.position.x - target.position.x;

        
        }

        // Update is called once per frame
        void Update()
        {
            if(target == null)
                return;

            //내 위치값
            Vector3 pos = transform.position;
        
            //캐릭터 위치보다 offsetX 거리만큼 유지하며 따라감
            //포지션 값을 가져오려면 변수로 한번 가져오고 변조해야함
            pos.x = target.position.x + offsetX;
            transform.position = pos;

        }

    }
}