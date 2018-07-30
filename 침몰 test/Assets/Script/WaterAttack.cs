using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : MonoBehaviour
{

    private Player player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }



    void OnTriggerStay2D(Collider2D waterarea)
    {
        if (waterarea.CompareTag("Player"))
        {
            player.DealOxygen(1);
        }
    }
    

    // Update is called once per frame
    void Update()
    {

    }
}
