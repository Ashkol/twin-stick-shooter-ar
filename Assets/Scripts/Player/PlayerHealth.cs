using AshkolTools.UI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] ProgressBar progressBar;
    int health = 100;
    [SerializeField] int maxHealth;
    public Animator animator;
    public Rigidbody rb;
    public PlayerMovement playerMovement;
    public GameObject deathText;

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

        if (health < 0 && animator)
        {
            animator.SetBool("Death_b", true);
            if (rb && playerMovement)
            {
                rb.isKinematic = true;
                playerMovement.enabled = false;
                deathText.SetActive(true);
            }
                
        }
            
    }

    public bool IsDead() => health <= 0;

}
