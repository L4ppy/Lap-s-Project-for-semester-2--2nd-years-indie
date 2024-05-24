using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;



public class GameManager : MonoBehaviour
{
    public Camera _mainCamera;
    public PlayerStats playerStats;
    public static GameManager instance;
    public int score, money;

    
    public GameObject focusObj;
    public LayerMask nodeMask;

    //==========Effects==========//
    public GameObject buildEffect;
    public GameObject sellEffect;

    //==========Tower==========// 
    private TurretBlueprint turetInfo;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000, nodeMask)/* && (hit.collider.gameObject.CompareTag("Occupied"))*/)
            {
                NodeObject nObj = hit.transform.GetComponent<NodeObject>();
                if (nObj.GetNodeState() == NodeState.Placed)
                {
                    hit.transform.GetComponent<NodeObject>().SetNodeState(NodeState.Placed);
                    focusObj.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);
                }
            }
        }
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit, 1000, nodeMask))// && (hit.collider.gameObject.CompareTag("placable")))
                return;
            focusObj.transform.position = hit.point + new Vector3(0, 1, 0);
            //  FocusObj.transform.position = new Vector3(hit.transform.p
        }

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000, nodeMask) && (hit.collider.gameObject.CompareTag("Placable")))
            {
                hit.collider.gameObject.tag = "Occupied";
                focusObj.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);

            }
            else
            {
                Destroy(focusObj);
                focusObj = null;
            }
        }
    }




    //public void UpdateScore()

    //{
    //    score = score + 10;
    //    ScoreDisplay.text = "Score: " + score;
    //    

    //}

    //public void UpdateMoney()
    //{
    //    money = money + 100;
    //    MoneyDisplay.text = "  Money: " + money;
    //}

}
