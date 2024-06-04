using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    public GameObject tower;
    public TurretBlueprint newTower;
    public bool canUpgrade;

    public void UpgradeLevelToTower()
    {
        if( tower.GetComponent<Turret>() != null && canUpgrade == true)
        {
            tower.GetComponent<Turret>().turretData = newTower;
        }
    }
}
