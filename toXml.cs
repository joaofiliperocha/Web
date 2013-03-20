 public string ToXml()
        {
            if (this == null)
                return null;
            try
            {
                using (var stream = new StringWriter())
                {
                    var settings = new XmlWriterSettings();
                    settings.Indent = false;
                    settings.OmitXmlDeclaration = true;
                    using (var writer = XmlWriter.Create(stream, settings))
                    {
                        var serializer = new XmlSerializer(this.GetType());
                        var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                        serializer.Serialize(writer, this, emptyNamepsaces);
                        return stream.ToString();
                    }
                }
            }
            catch
            {
                throw;
            }

        }