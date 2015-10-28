using UnityEngine;
using System.Collections;

public class Level2 : BoardGenTools {
	
	//heroes included in the parent class
	
	//minions included in the parent class
	
	//containers included in the parent class
	
	void Start () {
		
		Initialize ();
		
		DrawWalls(wallTiles);
		
		// Webs spawning
		DrawSidewalk(fullWeb, 5, -11);
		DrawSidewalk(fullWeb, 5, -23);
		DrawSidewalk(fullWeb, 5, -39);
		DrawSidewalk(fullWeb, 5, -45);
		DrawSidewalk(fullWeb, 5, -51);

		DrawSidewalk(fullWeb, -5, -5);
		DrawSidewalk(fullWeb, -5, -17);
		DrawSidewalk(fullWeb, -5, -39);
		DrawSidewalk(fullWeb, -5, -45);
		DrawSidewalk(fullWeb, -5, -51);
		
		DrawHeroes (1, "warrior");
		
	}
	
}