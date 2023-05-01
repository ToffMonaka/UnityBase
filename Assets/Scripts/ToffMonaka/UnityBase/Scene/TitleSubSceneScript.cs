/**
 * @file
 * @brief TitleSubSceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief TitleSubSceneScriptクラス
 */
public class TitleSubSceneScript : ToffMonaka.Lib.Scene.SubSceneScript
{
    /**
     * @brief コンストラクタ
     */
    public TitleSubSceneScript()
    {
        this.SetScriptType((int)ToffMonaka.UnityBase.Constant.Util.SCRIPT_TYPE.TITLE_SUB_SCENE);

        return;
    }

    /**
     * @brief _OnActivate関数
     */
    protected override void _OnActivate()
    {
        return;
    }

    /**
     * @brief _OnDeactivate関数
     */
    protected override void _OnDeactivate()
    {
        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        return;
    }

    /**
     * @brief OnStartButtonPointerClickEvent関数
     */
    public void OnStartButtonPointerClickEvent()
    {
        var scene_script = (ToffMonaka.Lib.Scene.SceneScript)this.GetHolder().Get((int)ToffMonaka.UnityBase.Constant.Util.SCRIPT_TYPE.PLAY_SCENE);

        scene_script.ChangeSubScene("Assets/Resources2/prefab/SelectSubScene.prefab");

        return;
    }
}
}
