using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField]private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;
    private LevelManager levelManager;

    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GetComponent<LevelManager>();
        anim = GetComponent<Animator>();
        dead = false;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // THis is where I would put my hurt animation IF I MADE ONE!!!

            // Flash red when hit && iFrames
            StartCoroutine(Invulnerability());

        }
        else
        {
            if (!dead) 
            {
                // Deactivates all attatched components
                foreach (Behaviour component in components)
                    component.enabled = false;

                //anim.SetBool("isJumping", false);
                anim.SetTrigger("die");

                // Flash red when hit && iFrames
                StartCoroutine(Invulnerability());

                dead = true;
            }
        }
    }

    private void Update()
    {
        // Debug Force Damage

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    TakeDamage(1);
        //}
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    // Function to respawn the player (Is not set up for enemy respawning)
    public void Respawn()
    {
        // Restart Level on Death Logic
        levelManager.ResetLevel();

        //// Player checkpoint respawn logic
        //dead = false;
        //AddHealth(startingHealth);
        //anim.ResetTrigger("die");
        //anim.Play("Idle Mage");
        //StartCoroutine(Invulnerability());

        //// Reactivates all attatched components
        //foreach (Behaviour component in components)
        //    component.enabled = true;
    }

    // Have the character flash red
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f); // Red Transparent
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        // Invulnerability
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
