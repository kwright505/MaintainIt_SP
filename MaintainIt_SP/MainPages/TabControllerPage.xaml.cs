using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MaintainIt_SP.MainPages
{
    public partial class TabControllerPage : TabbedPage
    {
        public TabControllerPage(Page page)
        {
            InitializeComponent();

            switch (page.Title) 
            {
                case "Home":
                    CurrentPage = Children[0];
                    break;
                case "Garage":
                    CurrentPage = Children[1];
                    break;
                case "Calendar":
                    CurrentPage = Children[2];
                    break;
                case "Documents":
                    CurrentPage = Children[3];
                    break;
                default:
                    CurrentPage = Children[0];
                    break;
            }



        }
    }
}
