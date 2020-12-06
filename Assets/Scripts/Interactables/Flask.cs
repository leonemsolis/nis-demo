using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : Interactable
{
    private void Start() {
        Init(IntType.FLASK);
    }

    private void OnMouseDown() {
        if(!activated
            && ScenarioManager.Instance.currentOperationType == OperationType.CHECK_OXYGEN) {
            activated = true;
            SetSelect();
            ScenarioManager.Instance.HideArrow();

            FindObjectOfType<Stick>().CheckOxygen(transform.position);
        }
    }
}
