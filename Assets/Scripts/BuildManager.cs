using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    public TurretData craneData;
    public TurretData goatData;

    //表示当前选择的炮台(要建造的炮台)
    public TurretData selectTurretData;

    public GameObject TurretTemp = null;

    public int money = 1000;

    public void OnCraneDrag()
    {
        selectTurretData = craneData;
        if(TurretTemp==null)
        {
            TurretTemp = GameObject.Instantiate(selectTurretData.turretPrefab, MouseMove.positionStart, Quaternion.identity);
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] myHit;
        myHit = Physics.RaycastAll(ray);
        for (int i = 0; i < myHit.Length; i++)
        {
            RaycastHit hit = myHit[i];
            if (hit.collider.gameObject.tag == "Earth")
            {
                TurretTemp.transform.position = hit.point;
            }
        }
 /*       if (Physics.Raycast(ray, out myHit))
        {
            Debug.Log(myHit.collider);
            if (myHit.collider.gameObject.tag == "Earth")
            {
                TurretTemp.transform.position = myHit.point;
            }
        }
  */      
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
                Destroy(TurretTemp);
                //开发炮台的建造
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isColloder = Physics.Raycast(ray, out hit, 100000, LayerMask.GetMask("MapCube"));
                if (isColloder)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();//得到点击的mapCube
                    if (mapCube.turretGo == null)
                    {
                        //可以创建
                        if (money >= selectTurretData.cost)
                        {
                            money -= selectTurretData.cost;
                            mapCube.BuildTurret(selectTurretData.turretPrefab);
                        }
                        else
                        {
                            //TODO
                        }
                    }
                    else
                    {
                        //TODO升级处理
                    }
                }

            
        }

    }
}
