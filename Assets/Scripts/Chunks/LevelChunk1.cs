using UnityEngine;
using System.Collections;

public class LevelChunk1 : MonoBehaviour {

	public GameObject[] backgroundTiles;
	public GameObject[] leftWall;
	public GameObject[] rightWall;
	public GameObject[] topwall;
	public GameObject[] leftCorner;
	public GameObject[] rightCorner;

	private Transform chunkContainer;
	private Transform tempContainer;

	private int chunkHeight = 27 + 4; // number of uiSize blocks and rows
	private int chunkLength = 9;

	private Vector3 chunkPos;

	
	void Awake ()
	{
		chunkContainer = new GameObject ("Chunk1").transform;

		tempContainer = new GameObject ("Temp").transform;

		chunkPos = transform.position;

		GameObject toInstantiate;


		for (int x=0; x<=chunkLength; x++) {
			for (int y=0; y>=-chunkHeight; y--) {

				//Choose a random tile from folder and instantiate it
				toInstantiate = backgroundTiles [Random.Range (0, backgroundTiles.Length)];

				//if the tile is on the borders of the array, then instantiate wall tiles instead using random wall tile from library
				
				if ((x == 0) && (y != chunkHeight)) {
					toInstantiate = leftWall [0];
				}
				
				if ((x == chunkLength) && (y != chunkHeight)) {
					toInstantiate = rightWall [0];
				}
				
				if ((y == chunkHeight) && (x >= 0) && (x < chunkLength)) {
					toInstantiate = topwall [0];
				}
				
				if ((y == chunkHeight) && (x == 0)) {
					toInstantiate = leftCorner [0];
				}
				
				if ((y == chunkHeight) && (x == chunkLength)) {
					toInstantiate = rightCorner [0];
				}
				
				//instantiate the objects with a grid structure using X and Y co-ordinates
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, -0.5f), Quaternion.identity) as GameObject;
				
				instance.transform.SetParent (chunkContainer);
			}
		}
		
		chunkContainer.position = new Vector3(-chunkLength/2f, transform.position.y, -0.5f);

	}
	
}
