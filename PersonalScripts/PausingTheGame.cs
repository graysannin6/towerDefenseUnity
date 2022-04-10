using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausingTheGame : MonoBehaviour
{

    public GameObject PausingUI;
	

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Continue();
		}
	}

	public void Continue()
	{
		PausingUI.SetActive(!PausingUI.activeSelf);

		if (PausingUI.activeSelf)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	public void Retry()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Spawner.AlienAlive = 0;
	}
	public void Menu()
	{
		Continue();
		SceneManager.LoadScene("Main Menu");
		Spawner.AlienAlive = 0;
	}
	// Start is called before the first frame update
	void Start()
    {
		
    }

}
