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

    // Pause the game on click
	private void PauseGame()
	{
		pauseMenu.SetActive(isPaused = true);
		Time.timeScale = 0f;
	}

    // Resume the game on click
	public void ResumeGame()
	{
		pauseMenu.SetActive(isPaused = false);
		Time.timeScale = 1f;
	}

    // Load main menu on click
	public void LoadMainMenu()
	{
		Debug.Log("Loading menu ...!");
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
	}

    // Quit game on click
	public void QuitGame()
	{
		Debug.Log("Game quited!");
		Application.Quit();
	}

    // Load current level game
	public void LoadGame()
	{
		SceneManager.LoadScene(levelName);
		Time.timeScale = 1f;
	}

    // Show game over screen
	public void ShowScreenGO()
	{
		gameOverScreen.SetActive(true);
	}
}
