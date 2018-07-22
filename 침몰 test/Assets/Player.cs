using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public Slider Healthbar;

    public bool rockCollide = false;

    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        MaxHealth = 20f;

        CurrentHealth = MaxHealth;
        Healthbar.value = CalculateHealth();
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


    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;

    }

    public void DealDamage(float damageValue)
    {

        CurrentHealth -= damageValue;
        Healthbar.value = CalculateHealth();

        if (CurrentHealth <= 0)
            Die();
    }

    void Die()
    {
        CurrentHealth = 0;
        Debug.Log("You dead.");
    }

    void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
