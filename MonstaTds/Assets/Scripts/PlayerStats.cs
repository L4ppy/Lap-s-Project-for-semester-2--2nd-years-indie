using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

	public static int Money = 0;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;

	public Image hpBar;

	void Start()
	{
		Money = startMoney;
		Lives = startLives;

		Rounds = 0;
	}
    private void Update()
    {
		
    }

	public void TakeDamage(int dam)
	{
		

		if (Lives <=0)
		{
			OnLose();
		}
		else Lives = Lives - dam;
        hpBar.fillAmount = (Lives / startLives) * 100;
    }

	public void OnLose()
	{
		Debug.Log("You lose");
	}

	public void onWin()
	{
        Debug.Log("You win");
    }

}
