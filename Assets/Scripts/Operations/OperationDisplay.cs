using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OperationDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image backgroud, badge;
    [SerializeField] private Sprite awaitBG, activeBG;
    [SerializeField] private Sprite awaitBadge, activeBadge, completeBadge, failBadge;

    // Returns true if current op is active
    public bool Refresh(Operation operation) {
        title.SetText(operation.name);
        switch(operation.status) {
            case OperationStatus.AWAIT:
                backgroud.sprite = awaitBG;
                badge.sprite = awaitBadge;
                return false;
            case OperationStatus.ACTIVE:
                backgroud.sprite = activeBG;
                badge.sprite = activeBadge;
                return true;
            case OperationStatus.COMPLETED:
                backgroud.sprite = activeBG;
                badge.sprite = completeBadge;
                return false;
            case OperationStatus.FAILED:
                backgroud.sprite = activeBG;
                badge.sprite = failBadge;
                return false;
        }
        return false;
    }
}
