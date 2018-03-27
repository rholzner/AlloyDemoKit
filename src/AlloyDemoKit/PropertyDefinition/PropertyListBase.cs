using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.Serialization;
using EPiServer.Framework.Serialization.Internal;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;

namespace AlloyDemoKit.PropertyDefinition
{
    public class PropertyListBase<T> : PropertyList<T>
    {
        public PropertyListBase()
        {
            _objectSerializer = this._objectSerializerFactory.Service.GetSerializer("application/json");
        }

        private Injected<ObjectSerializerFactory> _objectSerializerFactory;
        private IObjectSerializer _objectSerializer;

        protected override T ParseItem(string value)
        {
            return _objectSerializer.Deserialize<T>(value);
        }

    }

    [PropertyDefinitionTypePlugIn]
    public class AppendixTypeProperty : PropertyListBase<AppendixValueItem>
    {
    }

    public class AppendixValueItem
    {
        public int AppendixType { get; set; }

        public string Text { get; set; }
        public Url Url { get; set; }
    }
}