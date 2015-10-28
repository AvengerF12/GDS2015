using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroScript : MonoBehaviour {

	//Liam Macleans code
	//last updated: 22/09/2015, 10:44
	//created warrior script concept

	public int Health = 100;
	public int Armor = 100;
	public int HordeKilled = 0;
	public int Damage = 20;

	public int attackRange;
	public float attackSpeed;

    private Animator anim;

    public bool scrollingStop = false;

	// Use this for initialization
	void Start () {


        GetComponent<Transform>();

        anim = GetComponent<Animator>();

        anim.speed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {



		if (scrollingStop == false)
        {
            transform.Translate(0, -1 * Time.deltaTime, 0);
        }
	
		//if enemies exist and are in aggro range
			//go towards them into attack range and stop moving to waypoint
			//if attack speed cooldown is over
				//start attacking
			//else
				//wait for attack speed cooldown
			//if enemy dies by this characters finishing blow, add to hordekilled count
		//if enemies do not exist
			//carry on to the next waypoint
			
		//if caught in a trap
			//stop movement for 3 seconds

		//if this gameobject(warrior) gets to the end, gameover


	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Minion"))
        {
			Debug.Log(col.gameObject.GetComponent<MinionsScript>().minionType);
			int damage = col.gameObject.GetComponent<MinionsScript>().minionAttack;
			this.Health -= damage;

			if(this.Health <= 0){
				Destroy(this.gameObject);
			}

			col.gameObject.GetComponent<MinionsScript>().respawning = true;
            
        }
    }

}
