using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    #region[Public Variable]
    #endregion
    #region [Private Variables]
    #region [Health Stats]
    private int currentHealth = 100;

    private int maxHealthBase = 100;
    private int maxHealthModifier = 0;
    #endregion
    #region [Movement Stats]
    private float movementSpeedBase = 20f;
    private float movementSpeedModifier = 0f;
    #endregion
    #region [Melee Attack Stats]
    private int playerDamageBase = 10;
    private int playerDamageModifier = 0;

    private float attackSpeedBase = 1;
    private float attackSpeedModifier = 0;
    #endregion
    #region [Dodge Stats]
    private float dodgeDistanceBase = 10f;
    private float dodgeDistanceModifier = 0f;

    private float dodgeCooldownBase = 5f;
    private float dodgeCooldownModifier = 0;
    #endregion
    #region [Shield Stats]
    private float currentShieldHealth = 0;

    private float shieldHealthBase = 3;
    private float shieldHealthModifier = 0;

    private float shieldRechargeDelayBase = 10;
    private float shieldRechargeDelayModifier = 0;

    private float shieldRechargeRateBase = 0.5f;
    private float shieldRechargeRateModifier = 0;

    private float timeSinceLastHit = 0;

    #endregion
    #region [Ranged Attack Variables]
    private int rangedAttactDamageBase = 5;
    private int rangedAttactDamageModifier = 0;

    private float rangedAttactCooldownBase = 0;
    private float rangedAttactCooldownModifier = 0;
    #endregion

    private int Base = 0;
    private int Modifier = 0;

    private int Base = 0;
    private int Modifier = 0;

    private int Base = 0;
    private int Modifier = 0;

    private int Base = 0;
    private int Modifier = 0;
    #endregion


    #region[Unity Events]
    void Start()
    {
        currentHealth = maxHealthBase + maxHealthModifier;
    }
    void Update()
    {   
        CheckPlayerDeath();
        ReduceHealthToMaxHEalth();
        timeSinceLastHit += Time.deltaTime;
        rechargeShield();
    }
    #endregion
    #region[Custom Functions]
    public void hurtPlayer(int damageTaken)
    { 
        //remove any spare shield
        currentShieldHealth = Mathf.Floor(currentShieldHealth);

        if (currentShieldHealth <= 1)
        {   //Reduce the shield health
            currentShieldHealth--;
        }
        else
        {
            currentHealth -= damageTaken;
            CheckPlayerDeath();
        }
        timeSinceLastHit = 0;
    }
    public void healPlayer(int healing)
    {
        currentHealth += healing;
        ReduceHealthToMaxHEalth();
    }
    public void IncreaceMaxHealth(int increaseAmount)
    {
        maxHealth += increaseAmount;
        currentHealth += increaseAmount;
    }
    public int GetDamage()
    {
        return playerDamageBase + playerDamageModifier;
    }
    private void CheckPlayerDeath()
    {//kill the player if they have no health
        if (currentHealth <= 0)
        {
            //player death goes here
            Destroy(this.gameObject);
        }
    }
    private void ReduceHealthToMaxHEalth()
    {
        if (currentHealth > maxHealthBase +maxHealthModifier)
        {
            currentHealth = maxHealthModifier + maxHealthBase;
        }
        if (currentShieldHealth > shieldHealthBase + shieldHealthModifier)
        {
            currentShieldHealth = shieldHealthBase + shieldHealthModifier;
        }
    }
    private void rechargeShield()
    {
        if (timeSinceLastHit >= shieldRechargeDelayBase + shieldRechargeDelayModifier)
        {
            currentShieldHealth += (shieldRechargeRateBase + shieldRechargeRateModifier);
        }
    }
    #endregion
}
