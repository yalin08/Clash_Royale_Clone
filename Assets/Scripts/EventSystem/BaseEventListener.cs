using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public abstract class BaseEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T>
      where E : BaseEvent<T> where UER : UnityEvent<T>
{
    [Tooltip("Event to register with.")]
    [SerializeField]
    private E gameEvent;

    private E GameEvent
    {
        get => gameEvent;
        set => gameEvent = value;
    }

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    private UER unityEventResponse;

    private void OnEnable()
    {
        if (gameEvent == null)
        {
            return;
        }

        GameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        if (gameEvent == null)
        {
            return;
        }

        GameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(T item)
    {
        unityEventResponse?.Invoke(item);
    }
}
