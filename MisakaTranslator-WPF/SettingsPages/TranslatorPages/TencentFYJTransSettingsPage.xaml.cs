﻿using System;
using System.Collections.Generic;
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
using TranslatorLibrary;

namespace MisakaTranslator_WPF.SettingsPages.TranslatorPages
{
    /// <summary>
    /// TencentFYJTransSettingsPage.xaml 的交互逻辑
    /// </summary>
    public partial class TencentFYJTransSettingsPage : Page
    {
        public TencentFYJTransSettingsPage()
        {
            InitializeComponent();
            TransAppIDBox.Text = Common.appSettings.TXappID;
            TransSecretKeyBox.Text = Common.appSettings.TXappKey;
        }

        private void AuthTestBtn_Click(object sender, RoutedEventArgs e)
        {
            Common.appSettings.TXappID = TransAppIDBox.Text;
            Common.appSettings.TXappKey = TransSecretKeyBox.Text;
            ITranslator Trans = new TencentFYJTranslator();
            Trans.TranslatorInit(TransAppIDBox.Text, TransSecretKeyBox.Text);
            if (Trans.Translate("apple", "zh", "en") != null)
            {
                HandyControl.Controls.Growl.Success("翻译君API工作正常!");
            }
            else
            {
                HandyControl.Controls.Growl.Error("翻译君API工作异常\n" + Trans.GetLastError());
            }
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(TencentFYJTranslator.GetUrl_allpyAPI());
        }

        private void DocBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(TencentFYJTranslator.GetUrl_Doc());
        }

        private void BillBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(TencentFYJTranslator.GetUrl_bill());
        }

        private void TransTestBtn_Click(object sender, RoutedEventArgs e)
        {
            ITranslator Trans = new TencentFYJTranslator();
            Trans.TranslatorInit(Common.appSettings.TXappID, Common.appSettings.TXappKey);
            string res = Trans.Translate(TestSrcText.Text, TestDstLang.Text, TestSrcLang.Text);
            if (res != null)
            {
                HandyControl.Controls.MessageBox.Show(res, "翻译结果");
            }
            else
            {
                HandyControl.Controls.Growl.Error("翻译君API工作异常\n" + Trans.GetLastError());
            }
        }
    }
}