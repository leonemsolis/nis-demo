using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TubeEnd : Interactable
{
    private void Start() {
        Init(IntType.TUBE_END);
    }

    private void OnMouseDown() {
        if(!activated &&
            ScenarioManager.Instance.currentOperationType == OperationType.PLACE_TUBE_TO_FLASK) {
            ScenarioManager.Instance.HideArrow();
            FindObjectOfType<Bind>().SetDefault();
            activated = true;
            SetSelect();

            Sequence s = DOTween.Sequence();
            s.Append(transform.DOMove(FindObjectOfType<Flask>().transform.position + Vector3.up * .4f, .8f));
            s.Append(transform.DOLocalRotate(new Vector3(0f, 0f, 0f), .8f));
            s.AppendCallback(delegate {
                transform.SetParent(FindObjectOfType<Flask>().transform, true);
                GameEvents.Instance.FlaskClosed();
            });
        }
    }
}
