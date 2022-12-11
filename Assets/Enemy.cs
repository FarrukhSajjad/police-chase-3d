using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemyAgent;

    public Animator enemyRunAnimator;

    public bool isDead;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!this.isDead)
            {
                PlayerCharacter.Instance.playerAnimatorController.SetBool("attack", true);
                AudioManager.Instance.PlayHitSound();
                Invoke(nameof(EnemyDeath), 0.2f);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            PlayerCharacter.Instance.playerAnimatorController.SetBool("attack", false);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerCharacter.Instance.playerAnimatorController.SetBool("attack", true);
        }
    }

    private void Update()
    {
        if (PlayerCharacter.Instance == null) return;
        float distance = Vector3.Distance(transform.position, PlayerCharacter.Instance.transform.position);

        if (distance < 4)
        {
            enemyRunAnimator.SetBool("isRunning", true);

            Vector3 dirToPlayer = transform.position - PlayerCharacter.Instance.transform.position;

            Vector3 newPos = transform.position + dirToPlayer;

            enemyAgent.SetDestination(newPos);
        }

        else
        {
            enemyRunAnimator.SetBool("isRunning", false);
            this.gameObject.transform.LookAt(PlayerCharacter.Instance.transform);
        }

    }

    private void EnemyDeath()
    {
        if (!this.isDead)
        {
            enemyRunAnimator.SetBool("dying", true);
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Level.Instance.enemiesInThisLevel--;
            UIManager.Instance.totalEnemiesToKillText.text = Level.Instance.enemiesInThisLevel.ToString();
            Destroy(this.gameObject, 1.5f);
            this.isDead = true;
        }
    }
}
