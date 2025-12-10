using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VariableJoystick : Joystick
{
    [Header("Joystick Settings")]
    [SerializeField] private float moveThreshold = 1f;
    [SerializeField] private JoystickType joystickType = JoystickType.Fixed;

    [Header("Keyboard Input")]
    [SerializeField] private bool enableKeyboard = true;

    private Vector2 fixedPosition = Vector2.zero;
    private Vector2 keyboardInput = Vector2.zero;

    public float MoveThreshold
    {
        get => moveThreshold;
        set => moveThreshold = Mathf.Abs(value);
    }

    protected override void Start()
    {
        base.Start();
        fixedPosition = background.anchoredPosition;
        SetMode(joystickType);
    }

    private void Update()
    {
        // 키보드 입력 읽기
        ReadKeyboard();

        // 키보드가 활성화되어 있고 입력이 있다면 조이스틱 입력을 덮어씌움
        if (enableKeyboard && keyboardInput != Vector2.zero)
        {
            input = keyboardInput;
            UpdateHandleVisual(input);
        }
        else if (enableKeyboard && keyboardInput == Vector2.zero && !IsTouchActive())
        {
            // 키보드 입력도 없고 터치 입력도 없으면 input을 리셋
            input = Vector2.zero;
            UpdateHandleVisual(Vector2.zero);
        }
    }

    private void ReadKeyboard()
    {
        if (!enableKeyboard)
        {
            keyboardInput = Vector2.zero;
            return;
        }

        float x = 0f, y = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) x = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) x = 1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) y = 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) y = -1f;

        keyboardInput = new Vector2(x, y).normalized;
    }

    private bool IsTouchActive()
    {
        // 간단하게 터치나 마우스 드래그 중인지 체크
        return Input.GetMouseButton(0) || (Input.touchCount > 0);
    }

    private void UpdateHandleVisual(Vector2 value)
    {
        Vector2 radius = background.sizeDelta / 2;
        handle.anchoredPosition = value * radius * handleRange;
    }

    public void SetMode(JoystickType type)
    {
        joystickType = type;
        if (type == JoystickType.Fixed)
        {
            background.anchoredPosition = fixedPosition;
            background.gameObject.SetActive(true);
        }
        else
        {
            background.gameObject.SetActive(false);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (joystickType != JoystickType.Fixed)
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
        }
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (joystickType != JoystickType.Fixed)
            background.gameObject.SetActive(false);

        base.OnPointerUp(eventData);

        // 터치 입력이 끝났으므로 input 초기화
        input = Vector2.zero;
        UpdateHandleVisual(Vector2.zero);
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (joystickType == JoystickType.Dynamic && magnitude > moveThreshold)
        {
            Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
            background.anchoredPosition += difference;
        }
        base.HandleInput(magnitude, normalised, radius, cam);
    }
}

public enum JoystickType { Fixed, Floating, Dynamic }
