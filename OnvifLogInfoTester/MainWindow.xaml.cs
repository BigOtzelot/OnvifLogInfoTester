using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
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

namespace OnvifVideoSample
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{

			InitializeComponent();
			address.GotFocus += InitTextbox;
			user.GotFocus += InitTextbox;
			password.GotFocus += InitTextbox;
			button.Click += OnConnect;
		}

        private void TestThis()
        {
            // 
            //or "/onvif_device"));
            try
            {
                var device = new device.DeviceClient(WsdlBinding, new EndpointAddress("http://" + address.Text + "/onvif/device_service"));
                device.ClientCredentials.HttpDigest.ClientCredential.UserName = user.Text;
                device.ClientCredentials.HttpDigest.ClientCredential.Password = password.Password;
                device.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                var services = device.GetServices(false);
            }
            catch(Exception ex)
            {
                listBox.Items.Add(address.Text);
                listBox.Items.Add("GetServices throw an exception:");
                listBox.Items.Add(ex.Message);
            }

            

            string Model = "";
            string FirmwareVersion = "";
            string SerialNumber = "";
            string HardwareId = "";
            string returnDeviceInformation = "";

            try
            {
                var device = new device.DeviceClient(WsdlBinding, new EndpointAddress("http://" + address.Text + "/onvif/device_service"));
                device.ClientCredentials.HttpDigest.ClientCredential.UserName = user.Text;
                device.ClientCredentials.HttpDigest.ClientCredential.Password = password.Password;
                device.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                returnDeviceInformation = device.GetDeviceInformation(out Model, out FirmwareVersion, out SerialNumber, out HardwareId);
            }
            catch (Exception ex)
            {
                listBox.Items.Add(address.Text);
                listBox.Items.Add("GetDeviceInformation throw an exception:");
                listBox.Items.Add(ex.Message);
            }


            //OnvifVideoSample.device.RelayOutput[] outputnum = device.GetRelayOutputs();

            listBox.Items.Add("Device under test: " + returnDeviceInformation);
            listBox.Items.Add("Model: " + Model);
            listBox.Items.Add("FW: " + FirmwareVersion);
            listBox.Items.Add("SerialNumber: " + SerialNumber);
            listBox.Items.Add("");

            listBox.Items.Add("Result for GetSystemLog with \"Access\"");

            try
            {
                var device = new device.DeviceClient(WsdlBinding, new EndpointAddress("http://" + address.Text + "/onvif/device_service"));
                device.ClientCredentials.HttpDigest.ClientCredential.UserName = user.Text;
                device.ClientCredentials.HttpDigest.ClientCredential.Password = password.Password;
                device.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                device.SystemLog Log = device.GetSystemLog(OnvifVideoSample.device.SystemLogType.Access); //OnvifVideoSample.device.SystemLogType.Access
                string output = "Log-String: " + Log.String;
                listBox.Items.Add(output);
                if (Log.Binary == null)
                    listBox.Items.Add("Log-Binary was NULL");
                else
                {
                    output = "Log-Binary" + Log.Binary;
                    listBox.Items.Add(output);
                }
            }
            catch (Exception ex)
            {
                listBox.Items.Add("GetSystemLog with \"Access\" did throw an exception:");
                listBox.Items.Add(ex.Message);
            }

            listBox.Items.Add("");
            listBox.Items.Add("");
            listBox.Items.Add("Result for GetSystemLog with \"System\"");

            try
            {
                var device = new device.DeviceClient(WsdlBinding, new EndpointAddress("http://" + address.Text + "/onvif/device_service"));
                device.ClientCredentials.HttpDigest.ClientCredential.UserName = user.Text;
                device.ClientCredentials.HttpDigest.ClientCredential.Password = password.Password;
                device.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                device.SystemLog Log = device.GetSystemLog(OnvifVideoSample.device.SystemLogType.System); //OnvifVideoSample.device.SystemLogType.Access
                string output = "Log-String: " + Log.String;
                listBox.Items.Add(output);
                if (Log.Binary == null)
                    listBox.Items.Add("Log-Binary was NULL");
                else
                {
                    output = "Log-Binary" + Log.Binary;
                    listBox.Items.Add(output);
                }
            }
            catch (Exception ex)
            {
                listBox.Items.Add("GetSystemLog with \"System\" did throw an exception: ");
                listBox.Items.Add(ex.Message);
            }


            listBox.Items.Add("");
            listBox.Items.Add("");
            listBox.Items.Add("GetSystemSupportInformation TEST: ");
            try
            {
                var device = new device.DeviceClient(WsdlBinding, new EndpointAddress("http://" + address.Text + "/onvif/device_service"));
                device.ClientCredentials.HttpDigest.ClientCredential.UserName = user.Text;
                device.ClientCredentials.HttpDigest.ClientCredential.Password = password.Password;
                device.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                OnvifVideoSample.device.SupportInformation supportInfo = device.GetSystemSupportInformation();
                listBox.Items.Add("SupportInformation got string: " + supportInfo.String);

            }
            catch (Exception ex)
            {
                listBox.Items.Add("GetSystemSupportInformation did throw an exception: ");
                listBox.Items.Add(ex.Message);
            }


            listBox.Items.Add("");
            listBox.Items.Add("");
            listBox.Items.Add("GetSystemBackup TEST: ");
            try
            {
                var device = new device.DeviceClient(WsdlBinding, new EndpointAddress("http://" + address.Text + "/onvif/device_service"));
                device.ClientCredentials.HttpDigest.ClientCredential.UserName = user.Text;
                device.ClientCredentials.HttpDigest.ClientCredential.Password = password.Password;
                device.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                OnvifVideoSample.device.BackupFile[] backupFile = device.GetSystemBackup();
                listBox.Items.Add("BackupFile did return.");

            }
            catch (Exception ex)
            {
                listBox.Items.Add("GetSystemBackup did throw an exception: ");
                listBox.Items.Add(ex.Message);
            }




            listBox.Items.Add("");
            listBox.Items.Add("");
            listBox.Items.Add("GetSystemUris TEST: ");
            try
            {
                string SupportInfoUri;
                string SystemBackupUri;
                                var device = new device.DeviceClient(WsdlBinding, new EndpointAddress("http://" + address.Text + "/onvif/device_service"));
                device.ClientCredentials.HttpDigest.ClientCredential.UserName = user.Text;
                device.ClientCredentials.HttpDigest.ClientCredential.Password = password.Password;
                device.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                OnvifVideoSample.device.GetSystemUrisResponseExtension Extension;
                OnvifVideoSample.device.SystemLogUri[] systemUris = device.GetSystemUris(out SupportInfoUri, out SystemBackupUri, out Extension);

                listBox.Items.Add("systemUris: " + systemUris);
                listBox.Items.Add("SupportInfoUri: " + SupportInfoUri);
                listBox.Items.Add("SystemBackupUri: " + SystemBackupUri);
                listBox.Items.Add("Extension: " + Extension);

            }
            catch (Exception ex)
            {
                listBox.Items.Add("GetSystemUris did throw an exception: ");
                listBox.Items.Add(ex.Message);
            }
            int b = 0;
        }

        private void OnConnect(object sender, RoutedEventArgs e)
		{

            if (!string.IsNullOrEmpty(address.Text))
            {
                TestThis();
            }
            
        }

		private void InitTextbox(object sender, RoutedEventArgs e)
		{
			if (((sender as Control).Foreground as SolidColorBrush)?.Color == Colors.DarkGray) {
				if (sender is TextBox) {
					(sender as TextBox).Text = "";
				}
				else if (sender is PasswordBox) {
					(sender as PasswordBox).Password = "";
				}
				(sender as Control).Foreground = new SolidColorBrush(Colors.Black);
			}
		}


		System.ServiceModel.Channels.Binding WsdlBinding
		{
			get
			{
				HttpTransportBindingElement httpTransport = new HttpTransportBindingElement();
				httpTransport.AuthenticationScheme = System.Net.AuthenticationSchemes.Digest;
				return new CustomBinding(new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, Encoding.UTF8), httpTransport);
			}
		}

	}
}
