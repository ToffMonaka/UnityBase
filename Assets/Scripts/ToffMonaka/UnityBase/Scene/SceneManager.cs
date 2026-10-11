/**
 * @file
 * @brief SceneManagerファイル
 */

namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief SceneManagerCreateDescクラス
 */
public class SceneManagerCreateDesc : ToffMonaka.Tml.Scene.SceneManagerCreateDesc
{
}

/**
 * @brief SceneManagerクラス
 */
public class SceneManager : ToffMonaka.Tml.Scene.SceneManager
{
    public new SceneManagerCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public SceneManager()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
        base.Init();

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
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.SceneManagerCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new SceneManagerCreateDesc());

            return;
        }

	    this.createDesc = create_desc as SceneManagerCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief GetMainSceneNodeScript関数
     * @return main_scene_node_script (main_scene_node_script)
     */
    public new MainSceneNodeScript GetMainSceneNodeScript()
    {
        return (base.GetMainSceneNodeScript() as MainSceneNodeScript);
    }

    /**
     * @brief GetSubSceneNodeScript関数
     * @return sub_scene_node_script (sub_scene_node_script)
     */
    public new SubSceneNodeScript GetSubSceneNodeScript()
    {
        return (base.GetSubSceneNodeScript() as SubSceneNodeScript);
    }
}
}
}
