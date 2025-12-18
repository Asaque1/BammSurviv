using UnityEngine;

public class Player_Support_anims : MonoBehaviour
{
    [SerializeField] public Animator anims;

    public static Player_Support_anims Instance { get; private set; }

    private void Awake()
    {
        // 이미 인스턴스가 존재하는데
        if (Instance != null && Instance != this)
        {
            // 중복 생성된 오브젝트면 제거
            Destroy(gameObject);
            return;
        }

        // 최초 생성된 객체를 싱글톤으로 등록
        Instance = this;
    }

    public void onLevelUp()
    {
        anims.SetTrigger("LevelUp");
    }

    public void onHeal()
    {
        anims.SetTrigger("Heal");
    }
}
