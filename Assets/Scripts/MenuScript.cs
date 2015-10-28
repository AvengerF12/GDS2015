using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {


	public GameObject mainMenuCanvas;
	public GameObject warningMenuCanvas;


	// Use this for initialization
	void Start () 
	{
		mainMenuCanvas.SetActive(true);
		warningMenuCanvas.SetActive(false);
	}


	public void buttonOnExit()
	{
		mainMenuCanvas.SetActive(false);
		warningMenuCanvas.SetActive(true);
	}

	
	public void buttonOnCancel()
	{
		mainMenuCanvas.SetActive(true);
		warningMenuCanvas.SetActive(false);
	}
	
	public void buttonOnCancelYes()
	{
		Application.Quit();
	}
	
	public void buttonOnPlay()
	{
		Application.LoadLevel("Level1");
	}

}
