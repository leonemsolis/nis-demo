using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTubeController : MonoBehaviour
{
    private void OnEnable() {
        GameEvents.Instance.onPowderCanSelected += OnTrigger;
    }

    private void OnDisable() {
        GameEvents.Instance.onPowderCanSelected -= OnTrigger;
    }

    private void OnTrigger(int a, int b, int c) {
        GetComponent<Renderer>().material = MaterialManager.Instance.glassSelected;
        Debug.Log("TRIGGER: "+a+", "+b+", "+c);
    }
}
