using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public GameObject target, boss;
    private NavMeshAgent agent;
    private Animator animator;
    public float RotateSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
        rotateTowardsTarget();
    }
    void rotateTowardsTarget()
    {
        float stepSize = Time.deltaTime * RotateSpeed;
        Vector3 targetDir = boss.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Walk", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Attack", false);
        animator.SetBool("Walk", true);
    }
}
