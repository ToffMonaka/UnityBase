/**
 * @file
 * @brief SelectSubSceneStageItemScriptファイル
 */


using UnityEngine;
using TMPro;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief SelectSubSceneStageItemScriptクラス
 */
public class SelectSubSceneStageItemScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text = null;
    [SerializeField] private AudioSource _audioSource = null;

    private ToffMonaka.UnityBase.Scene.SelectSubSceneScript _selectSubSceneScript = null;
    private int _index = 0;

    /**
     * @brief Set関数
     * @param select_sub_scene_script (select_sub_scene_script)
     * @param index (index)
     * @param name (name)
     */
    public void Set(ToffMonaka.UnityBase.Scene.SelectSubSceneScript select_sub_scene_script, int index, string name)
    {
        this._selectSubSceneScript = select_sub_scene_script;
        this._index = index;
        this._text.SetText(name);

        return;
    }

    /**
     * @brief OnPointerClickEvent関数
     */
    public void OnPointerClickEvent()
    {
        this._audioSource.PlayOneShot(this._audioSource.clip);

        this._selectSubSceneScript.SetStageItemSelectIndex(this._index);

        this._selectSubSceneScript.Close(1);

        return;
    }
}
}
