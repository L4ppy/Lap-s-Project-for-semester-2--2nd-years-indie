using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum NodeState
{
    Placed,
    Available
}

public class NodeObject : MonoBehaviour, INodeInteract
{
    private NodeState nodeState;
    public TextMeshPro interactWindow;
    public NodeUI nodeUI;
    GameObject selectObj;
    private TurretBlueprint towerInfo;

    public NodeState GetNodeState()
    {
        return nodeState;
    }

    public void SetNodeState(NodeState state)
    {
        nodeState = state;
    }

    public void OnBuildTower(NodeState state, RaycastHit hit, GameObject tower)
    {
        
        if(state == NodeState.Placed)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit))
                return;

            selectObj = Instantiate(tower, hit.point, tower.transform.rotation);
            selectObj.GetComponent<Collider>().enabled = false;
        }
    }

    public void OnInteracted(NodeState state)
    {
        switch (state)
        {
            case NodeState.Placed:
                //UI
                break;

            case NodeState.Available:
                //UI
                break;

        }
    }

    public void OnUpgradeAble()
    {

    }

    public void OnSellTower()
    {
        
    }
}
