using UnityEngine;
using UnityEngine.AI;

public class Enemy : Essence
{
    [SerializeField] private WeaponForEnemy _weapon;

    public Transform player;
    public LayerMask Player;

    public float sightRange;
    public bool playerInSightRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);

        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        if (playerInSightRange)
        {
            transform.LookAt(player);
        }
    }
}
