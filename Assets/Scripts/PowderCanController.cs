using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderCanController : MonoBehaviour
{
    private Renderer rend;
    private bool selected = false;

    private void Start() {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseDown() {
        selected = !selected;
        if(selected) {
            rend.material = MaterialManager.Instance.glassSelected;
            GameEvents.Instance.PowderCanSelected(1, 2, 3);
        } else {
            rend.material = MaterialManager.Instance.glassHighlight;
        }
    }

    private void OnMouseEnter() {
        if(!selected) {
            rend.material = MaterialManager.Instance.glassHighlight; 
        }
    }

    private void OnMouseExit() {
        if(!selected) {
            rend.material = MaterialManager.Instance.glass;
        } else {
            rend.material = MaterialManager.Instance.glassSelected;
        }
    }
}
