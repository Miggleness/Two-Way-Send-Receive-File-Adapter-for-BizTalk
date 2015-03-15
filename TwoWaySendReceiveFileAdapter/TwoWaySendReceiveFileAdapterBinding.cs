using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using Microsoft.ServiceModel.Channels.Common;

namespace TwoWaySendReceiveFileAdapter
{
    public class TwoWaySendReceiveFileAdapterBinding : AdapterBinding
    {
        // Scheme in Binding does not have to be the same as Adapter Scheme. 
        // Over write this value as appropriate.
        private const string BindingScheme = "srfile";

        /// <summary>
        /// Initializes a new instance of the AdapterBinding class
        /// </summary>
        public TwoWaySendReceiveFileAdapterBinding()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the AdapterBinding class with a configuration name
        /// </summary>
        public TwoWaySendReceiveFileAdapterBinding(string configName)
        {
            ApplyConfiguration(configName);
        }

        private void ApplyConfiguration(string configurationName)
        {
           throw new NotImplementedException("The method or operation is not implemented.");
        }

        #region Private Fields

        private TwoWaySendReceiveFileAdapter binding;

        #endregion Private Fields

        #region Custom Generated Fields
               
        #endregion Custom Generated Fields

        #region Public Properties

        /// <summary>
        /// Gets the URI transport scheme that is used by the channel and listener factories that are built by the bindings.
        /// </summary>
        public override string Scheme
        {
            get
            {
                return BindingScheme;
            }
        }

        /// <summary>
        /// Returns a value indicating whether this binding supports metadata browsing.
        /// </summary>
        public override bool SupportsMetadataBrowse
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a value indicating whether this binding supports metadata retrieval.
        /// </summary>
        public override bool SupportsMetadataGet
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a value indicating whether this binding supports metadata searching.
        /// </summary>
        public override bool SupportsMetadataSearch
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the custom type of the ConnectionUri.
        /// </summary>
        public override Type ConnectionUriType
        {
            get
            {
                return typeof(TwoWaySendReceiveFileAdapterConnectionUri);
            }
        }

        #endregion Public Properties

        #region Custom Generated Properties

        private bool _preserveProperties;
        private string _SendOutboundPath;
        private string _ReceiveInboundPath;

        [System.Configuration.ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.PreserveProperties, DefaultValue = TwoWaySendReceiveFileAdapterConfigurationDefaults.DefaultPreserveProperties)]
        public bool PreserveProperties
        {
            get
            {
                return this._preserveProperties;
            }
            set
            {
                this._preserveProperties = value;
            }
        }

        [System.Configuration.ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.SendOutboundPath)]
        public string SendOutboundPath
        {
            get
            {
                return this._SendOutboundPath;
            }
            set
            {
                this._SendOutboundPath = value;
            }
        }

        [System.Configuration.ConfigurationProperty(TwoWaySendReceiveFileAdapterConfigurationStrings.ReceiveInboundPath)]
        public string ReceiveInboundPath
        {
            get
            {
                return this._ReceiveInboundPath;
            }
            set
            {
                this._ReceiveInboundPath = value;
            }
        }

        #endregion Custom Generated Properties

        #region Private Properties

        private TwoWaySendReceiveFileAdapter BindingElement
        {
            get
            {
                if (binding == null)
                {
                    binding = new TwoWaySendReceiveFileAdapter();
                }

                binding.PreserveProperties = this.PreserveProperties;
                binding.SendOutboundPath = this.SendOutboundPath;
                binding.ReceiveInboundPath = this.ReceiveInboundPath;

                return binding;
            }
        }

        #endregion Private Properties

        #region Public Methods

        public override BindingElementCollection CreateBindingElements()
        {
            BindingElementCollection bindingElements = new BindingElementCollection();
            //Only create once
            bindingElements.Add(this.BindingElement);
            //Return the clone
            return bindingElements.Clone();
        }

        #endregion Public Methods

    }
}
