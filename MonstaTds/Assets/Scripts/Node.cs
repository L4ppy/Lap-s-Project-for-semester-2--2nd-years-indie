using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
   

    //[HideInInspector]
    //public GameObject turret;
    //[HideInInspector]
    //public TurretBlueprint turretBlueprint;
    //[HideInInspector]
    //public bool isUpgraded = false;
    //private bool touchStarted = false;

    

    //BuildManager buildManager;

    //private void Start()
    //{
    //    //rend = GetComponent<Renderer>();
    //    //startColor = rend.material.color;
    //    buildManager = BuildManager.instance;
    //}

    

    

    
    //void Update()
    //{
        
    //}
    //public void UpgradeTurret()
    //{
    //    if (PlayerStats.Money < turretBlueprint.upgradeCost)
    //    {
    //        Debug.Log("Not enough money to upgrade that!");
    //        return;
    //    }

    //    PlayerStats.Money -= turretBlueprint.upgradeCost;

    //    //Get rid of the old turret
    //    Destroy(turret);

    //    //Build a new one
    //    //GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, GetTowerPosition(), Quaternion.identity);
    //    //turret = _turret;

    //    //GameObject effect = Instantiate(buildManager.buildEffect, GetTowerPosition(), Quaternion.identity);
    //    //Destroy(effect, 5f);

    //    //isUpgraded = true;

    //    //Debug.Log("Turret upgraded!");
    //}

    //public void SellTurret( GameObject _towerToSell)
    //{
    //    PlayerStats.Money += turretBlueprint.GetSellAmount();

    //    GameObject effect = Instantiate(buildManager.sellEffect, GetTowerPosition(), Quaternion.identity);
    //    Destroy(effect, 5f);

    //    Destroy(_towerToSell);
    //    turretBlueprint = null;
    //}

    

    //private void OnMouseExit()
    //{
    //    rend.material.color = startColor;

    //}
}
