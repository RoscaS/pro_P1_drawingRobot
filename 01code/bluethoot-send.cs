private void btnSendData(object sender, EventArgs e)
{ // send data blootooth
    lstbxDrawPoint.Items.Clear();
    Application.DoEvents();
    stopTransmitting   = false;
    stream             = client.GetStream();
    stream.ReadTimeout = 10000;
    StreamReader file  = new StreamReader(fileSource, true);
    string strLine     = "";

    new Thread(delegate () {
        do 
        { //Lit la ligne dans le fichier texte
            strLine = file.ReadLine();

            if (strLine == "" ||
                strLine == null || 
                strLine == ".")
            {
                break;
            }

            if (strLine.StartsWith("."))
            {
                strLine = strLine.Substring(1);
            }

            strLine += (char)10;
             //Envoi la ligne au robot
            byte[] msg = Encoding.ASCII.GetBytes(strLine);

            if (!stopTransmitting)
            {
                stream.Write(msg, 0, msg.Length);
            }

            byte[] rsp = new byte[128];
            string msgOK;
            //attend que le robot réponde
            if (!stopTransmitting)
            {
                do
                {
                    try
                    {
                        rsp = new byte[128];
                        stream.Read(rsp, 0, 128);
                    }

                    catch
                    {
                        Debug.WriteLine("Pas de message");
                    }

                    msgOK = "";
                    msgOK = Encoding.ASCII.GetString(rsp);
                    Debug.WriteLine(msgOK);
                    
                } 
                
                while (!msgOK.Contains("OK") && 
                         !msgOK.Contains("ok") && 
                         !stopTransmitting);

                if (!stopTransmitting)
                {   //écriture des logs                    
                    Invoke((MethodInvoker)delegate 
                    {   // Running on the UI thread
                        
                        string log = "";
                        log = strLine + " ; " + msgOK;
                        lstbxDrawPoint.Items.Add(log);
                        // scroll automatique du listbox -- 
                        // le clignotement vient d'ici !
                        int nItems = 
                            (int)(lstbxDrawPoint.Height / 
                            lstbxDrawPoint.ItemHeight);

                        lstbxDrawPoint.TopIndex = 
                            lstbxDrawPoint.Items.Count - 
                                nItems;
                    });

                }
            }
        }
        while (strLine != "."  && 
               strLine != ""   && 
               strLine != null && 
               !stopTransmitting);

        file.Close();
        if (!stopTransmitting)
        {
            Invoke((MethodInvoker)delegate {});
            MessageBox.Show("Dessin Terminé.", 
                            "Information", 
                            MessageBoxButtons.OK);
        }
    }).Start();
}


