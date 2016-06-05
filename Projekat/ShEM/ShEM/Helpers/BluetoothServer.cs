//using Microsoft.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Background;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Microsoft.VisualBasic;
using Windows.UI.Xaml;
using Windows.UI.Popups;

namespace ShEM.Helpers
{
    public class BluetoothServer
    {
        // The Chat Server's custom service Uuid: 34B1CF4D-1069-4AD6-89B6-E161D79BE4D8
        private static readonly Guid RfcommChatServiceUuid = Guid.Parse("34B1CF4D-1069-4AD6-89B6-E161D79BE4D8");

        // The Id of the Service Name SDP attribute
        private const UInt16 SdpServiceNameAttributeId = 0x100;

        // The SDP Type of the Service Name SDP attribute.
        // The first byte in the SDP Attribute encodes the SDP Attribute Type as follows :
        //    -  the Attribute Type size in the least significant 3 bits,
        //    -  the SDP Attribute Type value in the most significant 5 bits.
        private const byte SdpServiceNameAttributeType = (4 << 3) | 5;

        // The value of the Service Name SDP attribute
        private const string SdpServiceName = "Bluetooth Rfcomm Chat Service";

        private StreamSocket socket;
        private DataWriter writer;
        private RfcommServiceProvider rfcommProvider;
        private StreamSocketListener socketListener;

        void App_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            // Make sure we cleanup resources on suspend
            Disconnect();
        }

        /// <summary>
        /// Initialize a server socket listening for incoming Bluetooth Rfcomm connections
        /// </summary>
        async void InitializeRfcommServer()
        {
            try
            {
                rfcommProvider = await RfcommServiceProvider.CreateAsync(
                    RfcommServiceId.FromUuid(RfcommChatServiceUuid));

                // Create a listener for this service and start listening
                socketListener = new StreamSocketListener();
                socketListener.ConnectionReceived += OnConnectionReceived;

                await socketListener.BindServiceNameAsync(rfcommProvider.ServiceId.AsString(),
                    SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);

                // Set the SDP attributes and start Bluetooth advertising
                InitializeServiceSdpAttributes(rfcommProvider);
                rfcommProvider.StartAdvertising(socketListener);
               
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog("No bluetooth connection");
                await dialog.ShowAsync();
            }
        }

        /// <summary>
        /// Initialize the Rfcomm service's SDP attributes.
        /// </summary>
        /// <param name="rfcommProvider">The Rfcomm service provider to initialize.</param>
        private void InitializeServiceSdpAttributes(RfcommServiceProvider rfcommProvider)
        {
            var sdpWriter = new DataWriter();

            // Write the Service Name Attribute.

            sdpWriter.WriteByte(SdpServiceNameAttributeType);

            // The length of the UTF-8 encoded Service Name SDP Attribute.
            sdpWriter.WriteByte((byte)SdpServiceName.Length);

            // The UTF-8 encoded Service Name value.
            sdpWriter.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
            sdpWriter.WriteString(SdpServiceName);

            // Set the SDP Attribute on the RFCOMM Service Provider.
            rfcommProvider.SdpRawAttributes.Add(SdpServiceNameAttributeId, sdpWriter.DetachBuffer());
        }

        /// <summary>
        /// Invoked when the socket listener accepted an incoming Bluetooth connection.
        /// </summary>
        /// <param name="sender">The socket listener that accecpted the connection.</param>
        /// <param name="args">The connection accept parameters, which contain the connected socket.</param>
        private async void OnConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        {
            try
            {
                // Don't need the listener anymore
                socketListener.Dispose();
                socketListener = null;

                socket = args.Socket;

                writer = new DataWriter(socket.OutputStream);

                var reader = new DataReader(socket.InputStream);
                bool remoteDisconnection = false;
                while (true)
                {
                    uint readLength = await reader.LoadAsync(sizeof(uint));
                    if (readLength < sizeof(uint))
                    {
                        remoteDisconnection = true;
                        break;
                    }
                    uint currentLength = reader.ReadUInt32();

                    readLength = await reader.LoadAsync(currentLength);
                    if (readLength < currentLength)
                    {
                        remoteDisconnection = true;
                        break;
                    }
                    string message = reader.ReadString(currentLength);

                }

                reader.DetachStream();
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog("Invalid E-mail format");
                await dialog.ShowAsync();
            }
        }

        /// <summary>
        /// Send message over the Bluetooth socket.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Send()
        {
            try
            {
                if (socket != null)
                {
                    string message = null;
                    writer.WriteUInt32((uint)message.Length);
                    writer.WriteString(message);

                    await writer.StoreAsync();
                }
                else
                {
                    var dialog = new MessageDialog("No connection");
                    await dialog.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.ToString());
                await dialog.ShowAsync();
            }
        }

        /// <summary>
        /// Start the Bluetooth server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeRfcommServer();
        }
        /// <summary>
        /// Cleanup Bluetooth resources
        /// </summary>
        private void Disconnect()
        {
            if (rfcommProvider != null)
            {
                rfcommProvider.StopAdvertising();
                rfcommProvider = null;
            }

            if (socketListener != null)
            {
                socketListener.Dispose();
                socketListener = null;
            }

            if (writer != null)
            {
                writer.DetachStream();
                writer = null;
            }

            if (socket != null)
            {
                socket.Dispose();
                socket = null;
            }
        }
    }
}
