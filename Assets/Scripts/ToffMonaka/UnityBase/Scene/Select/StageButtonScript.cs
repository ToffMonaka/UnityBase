/**
 * @file
 * @brief StageButtonScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Select {
/**
 * @brief StageButtonScriptCreateDescクラス
 */
public class StageButtonScriptCreateDesc : Lib.Scene.ObjectScriptCreateDesc
{
    public UnityBase.Scene.Select.StageBoardScript boardScript = null;
    public UnityBase.Constant.Util.SCENE.STAGE_TYPE stageType = UnityBase.Constant.Util.SCENE.STAGE_TYPE.NONE;
}

/**
 * @brief StageButtonScriptクラス
 */
public class StageButtonScript : Lib.Scene.ObjectScript, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private Image _coverImage = null;

    public new UnityBase.Scene.Select.StageButtonScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Select.StageBoardScript _boardScript = null;
    private UnityBase.Constant.Util.SCENE.STAGE_TYPE _stageType = UnityBase.Constant.Util.SCENE.STAGE_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public StageButtonScript()
    {
        this._SetScriptIndex((int)UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.SELECT_STAGE_BUTTON);

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
        this._boardScript = this.createDesc.boardScript;
        this._stageType = this.createDesc.stageType;

        this._nameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.SCENE.STAGE_NAME_MST_STRING_ID_ARRAY[(int)this._stageType]));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Select.StageButtonScriptCreateDesc;

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

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        this._boardScript.RunStageButton(this._stageType);

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
        if (!this.IsControllable()) {
            return;
        }

        this._coverImage.gameObject.SetActive(false);

        return;
    }
}
}
}
