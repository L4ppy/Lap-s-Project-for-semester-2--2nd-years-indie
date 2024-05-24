using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{

	public static int Money = 0;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;

    public  

	void Start()
	{
		Money = startMoney;
		Lives = startLives;

		Rounds = 0;
	}
    private void Update()
    {
        
    }

}
