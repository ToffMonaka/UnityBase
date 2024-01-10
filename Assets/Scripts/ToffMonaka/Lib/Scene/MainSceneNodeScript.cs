/**
 * @file
 * @brief MainSceneNodeScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief MainSceneNodeScriptCreateDescクラス
 */
public class MainSceneNodeScriptCreateDesc : Lib.Scene.NodeScriptCreateDesc
{
}

/**
 * @brief MainSceneNodeScriptクラス
 */
public abstract class MainSceneNodeScript : Lib.Scene.NodeScript
{
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] private GameObject _inputNode = null;
    [SerializeField] private GameObject _graphicNode = null;
    [SerializeField] private GameObject _soundNode = null;
    [SerializeField] private GameObject _soundBgmNode = null;
    [SerializeField] private AudioClip[] _soundBgmAudioClipArray = null;
    [SerializeField] private GameObject _soundSeNode = null;
    [SerializeField] private AudioClip[] _soundSeAudioClipArray = null;

    public new Lib.Scene.MainSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     * @param node_script_index (node_script_index)
     */
    public MainSceneNodeScript(int node_script_index) : base(Lib.Util.SCENE.NODE_SCRIPT_TYPE.MAIN_SCENE, node_script_index, false)
    {
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
     * @brief _OnSetNode関数
     */
    protected override void _OnSetNode()
    {
        return;
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as Lib.Scene.MainSceneNodeScriptCreateDesc;

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
     * @brief GetSoundBgmNode関数
     * @return sound_bgm_node (sound_bgm_node)
     */
    public GameObject GetSoundBgmNode()
    {
        return (this._soundBgmNode);
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
     * @brief GetSoundSeNode関数
     * @return sound_se_node (sound_se_node)
     */
    public GameObject GetSoundSeNode()
    {
        return (this._soundSeNode);
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
