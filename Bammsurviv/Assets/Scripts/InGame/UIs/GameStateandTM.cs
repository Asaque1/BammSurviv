using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameStateandTM : MonoBehaviour
{

    public enum playState
    {
        onPlaying,
        onGamePaused,
        onGameOver,
        onGameClear,
    }
    [Header("timeM")]
    [SerializeField] public float playSec = 0f;
    [SerializeField] public TMPro.TextMeshProUGUI timeText;

    [Header("playState")]
    [SerializeField] playState nowPlayState = playState.onPlaying;

    [Header("onGOver")]
    [SerializeField] public GameObject gameOverUI;

    [Header("onGClear")]
    [SerializeField] public GameObject gameClearUI;

    private void Start()
    {
        playSec = 0f;
        nowPlayState = playState.onPlaying;
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playSec += Time.fixedDeltaTime;
        timeText.text = $"{Mathf.FloorToInt(playSec/60)}:{Mathf.FloorToInt(playSec % 60):D2}" ;
        if (nowPlayState == playState.onPlaying) Time.timeScale = 1f;
        else Time.timeScale = 0f;


        if (playSec >= 600f) GameClear();
    }

    public void WhenPlayerDie()
    {
        nowPlayState = playState.onGameOver;
        gameOverUI.SetActive(true);
    }
    public void OnPauseStart()
    {
        nowPlayState = playState.onGamePaused;
    }
    public void OnPauseEnd()
    {
        nowPlayState = playState.onPlaying;
        Time.timeScale = 1f;
    }

    void GameClear()
    {
        nowPlayState = playState.onGameClear;
        gameClearUI.SetActive(true);
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
