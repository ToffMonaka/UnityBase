/**
 * @file
 * @brief PlaySceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief PlaySceneScriptクラス
 */
public class PlaySceneScript : ToffMonaka.Lib.Scene.SceneScript
{
    /**
     * @brief コンストラクタ
     */
    public PlaySceneScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.PLAY_SCENE);

        return;
    }

    /**
     * @brief _OnActivate関数
     */
    protected override void _OnActivate()
    {
        this.Create(new ToffMonaka.Lib.Scene.ScriptHolder((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX_COUNT));
        this.ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TITLE_SUB_SCENE_PREFAB);

        return;
    }

    /**
     * @brief _OnDeactivate関数
     */
    protected override void _OnDeactivate()
    {
        this.Delete();

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
}
}
