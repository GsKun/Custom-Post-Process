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
        if(isDead)
            gs.intensity.value = Mathf.Lerp(gs.intensity.value, 1, Time.deltaTime * speed);
        else
            gs.intensity.value = Mathf.Lerp(gs.intensity.value, 0, Time.deltaTime * speed);
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnClickToggle);
    }
}
