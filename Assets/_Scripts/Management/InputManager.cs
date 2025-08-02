using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    private float getInputMove;
    public float GetInputMove => getInputMove;

    private bool getInputJump;
    public bool GetInputJump => getInputJump;

    private bool getInputPause;
    public bool GetInputPause => getInputPause;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        InputRun();
        InputJump();
        InputPause();
    }
    private void InputRun()
    {
        getInputMove = Input.GetAxis("Horizontal");
    }
    private void InputJump()
    {
        getInputJump = Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow);
    }
    private void InputPause()
    {
        getInputPause = Input.GetKeyDown(KeyCode.Escape);
    }
}
