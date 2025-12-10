using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("joystick and moveSpeed")]
    [SerializeField] VariableJoystick joystick;
    [SerializeField] float speed;

    Rigidbody2D rigid;
    Animator anim;
    Vector2 moveVec;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rigid.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        this.transform.rotation = Quaternion.identity;
        float x = joystick.Horizontal;
        float y = joystick.Vertical;
        moveVec = new Vector2(x, y) * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
        if (moveVec.sqrMagnitude == 0)
            return;
    }
}
