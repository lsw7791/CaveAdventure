    using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Image[] heartui;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int maxHealth = 5;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        for (int i = 0; i < heartui.Length; i++)
        {
            if (i < currentHealth)
            {
                heartui[i].sprite = fullHeart;
            }
            else
            {
                heartui[i].sprite = emptyHeart;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
            Debug.Log("Space 키 눌러서 체력 감소!");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(1);
            Debug.Log("H 키 눌러서 체력 회복!");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Heal(maxHealth);
            Debug.Log("R 키 눌러서 체력 최대 회복!");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(1);
            Debug.Log("D 키 눌러서 체력 감소!");
        }
    }
}

