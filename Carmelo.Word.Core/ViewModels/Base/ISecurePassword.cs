﻿using System.Security;

namespace Carmelo.Word.Core
{
    /// <summary>
    /// Interface provides a <see cref="SecureString"/> to the inheriting class.
    /// </summary>
    public interface ISecurePassword
    {
        SecureString Password { get; }
    }
}
