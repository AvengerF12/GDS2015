using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class MinionsScript : MonoBehaviour {
	
	public string minionType;
	public int minionHealth;
	public int minionAttack;
	public int minionSpeed;
	public int minionDirection;

	private Animator anim;
	private SpriteRenderer spriteR;
	public RuntimeAnimatorController[] animController;

    public bool respawning = false;
    private float respawnTime = 0f;
    private float minionRespawnTime = 0f;

    private Vector3 startingPos;

	private int viewWidth = 20;

    private bool bMove = false;

	private List<string> listType = new List<string>()
	{
		"redSpider",
		"blueSpider",
		"greenSpider",
		"purpleSpider",
		"brownSpider"
	};

	private List<int> listAttack = new List<int>()
	{
		50,
		100,
		150,
		100,
		100
	};

	private List<int> listSpeed = new List<int>()
	{
		4,
		8,
		2,
		4,
		4
	};

	// Use this for initialization

	void Start () {

		startingPos = transform.position;

		anim = GetComponent<Animator>();
		spriteR = GetComponent<SpriteRenderer> ();


		int randomChoice = Random.Range(0, listType.Count);

		minionType = listType[randomChoice];
		minionAttack = listAttack[randomChoice];
		minionSpeed = listSpeed[randomChoice];

        minionRespawnTime = (float)minionSpeed / (float)minionAttack * 30f;

        anim.runtimeAnimatorController = animController[randomChoice];

        if (this.transform.position.x < 0) {
			minionDirection = 1;
			this.transform.localScale = new Vector3 (-1, 1, 1); // Rotate spider position
		} else {
			minionDirection = -1;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -viewWidth/2f - 1 || transform.position.x > viewWidth/2f + 1) {
			respawning = true;
		}

        if (respawning == true) // check warriorScript for starting condition
        {
			respawnTime += Time.deltaTime;
			bMove = false;
			transform.position = startingPos;
			GetComponent<SpriteRenderer>().enabled = false;
			
			
			if (respawnTime >= minionRespawnTime)
			{
				GetComponent<SpriteRenderer>().enabled = true;
				respawning = false;
				respawnTime = 0;				
			}
        }

        if (bMove == true && respawning == false)
        {
			this.transform.Translate(new Vector3(minionDirection * minionSpeed * Time.deltaTime, 0));
        }

	}


    void OnMouseDown()
    {
        bMove = true;
    }

}
