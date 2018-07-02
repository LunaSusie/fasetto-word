using System;
using System.Windows;
using System.Windows.Controls;

namespace fasetto_word.Infrastructure.AttachedProperties
{
 
    /// <summary>
    /// The MonitorPassword attacthed property for a <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is PasswordBox passwordBox)) return;

            passwordBox.PasswordChanged -= PasswordChanged;
            if (!(bool) e.NewValue) return;

            HasTextProperty.SetValue(passwordBox);
            passwordBox.PasswordChanged += PasswordChanged;
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        } 
    }
    /// <summary>
    /// HasText attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
        {
            HasTextProperty.SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}