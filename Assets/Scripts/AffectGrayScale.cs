using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AffectGrayScale : MonoBehaviour
{
    public Toggle toggle;

    GrayScale gs;

    public bool isDead = false;
    public float speed = 2f;

    void Start()
    {
        Volume vol = GetComponent<Volume>();

        GrayScale temp;

        if (vol.profile.TryGet<GrayScale>(out temp))
        {
            gs = temp;
        }

        toggle.onValueChanged.AddListener(OnClickToggle);
    }

    private void OnClickToggle(bool isOn)
    {
        isDead = isOn;
    }

    void Update()
    {
        if (gs == null) return;

        if(isDead && gs.blend.value != 1)
        {
            if (gs.blend.value >= 0.99f)
                gs.blend.value = 1f;
            else
                gs.blend.value = Mathf.Lerp(gs.blend.value, 1, Time.deltaTime * speed);
        }
        else if(!isDead && gs.blend.value !=0)
        {
            if (gs.blend.value <= 0.01)
                gs.blend.value = 0f;
            else
                gs.blend.value = Mathf.Lerp(gs.blend.value, 0, Time.deltaTime * speed);
        }
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnClickToggle);
    }
}
