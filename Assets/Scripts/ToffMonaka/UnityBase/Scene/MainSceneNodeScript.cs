/**
 * @file
 * @brief MainSceneNodeScriptファイル
 */

using UnityEngine;
using ToffMonaka.UnityBase.Data;
using ToffMonaka.UnityBase.Input;
using ToffMonaka.UnityBase.Graphic;
using ToffMonaka.UnityBase.Sound;

namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief MainSceneNodeScriptCreateDescクラス
 */
public class MainSceneNodeScriptCreateDesc : ToffMonaka.Tml.Scene.MainSceneNodeScriptCreateDesc
{
}

/**
 * @brief MainSceneNodeScriptクラス
 */
public class MainSceneNodeScript : ToffMonaka.Tml.Scene.MainSceneNodeScript
{
    public new UnityBase.Scene.MainSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.MAIN_SCENE_NODE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        base._OnDestroy();

        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        if (base._OnCreate() < 0) {
            return (-1);
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
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
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        this._UpdateDataFile();

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        base._OnOpen();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

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
            var script = SceneUtil.GetManager().ChangeSubScene(Util.FILE_PATH.INIT_SUB_SCENE_PREFAB) as UnityBase.Scene.InitSubSceneNodeScript;
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
            DataUtil.systemConfigFile.readDesc.data.filePath = Application.persistentDataPath + "/" + Util.FILE_PATH.SYSTEM_CONFIG;
            DataUtil.systemConfigFile.writeDesc.data.filePath = DataUtil.systemConfigFile.readDesc.data.filePath;

            if (ToffMonaka.Tml.FileUtil.IsExistFile(DataUtil.systemConfigFile.readDesc.data.filePath)) {
                DataUtil.systemConfigFile.Read();
            } else {
                DataUtil.systemConfigFile.Write();
            }
        }

        {// UserDataFile Create
            DataUtil.userDataFile.readDesc.data.filePath = Application.persistentDataPath + "/" + Util.FILE_PATH.USER_DATA;
            DataUtil.userDataFile.writeDesc.data.filePath = DataUtil.userDataFile.readDesc.data.filePath;

            if (ToffMonaka.Tml.FileUtil.IsExistFile(DataUtil.userDataFile.readDesc.data.filePath)) {
                DataUtil.userDataFile.Read();
            } else {
                DataUtil.userDataFile.Write();
            }
        }

        return;
    }

    /**
     * @brief _EndDataFile関数
     */
    private void _EndDataFile()
    {
        if (DataUtil.systemConfigFile.GetDeleteFlag()) {
            DataUtil.systemConfigFile.Delete();
        }

        if (DataUtil.userDataFile.GetDeleteFlag()) {
            DataUtil.userDataFile.Delete();
        }

        if (DataUtil.systemConfigFile.GetWriteFlag()) {
            DataUtil.systemConfigFile.Write();
        }

        if (DataUtil.userDataFile.GetWriteFlag()) {
            DataUtil.userDataFile.Write();
        }

        return;
    }

    /**
     * @brief _UpdateDataFile関数
     */
    private void _UpdateDataFile()
    {
        if (DataUtil.systemConfigFile.GetWriteFlag()) {
            DataUtil.systemConfigFile.Write();
        }

        if (DataUtil.userDataFile.GetWriteFlag()) {
            DataUtil.userDataFile.Write();
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
            var manager = new ToffMonaka.Tml.Input.InputManager();
            var manager_create_desc = new ToffMonaka.Tml.Input.InputManagerCreateDesc();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            InputUtil.SetManager(manager);
        }

        {// GraphicManager Create
            var manager = new ToffMonaka.Tml.Graphic.GraphicManager();
            var manager_create_desc = new ToffMonaka.Tml.Graphic.GraphicManagerCreateDesc();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            GraphicUtil.SetManager(manager);
        }

        {// SoundManager Create
            var manager = new ToffMonaka.Tml.Sound.SoundManager();
            var manager_create_desc = new ToffMonaka.Tml.Sound.SoundManagerCreateDesc();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            SoundUtil.SetManager(manager);
        }

        {// SceneManager Create
            var manager = new ToffMonaka.Tml.Scene.SceneManager();
            var manager_create_desc = new ToffMonaka.Tml.Scene.SceneManagerCreateDesc();

            manager_create_desc.mainSceneNode = this.gameObject;
            manager_create_desc.inputNode = this.GetInputNode();
            manager_create_desc.graphicNode = this.GetGraphicNode();
            manager_create_desc.soundNode = this.GetSoundNode();
            manager_create_desc.soundBgmPrefabFilePath = Util.FILE_PATH.SOUND_BGM_PREFAB;
            manager_create_desc.soundBgmAudioClipArray = this.GetSoundBgmAudioClipArray();
            manager_create_desc.soundBgmVolume = DataUtil.systemConfigFile.data.soundBgmVolume;
            manager_create_desc.soundBgmMuteFlag = DataUtil.systemConfigFile.data.soundBgmMuteFlag;
            manager_create_desc.soundSePrefabFilePath = Util.FILE_PATH.SOUND_SE_PREFAB;
            manager_create_desc.soundSeAudioClipArray = this.GetSoundSeAudioClipArray();
            manager_create_desc.soundSeVolume = DataUtil.systemConfigFile.data.soundSeVolume;
            manager_create_desc.soundSeMuteFlag = DataUtil.systemConfigFile.data.soundSeMuteFlag;
            manager_create_desc.scriptCount = (int)SceneUtil.SCRIPT_INDEX_COUNT;

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            SceneUtil.SetManager(manager);
        }

        return (0);
    }

    /**
     * @brief _ReleaseManager関数
     */
    private void _ReleaseManager()
    {
        SceneUtil.SetManager(null);
        SoundUtil.SetManager(null);
        GraphicUtil.SetManager(null);
        InputUtil.SetManager(null);

        return;
    }
}
}
}
