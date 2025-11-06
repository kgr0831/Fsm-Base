using UnityEngine;

public class PlayerFSM : FsmBase
{
    Idle idle = new();
    Move move = new();
    Jump jump = new();

    void Start()
    {
        Set(idle);

        Add(idle, move, () => Input.GetKey(KeyCode.W));
        Add(move, idle, () => !Input.GetKey(KeyCode.W));
        Add(move, jump, () => Input.GetKeyDown(KeyCode.Space));
        Add(jump, idle, () => !Input.GetKey(KeyCode.Space));
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), "현재 상태: " + currentName);
    }
}
