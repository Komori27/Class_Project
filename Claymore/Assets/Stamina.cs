using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina = 100f;
    public float staminaRecoveryRate = 5f;

    private float lastTime;

    [SerializeField] PlayerHealth health;
    [SerializeField] PlayerStaminaHUD staminaBar;
    [SerializeField] PlayerHealthHUD healthBar;


    private void Start()
    {
        lastTime = Time.time;
        staminaBar.SetMaxStamina(maxStamina);
    }

    private void Update()
    {
        // Check if we need to recover stamina
        if (currentStamina < maxStamina)
        {
            float timeSinceLast = Time.time - lastTime;
            float staminaRecovered = timeSinceLast * staminaRecoveryRate;

            // Increase current stamina
            currentStamina = Mathf.Clamp(currentStamina + staminaRecovered, 0f, maxStamina);

            // Update lastTime
            lastTime = Time.time;
        }
    }

    public bool UseStamina(float amount)
    {
        // Check if we have enough stamina
        if (currentStamina >= amount)
        {
            // Decrease current stamina
            currentStamina -= amount;

            return true;
        }

        // Check if we have enough stamina
        if (currentStamina <= amount)
        {
            currentStamina = 0;
            float newHealth = health.currentHealth -= 20;
            healthBar.SetHealth(newHealth);
            if (newHealth == 0) 
            {
                health.Die();
            }
            return true;
        }
        return false;
    }
}