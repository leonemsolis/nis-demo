using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Container : Interactable
{
    private bool grabbed = false;

    private void Start() {
        Init(IntType.CONTAINER);
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
            ScenarioManager.Instance.currentOperationType == OperationType.GRAB_CONTAINER) {
            grabbed = true;
            GameEvents.Instance.ContainerSelected();
            SetSelect();
        }
    }

    public void Fill(Vector3 position) {
        SetDefault();
        Sequence s = DOTween.Sequence();
        // s.Append(transform.DOMove(position + Vector3.up * .4f + Vector3.back * .05f, 12f));
        // s.Append(transform.DOLocalRotate(new Vector3(160f, 0f, 0f), 5f));
        s.Append(transform.DOMove(position + Vector3.up * .4f + Vector3.back * .05f, 1f));
        s.Append(transform.DOLocalRotate(new Vector3(160f, 0f, 0f), 1f));
        s.AppendCallback(delegate {
            GameEvents.Instance.ProbeFilled();
        });
        s.Append(transform.DOLocalRotate(transform.eulerAngles, 1f));
        s.Append(transform.DOMove(transform.position, 2f));
    }
}
