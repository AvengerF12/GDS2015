using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelRand : BoardGenTools {

	// Use this for initialization
	void Start () {

		Initialize ();

		DrawWalls(wallTiles);

		// Webs spawning
		DrawSidewalk(fullWeb, -5, 0);
		DrawSidewalk(fullWeb, -5, 0);
		DrawSidewalk(fullWeb, 5, 0);
		DrawSidewalk(fullWeb, 5, 0);

		DrawHeroes(1);
    }
}
