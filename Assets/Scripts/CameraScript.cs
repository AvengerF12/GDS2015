using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// WIN/LOSE CONDITION HERE! Possibly need migration to different script.
// Find a way to figure out the number of stages in a level efficiently. Maybe sort board by rows and columns

public class CameraScript : MonoBehaviour {

    private GameObject heroContainer;

    // Lose condition var
	public GameObject lose;
	public GameObject win;
    private bool ended = false;
    float restartTimer = 0;

    private Camera cam;
	private int camSize = 16;
    private float camHeight;
    private float camWidth;
	private Vector3 camPos;

    private List<float> heroXs = new List<float>();
    private List<float> heroYs = new List<float>();

    private int childCount = 0;
    private Transform child;

    private int y;
    private int x;

	private float heroScale = 1.5F;

	private int scrollCount;
	public int screenCount;

	private int uiSize = 4;

    // Use this for initialization
    void Start () {

        cam = Camera.main;
		cam.orthographicSize = camSize;
        camHeight = 2f * camSize;
        camWidth = camHeight * 10/16;

		y = (int)camHeight - uiSize;
		x = 10;

		scrollCount = 0;

        camPos = new Vector3(0, -camHeight/2+0.5F, -5F); // Optimal pos

        transform.position = camPos;

    }
	
	// Update is called once per frame
	void LateUpdate () {

		heroContainer = GameObject.FindWithTag("Heroes");

        childCount = heroContainer.transform.childCount;

         // number of columns divided by 10

        heroXs.Clear();
        heroYs.Clear();

        for (int i = 0; i < childCount; i++)
        {
            child = heroContainer.transform.GetChild(i);

            heroXs.Add(child.position.x);
            heroYs.Add(child.position.y);

            heroXs.Sort();
            heroYs.Sort();

        }

		// camera scroll conditions

		if ((childCount > 0) && ((heroYs [0] - heroScale) < (camPos.y - (camHeight / 2 - uiSize))) && (scrollCount < (screenCount - 1))) {

			scrollCount++;

            camPos.y -= camHeight;



			StartCoroutine("moveCamera");

		}

		// End game conditions

		if (childCount > 0 && heroYs[childCount-1] <= (-camHeight * screenCount + uiSize) && ended == false) { // Heroes reach the end of the screen
			Instantiate(lose, new Vector3(0, cam.transform.position.y, -2), Quaternion.identity);
			StartCoroutine("startTimerRetry");
            ended = true;
        }

		if (childCount == 0 && ended == false) { // All the heroes are dead
            Instantiate(win, new Vector3(0, cam.transform.position.y, -2), Quaternion.identity);
			StartCoroutine("startTimerRetry");
            ended = true;
        }
		
    }

	IEnumerator moveCamera()
	{
		if (transform.position.y == (camPos.y + camHeight)) {
			for(int i = 0; i < childCount; i++){
				heroContainer.transform.GetChild(i).GetComponent<HeroScript>().scrollingStop = true;
			}
		}

		while(transform.position.y > camPos.y){
			transform.position = Vector3.MoveTowards (transform.position, camPos, 0.5F);
			yield return null;
		}

		for(int i = 0; i < childCount; i++){
			heroContainer.transform.GetChild(i).GetComponent<HeroScript>().scrollingStop = false;
		}
		heroContainer.transform.position = new Vector3(heroContainer.transform.position.x, heroContainer.transform.position.y - uiSize, heroContainer.transform.position.z);
	}

	IEnumerator startTimerRetry()
	{
		while (true) {
			restartTimer += Time.deltaTime;

			if(restartTimer >= 3){
				Application.LoadLevel("Level1");
			}

			yield return null;
		}

	}

	IEnumerator startTimerNext()
	{
		while (true) {
			restartTimer += Time.deltaTime;
			
//			if(restartTimer >= 3){
//				Application.LoadLevel("Level2");
//			}
			
			yield return null;
		}
		
	}
}
