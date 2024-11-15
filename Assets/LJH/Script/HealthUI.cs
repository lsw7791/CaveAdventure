using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthSlider;  
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;  
        healthSlider.maxValue = maxHealth;  
        healthSlider.value = currentHealth;  
    }

    void Update()
    {
        // D키를 눌렀을 때 체력 감소
        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(10f);  // 체력을 10만큼 감소
        }

        // H키를 눌렀을 때 체력 회복
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10f);  // 체력을 10만큼 회복
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;  

        healthSlider.value = currentHealth;  
    }

    
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;  

        healthSlider.value = currentHealth;     
    }
}
