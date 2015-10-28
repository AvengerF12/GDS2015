using UnityEngine;
using System.Collections;

public class HealerScript : MonoBehaviour {

	//Liam Macleans code
	//last updated: 22/09/2015, 10:44
	//created healer script concept

	public int Health = 100;
	public int Armor = 25;
	public int Heal = 20;
	public int HordeKilled = 0;
	public int Damage = 5;

	public int attackRange;
	public float attackSpeed;

    private bool roundEnd = false;
    private bool aggroRange = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (roundEnd == false)
        {
            transform.Translate(0, -1 * Time.deltaTime, 0);
        }
		//if enemies exist and are in aggro range
			//go towards them into attack range and stop moving to waypoint
			//if attack speed cooldown is over
				//start attacking
			//else
				//wait for attack speed cooldown
			//if any horde dies by this characters finishing blow, add to hordekilled count
		//if enemies do not exist
			//carry on to the next waypoint

		//if hero in heal range is not full health
			//if heal is on cooldown
				//wait
			//if heal is off cooldown
				//heal
		//if caught in a trap
			//stop movement for 3 seconds

		//if this gameobject(Healer) gets to the end, gameover
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "End")
        {
            //move to the minion
            aggroRange = true;
            roundEnd = true;
        }

    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag != "Enemies")
        {
        }
    }

}
