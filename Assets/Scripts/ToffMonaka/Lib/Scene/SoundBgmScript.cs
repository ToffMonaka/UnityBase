/**
 * @file
 * @brief SoundBgmScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief SoundBgmScriptCreateDescクラス
 */
public class SoundBgmScriptCreateDesc : Lib.Scene.ObjectScriptCreateDesc
{
}

/**
 * @brief SoundBgmScriptクラス
 */
public class SoundBgmScript : Lib.Scene.ObjectScript
{
    [SerializeField] private AudioSource _audioSource = null;

    public new Lib.Scene.SoundBgmScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public SoundBgmScript()
    {
        this._SetScriptIndex((int)Lib.Constant.Util.SCENE.SCRIPT_INDEX.SOUND_BGM);

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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as Lib.Scene.SoundBgmScriptCreateDesc;

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
