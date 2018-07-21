using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttack : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

	}

    void OnTriggerEnter2D(Collider2D rock)
    {
        if (rock.CompareTag("Player")) {
            player.DealDamage(5);
            Destroy(gameObject);
        }
    }
            
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
