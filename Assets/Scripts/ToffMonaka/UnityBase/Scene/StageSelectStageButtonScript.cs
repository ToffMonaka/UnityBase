﻿/**
 * @file
 * @brief StageSelectStageButtonScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief StageSelectStageButtonScriptCreateDescクラス
 */
public class StageSelectStageButtonScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.StageSelectSubSceneScript stageSelectScript = null;
    public ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.NONE;
}

/**
 * @brief StageSelectStageButtonScriptクラス
 */
public class StageSelectStageButtonScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private Image _coverImage = null;

    public new ToffMonaka.UnityBase.Scene.StageSelectStageButtonScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.StageSelectSubSceneScript _stageSelectScript = null;
    private ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE _stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public StageSelectStageButtonScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.STAGE_SELECT_STAGE_BUTTON);

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
        this._stageSelectScript = this.createDesc.stageSelectScript;
        this._stageType = this.createDesc.stageType;

        this._nameText.SetText(ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_NAME_ARRAY[(int)this._stageType]);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.StageSelectStageButtonScriptCreateDesc;

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
        if (!this.IsControllable()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        this._stageSelectScript.RunStageButton(this._stageType);

        return;
    }

    /**
     * @brief OnPointerEnterEvent関数
     */
    public void OnPointerEnterEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        this._coverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnPointerExitEvent関数
     */
    public void OnPointerExitEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        this._coverImage.gameObject.SetActive(false);

        return;
    }
}
}
