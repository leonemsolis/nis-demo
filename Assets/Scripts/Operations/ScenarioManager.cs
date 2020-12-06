using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public enum OperationStatus {ACTIVE, COMPLETED, FAILED, AWAIT};
public enum OperationType   {   NONE,
                                GRAB_CONTAINER, 
                                FILL_PROBE, 
                                CLOSE_PROBE, 
                                PLACE_PROBE,
                                PLACE_TUBE_TO_FLASK,
                                FIRE_UP_TORCH,
                                HEAT_UP_POWDER,
                                FIRE_UP_STICK,
                                CHECK_OXYGEN 
                            };

public class Operation
{
    public string name;
    public OperationStatus status;

    public OperationType type;

    private Action completeAction;    
    private Action failAction;

    public Operation(string name, OperationType type) {
        this.name = name;
        this.type = type;
        this.status = OperationStatus.AWAIT;
        Subscribe();
    }

    private void Subscribe() {
        switch(type) {
            case OperationType.GRAB_CONTAINER:
                GameEvents.Instance.onContainerSelected += OnCompleted;
                break;
            case OperationType.FILL_PROBE:
                GameEvents.Instance.onProbeFilled += OnCompleted;
                break;
            case OperationType.CLOSE_PROBE:
                GameEvents.Instance.onProbeClosed += OnCompleted;
                break;
            case OperationType.PLACE_PROBE:
                GameEvents.Instance.onProbeBinded += OnCompleted;
                break;
            case OperationType.PLACE_TUBE_TO_FLASK:
                GameEvents.Instance.onFlaskClosed += OnCompleted;
                break;
            case OperationType.FIRE_UP_TORCH:
                GameEvents.Instance.onTorchFired += OnCompleted;
                break;
            case OperationType.HEAT_UP_POWDER:
                GameEvents.Instance.onHeatPowder += OnCompleted;
                break;
            case OperationType.FIRE_UP_STICK:
                GameEvents.Instance.onStickFired += OnCompleted;
                break;
            case OperationType.CHECK_OXYGEN:
                GameEvents.Instance.onOxygenChecked += OnCompleted;
                break;
        }
    }

    private void Desubscribe() {
        switch(type) {
            case OperationType.GRAB_CONTAINER:
                GameEvents.Instance.onContainerSelected -= OnCompleted;
                break;
            case OperationType.FILL_PROBE:
                GameEvents.Instance.onProbeFilled -= OnCompleted;
                break;
            case OperationType.CLOSE_PROBE:
                GameEvents.Instance.onProbeClosed -= OnCompleted;
                break;
            case OperationType.PLACE_PROBE:
                GameEvents.Instance.onProbeBinded -= OnCompleted;
                break;
            case OperationType.PLACE_TUBE_TO_FLASK:
                GameEvents.Instance.onFlaskClosed -= OnCompleted;
                break;
            case OperationType.FIRE_UP_TORCH:
                GameEvents.Instance.onTorchFired -= OnCompleted;
                break;
            case OperationType.HEAT_UP_POWDER:
                GameEvents.Instance.onHeatPowder -= OnCompleted;
                break;
            case OperationType.FIRE_UP_STICK:
                GameEvents.Instance.onStickFired -= OnCompleted;
                break;
            case OperationType.CHECK_OXYGEN:
                GameEvents.Instance.onOxygenChecked -= OnCompleted;
                break;
        }
    }

    private void OnCompleted() {
        if(status == OperationStatus.ACTIVE) {
            status = OperationStatus.COMPLETED;
            Desubscribe();
            GameEvents.Instance.OperationCompleted(this);
        }
    }  

    private void OnFailed() {
        if(status == OperationStatus.ACTIVE) {
            status = OperationStatus.FAILED;
            Desubscribe();
            GameEvents.Instance.OperationFailed(this);
        }
    }
}

public class ScenarioManager : MonoBehaviour
{
    public List<Operation> operations;
    public static ScenarioManager Instance;
    [SerializeField] private GameObject HintArrow;

    private OperationsController operationsController;
    public OperationType currentOperationType;

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

        operations.Add(new Operation("Взять контейнер с KMnO4", OperationType.GRAB_CONTAINER));
        operations[0].status = OperationStatus.ACTIVE;
        MoveHintArrow(operations[0].type);
        currentOperationType = operations[0].type;

        operations.Add(new Operation("Насыпать KMnO4 в пробирку", OperationType.FILL_PROBE));
        
        operations.Add(new Operation("Закрыть пробирку трубкой", OperationType.CLOSE_PROBE));
        operations.Add(new Operation("Закрепить пробирку горизонтально", OperationType.PLACE_PROBE));
        operations.Add(new Operation("Положить второй конец трубки в колбу", OperationType.PLACE_TUBE_TO_FLASK));
        operations.Add(new Operation("Зажечь горелку", OperationType.FIRE_UP_TORCH));
        operations.Add(new Operation("Нагреть KMnO4", OperationType.HEAT_UP_POWDER));
        operations.Add(new Operation("Поджечь палочку", OperationType.FIRE_UP_STICK));
        operations.Add(new Operation("Проверить кислород вспыхиванием палочки", OperationType.CHECK_OXYGEN));

        operationsController = FindObjectOfType<OperationsController>();
        operationsController.InitializeList(operations);
    }

    public void Restart() {
        SceneManager.LoadScene("Lab");
    }

    public void ExitApplication() {
        Application.Quit();
    }

    private void MoveHintArrow(OperationType type) {
        HintArrow.SetActive(true);
        switch(type) {
            case OperationType.GRAB_CONTAINER:
                HintArrow.transform.position = FindObjectOfType<Container>().transform.position + Vector3.up * .2f;
                break;
            case OperationType.FILL_PROBE:
                HintArrow.transform.position = FindObjectOfType<Probe>().transform.position + Vector3.up * .3f;
                break;
            case OperationType.CLOSE_PROBE:
                HintArrow.transform.position = FindObjectOfType<TubeStart>().transform.position + Vector3.up * .2f;
                break;
            case OperationType.PLACE_PROBE:
                HintArrow.transform.position = FindObjectOfType<Bind>().transform.position + Vector3.up * .2f;
                break;
            case OperationType.PLACE_TUBE_TO_FLASK:
                HintArrow.transform.position = FindObjectOfType<TubeEnd>().transform.position + Vector3.up * .2f;
                break;
            case OperationType.FIRE_UP_TORCH:
                HintArrow.transform.position = FindObjectOfType<Torch>().transform.position + Vector3.up * .2f;
                break;
            case OperationType.HEAT_UP_POWDER:
                HideArrow();
                break;
            case OperationType.FIRE_UP_STICK:
                HintArrow.transform.position = FindObjectOfType<Stick>().transform.position + Vector3.up * .2f;
                break;
            case OperationType.CHECK_OXYGEN:
                HintArrow.transform.position = FindObjectOfType<Flask>().transform.position + Vector3.up * .2f;
                break;
            case OperationType.NONE:
                HideArrow();
                break;
        }
    }

    public void HideArrow() {
        HintArrow.SetActive(false);
    }

    private void OnOperationCompleted(Operation op) {
        print("OPERATION SUCCEED, "+op.name);

        bool allOpearationCompleted = true;
        currentOperationType = OperationType.NONE;
        foreach(Operation o in operations) {
            if(o.status == OperationStatus.AWAIT) {
                o.status = OperationStatus.ACTIVE;
                currentOperationType = o.type;
                MoveHintArrow(o.type);
                allOpearationCompleted = false;
                break;
            }
        }

        operationsController.UpdateList(operations);

        if(allOpearationCompleted) {
            StartCoroutine(ShowOverlay());
        }
    }

    public IEnumerator ShowOverlay() {
        yield return new WaitForSeconds(3f);
        float alpha = 0f;
        CanvasGroup group = FindObjectOfType<CanvasGroup>();
        while(alpha < 1f) {
            alpha += .1f;
            group.alpha = alpha;
            yield return new WaitForSeconds(.1f);
        }
        group.interactable = true;
    }

    private void OnOperationFailed(Operation op) {
        operationsController.UpdateList(operations);
        print("GAME OVER");
    }

    private void OnDisable() {
        GameEvents.Instance.onOperationCompleted -= OnOperationCompleted;
        GameEvents.Instance.onOperationFailed -= OnOperationFailed;
    }
    
}
