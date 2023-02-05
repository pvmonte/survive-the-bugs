using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public GameObject pauseMenu;
	public GameObject confirmPanel;

	public bool prevBtn;


	public void PauseGame(){
		Time.timeScale = 0;
		pauseMenu.SetActive (true);
	}

	public void ResumeGame(){
		Time.timeScale = 1;
		pauseMenu.SetActive (false);
	}

	public void MainMenu(){
		prevBtn = true;
		confirmPanel.SetActive (true);
	}

	public void Quit(){
		prevBtn = false;
		confirmPanel.SetActive (true);
	}

	public void ConfirmYes(){
		if (prevBtn) {
			SceneManager.LoadScene ("MainMenu");
		} else {
			Application.Quit ();
		}
	}

	public void ConfirmNo(){
		confirmPanel.SetActive (false);
	}
}
