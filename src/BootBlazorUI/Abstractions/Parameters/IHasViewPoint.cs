
using System;

using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义浏览器尺寸多适配的参数。
    /// </summary>
    public interface IHasViewPoints<TViewPoint> : IHasParameter where TViewPoint :struct
    {
        /// <summary>
        /// 设置适配小尺寸视窗的参数，<c>null</c> 使用默认值。
        /// </summary>
        public TViewPoint? Small { get; set; }

        /// <summary>
        /// 设置适配中等尺寸视窗的参数，<c>null</c> 使用默认值。
        /// </summary>
        public TViewPoint? Medium { get; set; }

        /// <summary>
        /// 设置适配大尺寸视窗的参数，<c>null</c> 使用默认值。
        /// </summary>
        public TViewPoint? Large { get; set; }

        /// <summary>
        /// 设置适配超大尺寸视窗的参数，<c>null</c> 使用默认值。
        /// </summary>
        public TViewPoint? ExtraLarge { get; set; }
    }

    /// <summary>
    /// 定义浏览器尺寸适配的参数。
    /// </summary>
    public interface IHasViewPoint : IHasParameter
    {
        /// <summary>
        /// 设置浏览器适配的数组，<c>null</c> 使用默认值。
        /// </summary>
        /// <value>
        /// <see cref="ViewPoint"/> 枚举数组或 <c>null</c>。
        /// </value>
        public ViewPoint? ViewPoint { get; set; }
    }
}
