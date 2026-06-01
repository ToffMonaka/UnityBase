/**
 * @file
 * @brief MainSceneNodeScriptファイル
 */

using UnityEngine;

namespace ToffMonaka {
namespace Tml.Scene {
/**
 * @brief MainSceneNodeScriptCreateDescクラス
 */
public class MainSceneNodeScriptCreateDesc : NodeScriptCreateDesc
{
}

/**
 * @brief MainSceneNodeScriptクラス
 */
public abstract class MainSceneNodeScript : NodeScript
{
    [SerializeField] private GameObject _inputNode = null;
    [SerializeField] private GameObject _graphicNode = null;
    [SerializeField] private GameObject _soundNode = null;
    [SerializeField] private AudioClip[] _soundBgmAudioClipArray = null;
    [SerializeField] private AudioClip[] _soundSeAudioClipArray = null;

    public new MainSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptType関数
     * @return script_type (script_type)
     */
    protected override sealed Util.SCENE.SCRIPT_TYPE _OnGetScriptType()
    {
        return (Util.SCENE.SCRIPT_TYPE.MAIN_SCENE_NODE);
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)Util.SCENE.SCRIPT_INDEX.MAIN_SCENE_NODE);
    }

    /**
     * @brief _OnGetActiveAutoFlag関数
     * @return active_auto_flg (active_auto_flag)
     */
    protected override sealed bool _OnGetActiveAutoFlag()
    {
        return (false);
    }

    /**
     * @brief _Awake関数
     */
    protected override void _Awake()
    {
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
     * @brief _Start関数
     */
    protected override void _Start()
    {
        this._OnStartApplication();

        base._Start();

        return;
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new MainSceneNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as MainSceneNodeScriptCreateDesc;

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
     * @brief GetInputNode関数
     * @return input_node (input_node)
     */
    public GameObject GetInputNode()
    {
        return (this._inputNode);
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
     * @brief GetSoundBgmAudioClipArray関数
     * @return sound_bgm_audio_clip_ary (sound_bgm_audio_clip_array)
     */
    public AudioClip[] GetSoundBgmAudioClipArray()
    {
        return (this._soundBgmAudioClipArray);
    }

    /**
     * @brief GetSoundSeAudioClipArray関数
     * @return sound_se_audio_clip_ary (sound_se_audio_clip_array)
     */
    public AudioClip[] GetSoundSeAudioClipArray()
    {
        return (this._soundSeAudioClipArray);
    }
}
}
}
