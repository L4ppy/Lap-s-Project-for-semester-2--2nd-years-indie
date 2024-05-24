using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INodeInteract
{
    void OnInteracted(NodeState state);
    void OnUpgradeAble();
    void OnSellTower();
}
