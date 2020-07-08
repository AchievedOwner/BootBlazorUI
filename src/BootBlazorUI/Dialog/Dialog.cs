using System;

namespace BootBlazorUI.Dialog
{
    /// <summary>
    /// The Instance of Dialog.
    /// </summary>
    public class Dialog
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dialog"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        internal Dialog(DialogOptions options)
        {
            Options = options;
        }
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        public DialogOptions Options { get; }
        /// <summary>
        /// Raises the Close event.
        /// </summary>
        public Action OnClose;
    }
}
