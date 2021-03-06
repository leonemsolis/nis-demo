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

    public event Action onContainerSelected;
    public void ContainerSelected() {
        if(onContainerSelected != null) {
            onContainerSelected();
        }
    }

    public event Action onProbeFilled;
    public void ProbeFilled() {
        if(onProbeFilled != null) {
            onProbeFilled();
        }
    }

    public event Action onProbeClosed;
    public void ProbeClosed() {
        if(onProbeClosed != null) {
            onProbeClosed();
        }
    }

    public event Action onProbeBinded;
    public void ProbeBinded() {
        if(onProbeBinded != null) {
            onProbeBinded();
        }
    }

    public event Action onFlaskClosed;
    public void FlaskClosed() {
        if(onFlaskClosed != null) {
            onFlaskClosed();
        }
    }

    public event Action onTorchFired;
    public void TorchFired() {
        if(onTorchFired != null) {
            onTorchFired();
        }
    }

    public event Action onHeatPowder;
    public void HeatPowder() {
        if(onHeatPowder != null) {
            onHeatPowder();
        }
    }

    public event Action onStickFired;
    public void StickFired() {
        if(onStickFired != null) {
            onStickFired();
        }
    }

    public event Action onOxygenChecked;
    public void OxygenChecked() {
        if(onOxygenChecked != null) {
            onOxygenChecked();
        }
    }
}
