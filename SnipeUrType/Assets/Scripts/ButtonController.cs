using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
	public void GoAssignment() { //main menu start button, retry button
		UIAudio.instance.PlayClick();
		SceneManager.LoadScene("Application Test");
		UIAudio.instance.PlaySwoosh();
	}
	public void GoQuit() { //quit button
		UIAudio.instance.PlayClick();
		UnityEngine.Application.Quit();
	} 
	public void GoCredits() { //main menu credits button
		UIAudio.instance.PlayClick();
		SceneManager.LoadScene("Credits");
	}
	public void GoCupid() { //when u click on cupid!
		//do something fun
		Debug.Log("goo goo ga ga");
	}
	public void GoGamePlay() {//continue to assignment 
		StartCoroutine(HuntWait());
		UIAudio.instance.PlayClick();
	} 

	private IEnumerator HuntWait()
	{
		UIAudio.instance.PlayHunt();
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene("SampleScene");
	}
	public void GoMainMenu() { //return to main menu
		UIAudio.instance.PlayClick();
		SceneManager.LoadScene("MainMenu");
	}
}
