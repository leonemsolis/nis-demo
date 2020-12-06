using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bind : Interactable
{
    private void Start() {
        Init(IntType.BIND);
    }

    private void OnMouseDown() {
        if(!activated &&
            ScenarioManager.Instance.currentOperationType == OperationType.PLACE_PROBE) {
            ScenarioManager.Instance.HideArrow();
            activated = true;
            SetSelect();
            FindObjectOfType<TubeStart>().SetDefault();
            FindObjectOfType<Probe>().BindToStand(transform.position);
        }
    }
}
