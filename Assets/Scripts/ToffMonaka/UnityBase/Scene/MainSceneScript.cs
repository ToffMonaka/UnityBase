﻿/**
 * @file
 * @brief MainSceneScriptファイル
 */


using UnityEngine;
using System;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MainSceneScriptCreateDescクラス
 */
public class MainSceneScriptCreateDesc : ToffMonaka.Lib.Scene.MainSceneScriptCreateDesc
{
}

/**
 * @brief MainSceneScriptクラス
 */
public class MainSceneScript : ToffMonaka.Lib.Scene.MainSceneScript
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
        {// MainSceneScript Create
            var script = this;
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MainSceneScriptCreateDesc();

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
        {// InitSubSceneScript Create
            var script = this.GetManager().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.INIT_SUB_SCENE_PREFAB) as ToffMonaka.UnityBase.Scene.InitSubSceneScript;
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
     * @brief _OnStartApplication関数
     */
    protected override void _OnStartApplication()
    {
        ToffMonaka.UnityBase.Global.languageType = ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE.ENGLISH;
        ToffMonaka.UnityBase.Global.soundBgmVolume = 1.0f;
        ToffMonaka.UnityBase.Global.soundBgmMuteFlag = false;
        ToffMonaka.UnityBase.Global.soundSeVolume = 1.0f;
        ToffMonaka.UnityBase.Global.soundSeMuteFlag = false;

        this._CreateManager();

        {// Test
            var csv_file = new ToffMonaka.Lib.File.CsvFile();

            /*
            csv_file.data.valueArray = new string[][]{
                new string[]{"11", "0", "0"},
                new string[]{"21", "22", "0"},
                new string[]{"31", "32", "33"},
                new string[]{"41", "42", "43", "44"}
            };

            csv_file.writeDesc.data.filePath = "test.txt";

            csv_file.Write();
            */

            csv_file.readDesc.data.filePath = "test.txt";

            csv_file.Read();

            Debug.Log("a1=" + csv_file.data.GetRowCount());
            Debug.Log("a2=" + csv_file.data.GetColumnCount());

            int a = 0;
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

            manager_create_desc.mainSceneNode = this.gameObject;
            manager_create_desc.scriptCount = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX_COUNT;

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            ToffMonaka.Lib.Scene.Util.SetManager(manager);
        }

        {// SceneInputManager Create
            var manager = new ToffMonaka.Lib.Scene.InputManager();
            var manager_create_desc = new ToffMonaka.Lib.Scene.InputManagerCreateDesc();

            manager_create_desc.inputNode = this.GetInputNode();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            ToffMonaka.Lib.Scene.Util.SetInputManager(manager);
        }

        {// SceneGraphicManager Create
            var manager = new ToffMonaka.Lib.Scene.GraphicManager();
            var manager_create_desc = new ToffMonaka.Lib.Scene.GraphicManagerCreateDesc();

            manager_create_desc.graphicNode = this.GetGraphicNode();

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            ToffMonaka.Lib.Scene.Util.SetGraphicManager(manager);
        }

        {// SceneSoundManager Create
            var manager = new ToffMonaka.Lib.Scene.SoundManager();
            var manager_create_desc = new ToffMonaka.Lib.Scene.SoundManagerCreateDesc();

            manager_create_desc.soundNode = this.GetSoundNode();
            manager_create_desc.bgmNode = this.GetSoundBgmNode();
            manager_create_desc.bgmAudioClipArray = this.GetSoundBgmAudioClipArray();
            manager_create_desc.seNode = this.GetSoundSeNode();
            manager_create_desc.seAudioClipArray = this.GetSoundSeAudioClipArray();
            manager_create_desc.bgmVolume = ToffMonaka.UnityBase.Global.soundBgmVolume;
            manager_create_desc.bgmMuteFlag = ToffMonaka.UnityBase.Global.soundBgmMuteFlag;
            manager_create_desc.seVolume = ToffMonaka.UnityBase.Global.soundSeVolume;
            manager_create_desc.seMuteFlag = ToffMonaka.UnityBase.Global.soundSeMuteFlag;

            if (manager.Create(manager_create_desc) < 0) {
                this._ReleaseManager();

                return (-1);
            }

            ToffMonaka.Lib.Scene.Util.SetSoundManager(manager);
        }

        return (0);
    }

    /**
     * @brief _ReleaseManager関数
     */
    private void _ReleaseManager()
    {
        ToffMonaka.Lib.Scene.Util.SetSoundManager(null);
        ToffMonaka.Lib.Scene.Util.SetGraphicManager(null);
        ToffMonaka.Lib.Scene.Util.SetInputManager(null);
        ToffMonaka.Lib.Scene.Util.SetManager(null);
        ToffMonaka.Lib.Sound.Util.SetManager(null);
        ToffMonaka.Lib.Graphic.Util.SetManager(null);
        ToffMonaka.Lib.Input.Util.SetManager(null);

        return;
    }
}
}
