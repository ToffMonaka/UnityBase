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
	public bool soundBgmMuteFlag = false;
    public string soundSePrefabFilePath = "";
    public AudioClip[] soundSeAudioClipArray = null;
	public float soundSeVolume = 1.0f;
	public bool soundSeMuteFlag = false;
    public int scriptCount = 0;
}

/**
 * @brief SceneManagerクラス
 */
public class SceneManager
{
    public SceneManagerCreateDesc createDesc{get; private set;} = null;

    private GameObject _mainSceneNode = null;
    private bool _mainSceneStartedFlag;
    private bool _mainSceneEndedFlag;
    private GameObject _subSceneNode = null;
    private GameObject _inputNode;
    private EventSystem _inputEventSystem;
    private GameObject _graphicNode;
    private GameObject _soundNode;
    private string _soundBgmPrefabFilePath;
    private System.Tuple<GameObject, SoundBgmNodeScript> _soundBgmNodeScript = null;
    private AudioClip[] _soundBgmAudioClipArray;
	private float _soundBgmVolume;
	private bool _soundBgmMuteFlag;
    private string _soundSePrefabFilePath;
    private List<System.Tuple<GameObject, SoundSeNodeScript>> _soundSeNodeScriptContainer = new();
    private AudioClip[] _soundSeAudioClipArray;
	private float _soundSeVolume;
	private bool _soundSeMuteFlag;
    private List<Script>[] _scriptArray = null;
    private MainSceneNodeScript _mainSceneNodeScript;
    private SubSceneNodeScript _subSceneNodeScript;
    private List<ObjectNodeScript>[]  _objectNodeScriptArray;
    private List<PartsScript>[]  _partsScriptArray;

    /**
     * @brief コンストラクタ
     */
    public SceneManager()
    {
        this.Init();

        return;
    }

    /**
     * @brief _Release関数
     */
    private void _Release()
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

        this._subSceneNode = null;
        this._mainSceneNode = null;

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this._Release();

        this._mainSceneStartedFlag = false;
        this._mainSceneEndedFlag = false;
        this._inputNode = null;
        this._inputEventSystem = null;
        this._graphicNode = null;
        this._soundNode = null;
        this._soundBgmPrefabFilePath = "";
        this._soundBgmAudioClipArray = null;
	    this._soundBgmVolume = 1.0f;
	    this._soundBgmMuteFlag = false;
        this._soundSePrefabFilePath = "";
        this._soundSeAudioClipArray = null;
	    this._soundSeVolume = 1.0f;
	    this._soundSeMuteFlag = false;
        this._mainSceneNodeScript = null;
        this._subSceneNodeScript = null;
        this._objectNodeScriptArray = null;
        this._partsScriptArray = null;

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
	        this._soundBgmMuteFlag = this.createDesc.soundBgmMuteFlag;
            this._soundSePrefabFilePath = desc.soundSePrefabFilePath;
            this._soundSeAudioClipArray = (AudioClip[])this.createDesc.soundSeAudioClipArray.Clone();
	        this._soundSeVolume = this.createDesc.soundSeVolume;
	        this._soundSeMuteFlag = this.createDesc.soundSeMuteFlag;

            this._scriptArray = new List<Script>[this.createDesc.scriptCount];

            for (int script_i = 0; script_i < this._scriptArray.Length; ++script_i) {
                this._scriptArray[script_i] = new List<Script>();
            }

            this._objectNodeScriptArray = new List<ObjectNodeScript>[this.createDesc.scriptCount];

            for (int obj_node_script_i = 0; obj_node_script_i < this._objectNodeScriptArray.Length; ++obj_node_script_i) {
                this._objectNodeScriptArray[obj_node_script_i] = new List<ObjectNodeScript>();
            }

            this._partsScriptArray = new List<PartsScript>[this.createDesc.scriptCount];

            for (int parts_script_i = 0; parts_script_i < this._partsScriptArray.Length; ++parts_script_i) {
                this._partsScriptArray[parts_script_i] = new List<PartsScript>();
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
        this._soundBgmNodeScript.Item2.GetAudioSource().volume = (this._soundBgmMuteFlag) ? 0.0f : this._soundBgmVolume;
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
     * @brief GetSoundBgmMuteFlag関数
     * @return bgm_mute_flg (bgm_mute_flag)
     */
    public bool GetSoundBgmMuteFlag()
    {
        return (this._soundBgmMuteFlag);
    }

    /**
     * @brief SetSoundBgmMuteFlag関数
     * @param bgm_mute_flg (bgm_mute_flag)
     */
    public void SetSoundBgmMuteFlag(bool bgm_mute_flg)
    {
        if (bgm_mute_flg == this._soundBgmMuteFlag) {
            return;
        }

        this._soundBgmMuteFlag = bgm_mute_flg;

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

        this._soundBgmNodeScript.Item2.GetAudioSource().volume = (this._soundBgmMuteFlag) ? 0.0f : this._soundBgmVolume;

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
        sound_se_node_script.Item2.GetAudioSource().volume = (this._soundSeMuteFlag) ? 0.0f : this._soundSeVolume;
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
     * @brief GetSoundSeMuteFlag関数
     * @return se_mute_flg (se_mute_flag)
     */
    public bool GetSoundSeMuteFlag()
    {
        return (this._soundSeMuteFlag);
    }

    /**
     * @brief SetSoundSeMuteFlag関数
     * @param se_mute_flg (se_mute_flag)
     */
    public void SetSoundSeMuteFlag(bool se_mute_flg)
    {
        if (se_mute_flg == this._soundSeMuteFlag) {
            return;
        }

        this._soundSeMuteFlag = se_mute_flg;

        this._FlushSoundSeVolume();

        return;
    }

    /**
     * @brief _FlushSoundSeVolume関数
     */
    private void _FlushSoundSeVolume()
    {
        foreach (var sound_se_node_script in this._soundSeNodeScriptContainer) {
            sound_se_node_script.Item2.GetAudioSource().volume = (this._soundSeMuteFlag) ? 0.0f : this._soundSeVolume;
        }

        return;
    }

    /**
     * @brief GetScript関数
     * @param script_inex (script_inex)
     * @return script (script)<br>
     * null=失敗
     */
    public Script GetScript(int script_inex)
    {
        if ((script_inex < 0)
        || (script_inex >= this._scriptArray.Length)) {
            return (null);
        }

        if (this._scriptArray[script_inex].Count <= 0) {
            return (null);
        }

        return (this._scriptArray[script_inex][0]);
    }

    /**
     * @brief GetScriptContainer関数
     * @param script_inex (script_inex)
     * @return script_cont (script_container)<br>
     * null=失敗
     */
    public List<Script> GetScriptContainer(int script_inex)
    {
        if ((script_inex < 0)
        || (script_inex >= this._scriptArray.Length)) {
            return (null);
        }

        return (this._scriptArray[script_inex]);
    }

    /**
     * @brief GetMainSceneNodeScript関数
     * @return main_scene_node_script (main_scene_node_script)
     */
    public MainSceneNodeScript GetMainSceneNodeScript()
    {
        return (this._mainSceneNodeScript);
    }

    /**
     * @brief GetSubSceneNodeScript関数
     * @return sub_scene_node_script (sub_scene_node_script)
     */
    public SubSceneNodeScript GetSubSceneNodeScript()
    {
        return (this._subSceneNodeScript);
    }

    /**
     * @brief GetObjectNodeScriptContainer関数
     * @param script_inex (script_inex)
     * @return obj_node_script_cont (object_node_script_container)
     */
    public List<ObjectNodeScript> GetObjectNodeScriptContainer(int script_inex)
    {
        return (this._objectNodeScriptArray[script_inex]);
    }

    /**
     * @brief GetPartsScriptContainer関数
     * @param script_inex (script_inex)
     * @return parts_script_cont (parts_script_container)
     */
    public List<PartsScript> GetPartsScriptContainer(int script_inex)
    {
        return (this._partsScriptArray[script_inex]);
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
        || (script.GetScriptIndex() >= this._scriptArray.Length)) {
            return (-1);
        }

        if (script.GetScriptIndex() >= 0) {
            this._scriptArray[script.GetScriptIndex()].Add(script);

		    switch (script.GetScriptType()) {
		    case SceneUtil.SCRIPT_TYPE.MAIN_SCENE_NODE: {
                this._mainSceneNodeScript = (MainSceneNodeScript)script;

			    break;
		    }
		    case SceneUtil.SCRIPT_TYPE.SUB_SCENE_NODE: {
                this._subSceneNodeScript = (SubSceneNodeScript)script;

			    break;
		    }
		    case SceneUtil.SCRIPT_TYPE.OBJECT_NODE: {
                this._objectNodeScriptArray[script.GetScriptIndex()].Add((ObjectNodeScript)script);

			    break;
		    }
		    case SceneUtil.SCRIPT_TYPE.PARTS: {
                this._partsScriptArray[script.GetScriptIndex()].Add((PartsScript)script);

			    break;
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
        || (script.GetScriptIndex() >= this._scriptArray.Length)) {
            return;
        }

        if (script.GetScriptIndex() >= 0) {
            this._scriptArray[script.GetScriptIndex()].Remove(script);

		    switch (script.GetScriptType()) {
		    case SceneUtil.SCRIPT_TYPE.MAIN_SCENE_NODE: {
                if (this._mainSceneNodeScript == (MainSceneNodeScript)script) {
                    this._mainSceneNodeScript = null;
                }

			    break;
		    }
		    case SceneUtil.SCRIPT_TYPE.SUB_SCENE_NODE: {
                if (this._subSceneNodeScript == (SubSceneNodeScript)script) {
                    this._subSceneNodeScript = null;
                }

			    break;
		    }
		    case SceneUtil.SCRIPT_TYPE.OBJECT_NODE: {
                this._objectNodeScriptArray[script.GetScriptIndex()].Remove((ObjectNodeScript)script);

			    break;
		    }
		    case SceneUtil.SCRIPT_TYPE.PARTS: {
                this._partsScriptArray[script.GetScriptIndex()].Remove((PartsScript)script);

			    break;
		    }
		    }
        }

        script.SetManagerAddedFlag(false);

        return;
    }
}
}
}
