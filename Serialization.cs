using System.Xml;

/// <summary>
/// Author: Laurent Goffin
/// Generic interfaces
/// </summary>
namespace Core.Interface
{
    /// <summary>
    /// Interface to allow the use of FileSerializer.Save and FileSerializer.Load
    /// </summary>
    /// <remarks>
    /// Use W3C recommendations for data format : http://www.w3.org/TR/xmlschema-2
    /// and more particularly ISO 8601 for date and time format
    /// </remarks>
    public interface IXmlSerializable
    {
        string[] Formats { get; }
        bool XmlWriter(XmlTextWriter writer);
        bool XmlReader(XmlNode root);
        string XmlVersion { get; }
    }
}
