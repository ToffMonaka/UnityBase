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
        this.SetScriptType((int)ToffMonaka.UnityBase.Constant.Util.SCRIPT_TYPE.PLAY_SCENE);

        return;
    }

    /**
     * @brief _OnActivate関数
     */
    protected override void _OnActivate()
    {
        this.Create(new ToffMonaka.Lib.Scene.ScriptHolder((int)ToffMonaka.UnityBase.Constant.Util.SCRIPT_TYPE_COUNT), "Assets/Resources2/prefab/TitleSubScene.prefab");

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
}
}
