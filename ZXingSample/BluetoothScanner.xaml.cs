using Android.Bluetooth;
using Java.Util;
using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZXingSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BluetoothScanner : ContentPage
	{
        static UUID MY_UUID_INSECURE = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");
        BluetoothAdapter btAdapter;

        IBluetoothLE ble;
        IAdapter adapter;
        IDevice device;
        CancellationTokenSource _cancellationTokenSource;

        public BluetoothScanner ()
		{
			InitializeComponent ();

            _ConnectionScanner();
		}

        private void _ConnectionScanner()
        {
            

            ConnectToMyDevice();

            //var pairedDevices = adapter.GetSystemConnectedOrPairedDevices();
            //adapter.StartScanningForDevicesAsync();
            //var pairedDevices = adapter.ConnectedDevices;
            //if (pairedDevices.Count > 0)
            //{
            //    foreach (var device in pairedDevices)
            //    {
            //        //pairedDevicesArrayAdapter.Add(device.Name + "\n" + device.Address);
            //    }
            //}
        }
        private async void ConnectToMyDevice()
        {
            var ble = CrossBluetoothLE.Current;
            var state = ble.State;
            var adapter = CrossBluetoothLE.Current.Adapter;
            _cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            //await adapter.StopScanningForDevicesAsync();
            using (device = await adapter.ConnectToKnownDeviceAsync(
                new Guid("00001101-0000-1000-8000-00805F9B34FB"), new ConnectParameters(true, false),
                cancellationToken: _cancellationTokenSource.Token))
            {

                if (device.State == DeviceState.Connected)
                {
                    //Debug.WriteLine("OK");
                }
                else
                {
                   // Debug.WriteLine("Error");
                }

            }
        }

    }
}