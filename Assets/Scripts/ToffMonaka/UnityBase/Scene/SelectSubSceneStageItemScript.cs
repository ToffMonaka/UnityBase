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
    [SerializeField] private TextMeshProUGUI _nameText = null;
    [SerializeField] private AudioSource _clickAudioSource = null;

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
        this._nameText.SetText(name);

        return;
    }

    /**
     * @brief OnPointerClickEvent関数
     */
    public void OnPointerClickEvent()
    {
        AudioSource.PlayClipAtPoint(this._clickAudioSource.clip, this._selectSubSceneScript.GetHolder().GetSceneScript().GetMainCamera().gameObject.transform.position);

        this._selectSubSceneScript.SetStageItemSelectIndex(this._index);

        this._selectSubSceneScript.Close();

        return;
    }
}
}
