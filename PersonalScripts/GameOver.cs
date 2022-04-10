using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	
	public Text roundsText;
    

    private void OnEnable()
    {
		roundsText.text = PlayerManager.Rounds.ToString();
	}
    public void Retry()
	{

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Spawner.AlienAlive = 0;
	}

	public void Menu()
	{
		SceneManager.LoadScene("Main Menu");
		Spawner.AlienAlive = 0;
	}
}
