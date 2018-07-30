using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    public float CurrentHealth;
    public float MaxHealth;

    public float CurrentPoison;//Poison bar
    public float MaxPoison;

    public float CurrentOxygen;//Oxygen bar
    public float MaxOxygen;


    public Slider Healthbar;
    public Slider Poisonbar;
    public Slider Oxygenbar;
    

    public bool rockCollide = false;//rock
    
    void Start()
    {
        

        CurrentHealth = MaxHealth;
        Healthbar.value = CalculateHealth();
        

        CurrentOxygen = MaxOxygen;
        Oxygenbar.value = CalculateOxygen();
        

        CurrentPoison = 0.001f;
        Poisonbar.value = CalculatePoison();
    }
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}


    }


    float CalculateHealth()//hp
    {
        return CurrentHealth / MaxHealth;

    }

    float CalculateOxygen() {
        return CurrentOxygen / MaxOxygen;
    }

    float CalculatePoison() {
        return CurrentPoison / MaxPoison;
    }

    public void DealDamage(float damageValue)//healthdamage
    {

        CurrentHealth -= damageValue;
        Healthbar.value = CalculateHealth();

        if (CurrentHealth <= 0)
            Die();
    }

    public void DealOxygen(float damageValue)//Oxygendamage
    {

        CurrentOxygen -= damageValue;
        Oxygenbar.value = CalculateOxygen();

        if (CurrentOxygen <= 0)
            Die();
    }

    public void DealPoison(float poisonValue)//Poisondamage
    {
        CurrentPoison += poisonValue;
        Poisonbar.value = CalculatePoison();

        if (CurrentPoison >= MaxPoison)
            Die();
    }

    void Die()//die
    {
        CurrentHealth = 0;
        CurrentPoison = MaxPoison;
        Debug.Log("You dead.");
    }

    void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
