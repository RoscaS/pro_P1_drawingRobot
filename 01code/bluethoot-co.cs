private void btnBluetooth_Co(object sender, EventArgs e)
{   // connexion
    client = new BluetoothClient();

    SelectBluetoothDeviceDialog sbdd = 
        new SelectBluetoothDeviceDialog();
    // options
    sbdd.ShowAuthenticated = true;
    sbdd.ShowRemembered    = false;
    sbdd.ShowUnknown       = true;

    if (sbdd.ShowDialog() == DialogResult.OK) {        
        if (sbdd.SelectedDevice.Authenticated) {   //connecter perif, doit être pairer avant

            bluetoothAddress = 
                sbdd.SelectedDevice.DeviceAddress;

            client = new BluetoothClient();
            
            BluetoothEndPoint ep = 
                new BluetoothEndPoint(bluetoothAddress, 
                          BluetoothService.SerialPort);

            try {
                client.Connect(ep);
                clientConnected = true;
                if (clientConnected && fileLoaded) {
                    btnSendScara.Enabled = true;
                }
            }

            catch {
                MessageBox.Show("Device not *LISTENING*", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        else {
            MessageBox.Show("Device not paired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}















// plan

private void btnBluetooth_Co(object sender, EventArgs e)
{ // connexion

    // pairing

    // options

    if (sbdd.ShowDialog() == DialogResult.OK)
    {        
        if (sbdd.SelectedDevice.Authenticated)
        { //connecter perif, doit être pairer avant
            Debug.WriteLine("Authenticated");

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
                Debug.WriteLine("Connected");

                Cursor.Current = Cursors.Arrow;
                btnBluetooth.ForeColor = Color.Green;

            }
            catch
            {

                Cursor.Current = Cursors.Arrow;

                MessageBox.Show("Device not *LISTENING*", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //client.Close();

        }
        else
        {
            MessageBox.Show("Device not paired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}