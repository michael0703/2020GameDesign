using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private int lastHealth;
    // Health system of player
    public Slider slider;
    public Gradient gradient;
    public Image image;
    public Text text;
    public Image hit;
    private float hitEffectCountdown = -1f;


    void Start()
    {
        lastHealth = playerHealth.startHealth;

        text.color = gradient.Evaluate(1f);
        image.color = gradient.Evaluate(1f);

    }
    void Update()
    {

        if (lastHealth > playerHealth.currentHealth)
        {
            lastHealth = playerHealth.currentHealth;
            slider.value = lastHealth;
            text.text = lastHealth.ToString().PadLeft(3, ' ') + "/100";
            text.color = gradient.Evaluate((float)lastHealth / playerHealth.startHealth);
            image.color = gradient.Evaluate((float)lastHealth / playerHealth.startHealth);

            hitEffectCountdown = 1f;
            Color color = hit.color;
            color.a = 1;
            hit.color = color;
        }



        hitEffectCountdown -= Time.deltaTime;
        if (hitEffectCountdown <= 0f)
        {
            // Debug.Log(hit);

            hit.enabled = false;
        }
        else
        {
            hit.enabled = true;
            Color color = hit.color;
            color.a = hitEffectCountdown;
            hit.color = color;
        }
    }
}
