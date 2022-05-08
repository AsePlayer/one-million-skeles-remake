using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * This script serves as a general-purpose Health module that can be added to any Object.
 * They will gain the ability to takeDamage and die, and bullets will be causing damages.
 */

public class Health : MonoBehaviour
{
    [SerializeField] protected int startingHealth = 100;
    [SerializeField] protected int maxhealth = 100;
    [SerializeField] private int health;
    [SerializeField] GameObject healthbar;

    [SerializeField] Image healthbarImage;
    private GameObject player;

    private Transform aimTransform;
    // Optimize with pooling system later
    //public event Action onDied;

    private void Awake()
    {
        health = startingHealth;
        healthbarImage = healthbar.transform.Find("HP").GetComponentInChildren<Image>();

        // New
        // aimTransform = transform.Find("AimWeapon");
    }

    private void Start()
    {
        Vector3 gohere = transform.position;
        gohere.y += (healthbar.transform.position.y - transform.position.y);
        gohere.x += (transform.root.transform.position.x);
        
        if (healthbar != null)
        {
            //healthbar.transform.position = Vector3.MoveTowards(healthbar.transform.position, gohere, 10f);
            healthbarImage.fillAmount = determineFillAmount();
        }
    }

    private void Update()
    {
        if (healthbar != null)
        {
            healthbarImage.fillAmount = determineFillAmount();
        }
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(healthbar);
            die();
        }
        else if (health > maxhealth)
        {
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

        GetComponent<UnitStateManager>().die();

        /*
         * Eventually propegate this out to Pooling system or whateva instead
         * if(onDied != null)
         * {
         *      onDied();
         * }
         */
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
        //Value between 0 and 1
        return ((float)health / (float)maxhealth);
    }
}