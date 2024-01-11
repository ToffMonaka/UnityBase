/**
 * @file
 * @brief InputDialogEngineファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief InputDialogEngineクラス
 */
public abstract class InputDialogEngine
{
    /**
     * @brief コンストラクタ
     */
    public InputDialogEngine()
    {
        return;
    }

    /**
     * @brief OnGetName関数
     * @return name (name)
     */
    public virtual string OnGetName()
    {
        return (System.String.Empty);
    }

    /**
     * @brief OnGetOkButtonFlag関数
     * @return ok_btn_flg (ok_button_flag)
     */
    public virtual bool OnGetOkButtonFlag()
    {
        return (false);
    }

    /**
     * @brief OnClickOkButton関数
     * @param dialog_node_script (dialog_node_script)
     */
    public virtual void OnClickOkButton(UnityBase.Scene.Ui.InputDialogNodeScript dialog_node_script)
    {
        return;
    }
}
}
}
