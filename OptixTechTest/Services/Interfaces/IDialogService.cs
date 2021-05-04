using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace OptixTechTest.Services
{
    public interface IDialogService
    {
        MessageBoxResult ShowDialog(string message, string title);
    }
}
