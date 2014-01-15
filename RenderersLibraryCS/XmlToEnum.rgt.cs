namespace RenderersLibraryCS
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Kodeo.Reegenerator;
    using System.Xml.Linq;
    public partial class XmlToEnum
    {
        XDocument _xdoc;
        string _className;
        int _firstValue;

        /// <summary>
        /// Method that gets called prior to calling <see cref="Render"/>.
        /// Use this method to initialize the properties to be used by the render process.
        /// You can access the project item attached to this generator by 
        /// using the <see cref="ProjectItem"/> property.
        /// </summary>
        /// 
        public override void PreRender()
        {
            base.PreRender();
            //read the source xml
            var xmlText = System.IO.File.ReadAllText(base.ProjectItem.FullPath);
            _xdoc = XDocument.Parse(xmlText);
            //get className
            _className = _xdoc.Root.Attribute("ClassName").Value;
            //get FirstValue
            var firstValueEle = _xdoc.Root.Attributes("FirstValue")
                                        .FirstOrDefault();
            _firstValue = Convert.ToInt32(firstValueEle.Value);
        }
    }
}