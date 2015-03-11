using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Channels;
using System.Xml;
using Microsoft.ServiceModel.Channels.Common;
using System.Diagnostics;
using System.IO;


namespace TwoWaySendReceiveFileAdapter
{
    public class TwoWaySendReceiveFileAdapterOutboundHandler : IOutboundHandler
    {
        private TwoWaySendReceiveFileAdapterConnection _connection;
        private MetadataLookup _metadataLookup;

        /// <summary>
        /// Initializes a new instance of the TwoWaySendReceiveFileAdapterOutboundHandler class
        /// </summary>
        public TwoWaySendReceiveFileAdapterOutboundHandler(TwoWaySendReceiveFileAdapterConnection connection, MetadataLookup metadataLookup)
        {
            _connection = connection;
            _metadataLookup = metadataLookup;
        }

        #region IOutboundHandler Members

        /// <summary>
        /// Creates a copy of the request message and returns it as a response message.
        /// </summary>
        /// <param name="message">The Message to be executed</param>
        /// <param name="timeout">The timeout for the operation</param>
        /// <returns>the response message, null if there was no response</returns>
        public Message Execute(Message message, TimeSpan timeout)
        {
            return CreateRequestMessage(message);
        }

        private Message CreateRequestMessage(Message requestMessage)
        {
            string propertiesToPromoteKey = "http://schemas.microsoft.com/BizTalk/2006/01/Adapters/WCF-properties/WriteToContext";
            Message message = null;

            // write outbound to folder
            using (var reader = requestMessage.GetReaderAtBodyContents())
            using (var fileStream = File.Create(_connection.ConnectionFactory.Adapter.SendOutboundFilePath))
            using (var writer = XmlWriter.Create(fileStream))
            {
                writer.WriteNode(reader, true);
            }

            // read inbound from source
            XmlReader readerResponse = new XmlTextReader(_connection.ConnectionFactory.Adapter.ReceiveInboundFilePath);

            message = Message.CreateMessage(MessageVersion.Default, requestMessage.Headers.Action, readerResponse);
            
            List<KeyValuePair<XmlQualifiedName, object>> propertiesToPromote = new List<KeyValuePair<XmlQualifiedName, object>>();

            if (_connection.ConnectionFactory.Adapter.PreserveProperties)
            {
                foreach (var property in requestMessage.Properties)
                {
                    string propertyNamespace = string.Empty;
                    string propertyName;
                    if (property.Key.Contains("#"))
                    {
                        string[] keySplit = property.Key.Split('#');
                        propertyNamespace = keySplit[0];
                        propertyName = keySplit[1];

                        if (propertyNamespace != "http://schemas.microsoft.com/BizTalk/2006/01/Adapters/WCF-properties"
                            && propertyNamespace != "http://schemas.microsoft.com/BizTalk/2003/messageagent-properties"
                            && propertyNamespace != "http://schemas.microsoft.com/BizTalk/2003/messagetracking-properties"
                            && (propertyNamespace != "http://schemas.microsoft.com/BizTalk/2003/system-properties"
                            || (propertyNamespace == "http://schemas.microsoft.com/BizTalk/2003/system-properties" && propertyName == "Operation")))
                        {
                            XmlQualifiedName qualifiedName = new XmlQualifiedName(propertyName, propertyNamespace);
                            //propertiesToPromote.Add(new KeyValuePair<XmlQualifiedName, object>(qualifiedName, property.Value));
                        }
                    }

                }

                message.Properties.Add(propertiesToPromoteKey, propertiesToPromote);
            }

            return message;
        }




        #endregion IOutboundHandler Members

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable

        protected virtual void Dispose(bool disposing)
        {
            // disposed
        }
    }
}
