﻿using BrewSentinel.Lib.Model;
using BrewSentinel.Lib.Sensors;
using BrewSentinel.ViewModel;
using Microsoft.AspNet.SignalR.Client;
using Rinsen.IoT.OneWire;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BrewSentinel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Start : Page
    {

        private OneWire onewire;
        private string deviceId = string.Empty;
        private DispatcherTimer timer;
        private bool inprog = false;
        TemperatureModel tempData;
        ThreadPoolTimer _timer;

        private OneWireDeviceHandler oneWireDeviceHandler;

        public Start()
        {
            this.InitializeComponent();
            this.tempData = new TemperatureModel();
            this.DataContext = new StartVIewModel() { TemperatureModel = tempData };

          
        }

        private async void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            GetTemperatures(null);
        }

        private async void GetTemperatures(ThreadPoolTimer timer)
        {
            try
            {
                if (this.oneWireDeviceHandler == null)
                {
                    this.oneWireDeviceHandler = new OneWireDeviceHandler(true, true);
                }

                foreach (var device in oneWireDeviceHandler.OneWireDevices.GetDevices<DS18B20>())
                {
                    var result = device.GetTemperature();
                    this.tempData.Temperature = result;
                    // Insert code to log result in some way
                    device.DS2482_100.Dispose();
                }

                this.oneWireDeviceHandler.Dispose();
                this.oneWireDeviceHandler = null;

            }
            catch (Exception e)
            {
                this.oneWireDeviceHandler.Dispose();
                this.oneWireDeviceHandler = null;
                // Insert code to log all exceptions!
            }
        }

        public void Close()
        {
            this.oneWireDeviceHandler.Dispose();
        }

        public void OnNavigateFrom(NavigationEventArgs e)
        {
            this.oneWireDeviceHandler.Dispose();          
        }
      




    }
}
