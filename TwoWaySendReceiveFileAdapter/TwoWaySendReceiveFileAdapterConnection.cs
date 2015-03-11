using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.ServiceModel.Channels.Common;

namespace TwoWaySendReceiveFileAdapter
{
    public class TwoWaySendReceiveFileAdapterConnection : IConnection
    {
        #region Private Fields

        private TwoWaySendReceiveFileAdapterConnectionFactory _connectionFactory;
        private string _connectionId;

        #endregion Private Fields

        /// <summary>
        /// Initializes a new instance of the TwoWaySendReceiveFileAdapterConnection class with the TwoWaySendReceiveFileAdapterConnectionFactory
        /// </summary>
        public TwoWaySendReceiveFileAdapterConnection(TwoWaySendReceiveFileAdapterConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
            this._connectionId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets the ConnectionFactory
        /// </summary>
        public TwoWaySendReceiveFileAdapterConnectionFactory ConnectionFactory
        {
            get
            {
                return this._connectionFactory;
            }
        }

        #endregion Public Properties

        #region IConnection Members

        /// <summary>
        /// Closes the connection to the target system
        /// </summary>
        public void Close(TimeSpan timeout)
        {
            
        }

        /// <summary>
        /// Returns a value indicating whether the connection is still valid
        /// </summary>
        /// <returns>Boolean</returns>
        public bool IsValid(TimeSpan timeout)
        {
            return true;
           
        }

        /// <summary>
        /// Opens the connection to the target system.
        /// </summary>
        public void Open(TimeSpan timeout)
        {
            
        }

        /// <summary>
        /// Clears the context of the Connection. This method is called when the connection is set back to the connection pool
        /// </summary>
        public void ClearContext()
        {
           
        }

        /// <summary>
        /// Builds a new instance of the specified IConnectionHandler type
        /// </summary>
        /// <typeparam name="TConnectionHandler">IConnectionHandler type</typeparam>
        /// /// <param name="metadataLookup">The MetadataLookup to use to retrieve operation metadata for the messages</param>
        /// <returns>A new instance of the specified IConnectionHandler type</returns>
        public TConnectionHandler BuildHandler<TConnectionHandler>(MetadataLookup metadataLookup)
             where TConnectionHandler : class, IConnectionHandler
        {

            
            if (typeof(IOutboundHandler).IsAssignableFrom(typeof(TConnectionHandler)))
            {
                return new TwoWaySendReceiveFileAdapterOutboundHandler(this, metadataLookup) as TConnectionHandler;
            }

            return default(TConnectionHandler);
        }

        /// <summary>
        /// Aborts the connection to the target system
        /// </summary>
        public void Abort()
        {
            //
            //TODO: Implement abort logic. DO NOT throw an exception from this method
            //
            // throw new NotImplementedException("The method or operation is not implemented.");
        }


        /// <summary>
        /// Gets the Id of the Connection
        /// </summary>
        public String ConnectionId
        {
            get
            {
                return _connectionId;
            }
        }

        #endregion IConnection Members
    }
}
