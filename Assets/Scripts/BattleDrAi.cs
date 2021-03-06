using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class BattleDrAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public float spreadAngle;
    public Transform BarrelExit;
    public Transform BarrelExit2;
    public int pelletCount;
    List<Quaternion> pellets;
    public float Vel;
    public AudioSource gunSound;

    public GameObject Centre;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        pellets = new List<Quaternion>(pelletCount);

        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            fire();
            fire2();


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void fire()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            pellets[i] = Random.rotation;
            GameObject pellet = Instantiate(projectile, BarrelExit.position, BarrelExit.transform.rotation);
            RaycastHit hit;
            if (Physics.Raycast(Centre.transform.position, Centre.transform.forward, out hit, Mathf.Infinity))
            {
                pellet.transform.LookAt(hit.point);
            }
            pellet.transform.rotation = Quaternion.RotateTowards(pellet.transform.rotation, pellets[i], spreadAngle);
            Debug.Log(pellet.transform.forward * Vel);
            pellet.GetComponent<Rigidbody>().AddForce(pellet.transform.forward * Vel);
            gunSound.Play();
            

            i++;
        }
    }

    void fire2()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            new WaitForSeconds(1000f);
            pellets[i] = Random.rotation;
            GameObject pellet = Instantiate(projectile, BarrelExit2.position, BarrelExit2.transform.rotation);
            RaycastHit hit;
            if (Physics.Raycast(Centre.transform.position, Centre.transform.forward, out hit, Mathf.Infinity))
            {
                pellet.transform.LookAt(hit.point);
            }
            pellet.transform.rotation = Quaternion.RotateTowards(pellet.transform.rotation, pellets[i], spreadAngle);
            Debug.Log(pellet.transform.forward * Vel);
            pellet.GetComponent<Rigidbody>().AddForce(pellet.transform.forward * Vel);
            gunSound.Play();

            i++;
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}