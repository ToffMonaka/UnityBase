/**
 * @file
 * @brief MainSceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief MainSceneScriptCreateDescクラス
 */
public class MainSceneScriptCreateDesc : Lib.Scene.MainSceneScriptCreateDesc
{
}

/**
 * @brief MainSceneScriptクラス
 */
public class MainSceneScript : Lib.Scene.MainSceneScript
{
    public new UnityBase.Scene.MainSceneScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public MainSceneScript()
    {
        this._SetScriptIndex((int)UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MAIN_SCENE);

        return;
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        {// MainSceneScript Create
            var script = this;
            var script_create_desc = new UnityBase.Scene.MainSceneScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);
        }

        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.MainSceneScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        {// InitSubSceneScript Create
            var script = this.GetManager().ChangeSubScene(UnityBase.Constant.Util.FILE_PATH.INIT_SUB_SCENE_PREFAB) as UnityBase.Scene.InitSubSceneScript;
            var script_create_desc = new UnityBase.Scene.InitSubSceneScriptCreateDesc();

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
     * @brief _OnStartApplication関数
     */
    protected override void _OnStartApplication()
    {
        {// SystemConfigFile Create
            UnityBase.Global.systemConfigFile.readDesc.data.filePath = Application.persistentDataPath + "/" + UnityBase.Constant.Util.FILE_PATH.SYSTEM_CONFIG;
            UnityBase.Global.systemConfigFile.writeDesc.data.filePath = Application.persistentDataPath + "/" + UnityBase.Constant.Util.FILE_PATH.SYSTEM_CONFIG;

            if (Lib.Data.Util.IsExistFile(UnityBase.Global.systemConfigFile.readDesc.data.filePath)) {
                UnityBase.Global.systemConfigFile.Read();
            } else {
                UnityBase.Global.systemConfigFile.Write();
            }
        }

        this._CreateManager();

        {// Test
        }

        return;
    }

    /**
     * @brief _OnEndApplication関数
     */
    protected override void _OnEndApplication()
    {
        this._ReleaseManager();

        return;
    }

    /**
     * @brief _CreateManager関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    private int _CreateManager()
    {
        this._ReleaseManager();

        {// InputManager Create
            var manager = new Lib.Input.Manager();
            var manager_create_desc = new Lib.Input.ManagerCreateDesc();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            Lib.Input.Util.SetManager(manager);
        }

        {// GraphicManager Create
            var manager = new Lib.Graphic.Manager();
            var manager_create_desc = new Lib.Graphic.ManagerCreateDesc();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            Lib.Graphic.Util.SetManager(manager);
        }

        {// SoundManager Create
            var manager = new Lib.Sound.Manager();
            var manager_create_desc = new Lib.Sound.ManagerCreateDesc();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            Lib.Sound.Util.SetManager(manager);
        }

        {// SceneManager Create
            var manager = new Lib.Scene.Manager();
            var manager_create_desc = new Lib.Scene.ManagerCreateDesc();

            manager_create_desc.mainSceneNode = this.gameObject;
            manager_create_desc.scriptCount = (int)UnityBase.Constant.Util.SCENE.SCRIPT_INDEX_COUNT;

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            Lib.Scene.Util.SetManager(manager);
        }

        {// SceneInputManager Create
            var manager = new Lib.Scene.InputManager();
            var manager_create_desc = new Lib.Scene.InputManagerCreateDesc();

            manager_create_desc.inputNode = this.GetInputNode();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            Lib.Scene.Util.SetInputManager(manager);
        }

        {// SceneGraphicManager Create
            var manager = new Lib.Scene.GraphicManager();
            var manager_create_desc = new Lib.Scene.GraphicManagerCreateDesc();

            manager_create_desc.graphicNode = this.GetGraphicNode();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            Lib.Scene.Util.SetGraphicManager(manager);
        }

        {// SceneSoundManager Create
            var manager = new Lib.Scene.SoundManager();
            var manager_create_desc = new Lib.Scene.SoundManagerCreateDesc();

            manager_create_desc.soundNode = this.GetSoundNode();
            manager_create_desc.bgmNode = this.GetSoundBgmNode();
            manager_create_desc.bgmAudioClipArray = this.GetSoundBgmAudioClipArray();
            manager_create_desc.seNode = this.GetSoundSeNode();
            manager_create_desc.seAudioClipArray = this.GetSoundSeAudioClipArray();
            manager_create_desc.bgmVolume = UnityBase.Global.systemConfigFile.data.soundBgmVolume;
            manager_create_desc.bgmMuteFlag = UnityBase.Global.systemConfigFile.data.soundBgmMuteFlag;
            manager_create_desc.seVolume = UnityBase.Global.systemConfigFile.data.soundSeVolume;
            manager_create_desc.seMuteFlag = UnityBase.Global.systemConfigFile.data.soundSeMuteFlag;

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            Lib.Scene.Util.SetSoundManager(manager);
        }

        return (0);
    }

    /**
     * @brief _ReleaseManager関数
     */
    private void _ReleaseManager()
    {
        Lib.Scene.Util.SetSoundManager(null);
        Lib.Scene.Util.SetGraphicManager(null);
        Lib.Scene.Util.SetInputManager(null);
        Lib.Scene.Util.SetManager(null);
        Lib.Sound.Util.SetManager(null);
        Lib.Graphic.Util.SetManager(null);
        Lib.Input.Util.SetManager(null);

        return;
    }
}
}
}
