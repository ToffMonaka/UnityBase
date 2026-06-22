/**
 * @file
 * @brief SoundBgmNodeScriptファイル
 */

using UnityEngine;

namespace ToffMonaka {
namespace Tml.Scene {
/**
 * @brief SoundBgmNodeScriptCreateDescクラス
 */
public class SoundBgmNodeScriptCreateDesc : NodeScriptCreateDesc
{
}

/**
 * @brief SoundBgmNodeScriptクラス
 */
public class SoundBgmNodeScript : NodeScript
{
    [SerializeField] private AudioSource _audioSource = null;

    public new SoundBgmNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SOUND_BGM_NODE);
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
    public override void SetCreateDesc(ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new SoundBgmNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as SoundBgmNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        if (this._audioSource.isPlaying == false) {
            this.Close(0);
        }

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
     * @brief GetAudioSource関数
     * @return audio_src (audio_source)
     */
    public AudioSource GetAudioSource()
    {
        return (this._audioSource);
    }
}
}
}
