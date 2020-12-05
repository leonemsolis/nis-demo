using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Operation
{
    public enum OpeartionType {GRAB_CONTAINER};
    private OpeartionType type;
    public string name;
    public bool completed = false;
    public bool failed = false;

    private Action completeAction;    
    private Action failAction;

    public Operation(string name, OpeartionType type) {
        this.name = name;
        this.type = type;
        Subscribe();
    }

    private void Subscribe() {
        switch(type) {
            case OpeartionType.GRAB_CONTAINER:
                GameEvents.Instance.onContainerSelected += OnCompleted;
                break;
        }
    }

    private void Desubscribe() {
        switch(type) {
            case OpeartionType.GRAB_CONTAINER:
                GameEvents.Instance.onContainerSelected -= OnCompleted;
                break;
        }
    }

    private void OnCompleted() {
        if(!failed) {
            completed = true;
            Desubscribe();
            GameEvents.Instance.OperationCompleted(this);
        }
    }  

    private void OnFailed() {
        failed = true;
        completed = false;
        Desubscribe();
        GameEvents.Instance.OperationFailed(this);
    }
}

public class ScenarioManager : MonoBehaviour
{
    public List<Operation>operations;

    public static ScenarioManager Instance;
    private void Awake() {
        if(!Instance) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            Initialize();
        } else {
            Destroy(gameObject);
        }
    }

    private void Initialize() {
        GameEvents.Instance.onOperationCompleted += OnOperationCompleted;
        GameEvents.Instance.onOperationFailed += OnOperationFailed;

        operations = new List<Operation>();
        operations.Add(new Operation("Взять колбу с KMnO4", Operation.OpeartionType.GRAB_CONTAINER));
    }

    private void OnOperationCompleted(Operation op) {
        print("OPERATION SUCCEED, "+op.name);
    }

    private void OnOperationFailed(Operation op) {
        print("GAME OVER");
    }

    private void OnDisable() {
        // GameEvents.Instance.onOperationCompleted -= OnOperationCompleted;
        GameEvents.Instance.onOperationFailed -= OnOperationFailed;
    }
    
}
