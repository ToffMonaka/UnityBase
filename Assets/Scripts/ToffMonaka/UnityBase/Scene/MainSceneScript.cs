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
        this._CreateManager();

        {// MainScene Create
            var create_desc = new ToffMonaka.UnityBase.Scene.MainSceneScriptCreateDesc();

            this.Create(create_desc);
        }

        return;
    }

    /**
     * @brief _OnRelease関数
     */
    protected override void _OnRelease()
    {
        this._ReleaseManager();

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
        {// InitSubScene Create
            var script = this.GetManager().GetSceneScript().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.INIT_SUB_SCENE_PREFAB) as ToffMonaka.UnityBase.Scene.InitSubSceneScript;
            var script_create_desc = new ToffMonaka.UnityBase.Scene.InitSubSceneScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);
        }

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

    /**
     * @brief _CreateManager関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    private int _CreateManager()
    {
        this._ReleaseManager();

        {// InputManager Create
            var manager = new ToffMonaka.Lib.Input.Manager();
            var manager_create_desc = new ToffMonaka.Lib.Input.ManagerCreateDesc();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            ToffMonaka.Lib.Input.Util.SetManager(manager);
        }

        {// GraphicManager Create
            var manager = new ToffMonaka.Lib.Graphic.Manager();
            var manager_create_desc = new ToffMonaka.Lib.Graphic.ManagerCreateDesc();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            ToffMonaka.Lib.Graphic.Util.SetManager(manager);
        }

        {// SoundManager Create
            var manager = new ToffMonaka.Lib.Sound.Manager();
            var manager_create_desc = new ToffMonaka.Lib.Sound.ManagerCreateDesc();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            ToffMonaka.Lib.Sound.Util.SetManager(manager);
        }

        {// SceneManager Create
            var manager = new ToffMonaka.Lib.Scene.Manager();
            var manager_create_desc = new ToffMonaka.Lib.Scene.ManagerCreateDesc();

            manager_create_desc.scriptCount = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX_COUNT;

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            ToffMonaka.Lib.Scene.Util.SetManager(manager);
        }

        return (0);
    }

    /**
     * @brief _ReleaseManager関数
     */
    private void _ReleaseManager()
    {
        ToffMonaka.Lib.Scene.Util.SetManager(null);
        ToffMonaka.Lib.Sound.Util.SetManager(null);
        ToffMonaka.Lib.Graphic.Util.SetManager(null);
        ToffMonaka.Lib.Input.Util.SetManager(null);

        return;
    }
}
}
