using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TubeStart : Interactable
{
    private bool grabbed = false;

    private void Start() {
        Init(IntType.TUBE_START);
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
            ScenarioManager.Instance.currentOperationType == OperationType.CLOSE_PROBE) {
            FindObjectOfType<Probe>().SetDefault();
            grabbed = true;
            SetSelect();

            Sequence s = DOTween.Sequence();
            s.Append(transform.DOMove(FindObjectOfType<Probe>().transform.position + Vector3.up * .15f, .8f));
            s.Append(transform.DOLocalRotate(new Vector3(-180f, 0f, 0f), .8f));
            s.AppendCallback(delegate {
                transform.SetParent(FindObjectOfType<Probe>().transform, true);
                GameEvents.Instance.ProbeClosed();
            });
        }
    }
}
