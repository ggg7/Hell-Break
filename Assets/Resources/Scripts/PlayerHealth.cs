using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image DamageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    bool damaged;
    bool isDead;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {
        if(damaged)
        {
            DamageImage.color = flashColor;
        }
        else
        {
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;
        
    }
}
