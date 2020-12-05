using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TubeEnd : Interactable
{
    private bool grabbed = false;

    private void Start() {
        Init(IntType.TUBE_END);
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
            ScenarioManager.Instance.currentOperationType == OperationType.PLACE_TUBE_TO_FLASK) {
            ScenarioManager.Instance.HideArrow();
            FindObjectOfType<Bind>().SetDefault();
            grabbed = true;
            SetSelect();

            Sequence s = DOTween.Sequence();
            s.Append(transform.DOMove(GameObject.Find("Flask").transform.position + Vector3.up * .4f, .8f));
            s.Append(transform.DOLocalRotate(new Vector3(0f, 0f, 0f), .8f));
            s.AppendCallback(delegate {
                transform.SetParent(GameObject.Find("Flask").transform, true);
                GameEvents.Instance.FlaskClosed();
            });
        }
    }
}
