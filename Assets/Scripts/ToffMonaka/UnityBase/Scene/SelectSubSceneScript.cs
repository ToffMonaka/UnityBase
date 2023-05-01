/**
 * @file
 * @brief SelectSubSceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief SelectSubSceneScriptクラス
 */
public class SelectSubSceneScript : ToffMonaka.Lib.Scene.SubSceneScript
{
    /**
     * @brief コンストラクタ
     */
    public SelectSubSceneScript()
    {
        this.SetScriptType((int)ToffMonaka.UnityBase.Constant.Util.SCRIPT_TYPE.SELECT_SUB_SCENE);

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
     * @brief OnTest2DButtonPointerClickEvent関数
     */
    public void OnTest2DButtonPointerClickEvent()
    {
        var scene_script = (ToffMonaka.Lib.Scene.SceneScript)this.GetHolder().Get((int)ToffMonaka.UnityBase.Constant.Util.SCRIPT_TYPE.PLAY_SCENE);

        scene_script.ChangeSubScene("Assets/Resources2/prefab/Test2DSubScene.prefab");

        return;
    }

    /**
     * @brief OnTest3DButtonPointerClickEvent関数
     */
    public void OnTest3DButtonPointerClickEvent()
    {
        var scene_script = (ToffMonaka.Lib.Scene.SceneScript)this.GetHolder().Get((int)ToffMonaka.UnityBase.Constant.Util.SCRIPT_TYPE.PLAY_SCENE);

        scene_script.ChangeSubScene("Assets/Resources2/prefab/Test3DSubScene.prefab");

        return;
    }
}
}
