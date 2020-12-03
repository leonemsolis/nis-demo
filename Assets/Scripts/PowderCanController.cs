using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowderCanController : MonoBehaviour
{
    private Renderer rend;

    private void Start() {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseDown() {
        transform.position += Vector3.down * .03f;
    }

    private void OnMouseEnter() {
        rend.material = MaterialManager.Instance.glassHighlight; 
    }

    private void OnMouseExit() {
        rend.material = MaterialManager.Instance.glass;
    }
}
