using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * This script serves as a general-purpose Health module that can be added to any Object.
 * They will gain the ability to takeDamage and die.
 */

public class Health : MonoBehaviour
{
    [SerializeField] protected int startingHealth = 100;
    [SerializeField] protected int maxhealth = 100;
    [SerializeField] private int health;
    [SerializeField] GameObject healthbar;
    [SerializeField] Image healthbarImage;

    public bool isDead;

    private void Awake()
    {
        // Set starting health and get the fill image
        health = startingHealth;
        healthbarImage = healthbar.transform.Find("HP").GetComponentInChildren<Image>();
    }

    private void Update()
    {
        // Update the health fill amount
        if (healthbar != null)
            healthbarImage.fillAmount = determineFillAmount();
    }

    public void takeDamage(int amount)
    {
        // Take damage
        health -= amount;
        if(health <= 0)
        {
            // Too much damage? Die.
            Destroy(healthbar);
            die();
        }
        else if (health > maxhealth)
        {
            // Too much health?? Max out.
            health = maxhealth;
        }
    }

    private void die()
    {
        // If player. Have it not destroy game object later and reset scene instead.
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }
        isDead = true;
        GetComponent<UnitStateManager>().die();
    }

    public int getHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return maxhealth;
    }

    private float determineFillAmount()
    {
        //Fill value between 0% and 100%
        return ((float)health / (float)maxhealth);
    }
}