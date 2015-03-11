using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ServiceModel.Channels.Common;

namespace TwoWaySendReceiveFileAdapter
{
    // Use TwoWaySendReceiveFileAdapterUtilities.Trace in the code to trace the adapter
    public class TwoWaySendReceiveFileAdapterUtilities
    {
        static AdapterTrace _trace;

        static TwoWaySendReceiveFileAdapterUtilities()
        {
            //
            // Initializes a new instance of  Microsoft.ServiceModel.Channels.Common.AdapterTrace using the specified name for the source
            //
            _trace = new AdapterTrace("TwoWaySendReceiveFileAdapter");
        }

        /// <summary>
        /// Gets the AdapterTrace
        /// </summary>
        public static AdapterTrace Trace
        {
            get
            {
                return _trace;
            }
        }

    }


}

