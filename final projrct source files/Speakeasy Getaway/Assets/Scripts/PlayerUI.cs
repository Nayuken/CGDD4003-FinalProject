using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public PlayerController player;
    public Timer timer;

    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;
    public PowerupDisplay HUD;

    public int total;
    public Text score;

    public GameObject gameOver;

    void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        HUD.Stable();
        total = 0;
    }

    void Update()
    {
        score.text = " x " + total;

        if (Input.GetKeyDown(KeyCode.X))
        {
            HUD.Switch(0);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            HUD.Switch(1);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            HUD.Switch(2);
        }
        if (currentHealth == 0)
        {
            player.isDead = true;
        }
        if (player.isDead)
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
