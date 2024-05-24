using UnityEngine;
using System.Collections;

[CreateAssetMenu()]
public class TurretBlueprint : ScriptableObject
{
	public string Name;
	public GameObject prefab;
    public GameObject upgradedPrefab;
    public int cost;
    public float damage;
    public float fireRate;
    public float fireCooldown;
    public float range;
	
	public int upgradeCost;

	public int GetSellAmount()
	{
		return cost / 2;
	}
}