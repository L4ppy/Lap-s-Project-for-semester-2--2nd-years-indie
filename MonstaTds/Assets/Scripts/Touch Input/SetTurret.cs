using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTurret : MonoBehaviour
{
    static createTurrets createTowers;
    [SerializeField] GameObject baseTurret;
    [SerializeField] GameObject laserTurret;
    [SerializeField] GameObject rockerTurret;

    private void Start()
    {
        createTowers = gameObject.GetComponent<createTurrets>();
    }

    public void SetBaseTurret()
    {
        createTowers.FocusObj = baseTurret;
    }



        
}
