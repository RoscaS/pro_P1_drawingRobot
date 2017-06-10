private void btnBluetooth(object sender, EventArgs e)
{   
    client = new BluetoothClient();

    SelectBluetoothDeviceDialog sbdd = 
        new SelectBluetoothDeviceDialog();
    
    sbdd.ShowAuthenticated = true;
    sbdd.ShowRemembered    = false;
    sbdd.ShowUnknown       = true;

    if (sbdd.ShowDialog() == DialogResult.OK) 
    {        
        if (sbdd.SelectedDevice.Authenticated) 
        {

            bluetoothAddress = 
                sbdd.SelectedDevice.DeviceAddress;

            client = new BluetoothClient();
            
            BluetoothEndPoint ep = 
                new BluetoothEndPoint(bluetoothAddress, 
                          BluetoothService.SerialPort);

            try 
            {
                Cursor.Current = Cursors.WaitCursor;

                client.Connect(ep);
                clientConnected = true;

                if (clientConnected && fileLoaded) 
                {
                    btnSendScara.Enabled = true;
                }
            }

            catch 
            {
                MessageBox.Show("Device not *LISTENING*", 
                                "Error", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
        }

        else 
        {
            MessageBox.Show("Device not paired", 
                            "Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
        }
    }
}
