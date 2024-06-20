using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class createTurrets : MonoBehaviour
{
    
    public GameObject baseTurret, laserTurret, rockerTurret, FocusObj;
    private bool towerOnWait = false;

    public void CreateTurret()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit))
            return;

        FocusObj = Instantiate(baseTurret, hit.point, baseTurret.transform.rotation);
        FocusObj.GetComponent<Collider>().enabled = false;
    }

    public void CreateLaserTuret()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out hit))
            return;

        FocusObj = Instantiate(laserTurret, hit.point, baseTurret.transform.rotation);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (FocusObj == null) towerOnWait = false;
        else towerOnWait = true;
        
       if (Input.GetMouseButtonDown(0))
        {
            
            
        }
        


        if (Input.GetMouseButton(0))
        {
            if ( FocusObj != null)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out hit))// && (hit.collider.gameObject.CompareTag("placable")))
                    return;
                FocusObj.transform.position = hit.point + new Vector3(0, 2, 0);
                //  FocusObj.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, FocusObj.transform.position.z);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.CompareTag("Placable")))
            {
                hit.collider.gameObject.tag = "Occupied";
                FocusObj.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                FocusObj = null;
            }
            else
            {
                Destroy(FocusObj);
                FocusObj = null;
            }


        }


    }


}
