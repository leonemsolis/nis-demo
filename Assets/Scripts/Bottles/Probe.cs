using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Probe : Bottle
{
    private bool filled = false;

    new protected void Start() {
        base.Start();
        SetType(BottleType.PROBE);
    }

    private void OnMouseEnter() {
        if(!filled) {
            SetHighlight();
        }
    }

    private void OnMouseExit() {
        if(!filled) {
            SetDefault();
        }
    }

    private void OnMouseDown() {
        if(!filled) {
            filled = true;
            transform.DOMove(transform.position + Vector3.up * .12f, .3f);
            transform.DORotate(Vector3.zero, .3f);
            
            FindObjectOfType<Container>().Fill(transform.position);
            SetSelect();
        }
    }
}
