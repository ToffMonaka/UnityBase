/**
 * @file
 * @brief SoundSeNodeScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief SoundSeNodeScriptCreateDescクラス
 */
public class SoundSeNodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
}

/**
 * @brief SoundSeNodeScriptクラス
 */
public class SoundSeNodeScript : Lib.Scene.ObjectNodeScript
{
    [SerializeField] private AudioSource _audioSource = null;

    public new Lib.Scene.SoundSeNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public SoundSeNodeScript() : base((int)Lib.Util.SCENE.SCRIPT_INDEX.SOUND_SE)
    {
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
	    this.createDesc = create_desc as Lib.Scene.SoundSeNodeScriptCreateDesc;

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
