public class LifecycleEventHandler {
    
    private readonly List<Action<float>> _fixedUpdateSubscribers = new(128);
    private readonly List<Action<float>> _updateSubscribers = new(128);

    public void OnUpdate(float deltaTime) {
        foreach(var listener in _updateSubscribers) {
            listener.Invoke(deltaTime);
        }
    }

    public void OnFixedUpdate(float deltaTime) {
        foreach(var listener in _fixedUpdateSubscribers) {
            listener.Invoke(deltaTime);
        }
    }

    public void RegisterFixedUpdateListener(Action<float> listenerFunc) {
        _fixedUpdateSubscribers.Add(listenerFunc);
    }

    public void RegisterUpdateListener(Action<float> listenerFunc) {
        _updateSubscribers.Add(listenerFunc);
    }

    public void UnregisterFixedUpdateListener(Action<float> listenerFunc) {
        _fixedUpdateSubscribers.Remove(listenerFunc);
    }

    public void UnregisterUpdateListener(Action<float> listenerFunc) {
        _updateSubscribers.Remove(listenerFunc);
    }
}