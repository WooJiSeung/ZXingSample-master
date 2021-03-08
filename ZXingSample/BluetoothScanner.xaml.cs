using Android.Bluetooth;
using Java.Util;
using Plugin.BLE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public BluetoothScanner ()
		{
			InitializeComponent ();

            _ConnectionScanner();
		}

        private void _ConnectionScanner()
        {
            var ble = CrossBluetoothLE.Current;
            var state = ble.State;
            var adapter = CrossBluetoothLE.Current.Adapter;

            //var pairedDevices = adapter.GetSystemConnectedOrPairedDevices();
            adapter.StartScanningForDevicesAsync();
            var pairedDevices = adapter.ConnectedDevices;
            if (pairedDevices.Count > 0)
            {
                foreach (var device in pairedDevices)
                {
                    //pairedDevicesArrayAdapter.Add(device.Name + "\n" + device.Address);
                }
            }
        }
    }
}