using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class newscript : MonoBehaviour
{
    public GameObject Turret, laserTurret, rocketTurret;
    public GameObject FocusObj;

    public void CreateTurret()
    {
        FocusObj = Instantiate(Turret, position, Turret.transform.rotation);
        FocusObj.GetComponent<Collider>().enabled = false;
    }
    public void CreateLaserTurret(Vector3 position)
    {
        FocusObj = Instantiate(Turret, position, Turret.transform.rotation);
        FocusObj.GetComponent<Collider>().enabled = false;
    }
    public void CreateRocketTurret(Vector3 position)
    {
        FocusObj = Instantiate(Turret, position, Turret.transform.rotation);
        FocusObj.GetComponent<Collider>().enabled = false;
    }

    void Update()
    {
        // Handle mouse input
        if (Input.GetMouseButtonDown(0))
        {
            HandleInput(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            MoveFocusObject(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            PlaceOrDestroyFocusObject(Input.mousePosition);
        }

        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    HandleInput(touch.position);
                }
            
            else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                MoveFocusObject(touch.position);
            }
            else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                PlaceOrDestroyFocusObject(touch.position);
            }
        }
    }

    void HandleInput(Vector3 inputPosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        if (!Physics.Raycast(ray, out hit))
            return;
        CreateTurret(hit.point);
    }

    void MoveFocusObject(Vector3 inputPosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        if (!Physics.Raycast(ray, out hit))
            return;
        if (FocusObj != null)
        {
            FocusObj.transform.position = hit.point + new Vector3(0, 1, 0);
        }
    }

    void PlaceOrDestroyFocusObject(Vector3 inputPosition)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("platform"))
        {
            hit.collider.gameObject.tag = "occupied";
            FocusObj.transform.position = new Vector3(hit.collider.gameObject.transform.position.x,
                FocusObj.transform.position.y, hit.collider.gameObject.transform.position.z);
        }
        else
        {
            Destroy(FocusObj);
            FocusObj = null;
        }
    }
}
