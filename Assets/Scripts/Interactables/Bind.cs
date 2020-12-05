using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bind : Interactable
{
    private bool grabbed = false;

    private void Start() {
        Init(IntType.BIND);
    }

    private void OnMouseEnter() {
        if(!grabbed) {
            SetHighlight();
        }
    }

    private void OnMouseExit() {
        if(!grabbed) {
            SetDefault();
        }
    }

    private void OnMouseDown() {
        if(!grabbed &&
            ScenarioManager.Instance.currentOperationType == OperationType.PLACE_PROBE) {
            grabbed = true;
            SetSelect();
            FindObjectOfType<Probe>().BindToStand(transform.position);
        }
    }
}
