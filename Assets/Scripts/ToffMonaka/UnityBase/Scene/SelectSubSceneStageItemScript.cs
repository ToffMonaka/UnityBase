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
        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        this._selectSubSceneScript.SetStageItemSelectIndex(this._index);

        this._selectSubSceneScript.Close(1);

        return;
    }
}
}
