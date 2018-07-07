using System.Security;

namespace fasetto_word.Core.Models
{
    /// <summary>
    /// a interface  for a class that can provide a SecurePassword
    /// </summary>
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}