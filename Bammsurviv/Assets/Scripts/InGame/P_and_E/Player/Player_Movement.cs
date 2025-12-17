using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("joystick and moveSpeed")]
    [SerializeField] VariableJoystick joystick;
    [SerializeField] public Player_StatData pData;
    [SerializeField] float speed;

    Rigidbody2D rigid;
    public Animator anim;
    Vector2 moveVec;
    private void Start()
    {
        speed = pData.player_BaseStat.MS;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rigid.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        speed = pData.player_finalStat.MS;
        this.transform.rotation = Quaternion.identity;
        float x = joystick.Horizontal;

        if (x > 0)
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        else if(x<0)
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("IsStopped", true);
        float y = joystick.Vertical;
        moveVec = new Vector2(x, y) * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
        if (moveVec.sqrMagnitude == 0)
            anim.SetBool("IsStopped",false);
            return;
    }
}
