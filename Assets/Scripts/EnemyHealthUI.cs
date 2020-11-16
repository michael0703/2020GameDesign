using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public EnemyHealth health;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        slider.value = (float)health.currentHealth/(float)health.startHealth;
    }
}
