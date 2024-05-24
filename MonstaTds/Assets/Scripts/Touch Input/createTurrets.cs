using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class createTurrets : MonoBehaviour
{

    public GameObject turret, FocusObj;
    public TextMeshPro button;
    // Start is called before the first frame update
    void Start()
    {
        
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

        if(Input.GetMouseButtonDown(0))
        {
           
        }

        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(!Physics.Raycast(ray, out hit))// && (hit.collider.gameObject.CompareTag("placable")))
              return;
            FocusObj.transform.position = hit.point+new Vector3(0,1,0);
            //  FocusObj.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, FocusObj.transform.position.z);

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
                Destroy(FocusObj);
                FocusObj = null;
            }


        }

        
    }


}
