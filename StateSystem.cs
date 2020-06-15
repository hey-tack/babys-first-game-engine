using System.Collections.Generic;

public class StateSystem {
    Dictionary<string, IGameObject> _stateStore = new Dictionary<string, IGameObject>();
    IGameObject _currentState = null;

    public void Update(double deltaTime) {
        if (_currentState == null) {
            return; // No state, nothing to do.
        }
        _currentState.Update(deltaTime);
    }

    public void Render() {
        if (_currentState == null) {
            return; // No state, nothing to do.
        }
        _currentState.Render();
    }

    public void AddState(string stateId, IGameObject state) {
        System.Diagnostics.Debug.Assert(Exists(stateId) == false);
        _stateStore.Add(stateId, state);
    }

    public void ChangeState(string stateId) {
        System.Diagnostics.Debug.Assert(Exists(stateId) == true); 
        _currentState = _stateStore[stateId];
    }

    public bool Exists(string stateId) {
        return _stateStore.ContainsKey(stateId);
    }
}