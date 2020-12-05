using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IntType {CONTAINER, PROBE, FLASK, TUBE_START, TUBE_END, BIND, TORCH};
public enum IntState {DEFAULT, HIGHLIGHT, SELECT};

public class Interactable : MonoBehaviour
{
    protected IntType type;
    protected IntState state;
    protected new Renderer renderer;
    protected Material defaultMaterial;

    protected void Init(IntType type) {
        renderer = GetComponent<Renderer>();
        this.type = type;
        // Set default material
        switch(type) {
            case IntType.CONTAINER:
            case IntType.PROBE:
            case IntType.FLASK:
                defaultMaterial = MaterialManager.Instance.glass;
                break;
            case IntType.TUBE_START:
            case IntType.TUBE_END:
                defaultMaterial = MaterialManager.Instance.tube;
                break;
            case IntType.BIND:
                defaultMaterial = MaterialManager.Instance.bind;
                break;
            case IntType.TORCH:
                defaultMaterial = MaterialManager.Instance.torch;
                break;
        }   
    }

    protected void SetType(IntType type) {
        this.type = type;
    }
    
    public void SetDefault() {
        state = IntState.DEFAULT;
        renderer.material = defaultMaterial;
    }

    protected void SetHighlight() {
        state = IntState.HIGHLIGHT;
        renderer.material = MaterialManager.Instance.highlight;
    }

    protected void SetSelect() {
        state = IntState.SELECT;
        renderer.material = MaterialManager.Instance.selected;
    }

    public virtual void Action(){}
}
