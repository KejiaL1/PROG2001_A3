using UnityEngine;
using UnityEngine.UI;

public class KeyUIController : MonoBehaviour
{
    // �ֱ��� Inspector �︳ֵ��Ӧ�� UI Image ���
    public Image WKeyImage;
    public Image AKeyImage;
    public Image SKeyImage;
    public Image DKeyImage;
    public Image SpaceKeyImage;

    // ����������͸��״̬����ɫ
    // ���磺normalColor Ϊ��ȫ��͸����transparentColor Ϊ��͸�����ɸ�����Ҫ���� alpha ֵ��
    public Color normalColor = new Color(1f, 1f, 1f, 1f);
    public Color transparentColor = new Color(1f, 1f, 1f, 0.5f);

    void Update()
    {
        // ���� W ������Ϊ��͸��������ָ���͸��
        WKeyImage.color = Input.GetKey(KeyCode.W) ? transparentColor : normalColor;
        // ���� A ������Ϊ��͸��������ָ���͸��
        AKeyImage.color = Input.GetKey(KeyCode.A) ? transparentColor : normalColor;
        // ���� S ������Ϊ��͸��������ָ���͸��
        SKeyImage.color = Input.GetKey(KeyCode.S) ? transparentColor : normalColor;
        // ���� D ������Ϊ��͸��������ָ���͸��
        DKeyImage.color = Input.GetKey(KeyCode.D) ? transparentColor : normalColor;
        // ���� �ո� ������Ϊ��͸��������ָ���͸��
        SpaceKeyImage.color = Input.GetKey(KeyCode.Space) ? transparentColor : normalColor;
    }
}
