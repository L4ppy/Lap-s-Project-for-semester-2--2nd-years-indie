using UnityEngine;

public class BuildManager : MonoBehaviour
{

	public static BuildManager instance;
	public PlayerStats playerStats; //store player point and money

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	//==========Effects==========//
	public GameObject buildEffect;
	public GameObject sellEffect;

    //==========Towers==========//
    private TurretBlueprint turretTower;


    //==========Nodes==========//
    private Node selectedNode;
	public NodeUI nodeUI;

	public bool CanUpgrade { get { return turretTower != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretTower.cost; } }

	//public void SelectNode(Node node)
	//{
	//	if (selectedNode == node)
	//	{
	//		DeselectNode();
	//		return;
	//	}

	//	selectedNode = node;
	//	turretTower = null;

	//	//nodeUI.SetTarget(node);
	//}

	//public void DeselectNode()
	//{
	//	selectedNode = null;
	//	//nodeUI.Hide();
	//}

	//public void SelectTurretToBuild(TurretBlueprint turret)
	//{
	//	turretToBuild = turret;
	//	DeselectNode();
	//}

	//public TurretBlueprint GetTurretToBuild()
	//{
	//	return turretToBuild;
	//}

}