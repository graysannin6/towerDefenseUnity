using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
	public void Next()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Menu()
    {
		Spawner.AlienAlive = 0;
		SceneManager.LoadScene("Main Menu");
	}
}
