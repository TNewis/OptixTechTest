using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace OptixTechTest.Services
{
    public class DialogService : IDialogService
    {
        public MessageBoxResult ShowDialog(string message, string title)
        {
            return MessageBox.Show(message, title);
        }
    }
}
