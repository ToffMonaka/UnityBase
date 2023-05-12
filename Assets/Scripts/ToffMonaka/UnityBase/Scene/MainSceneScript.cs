/**
 * @file
 * @brief MainSceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MainSceneScriptCreateDescクラス
 */
public class MainSceneScriptCreateDesc : ToffMonaka.Lib.Scene.SceneScriptCreateDesc
{
}

/**
 * @brief MainSceneScriptクラス
 */
public class MainSceneScript : ToffMonaka.Lib.Scene.SceneScript
{
    public new ToffMonaka.UnityBase.Scene.MainSceneScriptCreateDesc createDesc{get; private set;} = null;

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
        var create_desc = new ToffMonaka.UnityBase.Scene.MainSceneScriptCreateDesc();

        create_desc.holder = new ToffMonaka.Lib.Scene.ScriptHolder((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX_COUNT);

        this.SetCreateDesc(create_desc);
        this.Create();

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
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MainSceneScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        var sub_scene_script = this.GetHolder().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.INIT_SUB_SCENE_PREFAB) as ToffMonaka.UnityBase.Scene.InitSubSceneScript;
        var sub_scene_script_create_desc = new ToffMonaka.UnityBase.Scene.InitSubSceneScriptCreateDesc();

        sub_scene_script_create_desc.holder = this.GetHolder();

        sub_scene_script.Create(sub_scene_script_create_desc);
        sub_scene_script.Open(0);

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
