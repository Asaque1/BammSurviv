using UnityEngine;

public class weapon_Granade_ball : MonoBehaviour
{
    public Transform playerTransform; // 시작 위치
    public Transform target;   // 도착 위치
    public float jumpHeight = 2f; // 최대 높이
    public float jumpTime = 1f; // 점프하는 데 걸리는 시간
    public GameObject Boom;

    private bool isJumping = false;
    private float elapsedTime = 0f;
    float damage;
    bool isUlti;

    public void Init(float getting_Damage, bool gisUlti)
    {
        damage = getting_Damage;
        isUlti = gisUlti;
    }

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        target = enemyTracks.Instance.nearestEnemy;
    }
    public void Jump()
    {
        isJumping = true;
        elapsedTime = 0f;
    }

    void Update()
    {
        if (isJumping)
        {
            elapsedTime += Time.deltaTime;

            // 수평 위치 계산
            Vector3 horizontalPosition = Vector3.Lerp(playerTransform.position, target.position, elapsedTime / jumpTime);

            // 수직 위치 계산 (포물선 공식)
            float verticalPosition = jumpHeight * 4 * (elapsedTime / jumpTime) * (1 - elapsedTime / jumpTime);

            // 최종 위치 적용
            transform.position = new Vector3(horizontalPosition.x, playerTransform.position.y + verticalPosition, horizontalPosition.z);

            // 점프 완료
            if (elapsedTime >= jumpTime)
            {
                isJumping = false;
                GameObject explo;
                explo = Instantiate(Boom,this.transform.position, Quaternion.identity);

                weapon_Granade_attack attack_data = explo.GetComponent<weapon_Granade_attack>();
                attack_data.Init(damage,isUlti);
                Destroy(this.gameObject);
            }
        }
    }
}
