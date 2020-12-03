using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTubeController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("ENTER");
    }
}
