using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class createTurrets : MonoBehaviour
{
    public enum TowerTypes { basedTurret, laserTower, rocketLauncher };
    public GameObject turret, FocusObj;
    

    [SerializeField] private GameObject baseTurretPrefab;
    [SerializeField] private GameObject laserTowerPrefab;
    //[SerializeField] private GameObject rocketLauncherPrefab;

    private void Start()
    {
        
    }

    private void OnSelectTower(TowerTypes type)
    {
        switch (type)
        {
            case TowerTypes.basedTurret:
                turret = baseTurretPrefab;
                FocusObj = turret;
                break;
            case TowerTypes.laserTower:
                turret = laserTowerPrefab;
                FocusObj = turret;
                break;
            //case TowerTypes.rocketLauncher:
            //    turret = rocketLauncherPrefab;
            //    FocusObj = turret;
            //    break;
        }
    }
    public void CreateTurret()
    {
        
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit))
            return;

        FocusObj = Instantiate(turret, hit.point, turret.transform.rotation);
        FocusObj.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(!Physics.Raycast(ray, out hit))
              return;
            FocusObj.transform.position = hit.point+new Vector3(0,2,0);
            //FocusObj.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, FocusObj.transform.position.z);

        }
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.CompareTag("Placable")))
            {
                hit.collider.gameObject.tag = "Occupied";
                FocusObj.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);                
            }
            else
            {
                if (FocusObj != null)
                {
                    DestroyImmediate(FocusObj, true);
                    FocusObj = null;
                }
                
               
            }


        }

        
    }


}
