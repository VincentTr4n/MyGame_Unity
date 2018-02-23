using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;
	public GameObject pauseMenu;
	public string levelName;
	public GameObject gameOverScreen;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused) ResumeGame();
			else PauseGame();
		}
	}

	private void PauseGame()
	{
		pauseMenu.SetActive(isPaused = true);
		Time.timeScale = 0f;
	}

	public void ResumeGame()
	{
		pauseMenu.SetActive(isPaused = false);
		Time.timeScale = 1f;
	}

	public void LoadMainMenu()
	{
		Debug.Log("Loading menu ...!");
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
	}
	public void QuitGame()
	{
		Debug.Log("Game quited!");
		Application.Quit();
	}
	public void LoadGame()
	{
		SceneManager.LoadScene(levelName);
		Time.timeScale = 1f;
	}
	public void ShowScreenGO()
	{
		gameOverScreen.SetActive(true);
	}
}
