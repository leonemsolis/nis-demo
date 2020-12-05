using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static MaterialManager Instance;
    public Material glass, glassHighlight, glassSelected;


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
        glassHighlight = Resources.Load<Material>("GlassHighlight");
        glassSelected = Resources.Load<Material>("GlassSelected");
    }
}
