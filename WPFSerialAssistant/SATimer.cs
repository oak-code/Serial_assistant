using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WPFSerialAssistant
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 用于更新时间的定时器
        /// </summary>
        private DispatcherTimer clockTimer = new DispatcherTimer();

        /// <summary>
        /// 定时器初始化
        /// </summary>
        private void InitClockTimer()
        {
            clockTimer.Interval = new TimeSpan(0, 0, 1);
            clockTimer.IsEnabled = true;
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
        }

        private DispatcherTimer ComboBoxTimer = new DispatcherTimer();
        /// <summary>
        /// 用于检测串口信息的定时器
        /// </summary>
        private void InitComboBox_ClickTimer()
        {
            ComboBoxTimer.IsEnabled = false;
            ComboBoxTimer.Tick += ComboBoxTimer_Tick;
        }

        private void StartComboBoxTimer(int interval)
        {
            ComboBoxTimer.IsEnabled = true;
            ComboBoxTimer.Interval = TimeSpan.FromMilliseconds(interval);
            ComboBoxTimer.Start();
        }

        private void StopComboBoxTimer()
        {
            ComboBoxTimer.IsEnabled = false;
            ComboBoxTimer.Stop();
        }

        private DispatcherTimer autoSendDataTimer = new DispatcherTimer();
        /// <summary>
        /// 用于自动发送串口数据的定时器
        /// </summary>
        private void InitAutoSendDataTimer()
        {
            autoSendDataTimer.IsEnabled = false;
            autoSendDataTimer.Tick += AutoSendDataTimer_Tick;
        }

        private void StartAutoSendDataTimer(int interval)
        {
            autoSendDataTimer.IsEnabled = true;
            autoSendDataTimer.Interval = TimeSpan.FromMilliseconds(interval);
            autoSendDataTimer.Start();
        }

        private void StopAutoSendDataTimer()
        {
            autoSendDataTimer.IsEnabled = false;
            autoSendDataTimer.Stop();
        }
    }
}
