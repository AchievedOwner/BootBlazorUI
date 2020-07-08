namespace BootBlazorUI.Abstractions.Parameters
{
    /// <summary>
    /// 定义组件具有 Flex 布局的参数。
    /// </summary>
    public interface IHasFlex
    {
        public bool? Flex { get; set; }
        public bool? FlexInline { get; set; }
        public bool? FlexSmall { get; set; }
        public bool? FlexInlineSmall { get; set; }
        public bool? FlexMedium { get; set; }
        public bool? FlexInlineMedium { get; set; }
        public bool? FlexLarge { get; set; }
        public bool? FlexInlineLarge { get; set; }
        public bool? FlexExtraLarge { get; set; }
        public bool? FlextInlineExtraLarge { get; set; }

        public bool? FlexRow { get; set; }
        public bool? FlexRowReverse { get; set; }
        public bool? FlexColumn { get; set; }
        public bool? FlexColumnReverse { get; set; }

        public bool? FlexFill { get; set; }
        public bool? FlexShrink { get; set; }

    }
}
