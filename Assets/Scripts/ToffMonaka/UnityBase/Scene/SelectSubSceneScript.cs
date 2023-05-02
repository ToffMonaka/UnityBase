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
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.SELECT_SUB_SCENE);

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
     * @brief _OnDelete関数
     */
    protected override void _OnDelete()
    {
        return;
    }

    /**
     * @brief OnTest2DButtonPointerClickEvent関数
     */
    public void OnTest2DButtonPointerClickEvent()
    {
        this.GetHolder().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TEST_2D_SUB_SCENE_PREFAB);

        return;
    }

    /**
     * @brief OnTest3DButtonPointerClickEvent関数
     */
    public void OnTest3DButtonPointerClickEvent()
    {
        this.GetHolder().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TEST_3D_SUB_SCENE_PREFAB);

        return;
    }
}
}
