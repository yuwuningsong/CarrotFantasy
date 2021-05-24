using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour
{
    [SerializeField]
    public GameObject turretGo=null;//保存当前cube身上的炮台

    public void BuildTurret(GameObject turretPrefab)
    {
        turretGo = GameObject.Instantiate(turretPrefab,transform.position, Quaternion.identity);
        turretGo.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
    }
}
