using System.Windows.Input;
using Microsoft.Phone.Controls;
using voidsoft.HackerNews;

namespace HN.Views
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (new NavigationHelper(this)).NavigateToBrowser("http://www.voidsoft.ro");
        }


        private void TextBlock_MouseLeftButtonDown_API(object sender, MouseButtonEventArgs e)
        {
            (new NavigationHelper(this)).NavigateToBrowser("http://www.http://ronnieroller.com/");
        }
    }
}