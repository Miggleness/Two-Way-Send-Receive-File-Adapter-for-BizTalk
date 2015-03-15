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

        [ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundPath)]
        [System.ComponentModel.Category("Adapter Properties")]
        public string SendOutboundPath
        {
            get
            {
                return ((string)base[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundPath]);
            }
            set
            {
                base[TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundPath] = value;
            }
        }

        [ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundPath)]
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
                properties.Add(new ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundPath, typeof(string)));
                properties.Add(new ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundPath, typeof(string)));
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
            adapter.SendOutboundPath = this.SendOutboundPath;
            adapter.ReceiveInboundPath = this.ReceiveInboundPath;

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
            this.SendOutboundPath = adapter.SendOutboundPath;
            this.ReceiveInboundPath = adapter.ReceiveInboundPath;
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
            this.SendOutboundPath = source.SendOutboundPath;
            this.ReceiveInboundPath = source.ReceiveInboundPath;
        }

        #endregion Overriden Base Class Methods
    }

    /// <summary>
    /// Configuration strings for the binding properties
    /// </summary>
    public class TwoWaySendReceiveFileAdapterConfigurationStrings
    {
        internal const string PreserveProperties = "preserveProperties";
        internal const string SendOutboundPath = "SendOutboundPath";
        internal const string ReceiveInboundPath = "ReceiveInboundPath";
    }

    /// <summary>
    /// Provide defaults for the custom binding properties over here.
    /// </summary>
    public class TwoWaySendReceiveFileAdapterConfigurationDefaults
    {
        internal const bool DefaultPreserveProperties = false;
        internal const string DefaultSendOutboundPath = "";
        internal const string DefaultReceiveInboundPath = "";
    }
}
