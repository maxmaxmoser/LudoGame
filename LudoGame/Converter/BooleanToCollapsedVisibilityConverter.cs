using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace LudoGame.Converter
{  
    /// <summary>
    /// Convertisseur permettant d'indiquer si un composant graphique doit être visible avec la valeur booléenne true ou ou alors collapse avec false.
    /// </summary>
    /// <remarks>
    /// A utiliser dans le champ "Visibility" des composant graphiques XAML.
    /// </remarks>
    class BooleanToCollapsedVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
