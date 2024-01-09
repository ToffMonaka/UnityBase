/**
 * @file
 * @brief SelectDialogItemButtonScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief SelectDialogItemButtonScriptCreateDescクラス
 */
public class SelectDialogItemButtonScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
    public UnityBase.Scene.Ui.SelectDialogItemButtonEngine engine = null;
    public System.Action<UnityBase.Scene.Ui.SelectDialogItemButtonScript> onClick = null;
}

/**
 * @brief SelectDialogItemButtonScriptクラス
 */
public class SelectDialogItemButtonScript : Lib.Scene.ObjectNodeScript, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private Image _coverImage = null;

    public new UnityBase.Scene.Ui.SelectDialogItemButtonScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.SelectDialogItemButtonEngine _engine = null;
    private System.Action<UnityBase.Scene.Ui.SelectDialogItemButtonScript> _onClick = null;

    /**
     * @brief コンストラクタ
     */
    public SelectDialogItemButtonScript() : base((int)UnityBase.Util.SCENE.NODE_SCRIPT_INDEX.SELECT_DIALOG_ITEM_BUTTON)
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
        if (this.createDesc.engine == null) {
            return (-1);
        }

        this._engine = this.createDesc.engine;

        this._onClick = this.createDesc.onClick;

        this._nameText.SetText(this._engine.OnGetName());

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.SelectDialogItemButtonScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        this._coverImage.gameObject.SetActive(false);

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
        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        this.CompleteOpen();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        this.CompleteClose();

        return;
    }

    /**
     * @brief OnPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this._onClick(this);

        return;
    }

    /**
     * @brief OnPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._coverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnPointerExit(PointerEventData event_dat)
    {
        this._coverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief GetEngine関数
     * @return engine (engine)
     */
    public UnityBase.Scene.Ui.SelectDialogItemButtonEngine GetEngine()
    {
        return (this._engine);
    }
}
}
}
