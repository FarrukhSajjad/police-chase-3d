using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemyAgent;

    public Animator enemyRunAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Police Entered the enemy collider");
            PlayerCharacter.Instance.playerAnimatorController.SetBool("attack", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Police Extied the enemy collider");
            PlayerCharacter.Instance.playerAnimatorController.SetBool("attack", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Police Entered the enemy collider");
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
}
