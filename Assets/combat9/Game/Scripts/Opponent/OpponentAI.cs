 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpponentAI : MonoBehaviour
{

    //// Toutes vos variables existantes...
    public GameObject winMessageUI; // Référence à l'objet UI
    public string nextSceneName;   // Nom de la prochaine scène à charger
    private bool isDead = false;   // Pour éviter les appels multiples



    public float movementSpeed = 1f;
    public float rotationSpeed = 10f;
    public CharacterController characterController;
    public Animator animator;
    [Header("Opponent Fight")]
    public float attackCooldown = 0.5f;
    public int attackDamages = 5;
    public string[] attackAnimations = { "Attack1Animation", "Attack2Animation", "Attack3Animation", "Attack4Animation" };
    public float dodgeDistance = 2f;
    public int attackCont = 0;
    public int randomNumber;
    public float attackRadius = 2f;
    public FightingController[] fightingControllers;
    public Transform[] players;
    public bool isTakingDamage;
    private float lastAttackTime;

    public ParticleSystem attack1Effect;
    public ParticleSystem attack2Effect;
    public ParticleSystem attack3Effect;
    public ParticleSystem attack4Effect;
    public AudioClip[] hitSounds;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.GiveFullHealth(currentHealth);
        createRandomNumber();
    }
    private void Update()
    {
        //if(attackCont ==  randomNumber)
        //{
        //    attackCont = 0;
        //    createRandomNumber();
        //}
        for (int i = 0; i < fightingControllers.Length; i++)
        {
            if (players[i].gameObject.activeSelf && Vector3.Distance(transform.position, players[i].position)<= attackRadius)
            {
                animator.SetBool("Walking" , false);
                if(Time.time - lastAttackTime > attackCooldown)
                {
                    int randomAttackIndex = Random.Range(0, attackAnimations.Length);
                    if (!isTakingDamage)
                    {
                           PerformAttack(randomAttackIndex);
                    }
                    fightingControllers[i].StartCoroutine(fightingControllers[i].PlayHitDamageAnimation(attackDamages));
                }
            }
            else
            {

                if (players[i].gameObject.activeSelf)
                {
                    Vector3 direction = (players[i].position - transform.position).normalized;
                    characterController.Move(direction * movementSpeed * Time.deltaTime);
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    animator.SetBool("Walking", true);
                }
            }
        }
    }

    void PerformAttack(int attackIndex)
    {
        
            animator.Play(attackAnimations[attackIndex]);
            int damage = attackDamages;
            Debug.Log("performed attack" + (attackIndex + 1) + "dealing" + damage + "damage");
            lastAttackTime = Time.time;



        
      
        
           
        
    }
    void PerformeDodgeFront()
    {


        animator.Play("DodgeFrontAnimation");
        Vector3 dodgeDirection = -transform.forward * dodgeDistance;
        characterController.SimpleMove(dodgeDirection);

    }
    
    void createRandomNumber()
    {
        randomNumber = Random.Range(1,5);

    }
    public IEnumerator PlayHitDamageAnimation(int takeDamage)
    {
        yield return new WaitForSeconds(0.5f);
        if (hitSounds != null && hitSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, hitSounds.Length);
            AudioSource.PlayClipAtPoint(hitSounds[randomIndex], transform.position);
        }
        currentHealth -= takeDamage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        animator.Play("HitDamageAnimation");
    }
    void Die()
    {
        Debug.Log("Ennemie Died");

        if (isDead) return; // Si déjà mort, on ne répète pas
        isDead = true;

        ////Debug.Log("Enemy Died");
        //// Optionnel : Jouer une animation ou un effet avant la destruction
        //animator.Play("Standing React Death Backward");

        // Détruire l'ennemi après un délai pour permettre la fin des animations/effets
        //Destroy(gameObject, 2f); // Remplacez 2f par la durée de l'animation si nécessaire
        // Mettre le jeu en pause
        Time.timeScale = 0f;
        if (winMessageUI != null)
        {
            winMessageUI.SetActive(true); // Affiche le message de victoire


            //    // Jouer le son de victoire
            //    AudioSource audioSource = winMessageUI.GetComponent<AudioSource>();
            //    if (audioSource != null)
            //    {
            //        audioSource.Play();
            //    }
            //}
            // Mettre le jeu en pause (arrêt complet)
            StartCoroutine(StopGameAndLoadScene());

            // Charger la scène après un délai de 5 secondes
            Invoke("LoadNextScene", 2f);

        }
    }
        public void Attack1Effect()
    {
        attack1Effect.Play();
    }
    public void Attack2Effect()
    {
        attack2Effect.Play();
    }
    public void Attack3Effect()
    {
        attack3Effect.Play();
    }
    public void Attack4Effect()
    {
        attack4Effect.Play();
    }



        //void LoadNextScene()
        //{
        //    //Time.timeScale = 0.1f;
        //    if (!string.IsNullOrEmpty(nextSceneName))
        //    {
        //        SceneManager.LoadScene(nextSceneName); // Charge la prochaine scène
        //    }
        //}


        IEnumerator StopGameAndLoadScene()
        {
            // Arrêter le jeu (animations et physique)
            Time.timeScale = 0f;

            // Attendre 5 secondes tout en gardant l'interface utilisateur active
            float pauseEndTime = Time.realtimeSinceStartup + 5f;
            while (Time.realtimeSinceStartup < pauseEndTime)
            {
                yield return null; // Attendre la prochaine frame
            }

            // Reprendre le temps et charger la prochaine scène
            Time.timeScale = 1f;
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName); // Charger la scène suivante
            }
        }

    }
