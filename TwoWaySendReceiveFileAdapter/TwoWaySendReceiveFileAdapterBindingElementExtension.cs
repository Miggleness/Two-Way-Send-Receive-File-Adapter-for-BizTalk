using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;

namespace TwoWaySendReceiveFileAdapter
{
    /// <summary>
    /// This class is provided to surface Adapter as a binding element, so that it 
    /// can be used within a user-defined WCF "Custom Binding".
    /// 
    /// In configuration file, it is defined under
    /// <system.serviceModel>
    ///     <extensions>
    ///         <bindingElementExtensions>
    ///             <add name="{name}" type="{this}, {assembly}"/>
    ///         </bindingElementExtensions>
    ///     </extensions>
    /// </system.serviceModel>
    /// 
    /// </summary>
    public class TwoWaySendReceiveFileAdapterBindingElementExtension : BindingElementExtensionElement
    {
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

        [ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundFilePath)]
        [System.ComponentModel.Category("Adapter Properties")]
        public string SendOutboundFilePath
        {
            get
            {
                return ((string)base[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundFilePath]);
            }
            set
            {
                base[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundFilePath] = value;
            }
        }

        [ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundFilePath)]
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


        /// <summary>
        /// Default constructor
        /// </summary>
        public TwoWaySendReceiveFileAdapterBindingElementExtension()
        {
        }

        #region Overriden Base Class Methods
        /// <summary>
        /// Return the type of the adapter (binding element)
        /// </summary>
        public override Type BindingElementType
        {
            get
            {
                return typeof(TwoWaySendReceiveFileAdapter);
            }
        }
        /// <summary>
        /// Return all the properites defined in this class.
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                ConfigurationPropertyCollection properties = base.Properties;
                properties.Add(new ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.PreserveProperties, typeof(int), TwoWaySendReceiveFileAdapterConfigurationDefaults.DefaultPreserveProperties));
                properties.Add(new ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundFilePath, typeof(string)));
                properties.Add(new ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundFilePath, typeof(string)));
                return properties;
            }
        }

        /// <summary>
        /// Instantiate the adapter.
        /// </summary>
        /// <returns></returns>
        protected override BindingElement CreateBindingElement()
        {
            TwoWaySendReceiveFileAdapter adapter = new TwoWaySendReceiveFileAdapter();
            this.ApplyConfiguration(adapter);
            return adapter;
        }

        /// <summary>
        /// Pass the properties from configuration file to the adapter.
        /// </summary>
        /// <param name="bindingElement"></param>
        public override void ApplyConfiguration(BindingElement bindingElement)
        {
            base.ApplyConfiguration(bindingElement);
            TwoWaySendReceiveFileAdapter adapter = ((TwoWaySendReceiveFileAdapter)(bindingElement));
            adapter.PreserveProperties = this.PreserveProperties;
            adapter.SendOutboundFilePath = this.SendOutboundFilePath;
            adapter.ReceiveInboundFilePath = this.ReceiveInboundFilePath;

        }

        /// <summary>
        /// Initialize the binding properties from the adapter.
        /// </summary>
        /// <param name="bindingElement"></param>
        protected override void InitializeFrom(BindingElement bindingElement)
        {
            base.InitializeFrom(bindingElement);
            TwoWaySendReceiveFileAdapter adapter = ((TwoWaySendReceiveFileAdapter)(bindingElement));
            this.PreserveProperties = adapter.PreserveProperties;
            this.SendOutboundFilePath = adapter.SendOutboundFilePath;
            this.ReceiveInboundFilePath = adapter.ReceiveInboundFilePath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        public override void CopyFrom(ServiceModelExtensionElement from)
        {
            base.CopyFrom(from);
            TwoWaySendReceiveFileAdapterBindingElementExtension source = ((TwoWaySendReceiveFileAdapterBindingElementExtension)(from));
            this.PreserveProperties = source.PreserveProperties;
            this.SendOutboundFilePath = source.SendOutboundFilePath;
            this.ReceiveInboundFilePath = source.ReceiveInboundFilePath;
        }

        #endregion Overriden Base Class Methods
    }

    /// <summary>
    /// Configuration strings for the binding properties
    /// </summary>
    public class TwoWaySendReceiveFileAdapterConfigurationStrings
    {
        internal const string PreserveProperties = "preserveProperties";
        internal const string SendOutboundFilePath = "sendOutboundFilePath";
        internal const string ReceiveInboundFilePath = "receiveInboundFilePath";
    }

    /// <summary>
    /// Provide defaults for the custom binding properties over here.
    /// </summary>
    public class TwoWaySendReceiveFileAdapterConfigurationDefaults
    {
        internal const bool DefaultPreserveProperties = false;
        internal const string DefaultSendOutboundFilePath = "";
        internal const string DefaultReceiveInboundFilePath = "";
    }
}
