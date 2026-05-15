/**
 * @file
 * @brief SimpleCoverNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Cover {
/**
 * @brief SimpleCoverNodeScriptCreateDescクラス
 */
public class SimpleCoverNodeScriptCreateDesc : UnityBase.Scene.Ui.Cover.CoverNodeScriptCreateDesc
{
    public Color32 color = new Color32(0, 0, 0, 255);
    public float playTime = 1.0f;
    public float waitTime = 1.0f;
    public bool reverseFlag = false;

    /**
     * @brief GetPrefabFilePath関数
     * @return prefab_file_path (prefab_file_path)
     */
    public override string GetPrefabFilePath()
    {
        return (UnityBase.Util.FILE_PATH.SIMPLE_COVER_PREFAB);
    }

    /**
     * @brief GetNewScript関数
     * @param prefab_file_path (prefab_file_path)
     * @return script (script)
     */
    public override UnityBase.Scene.Ui.Cover.CoverNodeScript GetNewScript(string prefab_file_path)
    {
        var node = Lib.Scene.Util.GetPrefabNode(prefab_file_path);

        return (node.GetComponent<UnityBase.Scene.Ui.Cover.SimpleCoverNodeScript>());
    }
}

/**
 * @brief SimpleCoverNodeScriptクラス
 */
public class SimpleCoverNodeScript : UnityBase.Scene.Ui.Cover.CoverNodeScript
{
    [SerializeField] private Image _coverImage = null;

    public new UnityBase.Scene.Ui.Cover.SimpleCoverNodeScriptCreateDesc createDesc{get; private set;} = null;

    private Color32 _color = new Color32(0, 0, 0, 255);
    private float _playTime = 1.0f;
    private float _waitTime = 1.0f;
    private bool _reverseFlag = false;
    private Sequence _sequence = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SIMPLE_COVER_NODE);
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

        this._color = this.createDesc.color;
        this._playTime = this.createDesc.playTime;
        this._waitTime = this.createDesc.waitTime;
        this._reverseFlag = this.createDesc.reverseFlag;

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Cover.SimpleCoverNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Cover.SimpleCoverNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
    {
        base._OnDeactive();

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        base._OnOpen();

        this._sequence = DOTween.Sequence();

        if (!this._reverseFlag) {
            this._coverImage.color = new Color32(this._color.r, this._color.g, this._color.b, 255);

            this._sequence.AppendInterval(this._waitTime);
            this._sequence.Append(this._coverImage.DOFade(0.0f, this._playTime));
        } else {
            this._coverImage.color = new Color32(this._color.r, this._color.g, this._color.b, 0);

            this._sequence.Append(this._coverImage.DOFade(1.0f, this._playTime));
            this._sequence.AppendInterval(this._waitTime);
        }

        this._sequence.SetLink(this.gameObject);

        return;
    }

    /**
     * @brief _OnOpened関数
     */
    protected override void _OnOpened()
    {
        base._OnOpened();

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
     * @brief _OnClosed関数
     */
    protected override void _OnClosed()
    {
        base._OnClosed();

        return;
    }

    /**
     * @brief IsPlay関数
     * @return play_flg (play_flag)<br>
     * false=非プレイ,true=プレイ
     */
    public override bool IsPlay()
    {
        return ((this._sequence != null) ? this._sequence.IsActive() : false);
    }
}
}
}
