using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class OperationsController : MonoBehaviour
{
    [SerializeField] private OperationDisplay opDisplayPrefab;

    private List<OperationDisplay> operations;

    public void InitializeList(List<Operation> ops) {
        operations = new List<OperationDisplay>();

        foreach(Operation op in ops) {
            OperationDisplay od = Instantiate(opDisplayPrefab);
            od.transform.SetParent(transform, false);
            od.Refresh(op);

            operations.Add(od);
        }
    }

    public void UpdateList(List<Operation> ops) {
        for(int i = 0; i < operations.Count; ++i) {
            if(operations[i].Refresh(ops[i])) {
                if(operations.Count * 100f > 900f + GetComponent<RectTransform>().anchoredPosition.y) {
                    //auto scroll up 
                }
            }
        }
    }

}
