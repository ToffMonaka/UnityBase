/**
 * @file
 * @brief DialogScriptファイル
 */


using UnityEngine;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief DialogScriptCreateDescクラス
 */
public class DialogScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
}

/**
 * @brief DialogScriptクラス
 */
public class DialogScript : Lib.Scene.ObjectNodeScript
{
    [SerializeField] private CanvasGroup _canvasGroup = null;

    public new UnityBase.Scene.Ui.DialogScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     * @param script_index (script_index)
     */
    public DialogScript(int script_index) : base(script_index)
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
	    this.createDesc = create_desc as UnityBase.Scene.Ui.DialogScriptCreateDesc;

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
		switch (this.GetOpenType()) {
		case 1: {
            this._canvasGroup.alpha = 0.0f;

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(this._canvasGroup.DOFade(1.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            this._canvasGroup.alpha = 1.0f;

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteOpen();
        }

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
		switch (this.GetCloseType()) {
		case 1: {
            this._canvasGroup.alpha = 1.0f;

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(this._canvasGroup.DOFade(0.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            this._canvasGroup.alpha = 0.0f;

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteClose();
        }

        return;
    }
}
}
}
