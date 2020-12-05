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
            ScenarioManager.Instance.HideArrow();
            grabbed = true;
            SetSelect();
            FindObjectOfType<TubeStart>().SetDefault();
            FindObjectOfType<Probe>().BindToStand(transform.position);
        }
    }
}
