using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Events/Game Event")]
public class GameEvent : BaseEvent<Void>
{
    public void Raise() => Raise(new Void());
}
