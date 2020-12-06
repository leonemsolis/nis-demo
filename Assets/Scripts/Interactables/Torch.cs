using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Torch : Interactable
{
    private void Start() {
        Init(IntType.TORCH);
    }

    private void OnMouseDown() {
        if(!activated &&
            ScenarioManager.Instance.currentOperationType == OperationType.FIRE_UP_TORCH) {
            activated = true;
            SetSelect();
            FindObjectOfType<TubeEnd>().SetDefault();
            ScenarioManager.Instance.HideArrow();

            transform.GetChild(0).gameObject.SetActive(true);

            GameEvents.Instance.TorchFired();

            StartCoroutine(HeatPowder());
        }
    }

    private IEnumerator HeatPowder() {
        FindObjectOfType<ProgressBar>().Set(4f);
        yield return new WaitForSeconds(4f);
        SetDefault();
        GameEvents.Instance.HeatPowder();
    }
}
