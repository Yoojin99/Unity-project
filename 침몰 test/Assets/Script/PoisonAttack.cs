using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAttack : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }



    void OnTriggerStay2D(Collider2D poisonarea)
    {
        if (poisonarea.CompareTag("Player"))
        {
            player.DealPoison(3);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
