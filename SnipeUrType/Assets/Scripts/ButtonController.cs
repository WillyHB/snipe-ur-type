using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class MainMenuController : MonoBehaviour
{
	public void OnStartClick() { //main menu start button

		SceneManager.LoadScene("Assignment");
	}

	public void OnExitClick() { //main menu quit button
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		UnityEngine.Application.Quit();
	} 
	public void OnCreditsClick() { //main menu credits button
		SceneManager.LoadScene("Credits");
	}
}  

public class AssignmentController : MonoBehaviour
{
	public void OnContinueClick() {//continue to assignment 
		SceneManager.LoadScene("GamePlay");
	} 
}

public class ResultsController : MonoBehaviour
{
	public void OnMainMenuClick() { //return to main menu
		SceneManager.LoadScene("MainMenu");
	}
	public void OnNextClick() { //continue to next gameplay
		SceneManager.LoadScene("Assignment");
	}
}