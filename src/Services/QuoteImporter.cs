// ASR-SAST-003: XmlReader without DTD prohibition.
using System.Xml;

public class QuoteImporter
{
    public XmlDocument Import(Stream xml)
    {
        var settings = new XmlReaderSettings
        {
            // ASR-SAST-003: should be DtdProcessing.Prohibit.
            DtdProcessing = DtdProcessing.Parse,
            XmlResolver   = new XmlUrlResolver(),
        };
        using var r = XmlReader.Create(xml, settings);
        var doc = new XmlDocument { XmlResolver = new XmlUrlResolver() };
        doc.Load(r);
        return doc;
    }
}
