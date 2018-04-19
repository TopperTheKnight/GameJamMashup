using UnityEngine;
using System.Collections;

public class HealthSystemAttribute : MonoBehaviour
{
	public int health = 3;


	private int maxHealth;

    [Header("Healthbar")]
    public bool showHealthbar;
    public bool attachHealthbarToObject = true;
    public GameObject customHealthbar;
    public Vector3 healthbarPosition = new Vector3(0, 1, 0);

    private GameObject currentHealthbar;
    private GameObject healthbarChild;


    [Header("Data Management")]
    public bool assignToHealthVarible;
    public string healthVariableName;


    private void Start()
	{

        if (showHealthbar)
        {
            if (!customHealthbar)
            {
                customHealthbar = (GameObject)Resources.Load("Healthbar/DefaultHealthbar", typeof(GameObject));
            }

            if (attachHealthbarToObject)
            {
                currentHealthbar = Instantiate(customHealthbar, transform, false);
            }

            else
            {
                currentHealthbar = Instantiate(customHealthbar, Camera.main.transform, false);
            }

            currentHealthbar.transform.position += healthbarPosition;
            healthbarChild = currentHealthbar.transform.GetChild(0).gameObject;

            if (!healthbarChild)
            {
                Debug.Log("Healthbars must have a child to scale");
                showHealthbar = false;
            }
        }

		maxHealth = health; //note down the maximum health to avoid going over it when the player gets healed
	}


    void Update()
    {
        if (showHealthbar)
        {
            UpdateHealthbar();
        }

        if (assignToHealthVarible && DataManager.instance)
        {
            DataManager.instance.setAmount(healthVariableName, health, false);
        }
    }


    void UpdateHealthbar()
    {
        float fHealth = health;

        healthbarChild.transform.localScale = new Vector3( fHealth / maxHealth, 1, 1);
    }

	// changes the energy from the player
	// also notifies the UI (if present)
	public void ModifyHealth(int amount)
	{
		//avoid going over the maximum health by forcin
		if(health + amount > maxHealth)
		{
			amount = maxHealth - health;
		}
			
		health += amount;

		//DEAD
		if(health <= 0)
		{
			Destroy(gameObject);
		}


        if (assignToHealthVarible && DataManager.instance)
        {
            DataManager.instance.setAmount(healthVariableName, health, false);
        }
    }
}
