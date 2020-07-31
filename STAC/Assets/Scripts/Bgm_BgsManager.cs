using UnityEngine;
using UnityEngine.UI;

public class Bgm_BgsManager : MonoBehaviour
{
    public Slider bgm, se;
    void Start()
    {
        bgm.value = SoundMgr.instance.savedBgm;
        se.value = SoundMgr.instance.savedSE;
    }

    public void onBgmChange()
    {
        SoundMgr.instance.bgmValue(bgm.value);
        FindObjectOfType<BGM>().GetComponent<AudioSource>().volume = bgm.value;
    }

    public void onBgsChange()
    {
        SoundMgr.instance.seValue(se.value);
    }
}
