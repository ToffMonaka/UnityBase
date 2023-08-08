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
    public GameObject bgmNode = null;
    public AudioClip[] bgmAudioClipArray = null;
	public float bgmVolume = 1.0f;
	public bool bgmMuteFlag = false;
    public GameObject seNode = null;
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
    private GameObject _bgmNode = null;
    private Lib.Scene.SoundBgmScript _bgmScript = null;
    private AudioClip[] _bgmAudioClipArray = null;
	private float _bgmVolume = 1.0f;
	private bool _bgmMuteFlag = false;
    private GameObject _seNode = null;
    private List<Lib.Scene.SoundSeScript> _seScriptContainer = new List<Lib.Scene.SoundSeScript>();
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
        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this._Release();

        this._soundNode = null;
        this._bgmNode = null;
        this._bgmScript = null;
        this._bgmAudioClipArray = null;
	    this._bgmVolume = 1.0f;
	    this._bgmMuteFlag = false;
        this._seNode = null;
        this._seScriptContainer.Clear();
        this._seAudioClipArray = null;
	    this._seVolume = 1.0f;
	    this._seMuteFlag = false;

        return;
    }

    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public virtual int Create(Lib.Scene.SoundManagerCreateDesc desc = null)
    {
        this.Init();

        {// This Create
            if (desc != null) {
                this.SetCreateDesc(desc);
            }

            this._soundNode= desc.soundNode;
            this._bgmNode = desc.bgmNode;
            this._seNode = desc.seNode;

            this._bgmNode.SetActive(false);
            this._seNode.SetActive(false);

            var bgm_script = GameObject.Instantiate(this._bgmNode, this._bgmNode.transform.parent).GetComponent<Lib.Scene.SoundBgmScript>();
            var bgm_script_create_desc = new Lib.Scene.SoundBgmScriptCreateDesc();

            bgm_script.Create(bgm_script_create_desc);
            bgm_script.Open(0);

            this._bgmScript = bgm_script;

            this._bgmAudioClipArray = (AudioClip[])this.createDesc.bgmAudioClipArray.Clone();
	        this._bgmVolume = this.createDesc.bgmVolume;
	        this._bgmMuteFlag = this.createDesc.bgmMuteFlag;

            for (int se_script_i = 0; se_script_i < 8; ++se_script_i) {
                var se_script = GameObject.Instantiate(this._seNode, this._seNode.transform.parent).GetComponent<Lib.Scene.SoundSeScript>();
                var se_script_create_desc = new Lib.Scene.SoundSeScriptCreateDesc();

                se_script.Create(se_script_create_desc);
                se_script.Open(0);

                this._seScriptContainer.Add(se_script);
            }

            this._seAudioClipArray = (AudioClip[])this.createDesc.seAudioClipArray.Clone();
	        this._seVolume = this.createDesc.seVolume;
	        this._seMuteFlag = this.createDesc.seMuteFlag;
        }

        int create_res = this._OnCreate();

        if (create_res < 0) {
            this.Init();

            return (create_res);
        }

        return (0);
    }

    /**
     * @brief _OnCreate関数
     * @return result (result)<br>
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
        this._bgmScript.Open(0);
        this._bgmScript.GetAudioSource().clip = this._bgmAudioClipArray[bgm_index];
        this._bgmScript.GetAudioSource().volume = (this._bgmMuteFlag) ? 0.0f : this._bgmVolume;
        this._bgmScript.GetAudioSource().Play();

        return;
    }

    /**
     * @brief StopBgm関数
     */
    public void StopBgm()
    {
        this._bgmScript.GetAudioSource().Stop();

        return;
    }

    /**
     * @brief PauseBgm関数
     */
    public void PauseBgm()
    {
        this._bgmScript.GetAudioSource().Pause();

        return;
    }

    /**
     * @brief UnPauseBgm関数
     */
    public void UnPauseBgm()
    {
        this._bgmScript.GetAudioSource().UnPause();

        return;
    }

    /**
     * @brief GetBgmVolume関数
     * @return bgm_volume (bgm_volume)
     */
    public float GetBgmVolume()
    {
        return (this._bgmVolume);
    }

    /**
     * @brief SetBgmVolume関数
     * @param bgm_volume (bgm_volume)
     */
    public void SetBgmVolume(float bgm_volume)
    {
        float tmp_bgm_volume = System.Math.Clamp(bgm_volume, 0.0f, 1.0f);

        if (tmp_bgm_volume == this._bgmVolume) {
            return;
        }

        this._bgmVolume = tmp_bgm_volume;

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
        this._bgmScript.GetAudioSource().volume = (this._bgmMuteFlag) ? 0.0f : this._bgmVolume;

        return;
    }

    /**
     * @brief PlaySe関数
     * @param se_index (se_index)
     */
    public void PlaySe(int se_index)
    {
        Lib.Scene.SoundSeScript se_script = null;

        foreach (var se_script2 in this._seScriptContainer) {
            if (se_script2.GetAudioSource().isPlaying) {
                continue;
            }

            se_script = se_script2;

            break;
        }

        if (se_script == null) {
            var se_script2 = GameObject.Instantiate(this._seNode, this._seNode.transform.parent).GetComponent<Lib.Scene.SoundSeScript>();
            var se_script_create_desc2 = new Lib.Scene.SoundSeScriptCreateDesc();

            se_script2.Create(se_script_create_desc2);

            this._seScriptContainer.Add(se_script2);

            se_script = se_script2;
        }

        se_script.Open(0);
        se_script.GetAudioSource().clip = this._seAudioClipArray[se_index];
        se_script.GetAudioSource().volume = (this._seMuteFlag) ? 0.0f : this._seVolume;
        se_script.GetAudioSource().Play();

        return;
    }

    /**
     * @brief StopSe関数
     */
    public void StopSe()
    {
        foreach (var se_script in this._seScriptContainer) {
            se_script.GetAudioSource().Stop();
        }

        return;
    }

    /**
     * @brief PauseSe関数
     */
    public void PauseSe()
    {
        foreach (var se_script in this._seScriptContainer) {
            se_script.GetAudioSource().Pause();
        }

        return;
    }

    /**
     * @brief UnPauseSe関数
     */
    public void UnPauseSe()
    {
        foreach (var se_script in this._seScriptContainer) {
            se_script.GetAudioSource().UnPause();
        }

        return;
    }

    /**
     * @brief GetSeVolume関数
     * @return se_volume (se_volume)
     */
    public float GetSeVolume()
    {
        return (this._seVolume);
    }

    /**
     * @brief SetSeVolume関数
     * @param se_volume (se_volume)
     */
    public void SetSeVolume(float se_volume)
    {
        float tmp_se_volume = System.Math.Clamp(se_volume, 0.0f, 1.0f);

        if (tmp_se_volume == this._seVolume) {
            return;
        }

        this._seVolume = tmp_se_volume;

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
        foreach (var se_script in this._seScriptContainer) {
            se_script.GetAudioSource().volume = (this._seMuteFlag) ? 0.0f : this._seVolume;
        }

        return;
    }
}
}
}
