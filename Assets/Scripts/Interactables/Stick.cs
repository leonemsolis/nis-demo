using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stick : Interactable
{
    private void Start() {
        Init(IntType.STICK);
    }

    private void OnMouseDown() {
        if(!activated
            && ScenarioManager.Instance.currentOperationType == OperationType.FIRE_UP_STICK) {
            activated = true;
            SetSelect();
            ScenarioManager.Instance.HideArrow();

            FindObjectOfType<ProgressBar>().Set(3f);

            Sequence s = DOTween.Sequence();
            s.Append(transform.DOMove(
                FindObjectOfType<Torch>().transform.position + new Vector3(.2f, .2f, -.03f),
                .8f));
            s.Append(transform.DOLocalRotate(new Vector3(-30f, 101.6f, 0f), .8f));
            s.AppendInterval(1f);
            s.AppendCallback(delegate {
                transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                activated = false;
                SetDefault();
                GameEvents.Instance.StickFired();
            });
        }
    }

    public void CheckOxygen(Vector3 position) {
        Sequence s = DOTween.Sequence();
        FindObjectOfType<ProgressBar>().Set(3f);
        s.Append(transform.DOMove(position + new Vector3(.07f, .5f, 0f), .8f));
        s.Append(transform.DOLocalRotate(new Vector3(-70f, 101.6f, 0f), .8f));
        s.AppendInterval(1f);
        s.AppendCallback(delegate {
            transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            StartCoroutine(Sparks());
            FindObjectOfType<Flask>().SetDefault();
            GameEvents.Instance.OxygenChecked();
        });
    }

    private IEnumerator Sparks() {
        yield return new WaitForSeconds(1f);
        transform.GetChild(0).GetChild(1).GetComponent<ParticleSystem>().Play();
        StartCoroutine(Sparks());
    }
}
