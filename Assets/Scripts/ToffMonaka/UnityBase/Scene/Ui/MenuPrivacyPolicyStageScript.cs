/**
 * @file
 * @brief MenuPrivacyPolicyStageScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief MenuPrivacyPolicyStageScriptCreateDescクラス
 */
public class MenuPrivacyPolicyStageScriptCreateDesc : UnityBase.Scene.Ui.MenuStageScriptCreateDesc
{
}

/**
 * @brief MenuPrivacyPolicyStageScriptクラス
 */
public class MenuPrivacyPolicyStageScript : UnityBase.Scene.Ui.MenuStageScript
{
    [SerializeField] private ScrollRect _messageScrollRect = null;
    [SerializeField] private GameObject _messageNode = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new UnityBase.Scene.Ui.MenuPrivacyPolicyStageScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public MenuPrivacyPolicyStageScript()
    {
        this._SetScriptIndex((int)UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_PRIVACY_POLICY_STAGE);
        this._SetStageType(UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.PRIVACY_POLICY);

        return;
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
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        if (base._OnCreate() < 0) {
            return (-1);
        }

        this._messageNode.SetActive(false);

        {// MessageNode Create
            var en_str_ary = new string[]{
                "Application\n" +
                "\n" +
                "Toff Monaka built the Unity Base app as a Free app. This Service is provided by Toff Monaka at no cost and is intended for use as is.\n" +
                "This page is used to inform visitors regarding my policies with the collection, use, and disclosure of Personal Information if anyone decided to use my Service.\n" +
                "If you choose to use my Service, then you agree to the collection and use of information in relation to this policy. The Personal Information that I collect is used for providing and improving the Service. I will not use or share your information with anyone except as described in this Privacy Policy.\n" +
                "The terms used in this Privacy Policy have the same meanings as in our Terms and Conditions, which are accessible at Unity Base unless otherwise defined in this Privacy Policy.\n" +
                "\n" +
                "\n" +
                "Information Collection and Use\n" +
                "\n" +
                "For a better experience, while using our Service, I may require you to provide us with certain personally identifiable information, including but not limited to Play data. The information that I request will be retained on your device and is not collected by me in any way.\n" +
                "The app does use third-party services that may collect information used to identify you.\n" +
                "Link to the privacy policy of third-party service providers used by the app\n" +
                "  ・Google Play Services\n" +
                "  ・Unity\n" +
                "\n" +
                "\n" +
                "Log Data\n" +
                "\n" +
                "I want to inform you that whenever you use my Service, in a case of an error in the app I collect data and information (through third-party products) on your phone called Log Data. This Log Data may include information such as your device Internet Protocol(IP) address, device name, operating system version, the configuration of the app when utilizing my Service, the time and date of your use of the Service, and other statistics.\n" +
                "\n" +
                "\n" +
                "Cookies\n" +
                "\n" +
                "Cookies are files with a small amount of data that are commonly used as anonymous unique identifiers. These are sent to your browser from the websites that you visit and are stored on your device's internal memory.\n" +
                "This Service does not use these Cookies explicitly. However, the app may use third-party code and libraries that use Cookies to collect information and improve their services. You have the option to either accept or refuse these Cookies and know when a Cookies are being sent to your device. If you choose to refuse our Cookies, you may not be able to use some portions of this Service.\n" +
                "\n" +
                "\n" +
                "Service Providers\n" +
                "\n" +
                "I may employ third-party companies and individuals due to the following reasons\n" +
                "  ・To facilitate our Service\n" +
                "  ・To provide the Service on our behalf\n" +
                "  ・To perform Service-related services\n" +
                "  ・To assist us in analyzing how our Service is used\n" +
                "\n" +
                "I want to inform users of this Service that these third parties have access to their Personal Information. The reason is to perform the tasks assigned to them on our behalf. However, they are obligated not to disclose or use the information for any other purpose.\n" +
                "\n" +
                "\n" +
                "Security\n" +
                "\n" +
                "I value your trust in providing us your Personal Information, thus we are striving to use commercially acceptable means of protecting it. But remember that no method of transmission over the internet, or method of electronic storage is 100% secure and reliable, and I cannot guarantee its absolute security.\n" +
                "\n" +
                "\n" +
                "Links to Other Sites\n" +
                "\n" +
                "This Service may contain links to other sites. If you click on a third-party link, you will be directed to that site. Note that these external sites are not operated by me. Therefore, I strongly advise you to review the Privacy Policy of these websites. I have no control over and assume no responsibility for the content, privacy policies, or practices of any third-party sites or services.\n" +
                "\n" +
                "\n" +
                "Children's Privacy\n" +
                "\n" +
                "These Services do not address anyone under the age of 13. I do not knowingly collect personally identifiable information from children under 13 years of age. In the case I discover that a child under 13 has provided me with personal information, I immediately delete this from our servers. If you are a parent or guardian and you are aware that your child has provided us with personal information, please contact me so that I will be able to do the necessary actions.\n" +
                "\n" +
                "\n" +
                "Changes to Privacy Policy\n" +
                "\n" +
                "I may update our Privacy Policy from time to time. Thus, you are advised to review this page periodically for any changes. I will notify you of any changes by posting the new Privacy Policy on this page.\n" +
                "This policy is effective as of 2023-07-24\n" +
                "\n" +
                "\n" +
                "Contact Us\n" +
                "\n" +
                "If you have any questions about my Privacy Policy, do not hesitate to contact me at toff.monaka@gmail.com."
            };
            var jp_str_ary = new string[]{
                "アプリケーション\n" +
                "\n" +
                "Toff Monakaは、Unity Baseアプリを無料アプリとして構築しました。本サービスはToff Monakaによって無料で提供され、現状のまま使用することを目的としています。\n" +
                "このページは、誰かが私のサービスを使用することを決めた場合に、個人情報の収集、使用、開示に関する私のポリシーについて訪問者に通知するために使用されます。\n" +
                "私のサービスを使用することを選択した場合、このポリシーに関連した情報の収集と使用に同意したことになります。私が収集した個人情報は、サービスの提供と改善のために使用されます。このプライバシー ポリシーに記載されている場合を除き、私はあなたの情報を使用したり、誰かと共有したりすることはありません。\n" +
                "このプライバシー ポリシーで使用される用語は、当社の利用規約と同じ意味を持ち、このプライバシー ポリシーで別途定義されていない限り、Unity Baseからアクセスできます。\n" +
                "\n" +
                "\n" +
                "情報の収集と利用\n" +
                "\n" +
                "より良いエクスペリエンスを提供するために、当社のサービスをご利用いただく際に、Playデータを含む(ただしこれに限定されない)特定の個人を特定できる情報の提供をお客様に求める場合があります。私が要求した情報はあなたのデバイスに保存され、私によって収集されることはありません。\n" +
                "このアプリは、お客様を特定するために使用される情報を収集する可能性のあるサードパーティのサービスを使用します。\n" +
                "アプリで使用されるサードパーティサービスプロバイダーのプライバシーポリシーへのリンク\n" +
                "  ・Google Play Services\n" +
                "  ・Unity\n" +
                "\n" +
                "\n" +
                "ログデータ\n" +
                "\n" +
                "あなたが私のサービスを使用するたびに、アプリでエラーが発生した場合、私はあなたの携帯電話上でログデータと呼ばれるデータと情報を（サードパーティ製品を通じて）収集することをお知らせしたいと思います。このログデータには、デバイスのインターネットプロトコル(IP)アドレス、デバイス名、オペレーティングシステムのバージョン、サービス利用時のアプリの構成、サービスの使用日時、その他の統計などの情報が含まれる場合があります。\n" +
                "\n" +
                "\n" +
                "Cookie\n" +
                "\n" +
                "Cookieは、匿名の一意の識別子として一般に使用される少量のデータを含むファイルです。これらは、アクセスしたWebサイトからブラウザに送信され、デバイスの内部メモリに保存されます。\n" +
                "本サービスはこれらのCookieを明示的に使用しません。ただし、アプリは情報を収集しサービスを向上させるためにCookieを使用するサードパーティのコードとライブラリを使用する場合があります。これらのCookieを受け入れるか拒否するかを選択でき、Cookieがいつデバイスに送信されるかを知ることができます。当社のCookieを拒否することを選択した場合、本サービスの一部を使用できなくなる場合があります。\n" +
                "\n" +
                "\n" +
                "サービスプロバイダー\n" +
                "\n" +
                "私は、次の理由により、サードパーティの企業や個人を雇用する場合があります。\n" +
                "   ・当社のサービスを促進するため。\n" +
                "   ・当社に代わってサービスを提供するため。\n" +
                "   ・サービス関連サービスを実行するため。\n" +
                "   ・当社のサービスがどのように使用されているかの分析を支援するため。\n" +
                "\n" +
                "本サービスのユーザーに、これらの第三者がユーザーの個人情報にアクセスできることを知らせたいと思います。その理由は、私たちに代わって彼らに割り当てられたタスクを実行するためです。ただし、他の目的で情報を開示または使用しない義務があります。\n" +
                "\n" +
                "\n" +
                "セキュリティ\n" +
                "\n" +
                "私はお客様の信頼を大切に個人情報を提供していただくため、商業的に許容される個人情報の保護手段を使用するよう努めています。ただし、インターネット上の送信方法や電子保存方法は100%安全で信頼できるものではなく、その絶対的な安全性を保証することはできないことを覚えておいてください。\n" +
                "\n" +
                "\n" +
                "他のサイトへのリンク\n" +
                "\n" +
                "本サービスには他のサイトへのリンクが含まれる場合があります。サードパーティのリンクをクリックすると、そのサイトに移動します。これらの外部サイトは私が運営しているものではないことに注意してください。したがって、これらのWebサイトのプライバシー ポリシーを確認することを強くお勧めします。私は、第三者のサイトやサービスのコンテンツ、プライバシー ポリシー、慣行を管理することはできず、責任を負いません。\n" +
                "\n" +
                "\n" +
                "子供のプライバシー\n" +
                "\n" +
                "これらのサービスは13歳未満には対応しません。私は、13歳未満の子供から故意に個人を特定できる情報を収集しません。13歳未満の子供が私に個人情報を提供したことが判明した場合、私はこれを当社のサーバーから直ちに削除します。あなたが親または保護者で、お子様が当社に個人情報を提供したことをご存じの場合は、必要な措置を講じることができるよう、私にご連絡ください。\n" +
                "\n" +
                "\n" +
                "プライバシーポリシーの変更\n" +
                "\n" +
                "当社のプライバシーポリシーは随時更新される場合があります。したがって、変更がないか定期的にこのページを確認することをお勧めします。変更があった場合は、このページに新しいプライバシー ポリシーを掲載してお知らせします。\n" +
                "このポリシーは2023年7月24日から発効します。\n" +
                "\n" +
                "\n" +
                "お問い合わせ\n" +
                "\n" +
                "私のプライバシーポリシーについてご質問がございましたら、お気軽にtoff.monaka@gmail.comまでご連絡ください。"
            };
            string[] str_ary;

		    switch (UnityBase.Global.systemConfigFile.data.systemLanguageType) {
		    case UnityBase.Constant.Util.LANGUAGE_TYPE.JAPANESE: {
                str_ary = jp_str_ary;

			    break;
		    }
		    default: {
                str_ary = en_str_ary;

			    break;
		    }
		    }

            for (int str_i = 0; str_i < str_ary.Length; ++str_i) {
                var str = (str_i <= 0) ? str_ary[str_i] : "\n" + str_ary[str_i];

                var node = GameObject.Instantiate(this._messageNode, this._messageNode.transform.parent);

                node.GetComponent<TMP_Text>().SetText(str);

                node.SetActive(true);
            }
        }

        this._cancelButtonNameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.MST_STRING_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.MenuPrivacyPolicyStageScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        this._messageScrollRect.verticalNormalizedPosition = 1.0f;
        this._cancelButtonCoverImage.gameObject.SetActive(false);

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

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        base._OnUpdateOpen();

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
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        base._OnUpdateClose();

        return;
    }

    /**
     * @brief OnCancelButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);

        this.GetMenuScript().RunStageCancelButton();

        return;
    }

    /**
     * @brief OnCancelButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._cancelButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCancelButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerExit(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._cancelButtonCoverImage.gameObject.SetActive(false);

        return;
    }
}
}
}
