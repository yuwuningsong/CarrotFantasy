using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseMove : MonoBehaviour
{
    public static Vector3 positionStart;
    public void ClickImage()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] myHit;
        myHit = Physics.RaycastAll(ray);
        for(int i=0;i<myHit.Length;i++)
        {
            RaycastHit hit = myHit[i];
            Debug.Log(i+" "+hit.collider.gameObject.tag);
            if(hit.collider.gameObject.tag=="Earth")
            {
                Debug.Log(hit.point);
                positionStart = hit.point;
            }
        }        
    }

    /* public class ModelDrage : MonoBehaviour
     {
        private Camera cam;//发射射线的摄像机
         private GameObject go;//射线碰撞的物体
         public static string btnName;//射线碰撞物体的名字
         private Vector3 screenSpace;
         private Vector3 offset;
         private bool isDrage = false;


         void Start()
         {
             cam = Camera.main;
         }




         void Update()
         {
             //整体初始位置 
             Ray ray = cam.ScreenPointToRay(Input.mousePosition);
             //从摄像机发出到点击坐标的射线
             RaycastHit hitInfo;


             if (isDrage == false)
             {
                 if (Physics.Raycast(ray, out hitInfo))
                 {
                     //划出射线，只有在scene视图中才能看到
                     Debug.DrawLine(ray.origin, hitInfo.point);
                     go = hitInfo.collider.gameObject;
                     //print(btnName);
                     screenSpace = cam.WorldToScreenPoint(go.transform.position);
                     offset = go.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                     //物体的名字  
                     btnName = go.name ;
                     //组件的名字


                 }
                 else
                 {
                     btnName = null;
                 }


             }


             if (Input.GetMouseButton(0))
             {
                 Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
                 Vector3 currentPosition = cam.ScreenToWorldPoint(currentScreenSpace) + offset;


                 if (btnName != null)
                 {
                     go.transform.position = currentPosition;
                 }



                 isDrage = true;
             }
             else
             {
                 isDrage = false;
             }


         }

     }
 }*/


}

