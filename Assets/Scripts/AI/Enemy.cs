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

    

    private int _animIdDying;
    private int _animIdHit;
    

    private void Awake()
    {
        _player = GameObject.FindWithTag("EnemyTarget").transform;
        _animator = GetComponent<Animator>();
        SetAnimIDs();
    }

    private void Update()
    {
        _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, Player);
        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, Player);

        LookAtPlayer();

        if (_playerInAttackRange && _playerInSightRange) AttackPlayer();
    }

    private void SetAnimIDs()
    {
        _animIdDying = Animator.StringToHash("dying");
        _animIdHit = Animator.StringToHash("hit");
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

    public override void ApplyDamageCallback()
    {
        _animator.SetTrigger(_animIdHit);
    }

    public override void Die()
    {
        _animator.SetTrigger(_animIdDying);

        var collider = GetComponentInChildren<Collider>();
        collider.enabled = false;

        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        Destroy(this);

        DieCallback();
    }

    public override void DieCallback()
    {
        EventManager.OnEnemyKilled.Invoke();
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
