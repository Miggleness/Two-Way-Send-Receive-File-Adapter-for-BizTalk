using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Globalization;
using Microsoft.ServiceModel.Channels.Common;
using System.IO;

namespace TwoWaySendReceiveFileAdapter
{
    public class TwoWaySendReceiveFileAdapterBindingElement : StandardBindingElement
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the TwoWaySendReceiveFileAdapterBindingElement class
        /// </summary>
        public TwoWaySendReceiveFileAdapterBindingElement()
            : base(null)
        {
        }


        /// <summary>
        /// Initializes a new instance of the TwoWaySendReceiveFileAdapterBindingElement class with a configuration name
        /// </summary>
        public TwoWaySendReceiveFileAdapterBindingElement(string configurationName)
            : base(configurationName)
        {
        }

        #endregion Constructors

        #region Protected Properties

        /// <summary>
        /// Gets the type of the BindingElement
        /// </summary>
        protected override Type BindingElementType
        {
            get
            {
                return typeof(TwoWaySendReceiveFileAdapterBinding);
            }
        }

        #endregion Protected Properties

        #region StandardBindingElement Members

        // Initializes the binding with the configuration properties
        protected override void InitializeFrom(Binding baseBinding)
        {
            base.InitializeFrom(baseBinding);
            TwoWaySendReceiveFileAdapterBinding binding = (TwoWaySendReceiveFileAdapterBinding)baseBinding;
            this[TwoWaySendReceiveFileAdapterConfigurationStrings.PreserveProperties] = binding.PreserveProperties;
            this[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundPath] = binding.SendOutboundPath;
            this[TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundPath] = binding.ReceiveInboundPath;
        }

        // Applies the configuration
        protected override void OnApplyConfiguration(Binding baseBinding)
        {
            if (baseBinding == null)
            {
                throw new ArgumentNullException("binding");
            }

            TwoWaySendReceiveFileAdapterBinding binding = (TwoWaySendReceiveFileAdapterBinding)baseBinding;
            binding.PreserveProperties = (bool)this[TwoWaySendReceiveFileAdapterConfigurationStrings.PreserveProperties];
            binding.SendOutboundPath = (string)this[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundPath];
            binding.ReceiveInboundPath = (string)this[TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundPath];

            // Add backslash at end of path
            if (false == binding.SendOutboundPath.EndsWith(@"\"))
            {
                binding.SendOutboundPath += @"\";
            }
            if (false == binding.ReceiveInboundPath.EndsWith(@"\"))
            {
                binding.ReceiveInboundPath += @"\";
            }

            ValidatePath(binding.SendOutboundPath, TransmissionDirection.Outbound);
            ValidatePath(binding.ReceiveInboundPath, TransmissionDirection.Inbound);

        }

        private static void ValidatePath(string path, TransmissionDirection direction)
        {
            bool isFail = false;

            // Verify values
            if (File.Exists(path) || Directory.Exists(path))
            {
                var attributes = File.GetAttributes(path);
                if ((attributes & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    isFail = true;
                }
            }
            else
            {
                isFail = true;
            }

            if(isFail)
            {
                throw new ApplicationException(string.Format("{0} path '{1}' does not exist or is not a directory. Provide a valid directory path.", direction.ToString(), path));
            }
        }

        // Returns a collection of the configuration properties
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                ConfigurationPropertyCollection properties = base.Properties;
                properties.Add(new ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.PreserveProperties, typeof(bool), TwoWaySendReceiveFileAdapterConfigurationDefaults.DefaultPreserveProperties, null, null, ConfigurationPropertyOptions.None));
                properties.Add(new ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundPath, typeof(string), string.Empty, null, null, ConfigurationPropertyOptions.None));
                properties.Add(new ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundPath, typeof(string), string.Empty, null, null, ConfigurationPropertyOptions.None));
                return properties;
            }
        }

        #endregion StandardBindingElement Members

        #region Adapter Custom Configuration Properties

        [ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.PreserveProperties, DefaultValue = TwoWaySendReceiveFileAdapterConfigurationDefaults.DefaultPreserveProperties)]
        [System.ComponentModel.Category("Adapter Properties")]
        public bool PreserveProperties
        {
            get
            {
                return ((bool)(base[TwoWaySendReceiveFileAdapterConfigurationStrings.PreserveProperties]));
            }
            set
            {
                base[TwoWaySendReceiveFileAdapterConfigurationStrings.PreserveProperties] = value;
            }
        }

        [ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundPath, DefaultValue = TwoWaySendReceiveFileAdapterConfigurationDefaults.DefaultSendOutboundPath)]
        [System.ComponentModel.Category("Adapter Properties")]
        public string SendOutboundPath
        {
            get
            {
                return ((string)(base[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundPath]));
            }
            set
            {
                base[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundPath] = value;
            }
        }

        [ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundPath, DefaultValue = TwoWaySendReceiveFileAdapterConfigurationDefaults.DefaultReceiveInboundPath)]
        [System.ComponentModel.Category("Adapter Properties")]
        public string ReceiveInboundPath
        {
            get
            {
                return ((string)(base[TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundPath]));
            }
            set
            {
                base[TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundPath] = value;
            }
        }

        #endregion Adapter Custom Configuration Properties
    }
}
