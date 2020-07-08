namespace BootBlazorUI.Abstractions
{
    using System.Collections.Generic;

    using Parameters;

    /// <summary>
    /// 提供 Boot 组件公共参数的组件的功能。
    /// </summary>
    public interface IBootComponentParameters : 
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
        /// <summary>
        /// 返回所有公用参数的 css 名称列表。
        /// </summary>
        IReadOnlyList<string> GetParameterClass();

        /// <summary>
        /// 返回所有公用参数的 style 名称列表。
        /// </summary>
        IReadOnlyList<string> GetParameterStyle();
    }
}
