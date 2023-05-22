/**
 * @file
 * @brief SelectSubSceneStageButtonScriptファイル
 */


using UnityEngine;
using TMPro;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief SelectSubSceneStageButtonCreateDescクラス
 */
public class SelectSubSceneStageButtonCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.SelectSubSceneScript selectSubSceneScript = null;
    public int index = 0;
    public string name = "";
}

/**
 * @brief SelectSubSceneStageButtonScriptクラス
 */
public class SelectSubSceneStageButtonScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private TextMeshProUGUI _nameText = null;

    public new ToffMonaka.UnityBase.Scene.SelectSubSceneStageButtonCreateDesc createDesc{get; private set;} = null;
    private ToffMonaka.UnityBase.Scene.SelectSubSceneScript _selectSubSceneScript = null;
    private int _index = 0;

    /**
     * @brief コンストラクタ
     */
    public SelectSubSceneStageButtonScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.SELECT_SUB_SCENE_STAGE_BUTTON);

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
        this._selectSubSceneScript = this.createDesc.selectSubSceneScript;
        this._index = this.createDesc.index;
        this._nameText.SetText(this.createDesc.name);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.SelectSubSceneStageButtonCreateDesc;

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
        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        this.CompleteOpen();

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
        this.CompleteClose();

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
     * @brief OnPointerClickEvent関数
     */
    public void OnPointerClickEvent()
    {
        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        this._selectSubSceneScript.SetStageItemSelectIndex(this._index);

        this._selectSubSceneScript.Close(1);

        return;
    }
}
}
