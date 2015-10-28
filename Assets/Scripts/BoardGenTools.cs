using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
// Find a way to get rows and columns automagically
public class BoardGenTools : MonoBehaviour {

	// Antonello's code
	//last updated: 21/10/2015, 17:47
	//Collections of functions to build levels


	//Liam Macleans code
	//last updated: 22/09/2015, 09:32
	//created tile generation code

	public int columns; 
	public int rows;

	public GameObject[] fullWeb;
	public GameObject[] wallTiles;

	//heroes
    public GameObject warrior;
    public GameObject healer;
    public GameObject mage;
    public GameObject brute;

    //minions
    public GameObject spiders;

    public Transform boardContainer;
    public Transform sideContainer;
	public Transform minionContainer;
	public Transform heroContainer;



	public void Initialize()
	{
		// Variables won't update if initialized while global

		// Technically it should be ten but by keeping it nine it simplifies the code
		// There are always 10 columns in total
		columns = 9; //9
		rows = 28; // 28

		
		//create the board gameobject
		boardContainer = new GameObject ("Board").transform;
		sideContainer = new GameObject("Sidewalk").transform;
		heroContainer = new GameObject("Heroes").transform;
		minionContainer = new GameObject("Minions").transform;

		heroContainer.tag = "Heroes";
	}
	


	public void DrawWalls(GameObject[] wallTiles)
    {
		// wallsCount = extension of the wall per each side
		int wallLength = 20;

        GameObject toInstantiate = wallTiles[0];
        GameObject instance;
		
		int screenCount = Camera.main.GetComponent<CameraScript>().screenCount;

        // Coordinates

        for (int x = 0; x < wallLength; x++) {
            for (int y = 0; y >= -rows*screenCount; y--) {

                instance = Instantiate(toInstantiate, new Vector3(x, y, -0.1f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardContainer);
            }
        }
		
		boardContainer.position = new Vector3 (0.5f-wallLength/2f, 0, -0.1f);
        
    }



    // Draws any "bridge" needed on the side of the screen

	public void DrawSidewalk(GameObject[] sidewalk, float x, float y)
    {

        int k = 0;

        int sidePieces = 4; // pieces of sidewalks that form a complete one
        int minionPos = 3; // relative to the sidewalk pieces

        int random = Random.Range(0, rows);

		if(y == 0){ // input y=0 for random y
			y=random;
		}

        for (k = 0; k < sidePieces; k++)
        {

            // Handles rotation between right and left
            if (x < 0) {

				GameObject sideInstance = Instantiate(sidewalk[k], new Vector3(x - k + 0.5f, y, -0.5f), Quaternion.identity) as GameObject;
                sideInstance.transform.Rotate(new Vector3(0, 0, 180));
				sideInstance.transform.SetParent(sideContainer);

			} else if(x > 0){
				// -1 needed to avoid discrepancy in the board since columns = 10 but the tenth column x is 9.
				// This function requires 9 but others the value columns = 10.
				GameObject sideInstance = Instantiate(sidewalk[k], new Vector3(x + k - 0.5f, y, -0.5f), Quaternion.identity) as GameObject;
				sideInstance.transform.SetParent(sideContainer);
			}

        }
		
		if(x < 0){
			GameObject minionInstance = Instantiate(spiders, new Vector3(x - minionPos + 0.5f, y, -1f), Quaternion.identity) as GameObject;
			minionInstance.transform.SetParent(minionContainer);
		} else if(x > 0){
			GameObject minionInstance = Instantiate(spiders, new Vector3(x + minionPos - 0.5f, y, -1f), Quaternion.identity) as GameObject;
			minionInstance.transform.SetParent(minionContainer);
		}
    }



	public void DrawHeroes(int heroCount, string hero1="random", string hero2="random", string hero3="random", string hero4="random")
	{

		float camHeight = Camera.main.orthographicSize * 2F;
		float camWidth = camHeight*10/16;
		Vector3 camPos = Camera.main.transform.position;

		Dictionary<string,GameObject> heroArray = new Dictionary<string,GameObject> ()
		{
			{"warrior", warrior},
			{"mage", mage},
			{"brute", brute},
			{"healer", healer}
		};

		float[] heroesPosX = new float[4] {0, 0, -1.5f, 1.5f};
		float[] heroesPosY = new float[4] {-3, -1, -2, -2};
		string[] heroChoice = new string[4] {hero1, hero2, hero3, hero4};

		GameObject hero;

		for (int i=0; i<heroCount; i++) {

			if(heroChoice[i] != "random"){

				hero = heroArray[heroChoice[i]];
			} else {

				GameObject[] temp = new GameObject[4]; 
				heroArray.Values.CopyTo(temp, 0);
				hero = temp[Random.Range(0,heroArray.Count)];
			}

			heroArray.Remove(heroChoice[i]);

			GameObject instance = Instantiate(hero, new Vector3(heroesPosX[i], heroesPosY[i], -1f), Quaternion.identity) as GameObject;
			instance.transform.SetParent(heroContainer);
		}

	}

}
