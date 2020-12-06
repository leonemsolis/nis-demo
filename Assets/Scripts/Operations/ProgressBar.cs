using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProgressBar : MonoBehaviour
{
    private const float WIDTH = 390f;
    private Coroutine current;

    private Image bg, progress;

    private void Start() {
        bg = GetComponent<Image>();
        progress = transform.GetChild(0).GetComponent<Image>();
        Hide();
    }

    private void Hide() {
        bg.enabled = false;
        progress.enabled = false;
    }

    public void Set(float time) {
        bg.enabled = true;
        progress.enabled = true;
        if(current != null) {
            StopCoroutine(current);
        }
        current = StartCoroutine(StartProgress(time));
    }

    private IEnumerator StartProgress(float time) {
        float passed = 0f;
        while(passed < time) {
            passed += .1f;
            yield return new WaitForSeconds(.1f);
            progress.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 
            passed / time * WIDTH);
        }
        Hide();
    }
}
