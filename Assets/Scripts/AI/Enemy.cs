using UnityEngine;

public class Enemy : Essence
{
    private Transform _player;
    public LayerMask Player;

    [SerializeField] private float _sightRange;
    private bool _playerInSightRange;

    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackCooldown;
    private bool _isAttacking = false;
    private bool _playerInAttackRange = false;
    

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, Player);
        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, Player);

        LookAtPlayer();

        if (_playerInAttackRange && _playerInSightRange) AttackPlayer();
    }

    private void LookAtPlayer()
    {
        if (_playerInSightRange)
        {
            transform.LookAt(_player);
        }
    }

    private void AttackPlayer()
    {
        transform.LookAt(_player);

        if (!_isAttacking)
        {
            Shoot();

            _isAttacking = true;
            Invoke(nameof(ResetAttack), _attackCooldown);
        }
    }

    private void ResetAttack()
    {
        _isAttacking = false;
    }

    public override void Shoot()
    {
        Weapon.Shoot(transform.position, transform.forward);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
    }
}
