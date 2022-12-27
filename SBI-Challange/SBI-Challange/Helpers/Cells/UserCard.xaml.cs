using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SBIChallange.Helpers.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserCard : Grid
    {
        public UserCard()
        {
            InitializeComponent();
        }
    }
}