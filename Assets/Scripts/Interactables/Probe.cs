using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Probe : Interactable
{
    private void Start() {
        Init(IntType.PROBE);
    }

    private void OnMouseDown() {
        if(!activated && 
            ScenarioManager.Instance.currentOperationType == OperationType.FILL_PROBE) {
            ScenarioManager.Instance.HideArrow();
            activated = true;
            transform.DOMove(transform.position + Vector3.up * .12f, .3f);
            transform.DORotate(Vector3.zero, .3f);
            
            FindObjectOfType<Container>().Fill(transform.position);
            SetSelect();
        }
    }

    public void BindToStand(Vector3 position) {
        SetDefault();
        FindObjectOfType<ProgressBar>().Set(13f);
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOLocalRotate(new Vector3(-90f, 0f, 0f), 4f));
        s.Append(transform.DOMove(position + Vector3.forward * .05f, 9f));
        // s.Append(transform.DOLocalRotate(new Vector3(-90f, 0f, 0f), 1f));
        // s.Append(transform.DOMove(position + Vector3.forward * .05f, 1f));
        s.AppendCallback(delegate {
            GameEvents.Instance.ProbeBinded();
            FindObjectOfType<Bind>().SetDefault();
        });
    }
}