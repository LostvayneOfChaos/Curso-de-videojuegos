using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float rangeDetection;
    public  Transform[] positions;
    private NavMeshAgent agente;
    private int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        if(positions.Length > 0)
        {
            agente.SetDestination(positions[0].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float distancia = Vector3.Distance(transform.position, positions[index].position);
        if (distanceToTarget < rangeDetection)
        {
            agente.SetDestination(target.position);

        }

        else if (distancia < 9.0f)
        {
            index = (index + 1) % positions.Length;
            agente.SetDestination(positions[index].position);
        }
        


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game over");
        Destroy(other.gameObject); // Desaparece el objeto
    }







}
