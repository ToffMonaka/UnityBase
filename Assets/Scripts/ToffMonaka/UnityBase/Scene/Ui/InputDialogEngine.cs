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
     * @param dialog_script (dialog_script)
     */
    public virtual void OnClickOkButton(UnityBase.Scene.Ui.InputDialogScript dialog_script)
    {
        return;
    }
}
}
}
