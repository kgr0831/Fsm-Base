using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;


public class FsmBase : MonoBehaviour
{
    public string currentName;
    IState current;
    List<Transition> transitions = new();

    public void Set(IState next)
    {
        current?.Exit();
        current = next;
        currentName = next.GetType().Name;
        current.Enter();
    }

    public void Add(IState from, IState to, Func<bool> condition)
    {
        transitions.Add(new Transition { from = from, to = to, condition = condition });
    }

    public bool Is(IState state) => current == state;
    public bool Is<T>() where T : IState => current is T;

    void Update()
    {
        var t = transitions.FirstOrDefault(x => x.from == current && x.Can());
        if (t != null) Set(t.to);
        current?.Update();
    }
}


public interface IState
{
    void Enter();
    void Update();
    void Exit();
}

public class Transition
{
    public IState from;
    public IState to;
    public Func<bool> condition;
    public bool Can() => condition?.Invoke() ?? false;
}
