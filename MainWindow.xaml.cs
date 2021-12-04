﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Web.WebView2.Core;

namespace navigateurWeb4A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    class VisitedUrl : ObservableCollection<string>
    {
     
    }
    public partial class MainWindow : Window
    {
        VisitedUrl l1 = new VisitedUrl();
        public MainWindow()
        {
            InitializeComponent();
            visitedUrl.ItemsSource = l1; 
            webView.NavigationStarting += EnsureHttps;
        }
        void EnsureHttps(Object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            string uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                webView.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
                args.Cancel = true;
            }
            else webView.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is safe, please go on !')");
        }
        private void WebView_NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                l1.Add(addressBar.Text);
                webView.CoreWebView2.Navigate(addressBar.Text);
            }
        }
    }
}