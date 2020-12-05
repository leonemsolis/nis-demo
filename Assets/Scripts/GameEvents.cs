﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    
    private void Awake() {
        if(!Instance) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public event Action<Operation> onOperationCompleted;
    public void OperationCompleted(Operation op) {
        if(onOperationCompleted != null) {
            onOperationCompleted(op);
        }
    }

    public event Action<Operation> onOperationFailed;
    public void OperationFailed(Operation op) {
        if(onOperationFailed != null) {
            onOperationFailed(op);
        }
    }

    // public event Action<int, int, int> onPowderCanSelected;
    public event Action onContainerSelected;

    public void ContainerSelected() {
        if(onContainerSelected != null) {
            onContainerSelected();
        }
    }

    public Action GetContainerSelectedAction() {
        return onContainerSelected;
    }
}
