using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;
	// Start is called before the first frame update
	void Start()
    {
		GameIsOver = false;
    }

	// Update is called once per frame
	void Update()
	{
		if (GameIsOver)
			return;

		if (PlayerManager.Lives <= 0)
		{
			EndGame();
		}
	}
	void EndGame()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
	}
	public void WinLevel()
	{
		completeLevelUI.SetActive(true);
		
	}
}
