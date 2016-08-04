using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    #region[Public Variable]
    #endregion
    #region [Private Variables]
    private int currentHealth = 100;
    private int maxHealth = 100;
    private int playerDamage = 10;
    #endregion
    #region[Unity Events]
    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        CheckPlayerDeath();
    }
    #endregion
    #region[Custom Functions]
    public void hurtPlayer(int damageTaken)
    {
        currentHealth -= damageTaken;
        CheckPlayerDeath();
    }
    public void healPlayer(int healing)
    {
        currentHealth += healing;
    }
    public void IncreaceMaxHealth(int increaseAmount)
    {
        maxHealth += increaseAmount;
        currentHealth += increaseAmount;
    }
    public int GetDamage()
    {
        return playerDamage;
    }
    private void CheckPlayerDeath()
    {//kill the player if they have no health
        if (currentHealth <= 0)
        {
            //player death goes here
            Destroy(this.gameObject);
        }
    }
    #endregion
}
