using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static MaterialManager Instance;
    public Material glass, tube, bind, torch;
    public Material highlight, selected;


    private void Awake() {
        if(!Instance) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            LoadMaterials();
        } else {
            Destroy(gameObject);
        }
    }

    private void LoadMaterials() {
        glass = Resources.Load<Material>("Glass");
        tube = Resources.Load<Material>("Tube");
        bind = Resources.Load<Material>("Bind");
        torch = Resources.Load<Material>("Torch");
        highlight = Resources.Load<Material>("Highlight");
        selected = Resources.Load<Material>("Selected");
    }
}
