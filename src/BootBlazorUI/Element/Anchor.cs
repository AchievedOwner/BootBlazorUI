using System.ComponentModel;

using BootBlazorUI.Abstractions;
using BootBlazorUI.Abstractions.Parameters;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 呈现 a 元素的超链接组件。
    /// </summary>
    /// <seealso cref="BootBlazorUI.Abstractions.BootComponentBase" />
    /// <seealso cref="BootBlazorUI.Abstractions.Parameters.IHasChildContent" />
    [Element("a")]
    public class Anchor : BootComponentBase, IHasChildContent,IHasTitle
    {
        /// <summary>
        /// 设置组件的一段 UI 内容。
        /// </summary>
        [Parameter]public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置超链接地址。
        /// </summary>
        [Parameter][ElementAttr("href")]public string Link { get; set; }

        /// <summary>
        /// 设置超链接在何处打开链接文档。
        /// </summary>
        [Parameter][ElementAttr("target")] public LinkTarget? LinkTarget { get; set; }
        /// <summary>
        /// 设置被下载的超链接目标。
        /// </summary>
        [Parameter][ElementAttr] public string Download { get; set; }
        /// <summary>
        /// 设置被链接文档的的 MIME 类型。
        /// </summary>
        [Parameter][ElementAttr] public string Type { get; set; }
        /// <summary>
        /// 设置组件在鼠标悬停后显示的标题内容。
        /// </summary>
        [Parameter][ElementAttr]public string Title { get; set; }
    }

    /// <summary>
    /// 超链接的目标选项。
    /// </summary>
    public enum LinkTarget
    {
        /// <summary>
        /// 浏览器总在一个新打开、未命名的窗口中载入目标文档。
        /// </summary>
        [Description("_blank")]
        Blank,
        /// <summary>
        /// 这个目标使得文档载入包含这个超链接的窗口，目标将会清除所有被包含的框架并将文档载入整个浏览器窗口。
        /// </summary>
        [Description("_top")]
        Top,
        /// <summary>
        /// 这个目标使得文档载入父窗口或者包含来超链接引用的框架的框架集。如果这个引用是在窗口或者在顶级框架中，那么它与目标 <see cref="Self"/> 等效。
        /// </summary>
        [Description("_parent")]
        Parent,
        /// <summary>
        /// 这个目标的值对所有没有指定目标的超链接标签是默认目标，它使得目标文档载入并显示在相同的框架或者窗口中作为源文档。
        /// 这个目标是多余且不必要的，除非和文档标题 &lt;base> 标签中的 target 属性一起使用。
        /// </summary>
        [Description("_self")]
        Self
    }
}
