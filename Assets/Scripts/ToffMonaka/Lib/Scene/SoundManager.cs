/**
 * @file
 * @brief SoundManagerファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief SoundManagerCreateDescクラス
 */
public class SoundManagerCreateDesc
{
    public GameObject soundNode = null;
    public string bgmPrefabFilePath = "";
    public AudioClip[] bgmAudioClipArray = null;
	public float bgmVolume = 1.0f;
	public bool bgmMuteFlag = false;
    public string sePrefabFilePath = "";
    public AudioClip[] seAudioClipArray = null;
	public float seVolume = 1.0f;
	public bool seMuteFlag = false;
}

/**
 * @brief SoundManagerクラス
 */
public class SoundManager
{
    public Lib.Scene.SoundManagerCreateDesc createDesc{get; private set;} = null;

    private GameObject _soundNode = null;
    public string _bgmPrefabFilePath = "";
    private System.Tuple<GameObject, Lib.Scene.SoundBgmNodeScript> _bgmNodeScript = null;
    private AudioClip[] _bgmAudioClipArray = null;
	private float _bgmVolume = 1.0f;
	private bool _bgmMuteFlag = false;
    public string _sePrefabFilePath = "";
    private List<System.Tuple<GameObject, Lib.Scene.SoundSeNodeScript>> _seNodeScriptContainer = new List<System.Tuple<GameObject, Lib.Scene.SoundSeNodeScript>>();
    private AudioClip[] _seAudioClipArray = null;
	private float _seVolume = 1.0f;
	private bool _seMuteFlag = false;

    /**
     * @brief コンストラクタ
     */
    public SoundManager()
    {
        return;
    }

    /**
     * @brief _Release関数
     */
    private void _Release()
    {
        if (this._bgmNodeScript != null) {
            var node = this._bgmNodeScript.Item1;

            Lib.Scene.Util.ReleasePrefabNode(ref node);

            this._bgmNodeScript = null;
        }

        foreach (var se_node_script in this._seNodeScriptContainer) {
            var node = se_node_script.Item1;

            Lib.Scene.Util.ReleasePrefabNode(ref node);
        }

        this._seNodeScriptContainer.Clear();

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this._Release();

        this._soundNode = null;
        this._bgmPrefabFilePath = "";
        this._bgmAudioClipArray = null;
	    this._bgmVolume = 1.0f;
	    this._bgmMuteFlag = false;
        this._sePrefabFilePath = "";
        this._seAudioClipArray = null;
	    this._seVolume = 1.0f;
	    this._seMuteFlag = false;

        return;
    }

    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public virtual int Create(Lib.Scene.SoundManagerCreateDesc desc = null)
    {
        this.Init();

        {// This Create
            if (desc != null) {
                this.SetCreateDesc(desc);
            }

            this._soundNode = desc.soundNode;

            this._bgmPrefabFilePath = desc.bgmPrefabFilePath;

            // BgmNodeScript Create
            if (this._bgmNodeScript == null) {
                var node = Lib.Scene.Util.GetPrefabNode(this._bgmPrefabFilePath, this._soundNode);
                var script = node.GetComponent<Lib.Scene.SoundBgmNodeScript>();
                var script_create_desc = new Lib.Scene.SoundBgmNodeScriptCreateDesc();

                script.Create(script_create_desc);

                this._bgmNodeScript = new System.Tuple<GameObject, Lib.Scene.SoundBgmNodeScript>(node, script);
            }

            this._bgmAudioClipArray = (AudioClip[])this.createDesc.bgmAudioClipArray.Clone();
	        this._bgmVolume = this.createDesc.bgmVolume;
	        this._bgmMuteFlag = this.createDesc.bgmMuteFlag;

            this._sePrefabFilePath = desc.sePrefabFilePath;

            // SeNodeScript Create
            for (int se_node_script_i = 0; se_node_script_i < 8; ++se_node_script_i) {
                var node = Lib.Scene.Util.GetPrefabNode(this._sePrefabFilePath, this._soundNode);
                var script = node.GetComponent<Lib.Scene.SoundSeNodeScript>();
                var script_create_desc = new Lib.Scene.SoundSeNodeScriptCreateDesc();

                script.Create(script_create_desc);

                this._seNodeScriptContainer.Add(new System.Tuple<GameObject, Lib.Scene.SoundSeNodeScript>(node, script));
            }

            this._seAudioClipArray = (AudioClip[])this.createDesc.seAudioClipArray.Clone();
	        this._seVolume = this.createDesc.seVolume;
	        this._seMuteFlag = this.createDesc.seMuteFlag;
        }

        int create_result_val = this._OnCreate();

        if (create_result_val < 0) {
            this.Init();

            return (create_result_val);
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
    public virtual void SetCreateDesc(Lib.Scene.SoundManagerCreateDesc create_desc)
    {
        this.createDesc = create_desc;

        return;
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
     * @brief PlayBgm関数
     * @param bgm_index (bgm_index)
     */
    public void PlayBgm(int bgm_index)
    {
        if (this._bgmNodeScript == null) {
            return;
        }

        this._bgmNodeScript.Item2.Open(0);
        this._bgmNodeScript.Item2.GetAudioSource().clip = this._bgmAudioClipArray[bgm_index];
        this._bgmNodeScript.Item2.GetAudioSource().volume = (this._bgmMuteFlag) ? 0.0f : this._bgmVolume;
        this._bgmNodeScript.Item2.GetAudioSource().Play();

        return;
    }

    /**
     * @brief StopBgm関数
     */
    public void StopBgm()
    {
        if (this._bgmNodeScript == null) {
            return;
        }

        this._bgmNodeScript.Item2.GetAudioSource().Stop();

        return;
    }

    /**
     * @brief PauseBgm関数
     */
    public void PauseBgm()
    {
        if (this._bgmNodeScript == null) {
            return;
        }

        this._bgmNodeScript.Item2.GetAudioSource().Pause();

        return;
    }

    /**
     * @brief UnPauseBgm関数
     */
    public void UnPauseBgm()
    {
        if (this._bgmNodeScript == null) {
            return;
        }

        this._bgmNodeScript.Item2.GetAudioSource().UnPause();

        return;
    }

    /**
     * @brief GetBgmVolume関数
     * @return bgm_vol (bgm_volume)
     */
    public float GetBgmVolume()
    {
        return (this._bgmVolume);
    }

    /**
     * @brief SetBgmVolume関数
     * @param bgm_vol (bgm_volume)
     */
    public void SetBgmVolume(float bgm_vol)
    {
        float tmp_bgm_vol = System.Math.Clamp(bgm_vol, 0.0f, 1.0f);

        if (tmp_bgm_vol == this._bgmVolume) {
            return;
        }

        this._bgmVolume = tmp_bgm_vol;

        this._FlushBgmVolume();

        return;
    }

    /**
     * @brief GetBgmMuteFlag関数
     * @return bgm_mute_flg (bgm_mute_flag)
     */
    public bool GetBgmMuteFlag()
    {
        return (this._bgmMuteFlag);
    }

    /**
     * @brief SetBgmMuteFlag関数
     * @param bgm_mute_flg (bgm_mute_flag)
     */
    public void SetBgmMuteFlag(bool bgm_mute_flg)
    {
        if (bgm_mute_flg == this._bgmMuteFlag) {
            return;
        }

        this._bgmMuteFlag = bgm_mute_flg;

        this._FlushBgmVolume();

        return;
    }

    /**
     * @brief _FlushBgmVolume関数
     */
    private void _FlushBgmVolume()
    {
        if (this._bgmNodeScript == null) {
            return;
        }

        this._bgmNodeScript.Item2.GetAudioSource().volume = (this._bgmMuteFlag) ? 0.0f : this._bgmVolume;

        return;
    }

    /**
     * @brief PlaySe関数
     * @param se_index (se_index)
     */
    public void PlaySe(int se_index)
    {
        System.Tuple<GameObject, Lib.Scene.SoundSeNodeScript> se_node_script = null;

        foreach (var se_node_script2 in this._seNodeScriptContainer) {
            if (se_node_script2.Item2.GetAudioSource().isPlaying) {
                continue;
            }

            se_node_script = se_node_script2;

            break;
        }

        // SeNodeScript Create
        if (se_node_script == null) {
            var node = Lib.Scene.Util.GetPrefabNode(this._sePrefabFilePath, this._soundNode);
            var script = node.GetComponent<Lib.Scene.SoundSeNodeScript>();
            var script_create_desc = new Lib.Scene.SoundSeNodeScriptCreateDesc();

            script.Create(script_create_desc);

            se_node_script = new System.Tuple<GameObject, Lib.Scene.SoundSeNodeScript>(node, script);

            this._seNodeScriptContainer.Add(se_node_script);
        }

        se_node_script.Item2.Open(0);
        se_node_script.Item2.GetAudioSource().clip = this._seAudioClipArray[se_index];
        se_node_script.Item2.GetAudioSource().volume = (this._seMuteFlag) ? 0.0f : this._seVolume;
        se_node_script.Item2.GetAudioSource().Play();

        return;
    }

    /**
     * @brief StopSe関数
     */
    public void StopSe()
    {
        foreach (var se_node_script in this._seNodeScriptContainer) {
            se_node_script.Item2.GetAudioSource().Stop();
        }

        return;
    }

    /**
     * @brief PauseSe関数
     */
    public void PauseSe()
    {
        foreach (var se_node_script in this._seNodeScriptContainer) {
            se_node_script.Item2.GetAudioSource().Pause();
        }

        return;
    }

    /**
     * @brief UnPauseSe関数
     */
    public void UnPauseSe()
    {
        foreach (var se_node_script in this._seNodeScriptContainer) {
            se_node_script.Item2.GetAudioSource().UnPause();
        }

        return;
    }

    /**
     * @brief GetSeVolume関数
     * @return se_vol (se_volume)
     */
    public float GetSeVolume()
    {
        return (this._seVolume);
    }

    /**
     * @brief SetSeVolume関数
     * @param se_vol (se_volume)
     */
    public void SetSeVolume(float se_vol)
    {
        float tmp_se_vol = System.Math.Clamp(se_vol, 0.0f, 1.0f);

        if (tmp_se_vol == this._seVolume) {
            return;
        }

        this._seVolume = tmp_se_vol;

        this._FlushSeVolume();

        return;
    }

    /**
     * @brief GetSeMuteFlag関数
     * @return se_mute_flg (se_mute_flag)
     */
    public bool GetSeMuteFlag()
    {
        return (this._seMuteFlag);
    }

    /**
     * @brief SetSeMuteFlag関数
     * @param se_mute_flg (se_mute_flag)
     */
    public void SetSeMuteFlag(bool se_mute_flg)
    {
        if (se_mute_flg == this._seMuteFlag) {
            return;
        }

        this._seMuteFlag = se_mute_flg;

        this._FlushSeVolume();

        return;
    }

    /**
     * @brief _FlushSeVolume関数
     */
    private void _FlushSeVolume()
    {
        foreach (var se_node_script in this._seNodeScriptContainer) {
            se_node_script.Item2.GetAudioSource().volume = (this._seMuteFlag) ? 0.0f : this._seVolume;
        }

        return;
    }
}
}
}
