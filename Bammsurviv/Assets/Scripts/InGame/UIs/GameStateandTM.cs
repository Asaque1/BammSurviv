using UnityEngine;
using UnityEngine.InputSystem;

public class GameStateandTM : MonoBehaviour
{

    public enum playState
    {
        onPlaying,
        onPaused,
        onGameOver,
        onGameClear,
    }
    [Header("timeM")]
    [SerializeField] public float playSec = 0f;
    [SerializeField] public TMPro.TextMeshProUGUI timeText;

    [Header("playState")]
    [SerializeField] playState nowPlayState = playState.onPlaying;
    [SerializeField] float playTimeSpeed;

    [Header("onGPaused")]
    [SerializeField] public GameObject gamePauseUI;

    [Header("onGOver")]
    [SerializeField] public GameObject gameOverUI;

    [Header("onGClear")]
    [SerializeField] public GameObject gameClearUI;

    private void Start()
    {
        playSec = 0f;
        nowPlayState = playState.onPlaying;
        playTimeSpeed = 1f;
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playSec += Time.fixedDeltaTime;
        timeText.text = $"{Mathf.FloorToInt(playSec/60)}:{Mathf.FloorToInt(playSec % 60):D2}" ;
        if (nowPlayState == playState.onPlaying) Time.timeScale = 1f;
        else Time.timeScale = 0f;

        if (Keyboard.current.escapeKey.wasPressedThisFrame) PauseMenuChange(gamePauseUI.activeSelf); //false at first
        if (playSec >= 600f) GameClear();
    }

    void WhenPlayerDie()
    {
        nowPlayState = playState.onGameOver;
        gameOverUI.SetActive(true);
    }

    void PauseMenuChange(bool param) //false at first
    {
        gamePauseUI.SetActive(!param); //true at first
        if (param) nowPlayState = playState.onPlaying;
        else nowPlayState = playState.onPaused;//work at first
    }

    void GameClear()
    {
        gameClearUI.SetActive(true);
    }
}
