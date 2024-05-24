using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class NodeUI : MonoBehaviour
{

	public GameObject ui;

	public TMP_Text upgradeCost, sellCost;
	public Button upgradeButton;
    private NodeObject target;

	//public void SetTarget(Node _target)
	//{
	//	target = _target;

	//	transform.position = target.GetTowerPosition();

	//	if (!target.isUpgraded)
	//	{
	//		upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
	//		upgradeButton.interactable = true;
	//	}
	//	else
	//	{
	//		upgradeCost.text = "DONE";
	//		upgradeButton.interactable = false;
	//	}

	//	sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

	//	ui.SetActive(true);
	//}
    public void Show()
    {

    }
	public void Hide()
	{
		
	}

    public void Upgrade(int price, string name)
	{
		
	}

	public void Sell()
	{
		
	}

}
