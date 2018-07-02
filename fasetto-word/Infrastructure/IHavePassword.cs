using System.Security;

namespace fasetto_word.Infrastructure
{
    /// <summary>
    /// a interface  for a class that can provide a SecurePassword
    /// </summary>
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}