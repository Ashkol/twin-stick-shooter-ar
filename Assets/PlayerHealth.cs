using AshkolTools.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] ProgressBar progressBar;
    int health = 100;
    [SerializeField] int maxHealth;

    private void Start()
    {
        health = maxHealth;
        progressBar.maximum = maxHealth;
        progressBar.minimum = 0;
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        progressBar.current = health;
        progressBar.UpdateFill();
    }

    public bool IsDead() => health <= 0;

}
