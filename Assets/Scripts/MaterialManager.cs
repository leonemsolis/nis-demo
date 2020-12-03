using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Material glass;
    public Material glassHighlight;

    public static MaterialManager Instance{set; get;}

    private void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            glass = Resources.Load<Material>("Glass");
            glassHighlight = Resources.Load<Material>("GlassHighlight");
            print(glass);
            print(glassHighlight);

        } else {
            Destroy(gameObject);
        }
    }
}
