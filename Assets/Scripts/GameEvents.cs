using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    
    private void Awake() {
        if(!Instance) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public event Action<int, int, int> onPowderCanSelected;
    // public event Action


    public void PowderCanSelected(int a, int b, int c) {
        if(onPowderCanSelected != null) {
            onPowderCanSelected(a, b, c);
        }
    }
}
