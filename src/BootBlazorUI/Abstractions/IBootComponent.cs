
using BootBlazorUI.Abstractions.Parameters;

using YoiBlazor;

namespace BootBlazorUI.Abstractions
{
    /// <summary>
    /// 提供 Boot 组件公共参数的组件的功能。
    /// </summary>
    public interface IBootComponent :IBlazorComponent,
        IHasWidth, 
        IHasBackgroundColor, 
        IHasTextAlign, 
        IHasTextColor, 
        IHasMargin, 
        IHasPadding, 
        IHasBorder, 
        IHasFloat, 
        IHasHeight,
        IHasOverflow,
        IHasShadow,
        IHasRounded,
        IHasDisplay,
        IHasVisibility
    {
    }
}
