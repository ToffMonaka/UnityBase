/**
 * @file
 * @brief DialogNodeScriptファイル
 */


using UnityEngine;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Dialog {
/**
 * @brief DialogNodeScriptCreateDescクラス
 */
public class DialogNodeScriptCreateDesc : ToffMonaka.Tml.Scene.ObjectNodeScriptCreateDesc
{
    /**
     * @brief GetPrefabFilePath関数
     * @return prefab_file_path (prefab_file_path)
     */
    public virtual string GetPrefabFilePath()
    {
        return (System.String.Empty);
    }

    /**
     * @brief GetNewScript関数
     * @param prefab_file_path (prefab_file_path)
     * @return script (script)
     */
    public virtual UnityBase.Scene.Ui.Dialog.DialogNodeScript GetNewScript(string prefab_file_path)
    {
        return (null);
    }
}

/**
 * @brief DialogNodeScriptクラス
 */
public abstract class DialogNodeScript : ToffMonaka.Tml.Scene.ObjectNodeScript
{
    [SerializeField] private CanvasGroup _canvasGroup = null;

    public new UnityBase.Scene.Ui.Dialog.DialogNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.DIALOG_NODE);
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

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Dialog.DialogNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Dialog.DialogNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

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
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

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
}
}
}
