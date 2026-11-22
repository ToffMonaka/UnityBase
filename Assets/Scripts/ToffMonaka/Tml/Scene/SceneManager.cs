/**
 * @file
 * @brief SceneManagerファイル
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

namespace ToffMonaka {
namespace Tml.Scene {
/**
 * @brief SceneManagerCreateDescクラス
 */
public class SceneManagerCreateDesc
{
    public GameObject mainSceneNode = null;
    public GameObject inputNode = null;
    public GameObject graphicNode = null;
    public GameObject soundNode = null;
    public string soundBgmPrefabFilePath = "";
    public AudioClip[] soundBgmAudioClipArray = null;
	public float soundBgmVolume = 1.0f;
    public string soundSePrefabFilePath = "";
    public AudioClip[] soundSeAudioClipArray = null;
	public float soundSeVolume = 1.0f;
    public int scriptTypeCount = SceneUtil.SCRIPT_TYPE_COUNT;
    public int scriptSceneTypeCount = SceneUtil.SCRIPT_SCENE_TYPE_COUNT;
    public int scriptNotifyTypeCount = SceneUtil.SCRIPT_NOTIFY_TYPE_COUNT;
}

/**
 * @brief SceneManagerクラス
 */
public class SceneManager
{
    public SceneManagerCreateDesc createDesc{get; private set;} = null;

    private GameObject _mainSceneNode = null;
    private bool _mainSceneStartedFlag = false;
    private bool _mainSceneEndedFlag = false;
    private GameObject _subSceneNode = null;
    private GameObject _inputNode = null;
    private EventSystem _inputEventSystem = null;
    private GameObject _graphicNode = null;
    private GameObject _soundNode = null;
    private string _soundBgmPrefabFilePath = "";
    private System.Tuple<GameObject, SoundBgmNodeScript> _soundBgmNodeScript = null;
    private AudioClip[] _soundBgmAudioClipArray = null;
	private float _soundBgmVolume = 0.5f;
    private string _soundSePrefabFilePath = "";
    private List<System.Tuple<GameObject, SoundSeNodeScript>> _soundSeNodeScriptContainer = new();
    private AudioClip[] _soundSeAudioClipArray = null;
	private float _soundSeVolume = 0.5f;
    private List<Script>[] _scriptArray = null;
    private Script[] _scriptArrayByScriptSceneType = null;
    private List<Script>[] _scriptArrayByScriptNotifyType = null;

    /**
     * @brief コンストラクタ
     */
    public SceneManager()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        SceneUtil.ReleasePrefabNode(ref this._subSceneNode);

        if (this._soundBgmNodeScript != null) {
            var node = this._soundBgmNodeScript.Item1;

            SceneUtil.ReleasePrefabNode(ref node);

            this._soundBgmNodeScript = null;
        }

        foreach (var sound_se_node_script in this._soundSeNodeScriptContainer) {
            var node = sound_se_node_script.Item1;

            SceneUtil.ReleasePrefabNode(ref node);
        }

        this._soundSeNodeScriptContainer.Clear();

        if (this._scriptArray != null) {
            foreach (var script_cont in this._scriptArray) {
                var tmp_script_cont = new List<Script>(script_cont);

                foreach (var tmp_script in tmp_script_cont) {
                    tmp_script.DestroyByManager();
                }

                tmp_script_cont.Clear();
            }

            this._scriptArray = null;
        }

        this._mainSceneStartedFlag = false;
        this._mainSceneEndedFlag = false;
        this._inputNode = null;
        this._inputEventSystem = null;
        this._graphicNode = null;
        this._soundNode = null;
        this._soundBgmPrefabFilePath = "";
        this._soundBgmAudioClipArray = null;
	    this._soundBgmVolume = 0.5f;
        this._soundSePrefabFilePath = "";
        this._soundSeAudioClipArray = null;
	    this._soundSeVolume = 0.5f;
        this._scriptArrayByScriptSceneType = null;
        this._scriptArrayByScriptNotifyType = null;

        return;
    }

    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public virtual int Create(SceneManagerCreateDesc desc = null)
    {
        this.Init();

        {// This Create
            this.SetCreateDesc(desc);

            this._mainSceneNode = desc.mainSceneNode;
            this._inputNode = desc.inputNode;
            this._inputEventSystem = EventSystem.current;
            this._inputEventSystem.enabled = false;
            this._graphicNode= desc.graphicNode;
            this._soundNode = desc.soundNode;
            this._soundBgmPrefabFilePath = desc.soundBgmPrefabFilePath;
            this._soundBgmAudioClipArray = (AudioClip[])this.createDesc.soundBgmAudioClipArray.Clone();
	        this._soundBgmVolume = this.createDesc.soundBgmVolume;
            this._soundSePrefabFilePath = desc.soundSePrefabFilePath;
            this._soundSeAudioClipArray = (AudioClip[])this.createDesc.soundSeAudioClipArray.Clone();
	        this._soundSeVolume = this.createDesc.soundSeVolume;

            this._scriptArray = new List<Script>[this.createDesc.scriptTypeCount];

            for (int script_i = 0; script_i < this._scriptArray.Length; ++script_i) {
                this._scriptArray[script_i] = new List<Script>();
            }

            this._scriptArrayByScriptSceneType = new Script[this.createDesc.scriptSceneTypeCount];

            for (int script_i = 0; script_i < this._scriptArrayByScriptSceneType.Length; ++script_i) {
                this._scriptArrayByScriptSceneType[script_i] = null;
            }

            this._scriptArrayByScriptNotifyType = new List<Script>[this.createDesc.scriptNotifyTypeCount];

            for (int script_i = 0; script_i < this._scriptArrayByScriptNotifyType.Length; ++script_i) {
                this._scriptArrayByScriptNotifyType[script_i] = new List<Script>();
            }
        }

        int create_result_val = this._OnCreate();

        if (create_result_val < 0) {
            this.Init();

            return (create_result_val);
        }

        // SoundBgmNodeScript Create
        if (this._soundBgmNodeScript == null) {
            var node = SceneUtil.GetPrefabNode(this._soundBgmPrefabFilePath, this._soundNode);
            var script = node.GetComponent<SoundBgmNodeScript>();
            var script_create_desc = new SoundBgmNodeScriptCreateDesc();

            script.Create(script_create_desc);

            this._soundBgmNodeScript = new System.Tuple<GameObject, SoundBgmNodeScript>(node, script);
        }

        // SoundSeNodeScript Create
        for (int sound_se_node_script_i = 0; sound_se_node_script_i < 8; ++sound_se_node_script_i) {
            var node = SceneUtil.GetPrefabNode(this._soundSePrefabFilePath, this._soundNode);
            var script = node.GetComponent<SoundSeNodeScript>();
            var script_create_desc = new SoundSeNodeScriptCreateDesc();

            script.Create(script_create_desc);

            this._soundSeNodeScriptContainer.Add(new System.Tuple<GameObject, SoundSeNodeScript>(node, script));
        }

        return (0);
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected virtual int _OnCreate()
    {
        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public virtual void SetCreateDesc(SceneManagerCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new SceneManagerCreateDesc());

            return;
        }

        this.createDesc = create_desc;

        return;
    }

    /**
     * @brief GetMainSceneNode関数
     * @return main_scene_node (main_scene_node)
     */
    public GameObject GetMainSceneNode()
    {
        return (this._mainSceneNode);
    }

    /**
     * @brief StartMainScene関数
     */
    public void StartMainScene()
    {
        if ((this._mainSceneNode == null)
        || (this._mainSceneStartedFlag)
        || (this._mainSceneEndedFlag)) {
            return;
        }

        this._mainSceneStartedFlag = true;

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        return;
    }

    /**
     * @brief EndMainScene関数
     */
    public void EndMainScene()
    {
        if ((this._mainSceneNode == null)
        || (this._mainSceneStartedFlag)
        || (this._mainSceneEndedFlag)) {
            return;
        }

        this._mainSceneEndedFlag = true;

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

        return;
    }

    /**
     * @brief GetSubSceneNode関数
     * @return sub_scene_node (sub_scene_node)
     */
    public GameObject GetSubSceneNode()
    {
        return (this._subSceneNode);
    }

    /**
     * @brief ChangeSubScene関数
     * @param prefab_file_path (prefab_file_path)
     * @return sub_scene_node_script (sub_scene_node_script)<br>
     * null=失敗
     */
    public SubSceneNodeScript ChangeSubScene(string prefab_file_path)
    {
        SceneUtil.ReleasePrefabNode(ref this._subSceneNode);

        if ((this._mainSceneNode == null)
        || (prefab_file_path.Length <= 0)) {
            return (null);
        }

        this._subSceneNode = SceneUtil.GetPrefabNode(prefab_file_path, this._mainSceneNode);

        return (this._subSceneNode.GetComponent<SubSceneNodeScript>());
    }

    /**
     * @brief GetInputNode関数
     * @return input_node (input_node)
     */
    public GameObject GetInputNode()
    {
        return (this._inputNode);
    }

    /**
     * @brief GetInputEventSystem関数
     * @return input_event_sys (input_event_system)
     */
    public EventSystem GetInputEventSystem()
    {
        return (this._inputEventSystem);
    }

    /**
     * @brief EnableInputEventSystem関数
     */
    public void EnableInputEventSystem()
    {
        this._inputEventSystem.enabled = true;

        return;
    }

    /**
     * @brief DisableInputEventSystem関数
     */
    public void DisableInputEventSystem()
    {
        this._inputEventSystem.enabled = false;

        return;
    }

    /**
     * @brief GetGraphicNode関数
     * @return graphic_node (graphic_node)
     */
    public GameObject GetGraphicNode()
    {
        return (this._graphicNode);
    }

    /**
     * @brief GetSoundNode関数
     * @return sound_node (sound_node)
     */
    public GameObject GetSoundNode()
    {
        return (this._soundNode);
    }

    /**
     * @brief PlaySoundBgm関数
     * @param sound_bgm_index (sound_bgm_index)
     */
    public void PlaySoundBgm(int sound_bgm_index)
    {
        if (this._soundBgmNodeScript == null) {
            return;
        }

        this._soundBgmNodeScript.Item2.Open(0);
        this._soundBgmNodeScript.Item2.GetAudioSource().clip = this._soundBgmAudioClipArray[sound_bgm_index];
        this._soundBgmNodeScript.Item2.GetAudioSource().volume = this._soundBgmVolume;
        this._soundBgmNodeScript.Item2.GetAudioSource().Play();

        return;
    }

    /**
     * @brief StopSoundBgm関数
     */
    public void StopSoundBgm()
    {
        if (this._soundBgmNodeScript == null) {
            return;
        }

        this._soundBgmNodeScript.Item2.GetAudioSource().Stop();

        return;
    }

    /**
     * @brief PauseSoundBgm関数
     */
    public void PauseSoundBgm()
    {
        if (this._soundBgmNodeScript == null) {
            return;
        }

        this._soundBgmNodeScript.Item2.GetAudioSource().Pause();

        return;
    }

    /**
     * @brief UnPauseSoundBgm関数
     */
    public void UnPauseSoundBgm()
    {
        if (this._soundBgmNodeScript == null) {
            return;
        }

        this._soundBgmNodeScript.Item2.GetAudioSource().UnPause();

        return;
    }

    /**
     * @brief GetSoundBgmVolume関数
     * @return sound_bgm_vol (sound_bgm_volume)
     */
    public float GetSoundBgmVolume()
    {
        return (this._soundBgmVolume);
    }

    /**
     * @brief SetSoundBgmVolume関数
     * @param sound_bgm_vol (sound_bgm_volume)
     */
    public void SetSoundBgmVolume(float sound_bgm_vol)
    {
        float tmp_sound_bgm_vol = System.Math.Clamp(sound_bgm_vol, 0.0f, 1.0f);

        if (tmp_sound_bgm_vol == this._soundBgmVolume) {
            return;
        }

        this._soundBgmVolume = tmp_sound_bgm_vol;

        this._FlushSoundBgmVolume();

        return;
    }

    /**
     * @brief _FlushSoundBgmVolume関数
     */
    private void _FlushSoundBgmVolume()
    {
        if (this._soundBgmNodeScript == null) {
            return;
        }

        this._soundBgmNodeScript.Item2.GetAudioSource().volume = this._soundBgmVolume;

        return;
    }

    /**
     * @brief PlaySoundSe関数
     * @param sound_se_index (sound_se_index)
     */
    public void PlaySoundSe(int sound_se_index)
    {
        System.Tuple<GameObject, SoundSeNodeScript> sound_se_node_script = null;

        foreach (var sound_se_node_script2 in this._soundSeNodeScriptContainer) {
            if (sound_se_node_script2.Item2.GetAudioSource().isPlaying) {
                continue;
            }

            sound_se_node_script = sound_se_node_script2;

            break;
        }

        // SoundSeNodeScript Create
        if (sound_se_node_script == null) {
            var node = SceneUtil.GetPrefabNode(this._soundSePrefabFilePath, this._soundNode);
            var script = node.GetComponent<SoundSeNodeScript>();
            var script_create_desc = new SoundSeNodeScriptCreateDesc();

            script.Create(script_create_desc);

            sound_se_node_script = new System.Tuple<GameObject, SoundSeNodeScript>(node, script);

            this._soundSeNodeScriptContainer.Add(sound_se_node_script);
        }

        sound_se_node_script.Item2.Open(0);
        sound_se_node_script.Item2.GetAudioSource().clip = this._soundSeAudioClipArray[sound_se_index];
        sound_se_node_script.Item2.GetAudioSource().volume = this._soundSeVolume;
        sound_se_node_script.Item2.GetAudioSource().Play();

        return;
    }

    /**
     * @brief StopSoundSe関数
     */
    public void StopSoundSe()
    {
        foreach (var sound_se_node_script in this._soundSeNodeScriptContainer) {
            sound_se_node_script.Item2.GetAudioSource().Stop();
        }

        return;
    }

    /**
     * @brief PauseSoundSe関数
     */
    public void PauseSoundSe()
    {
        foreach (var sound_se_node_script in this._soundSeNodeScriptContainer) {
            sound_se_node_script.Item2.GetAudioSource().Pause();
        }

        return;
    }

    /**
     * @brief UnPauseSoundSe関数
     */
    public void UnPauseSoundSe()
    {
        foreach (var sound_se_node_script in this._soundSeNodeScriptContainer) {
            sound_se_node_script.Item2.GetAudioSource().UnPause();
        }

        return;
    }

    /**
     * @brief GetSoundSeVolume関数
     * @return sound_se_vol (sound_se_volume)
     */
    public float GetSoundSeVolume()
    {
        return (this._soundSeVolume);
    }

    /**
     * @brief SetSoundSeVolume関数
     * @param sound_se_vol (sound_se_volume)
     */
    public void SetSoundSeVolume(float sound_se_vol)
    {
        float tmp_sound_se_vol = System.Math.Clamp(sound_se_vol, 0.0f, 1.0f);

        if (tmp_sound_se_vol == this._soundSeVolume) {
            return;
        }

        this._soundSeVolume = tmp_sound_se_vol;

        this._FlushSoundSeVolume();

        return;
    }

    /**
     * @brief _FlushSoundSeVolume関数
     */
    private void _FlushSoundSeVolume()
    {
        foreach (var sound_se_node_script in this._soundSeNodeScriptContainer) {
            sound_se_node_script.Item2.GetAudioSource().volume = this._soundSeVolume;
        }

        return;
    }

    /**
     * @brief GetScript関数
     * @param script_type (script_type)
     * @return script (script)<br>
     * null=失敗
     */
    public Script GetScript(SceneUtil.SCRIPT_SCENE_TYPE script_type)
    {
        if (this._scriptArray[(int)script_type].Count <= 0) {
            return (null);
        }

        return (this._scriptArray[(int)script_type][0]);
    }

    /**
     * @brief GetScriptContainer関数
     * @param script_type (script_type)
     * @return script_cont (script_container)<br>
     * null=失敗
     */
    public List<Script> GetScriptContainer(SceneUtil.SCRIPT_SCENE_TYPE script_type)
    {
        return (this._scriptArray[(int)script_type]);
    }

    /**
     * @brief GetMainSceneNodeScript関数
     * @return main_scene_node_script (main_scene_node_script)
     */
    public MainSceneNodeScript GetMainSceneNodeScript()
    {
        return ((MainSceneNodeScript)this._scriptArrayByScriptSceneType[(int)SceneUtil.SCRIPT_SCENE_TYPE.MAIN]);
    }

    /**
     * @brief GetSubSceneNodeScript関数
     * @return sub_scene_node_script (sub_scene_node_script)
     */
    public SubSceneNodeScript GetSubSceneNodeScript()
    {
        return ((SubSceneNodeScript)this._scriptArrayByScriptSceneType[(int)SceneUtil.SCRIPT_SCENE_TYPE.SUB]);
    }

    /**
     * @brief AddScript関数
     * @param script (script)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int AddScript(Script script)
    {
        if ((script == null)
        || (script.GetManagerAddedFlag())
        || ((int)script.GetScriptType() >= this._scriptArray.Length)) {
            return (-1);
        }

        if (script.GetScriptType() != SceneUtil.SCRIPT_TYPE.NONE) {
            this._scriptArray[(int)script.GetScriptType()].Add(script);

            if (script.GetScriptSceneType() != SceneUtil.SCRIPT_SCENE_TYPE.NONE) {
                this._scriptArrayByScriptSceneType[(int)script.GetScriptSceneType()] = script;
            }

            if (script.GetScriptNotifyTypeArray() != null) {
                foreach (var script_notify_type in script.GetScriptNotifyTypeArray()) {
                    this._scriptArrayByScriptNotifyType[(int)script_notify_type].Add(script);
                }
            }
        }

        script.SetManagerAddedFlag(true);

        return (0);
    }

    /**
     * @brief RemoveScript関数
     * @param script (script)
     */
    public void RemoveScript(Script script)
    {
        if ((script == null)
        || (!script.GetManagerAddedFlag())
        || ((int)script.GetScriptType() >= this._scriptArray.Length)) {
            return;
        }

        if (script.GetScriptType() != SceneUtil.SCRIPT_TYPE.NONE) {
            this._scriptArray[(int)script.GetScriptType()].Remove(script);

            if (script.GetScriptSceneType() != SceneUtil.SCRIPT_SCENE_TYPE.NONE) {
                if (this._scriptArrayByScriptSceneType[(int)script.GetScriptSceneType()] == script) {
                    this._scriptArrayByScriptSceneType[(int)script.GetScriptSceneType()] = null;
                }
            }

            if (script.GetScriptNotifyTypeArray() != null) {
                foreach (var script_notify_type in script.GetScriptNotifyTypeArray()) {
                    this._scriptArrayByScriptNotifyType[(int)script_notify_type].Remove(script);
                }
            }
        }

        script.SetManagerAddedFlag(false);

        return;
    }

    /**
     * @brief NotifyToScript関数
     * @param notify_type (notify_type)
     */
    public void NotifyToScript(SceneUtil.SCRIPT_NOTIFY_TYPE notify_type)
    {
        var script_cont = this._scriptArrayByScriptNotifyType[(int)notify_type];

        foreach (var script in script_cont) {
            script.NotifyFromManager(notify_type);
        }

        return;
    }
}
}
}
