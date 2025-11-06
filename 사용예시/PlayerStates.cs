using UnityEngine;

public class Idle : IState
{
    public void Enter() => Debug.Log("Enter Idle");
    public void Update() => Debug.Log("Update Idle");
    public void Exit() => Debug.Log("Exit Idle");
}

public class Move : IState
{
    public void Enter() => Debug.Log("Enter Move");
    public void Update() => Debug.Log("Update Move");
    public void Exit() => Debug.Log("Exit Move");
}

public class Jump : IState
{
    public void Enter() => Debug.Log("Enter Jump");
    public void Update() => Debug.Log("Update Jump");
    public void Exit() => Debug.Log("Exit Jump");
}
