/**
 * @file
 * @brief PrivacyPolicyMessageUtilファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu {
/**
 * @brief PrivacyPolicyMessageUtilクラス
 */
public static class PrivacyPolicyMessageUtil
{
    public static readonly string[] ENGLISH_TEXT_ARRAY = {
        "Privacy Policy\n" +
        "\n" +
        "This privacy policy applies to the Unity Base app (hereby referred to as \"Application\") for mobile devices that was created by Toff Monaka (hereby referred to as \"Service Provider\") as a Free service. This service is intended for use \"AS IS\".\n" +
        "\n" +
        "\n" +
        "Information Collection and Use\n" +
        "\n" +
        "The Application collects information when you download and use it. This information may include information such as\n" +
        " ・Your device's Internet Protocol address (e.g. IP address)\n" +
        " ・The pages of the Application that you visit, the time and date of your visit, the time spent on those pages\n" +
        " ・The time spent on the Application\n" +
        " ・The operating system you use on your mobile device\n" +
        "\n" +
        "The Application does not gather precise information about the location of your mobile device.\n" +
        "The Service Provider may use the information you provided to contact you from time to time to provide you with important information, required notices and marketing promotions.\n" +
        "For a better experience, while using the Application, the Service Provider may require you to provide us with certain personally identifiable information. The information that the Service Provider request will be retained by them and used as described in this privacy policy.\n" +
        "\n" +
        "\n" +
        "Third Party Access\n" +
        "\n" +
        "Only aggregated, anonymized data is periodically transmitted to external services to aid the Service Provider in improving the Application and their service. The Service Provider may share your information with third parties in the ways that are described in this privacy statement.\n" +
        "Please note that the Application utilizes third-party services that have their own Privacy Policy about handling data. Below are third-party service used by the Application:\n" +
        " ・Google Play Services\n" +
        " ・Unity\n" +
        "\n" +
        "The Service Provider may disclose User Provided and Automatically Collected Information:\n" +
        " ・as required by law, such as to comply with a subpoena, or similar legal process;\n" +
        " ・when they believe in good faith that disclosure is necessary to protect their rights, protect your safety or the safety of others, investigate fraud, or respond to a government request;\n" +
        " ・with their trusted services providers who work on their behalf, do not have an independent use of the information we disclose to them, and have agreed to adhere to the rules set forth in this privacy statement.\n" +
        "\n" +
        "\n" +
        "Opt-Out Rights\n" +
        "\n" +
        "You can stop all collection of information by the Application easily by uninstalling it. You may use the standard uninstall processes as may be available as part of your mobile device or via the mobile application marketplace or network.\n" +
        "\n" +
        "\n" +
        "Data Retention Policy\n" +
        "\n" +
        "The Service Provider will retain User Provided data for as long as you use the Application and for a reasonable time thereafter. If you'd like them to delete User Provided Data that you have provided via the Application, please contact them at the Service Provider and they will respond in a reasonable time.\n" +
        "\n" +
        "\n" +
        "Children\n" +
        "\n" +
        "The Service Provider does not use the Application to knowingly solicit data from or market to children under the age of 13.\n" +
        "The Application does not address anyone under the age of 13. The Service Provider does not knowingly collect personally identifiable information from children under 13 years of age. In the case the Service Provider discover that a child under 13 has provided personal information, the Service Provider will immediately delete this from their servers. If you are a parent or guardian and you are aware that your child has provided us with personal information, please contact the Service Provider so that they will be able to take the necessary actions.\n" +
        "\n" +
        "\n" +
        "Security\n" +
        "\n" +
        "The Service Provider is concerned about safeguarding the confidentiality of your information. The Service Provider provides physical, electronic, and procedural safeguards to protect information the Service Provider processes and maintains.\n" +
        "\n" +
        "\n" +
        "Changes\n" +
        "\n" +
        "This Privacy Policy may be updated from time to time for any reason. The Service Provider will notify you of any changes to the Privacy Policy by updating this page with the new Privacy Policy. You are advised to consult this Privacy Policy regularly for any changes, as continued use is deemed approval of all changes.\n" +
        "This privacy policy is effective as of 2024-05-10\n" +
        "\n" +
        "\n" +
        "Your Consent\n" +
        "\n" +
        "By using the Application, you are consenting to the processing of your information as set forth in this Privacy Policy now and as amended by us.\n" +
        "\n" +
        "\n" +
        "Contact Us\n" +
        "\n" +
        "If you have any questions regarding privacy while using the Application, or have questions about the practices, please contact the Service Provider via email at toff.monaka@gmail.com."
    };
    public static readonly string[] JAPANESE_TEXT_ARRAY = {
        "プライバシーポリシー\n" +
        "\n" +
        "このプライバシーポリシーは、Toff Monaka(以下「サービスプロバイダー」)が無料サービスとして作成したモバイルデバイス用のUnity Base(以下「アプリケーション」)に適用されます。このサービスは「現状のまま」使用することを目的としています。\n" +
        "\n" +
        "\n" +
        "情報の収集と利用\n" +
        "\n" +
        "アプリケーションは、ダウンロードして使用するときに情報を収集します。この情報には、次のような情報が含まれる場合があります。\n" +
        " ・デバイスのインターネットプロトコルアドレス(IPアドレスなど)\n" +
        " ・お客様が訪問したアプリケーションのページ、訪問日時、それらのページに費やした時間\n" +
        " ・アプリケーションに費やした時間\n" +
        " ・モバイルデバイスで使用しているオペレーティングシステム\n" +
        "\n" +
        "アプリケーションは、モバイルデバイスの位置に関する正確な情報を収集しません。\n" +
        "サービスプロバイダーは、重要な情報、必要な通知、マーケティングプロモーションを提供するために、お客様が提供した情報を使用して随時お客様に連絡する場合があります。\n" +
        "より良いエクスペリエンスを実現するために、アプリケーションの使用中に、サービスプロバイダーはお客様に特定の個人を特定できる情報の提供を要求する場合があります。サービスプロバイダーが要求した情報はサービスプロバイダーによって保持され、このプライバシーポリシーに記載されているように使用されます。\n" +
        "\n" +
        "\n" +
        "サードパーティのアクセス\n" +
        "\n" +
        "サービスプロバイダーによるアプリケーションとそのサービスの改善を支援するために、集約され匿名化されたデータのみが外部サービスに定期的に送信されます。サービスプロバイダーは、このプライバシーに関する声明に記載されている方法で、お客様の情報を第三者と共有する場合があります。\n" +
        "本アプリケーションは、データの取り扱いに関して独自のプライバシーポリシーを持つサードパーティのサービスを利用していることに注意してください。以下は、アプリケーションで使用されるサードパーティサービスです。\n" +
        " ・Google Play Services\n" +
        " ・Unity\n" +
        "\n" +
        "サービスプロバイダーは、ユーザーが提供した情報および自動的に収集された情報を開示する場合があります。\n" +
        " ・召喚状または同様の法的手続きに従うなど、法律で要求される場合。\n" +
        " ・自分の権利を守り、自分や他人の安全を守り、詐欺を調査し、または政府の要請に応えるために開示が必要であると誠意を持って信じている場合。\n" +
        " ・彼らの信頼できるサービスプロバイダーは、彼らに代わって働き、当社が彼らに開示する情報を独自に使用することはなく、このプライバシーステートメントに記載されている規則を遵守することに同意しています。\n" +
        "\n" +
        "\n" +
        "オプトアウトの権利\n" +
        "\n" +
        "アプリケーションをアンインストールすることで、アプリケーションによるすべての情報収集を簡単に停止できます。モバイルデバイスの一部として、またはモバイルアプリケーションマーケットプレイスやネットワーク経由で利用できる標準のアンインストールプロセスを使用できます。\n" +
        "\n" +
        "\n" +
        "データ保持\n" +
        "\n" +
        "サービスプロバイダーは、ユーザーがアプリケーションを使用している間およびその後の合理的な期間、ユーザー提供のデータを保持します。アプリケーション経由で提供したユーザー提供データの削除を希望する場合は、サービスプロバイダーまでご連絡ください。適切な時間内に対応させていただきます。\n" +
        "\n" +
        "\n" +
        "お子様の情報\n" +
        "\n" +
        "サービスプロバイダーは、13歳未満の子供に対して故意にデータを要求したり、子供に売り込んだりするためにアプリケーションを使用しません。\n" +
        "アプリケーションは、13歳未満には対応していません。サービスプロバイダーは、13歳未満の子供から故意に個人を特定できる情報を収集しません。13歳未満の子供が個人情報を提供したことをサービスプロバイダーが発見した場合、サービスプロバイダーはこれをサーバーから直ちに削除します。お客様が親または保護者で、お子様が当社に個人情報を提供したことに気づいている場合は、必要な措置を講じられるよう、サービスプロバイダーまでご連絡ください。\n" +
        "\n" +
        "\n" +
        "セキュリティ\n" +
        "\n" +
        "サービスプロバイダーは、お客様の情報の機密性の保護に配慮しています。サービスプロバイダーは、サービスプロバイダーが処理および維持する情報を保護するために、物理的、電子的、および手続き上の保護手段を提供します。\n" +
        "\n" +
        "\n" +
        "プライバシーポリシーの変更\n" +
        "\n" +
        "このプライバシーポリシーは、理由の如何を問わず、随時更新される場合があります。サービスプロバイダーは、このページを新しいプライバシーポリシーで更新することにより、プライバシーポリシーの変更をお客様に通知します。継続して使用するとすべての変更が承認されたものとみなされますので、変更については定期的にこのプライバシーポリシーを参照することをお勧めします。\n" +
        "このプライバシーポリシーは、2024年5月10日から発効します。\n" +
        "\n" +
        "\n" +
        "お客様の同意\n" +
        "\n" +
        "アプリケーションを使用することにより、お客様は、このプライバシーポリシーに現在規定されている通り、および当社によって修正された通りに、お客様の情報が処理されることに同意したものとみなされます。\n" +
        "\n" +
        "\n" +
        "お問い合わせ\n" +
        "\n" +
        "アプリケーションの使用中にプライバシーに関するご質問がある場合、またはその慣行についてご質問がある場合は、電子メール(toff.monaka@gmail.com)でサービスプロバイダーにお問い合わせください。"
    };
}
}
}
