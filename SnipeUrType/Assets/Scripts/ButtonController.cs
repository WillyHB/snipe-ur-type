using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
	public AudioSource cupidSound;

	public void GoAssignment() { //main menu start button, retry button

		SceneManager.LoadScene("Assignment");
	}
	public void GoQuit() { //quit button
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		
	} 
	public void GoCredits() { //main menu credits button
		SceneManager.LoadScene("Credits");
	}
	public void GoCupid() { //when u click on cupid!
		//do something fun
		Debug.Log("goo goo ga ga");
		cupidSound.Play();
	}
	public void GoGamePlay() {//continue to assignment 
		SceneManager.LoadScene("SampleScene");
	} 
	public void GoMainMenu() { //return to main menu
		SceneManager.LoadScene("MainMenu");
	}
}