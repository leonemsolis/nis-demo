using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Bottle
{
    private bool selected = false;

    new protected void Start() {
        base.Start();
        SetType(BottleType.CONTAINER);
    }

    private void OnMouseDown() {
        selected = !selected;
        if(selected) {
            GameEvents.Instance.ContainerSelected();
            SetSelect();
        } else {
            SetDefault();
        }
    }
}
