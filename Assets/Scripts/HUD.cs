using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	private Transform hudContainer;

	private Camera mainCam;

	private int camSize;
	private float camWidth;
	private float camHeight;
	private Vector3 camPos;
	
	public GameObject[] tiles = new GameObject[2];

	// Use this for initialization
	void Start () 
	{
		GameObject instance;

		mainCam = Camera.main;

		camSize = 16;
		camHeight = camSize * 2F;
		camWidth = camHeight * 10/16;

		hudContainer = new GameObject ("UI").transform;

		for (int x=0; x<20; x++) {
			for (int y=0; y<4; y++){
				instance = Instantiate(tiles[0], new Vector3(x,y,-2.5F),Quaternion.identity) as GameObject;
				instance.transform.SetParent(hudContainer);
			}
		}

	}

	void Update()
	{
		camPos = mainCam.transform.position;

		float x = camPos.x;
		float y = camPos.y - camHeight;

		hudContainer.position = new Vector3 (0.5f-camWidth/2f, camPos.y - 15.5F, 0);

	}

}
