/**
 * @file
 * @brief MainSceneNodeScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief MainSceneNodeScriptCreateDescクラス
 */
public class MainSceneNodeScriptCreateDesc : Lib.Scene.MainSceneNodeScriptCreateDesc
{
}

/**
 * @brief MainSceneNodeScriptクラス
 */
public class MainSceneNodeScript : Lib.Scene.MainSceneNodeScript
{
    public new UnityBase.Scene.MainSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.MAIN_SCENE_NODE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.MainSceneNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.MainSceneNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
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
        this._UpdateDataFile();

        return;
    }

    /**
     * @brief _OnStartApplication関数
     */
    protected override void _OnStartApplication()
    {
        this._StartDataFile();

        this._CreateManager();

        {// MainSceneNodeScript Create
            var script = this;
            var script_create_desc = new UnityBase.Scene.MainSceneNodeScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);
        }
        
        {// InitSubSceneNodeScript Create
            var script = UnityBase.Global.GetSceneManager().ChangeSubScene(UnityBase.Util.FILE_PATH.INIT_SUB_SCENE_PREFAB) as UnityBase.Scene.InitSubSceneNodeScript;
            var script_create_desc = new UnityBase.Scene.InitSubSceneNodeScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);
        }

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

        this._EndDataFile();

        return;
    }

    /**
     * @brief _StartDataFile関数
     */
    private void _StartDataFile()
    {
        {// SystemConfigFile Create
            UnityBase.Global.systemConfigFile.readDesc.data.filePath = Application.persistentDataPath + "/" + UnityBase.Util.FILE_PATH.SYSTEM_CONFIG;
            UnityBase.Global.systemConfigFile.writeDesc.data.filePath = UnityBase.Global.systemConfigFile.readDesc.data.filePath;

            if (Lib.Data.Util.IsExistFile(UnityBase.Global.systemConfigFile.readDesc.data.filePath)) {
                UnityBase.Global.systemConfigFile.Read();
            } else {
                UnityBase.Global.systemConfigFile.Write();
            }
        }

        {// UserDataFile Create
            UnityBase.Global.userDataFile.readDesc.data.filePath = Application.persistentDataPath + "/" + UnityBase.Util.FILE_PATH.USER_DATA;
            UnityBase.Global.userDataFile.writeDesc.data.filePath = UnityBase.Global.userDataFile.readDesc.data.filePath;

            if (Lib.Data.Util.IsExistFile(UnityBase.Global.userDataFile.readDesc.data.filePath)) {
                UnityBase.Global.userDataFile.Read();
            } else {
                UnityBase.Global.userDataFile.Write();
            }
        }

        return;
    }

    /**
     * @brief _EndDataFile関数
     */
    private void _EndDataFile()
    {
        if (UnityBase.Global.systemConfigFile.GetDeleteFlag()) {
            UnityBase.Global.systemConfigFile.Delete();
        }

        if (UnityBase.Global.userDataFile.GetDeleteFlag()) {
            UnityBase.Global.userDataFile.Delete();
        }

        if (UnityBase.Global.systemConfigFile.GetWriteFlag()) {
            UnityBase.Global.systemConfigFile.Write();
        }

        if (UnityBase.Global.userDataFile.GetWriteFlag()) {
            UnityBase.Global.userDataFile.Write();
        }

        return;
    }

    /**
     * @brief _UpdateDataFile関数
     */
    private void _UpdateDataFile()
    {
        if (UnityBase.Global.systemConfigFile.GetWriteFlag()) {
            UnityBase.Global.systemConfigFile.Write();
        }

        if (UnityBase.Global.userDataFile.GetWriteFlag()) {
            UnityBase.Global.userDataFile.Write();
        }

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

            UnityBase.Global.SetInputManager(manager);
        }

        {// GraphicManager Create
            var manager = new Lib.Graphic.Manager();
            var manager_create_desc = new Lib.Graphic.ManagerCreateDesc();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            UnityBase.Global.SetGraphicManager(manager);
        }

        {// SoundManager Create
            var manager = new Lib.Sound.Manager();
            var manager_create_desc = new Lib.Sound.ManagerCreateDesc();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            UnityBase.Global.SetSoundManager(manager);
        }

        {// SceneManager Create
            var manager = new Lib.Scene.Manager();
            var manager_create_desc = new Lib.Scene.ManagerCreateDesc();

            manager_create_desc.mainSceneNode = this.gameObject;
            manager_create_desc.inputNode = this.GetInputNode();
            manager_create_desc.graphicNode = this.GetGraphicNode();
            manager_create_desc.soundNode = this.GetSoundNode();
            manager_create_desc.soundBgmPrefabFilePath = UnityBase.Util.FILE_PATH.SOUND_BGM_PREFAB;
            manager_create_desc.soundBgmAudioClipArray = this.GetSoundBgmAudioClipArray();
            manager_create_desc.soundBgmVolume = UnityBase.Global.systemConfigFile.data.soundBgmVolume;
            manager_create_desc.soundBgmMuteFlag = UnityBase.Global.systemConfigFile.data.soundBgmMuteFlag;
            manager_create_desc.soundSePrefabFilePath = UnityBase.Util.FILE_PATH.SOUND_SE_PREFAB;
            manager_create_desc.soundSeAudioClipArray = this.GetSoundSeAudioClipArray();
            manager_create_desc.soundSeVolume = UnityBase.Global.systemConfigFile.data.soundSeVolume;
            manager_create_desc.soundSeMuteFlag = UnityBase.Global.systemConfigFile.data.soundSeMuteFlag;
            manager_create_desc.scriptCount = (int)UnityBase.Util.SCENE.SCRIPT_INDEX_COUNT;

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            UnityBase.Global.SetSceneManager(manager);
        }

        return (0);
    }

    /**
     * @brief _ReleaseManager関数
     */
    private void _ReleaseManager()
    {
        UnityBase.Global.SetSceneManager(null);
        UnityBase.Global.SetSoundManager(null);
        UnityBase.Global.SetGraphicManager(null);
        UnityBase.Global.SetInputManager(null);

        return;
    }
}
}
}
