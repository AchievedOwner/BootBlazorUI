using System;

using Xunit;

namespace BootBlazorUI.Test
{
    using Abstractions;

    using YoiBlazor;

    public class ExtensionTest
    {
        [CssClass("bg-")] public Color BgColor { get; set; } = Color.Primary;
        [CssClass("margin")] public int? Margin { get; set; }


        [Theory]
        [InlineData(new object[] { Color.Primary})]
        [InlineData(new object[] { Color.Success })]
        [InlineData(new object[] { Color.Info })]
        [InlineData(new object[] { Color.Secondary })]
        [InlineData(new object[] { Color.Danger })]
        [InlineData(new object[] { Color.Dark })]
        [InlineData(new object[] { Color.Light })]
        [InlineData(new object[] { Color.Warning })]
        public void TestGetEnumCssClass(Color color)
        {
            BgColor = color;

            var css = BgColor.GetEnumCssClass();
            Assert.Equal($"bg-{color.GetEnumCssClass()}", css);
        }
    }
}
