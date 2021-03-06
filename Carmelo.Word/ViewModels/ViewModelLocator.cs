﻿using Carmelo.Word.Core;

namespace Carmelo.Word
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Singleton instance of the locator.
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// Application view model.
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IocContainer.Get<ApplicationViewModel>();
    }
}
