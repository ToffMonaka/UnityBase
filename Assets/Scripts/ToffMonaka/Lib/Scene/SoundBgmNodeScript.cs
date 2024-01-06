/**
 * @file
 * @brief SoundBgmNodeScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief SoundBgmNodeScriptCreateDescクラス
 */
public class SoundBgmNodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
}

/**
 * @brief SoundBgmNodeScriptクラス
 */
public class SoundBgmNodeScript : Lib.Scene.ObjectNodeScript
{
    [SerializeField] private AudioSource _audioSource = null;

    public new Lib.Scene.SoundBgmNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public SoundBgmNodeScript()
    {
        this._SetScriptIndex((int)Lib.Util.SCENE.SCRIPT_INDEX.SOUND_BGM);

        return;
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
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as Lib.Scene.SoundBgmNodeScriptCreateDesc;

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
        if (this._audioSource.isPlaying == false) {
            this.Close(0);
        }

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
