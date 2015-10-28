using UnityEngine;
using System.Collections;

public class Level1 : BoardGenTools {

	//heroes included in the parent class

	//minions included in the parent class

	//containers included in the parent class

	void Start () {
		
		Initialize ();
		
		DrawWalls(wallTiles);

		// Webs spawning
		DrawSidewalk(fullWeb, 5, -11);
		DrawSidewalk(fullWeb, 5, -23);
		DrawSidewalk(fullWeb, -5, -5);
		DrawSidewalk(fullWeb, -5, -17);

		DrawHeroes (1, "warrior");
	}

}