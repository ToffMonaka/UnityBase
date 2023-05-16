/**
 * @file
 * @brief SceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief SceneScriptCreateDescクラス
 */
public class SceneScriptCreateDesc : ToffMonaka.Lib.Scene.ScriptCreateDesc
{
}

/**
 * @brief SceneScriptクラス
 */
public abstract class SceneScript : ToffMonaka.Lib.Scene.Script
{
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] private AudioClip[] _bgmAudioClipArray = null;
    [SerializeField] private AudioClip[] _seAudioClipArray = null;

    public new ToffMonaka.Lib.Scene.SceneScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public SceneScript()
    {
        this._SetScriptType((int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SCENE);

        return;
    }

    /**
     * @brief _Awake関数
     */
    protected override void _Awake()
    {
        this._OnStartApplication();

        base._Awake();

        return;
    }

    /**
     * @brief _Destroy関数
     */
    protected override void _Destroy()
    {
        base._Destroy();

        this._OnEndApplication();

        return;
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.Lib.Scene.SceneScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _Active関数
     */
    protected override void _Active()
    {
        base._Active();

        return;
    }

    /**
     * @brief _Deactive関数
     */
    protected override void _Deactive()
    {
        base._Deactive();

        return;
    }

    /**
     * @brief _FirstUpdate関数
     */
    protected override void _FirstUpdate()
    {
        base._FirstUpdate();

        return;
    }

    /**
     * @brief _Update関数
     */
    protected override void _Update()
    {
        base._Update();

        return;
    }

    /**
     * @brief _FixedUpdate関数
     */
    protected override void _FixedUpdate()
    {
        base._FixedUpdate();

        return;
    }

    /**
     * @brief _LateUpdate関数
     */
    protected override void _LateUpdate()
    {
        base._LateUpdate();

        return;
    }

    /**
     * @brief _OnStartApplication関数
     */
    protected virtual void _OnStartApplication()
    {
        return;
    }

    /**
     * @brief _OnEndApplication関数
     */
    protected virtual void _OnEndApplication()
    {
        return;
    }

    /**
     * @brief GetMainCamera関数
     * @return main_camera (main_camera)
     */
    public Camera GetMainCamera()
    {
        return (this._mainCamera);
    }

    /**
     * @brief GetBgmAudioClipArray関数
     * @return bgm_audio_clip_ary (bgm_audio_clip_array)
     */
    public AudioClip[] GetBgmAudioClipArray()
    {
        return (this._bgmAudioClipArray);
    }

    /**
     * @brief GetSeAudioClipArray関数
     * @return se_audio_clip_ary (se_audio_clip_array)
     */
    public AudioClip[] GetSeAudioClipArray()
    {
        return (this._seAudioClipArray);
    }
}
}
