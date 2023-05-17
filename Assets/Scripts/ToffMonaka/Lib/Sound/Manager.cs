/**
 * @file
 * @brief Managerファイル
 */


using UnityEngine;
using System;
using System.Collections.Generic;


namespace ToffMonaka.Lib.Sound {
/**
 * @brief ManagerCreateDescクラス
 */
public class ManagerCreateDesc
{
    public AudioClip[] bgmAudioClipArray = null;
	public float bgmVolume = 1.0f;
	public bool bgmMuteFlag = false;
    public AudioClip[] seAudioClipArray = null;
	public float seVolume = 1.0f;
	public bool seMuteFlag = false;
}

/**
 * @brief Managerクラス
 */
public class Manager
{
    public ToffMonaka.Lib.Sound.ManagerCreateDesc createDesc{get; private set;} = null;
    private AudioClip[] _bgmAudioClipArray = null;
	private float _bgmVolume = 1.0f;
	private bool _bgmMuteFlag = false;
    private AudioSource _bgmAudioSource = null;
    private AudioClip[] _seAudioClipArray = null;
	private float _seVolume = 1.0f;
	private bool _seMuteFlag = false;
    private List<AudioSource> _seAudioSourceContainer = new List<AudioSource>();

    /**
     * @brief コンストラクタ
     */
    public Manager()
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

        this._bgmAudioClipArray = null;
	    this._bgmVolume = 1.0f;
	    this._bgmMuteFlag = false;
        this._bgmAudioSource = null;
        this._seAudioClipArray = null;
	    this._seVolume = 1.0f;
	    this._seMuteFlag = false;
        this._seAudioSourceContainer.Clear();

        return;
    }

    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Create(ToffMonaka.Lib.Sound.ManagerCreateDesc desc = null)
    {
        this.Init();

        if (desc != null) {
            this.SetCreateDesc(desc);
        }

        {// This Create
            this._bgmAudioClipArray = (AudioClip[])this.createDesc.bgmAudioClipArray.Clone();
	        this._bgmVolume = this.createDesc.bgmVolume;
	        this._bgmMuteFlag = this.createDesc.bgmMuteFlag;

            var bgm_node = new GameObject("Bgm");
            var bgm_audio_src = bgm_node.AddComponent<AudioSource>();

            bgm_audio_src.playOnAwake = false;
            bgm_audio_src.loop = true;

            this._bgmAudioSource = bgm_audio_src;

            this._seAudioClipArray = (AudioClip[])this.createDesc.seAudioClipArray.Clone();
	        this._seVolume = this.createDesc.seVolume;
	        this._seMuteFlag = this.createDesc.seMuteFlag;

            for (int se_node_i = 0; se_node_i < 8; ++se_node_i) {
                var se_node = new GameObject("Se" + ((se_node_i == 0) ? "" : (se_node_i + 1)));
                var se_audio_src = se_node.AddComponent<AudioSource>();

                se_audio_src.playOnAwake = false;
                se_audio_src.loop = false;

                this._seAudioSourceContainer.Add(se_audio_src);
            }
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
    public virtual void SetCreateDesc(ToffMonaka.Lib.Sound.ManagerCreateDesc create_desc)
    {
        this.createDesc = create_desc;

        return;
    }

    /**
     * @brief PlayBgm関数
     * @param bgm_index (bgm_index)
     */
    public void PlayBgm(int bgm_index)
    {
        this._bgmAudioSource.clip = this._bgmAudioClipArray[bgm_index];

        this._bgmAudioSource.Play();

        return;
    }

    /**
     * @brief StopBgm関数
     */
    public void StopBgm()
    {
        this._bgmAudioSource.Stop();

        return;
    }

    /**
     * @brief PauseBgm関数
     */
    public void PauseBgm()
    {
        this._bgmAudioSource.Pause();

        return;
    }

    /**
     * @brief UnPauseBgm関数
     */
    public void UnPauseBgm()
    {
        this._bgmAudioSource.UnPause();

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
        this._bgmVolume = bgm_volume;

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
        this._bgmMuteFlag = bgm_mute_flg;

        return;
    }

    /**
     * @brief PlaySe関数
     * @param se_index (se_index)
     */
    public void PlaySe(int se_index)
    {
        AudioSource se_audio_src = null;

        foreach (var se_audio_src2 in this._seAudioSourceContainer) {
            if (se_audio_src2.isPlaying) {
                continue;
            }

            se_audio_src = se_audio_src2;

            break;
        }

        if (se_audio_src == null) {
            var se_node2 = new GameObject("Se" + (this._seAudioSourceContainer.Count + 1));
            var se_audio_src2 = se_node2.AddComponent<AudioSource>();

            se_audio_src2.playOnAwake = false;
            se_audio_src2.loop = false;

            this._seAudioSourceContainer.Add(se_audio_src2);

            se_audio_src = se_audio_src2;
        }

        se_audio_src.clip = this._seAudioClipArray[se_index];

        se_audio_src.Play();

        return;
    }

    /**
     * @brief StopSe関数
     */
    public void StopSe()
    {
        foreach (var se_audio_src in this._seAudioSourceContainer) {
            se_audio_src.Stop();
        }

        return;
    }

    /**
     * @brief PauseSe関数
     */
    public void PauseSe()
    {
        foreach (var se_audio_src in this._seAudioSourceContainer) {
            se_audio_src.Pause();
        }

        return;
    }

    /**
     * @brief UnPauseSe関数
     */
    public void UnPauseSe()
    {
        foreach (var se_audio_src in this._seAudioSourceContainer) {
            se_audio_src.UnPause();
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
        this._seVolume = se_volume;

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
        this._seMuteFlag = se_mute_flg;

        return;
    }
}
}
