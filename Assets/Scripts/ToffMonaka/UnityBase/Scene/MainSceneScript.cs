/**
 * @file
 * @brief MainSceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MainSceneScriptクラス
 */
public class MainSceneScript : ToffMonaka.Lib.Scene.SceneScript
{
    /**
     * @brief コンストラクタ
     */
    public MainSceneScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MAIN_SCENE);

        return;
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        this.Create(new ToffMonaka.Lib.Scene.ScriptHolder((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX_COUNT));

        return;
    }

    /**
     * @brief _OnRelease関数
     */
    protected override void _OnRelease()
    {
        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        return (0);
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        this.GetHolder().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.INIT_SUB_SCENE_PREFAB);

        var sub_scene_script = this.GetHolder().GetSubSceneScript() as ToffMonaka.UnityBase.Scene.InitSubSceneScript;

        sub_scene_script.Open();

        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
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
