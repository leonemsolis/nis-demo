using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BottleState {DEFAULT, HIGHLIGHT, SELECT};
public enum BottleType {CONTAINER, PROBE, FLASK};

public class Bottle : MonoBehaviour
{
    protected BottleType type;
    protected BottleState state;
    protected new Renderer renderer;

    protected void Start() {
        renderer = GetComponent<Renderer>();
        SetDefault();
    }

    protected void SetType(BottleType type) {
        this.type = type;
    }
    
    protected void SetDefault() {
        state = BottleState.DEFAULT;
        renderer.material = MaterialManager.Instance.glass;
    }

    protected void SetHighlight() {
        state = BottleState.HIGHLIGHT;
        renderer.material = MaterialManager.Instance.glassHighlight;
    }

    protected void SetSelect() {
        state = BottleState.SELECT;
        renderer.material = MaterialManager.Instance.glassSelected;
    }

    public virtual void Action(){}
}
