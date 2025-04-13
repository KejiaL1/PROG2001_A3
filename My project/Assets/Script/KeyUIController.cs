using UnityEngine;
using UnityEngine.UI;

public class KeyUIController : MonoBehaviour
{
    // 分别在 Inspector 里赋值对应的 UI Image 组件
    public Image WKeyImage;
    public Image AKeyImage;
    public Image SKeyImage;
    public Image DKeyImage;
    public Image SpaceKeyImage;

    // 定义正常与透明状态的颜色
    // 例如：normalColor 为完全不透明，transparentColor 为半透明（可根据需要调整 alpha 值）
    public Color normalColor = new Color(1f, 1f, 1f, 1f);
    public Color transparentColor = new Color(1f, 1f, 1f, 0.5f);

    void Update()
    {
        // 按下 W 键则设为半透明，否则恢复不透明
        WKeyImage.color = Input.GetKey(KeyCode.W) ? transparentColor : normalColor;
        // 按下 A 键则设为半透明，否则恢复不透明
        AKeyImage.color = Input.GetKey(KeyCode.A) ? transparentColor : normalColor;
        // 按下 S 键则设为半透明，否则恢复不透明
        SKeyImage.color = Input.GetKey(KeyCode.S) ? transparentColor : normalColor;
        // 按下 D 键则设为半透明，否则恢复不透明
        DKeyImage.color = Input.GetKey(KeyCode.D) ? transparentColor : normalColor;
        // 按下 空格 键则设为半透明，否则恢复不透明
        SpaceKeyImage.color = Input.GetKey(KeyCode.Space) ? transparentColor : normalColor;
    }
}
