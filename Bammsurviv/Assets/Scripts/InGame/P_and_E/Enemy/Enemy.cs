using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamagable
{
    public Transform player_Transform;
    public float ms;
    public UnityEvent ontouched;
    public int damage;
    public int maxHp;
    public float nowHp;

    public float attackCool;
    public float nowattackCool;
    public bool canAttack;

    void Start()
    {
        player_Transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        nowHp = maxHp;
    }

    public void Init(int getMHP, int getDMG, float getMS)
    {
        ms = getMS;
        damage = getDMG;
        maxHp = getMHP;
        nowHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (nowattackCool > 0 && !canAttack)
        {
            nowattackCool -= Time.deltaTime;
        }
        else
        {
            canAttack = true;
            nowattackCool = attackCool;

        }

        if (player_Transform == null)
            return;

        MoveToPlayer();

        if (nowHp <= 0)
            Die();
    }
    public void GetDamage(float gethurt)
    {
        nowHp -= gethurt;
    }
    public void MoveToPlayer()
    {
        Vector2 dir = player_Transform.position - transform.position;
        dir = dir.normalized;
        if (dir.x > 0)
        {
            // 오른쪽으로 이동
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dir.x < 0)
        {
            // 왼쪽으로 이동
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += (Vector3)(dir * ms * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ontouched.Invoke();
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            if (canAttack)
            {
                canAttack = false;
                damagable.GetDamage(damage);
            }

        }
    }


    public GameObject explosion;
    public void Call_Explosion()
    {
        Instantiate(explosion,this.gameObject.transform.position,this.gameObject.transform.rotation);
        Die();
    }
    public void Die()
    {
        Animator animator = this.gameObject.GetComponent<Animator>();
        animator.SetTrigger("Die");
        Destroy(this.gameObject);
    }

}
