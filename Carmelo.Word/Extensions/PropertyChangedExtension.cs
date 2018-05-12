﻿using System.ComponentModel;

namespace Carmelo.Word.Extensions
{
    /// <summary>
    /// Extension safely invokes <see cref="PropertyChangedEventHandler"/>.
    /// </summary>
    public static class PropertyChangedExtension
    {
        /// <summary>
        /// Invokes <see cref="PropertyChangedEventHandler"/> object after checking null status.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="sender"></param>
        /// <param name="propertyName"></param>
        public static void SafeInvoke(this PropertyChangedEventHandler handler, object sender, string propertyName)
        {
            handler?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}
