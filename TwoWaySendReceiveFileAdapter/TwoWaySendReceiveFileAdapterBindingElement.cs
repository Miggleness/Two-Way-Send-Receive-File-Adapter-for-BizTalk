using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Globalization;
using Microsoft.ServiceModel.Channels.Common;

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
            this[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundFilePath] = binding.SendOutboundFilePath;
            this[TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundFilePath] = binding.ReceiveInboundFilePath;
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
            binding.SendOutboundFilePath = (string)this[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundFilePath];
            binding.ReceiveInboundFilePath = (string)this[TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundFilePath];

        }

        // Returns a collection of the configuration properties
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                ConfigurationPropertyCollection properties = base.Properties;
                properties.Add(new ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.PreserveProperties, typeof(bool), TwoWaySendReceiveFileAdapterConfigurationDefaults.DefaultPreserveProperties, null, null, ConfigurationPropertyOptions.None));
                properties.Add(new ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundFilePath, typeof(string), string.Empty, null, null, ConfigurationPropertyOptions.None));
                properties.Add(new ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundFilePath, typeof(string), string.Empty, null, null, ConfigurationPropertyOptions.None));
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

        [ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundFilePath, DefaultValue = TwoWaySendReceiveFileAdapterConfigurationDefaults.DefaultSendOutboundFilePath)]
        [System.ComponentModel.Category("Adapter Properties")]
        public string SendOutboundFilePath
        {
            get
            {
                return ((string)(base[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundFilePath]));
            }
            set
            {
                base[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundFilePath] = value;
            }
        }

        [ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundFilePath, DefaultValue = TwoWaySendReceiveFileAdapterConfigurationDefaults.DefaultReceiveInboundFilePath)]
        [System.ComponentModel.Category("Adapter Properties")]
        public string ReceiveInboundFilePath
        {
            get
            {
                return ((string)(base[TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundFilePath]));
            }
            set
            {
                base[TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundFilePath] = value;
            }
        }

        #endregion Adapter Custom Configuration Properties
    }
}
